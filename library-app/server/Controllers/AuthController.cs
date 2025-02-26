using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using library_app.Models;
using library_app.Models.Dto;
using Swashbuckle.AspNetCore.Annotations;

namespace library_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration, ILogger<AuthController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost("register")]
        [SwaggerOperation(Summary = "Register a new user", Description = "Register a new user with the provided details")]
        public async Task<ActionResult<User>> Register(User user)
        {
            var existingUser = await _userManager.FindByNameAsync(user.UserName);
            if (existingUser != null)
            {
                return BadRequest("Username already exists");
            }

            var result = await _userManager.CreateAsync(user, user.PasswordHash);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            await _userManager.AddToRoleAsync(user, user.Role);

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPost("login")]
        [SwaggerOperation(Summary = "Login a user", Description = "Login a user with the provided credentials")]
        public async Task<ActionResult<string>> Login(LoginRequest loginRequest)
        {
            _logger.LogInformation("Login attempt for user: {Username}", loginRequest.Username);

            var user = await _userManager.FindByNameAsync(loginRequest.Username);
            if (user == null)
            {
                _logger.LogWarning("User not found: {Username}", loginRequest.Username);
                return Unauthorized("Invalid username or password");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginRequest.Password, false);
            if (!result.Succeeded)
            {
                _logger.LogWarning("Invalid password for user: {Username}", loginRequest.Username);
                return Unauthorized("Invalid username or password");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get user by ID", Description = "Retrieve a user by their ID")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
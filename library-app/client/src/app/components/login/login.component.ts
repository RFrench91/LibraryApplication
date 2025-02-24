import { Component, EventEmitter, Output } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  @Output() toggleSignup = new EventEmitter<void>();
  username = '';
  password = '';
  errorMessage = '';

  constructor(private authService: AuthService, private router: Router) { }


  onToggleSignup(): void {
    this.toggleSignup.emit();
  }

  login(): void {
    this.authService.login(this.username, this.password).subscribe(response => {
      if (response) {
        this.authService.setCurrentUser(response.user);
        this.router.navigate(['/']);
      } else {
        this.errorMessage = 'Invalid username or password';
      }
    }, error => {
      this.errorMessage = 'Invalid username or password';
    });
  }
}
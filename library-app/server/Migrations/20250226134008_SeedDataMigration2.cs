﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using library_app.Models;

#nullable disable

namespace libraryapp.Migrations
{
    public partial class SeedDataMigration2 : Migration
    {
        private static readonly PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var customer = new User
            {
                Id = "1",
                UserName = "customer1",
                NormalizedUserName = "CUSTOMER1",
                Email = "customer1@example.com",
                NormalizedEmail = "CUSTOMER1@EXAMPLE.COM",
                EmailConfirmed = true,
                Role = "Customer",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                PhoneNumber = "5555555555",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = false,
                AccessFailedCount = 0
            };
            customer.PasswordHash = _passwordHasher.HashPassword(customer, "password");

            var librarian = new User
            {
                Id = "2",
                UserName = "librarian1",
                NormalizedUserName = "LIBRARIAN1",
                Email = "librarian1@example.com",
                NormalizedEmail = "LIBRARIAN1@EXAMPLE.COM",
                EmailConfirmed = true,
                Role = "Librarian",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                PhoneNumber = "5555555555",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = false,
                AccessFailedCount = 0
            };
            librarian.PasswordHash = _passwordHasher.HashPassword(librarian, "password");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount", "Role" },
                values: new object[,]
                {
                    { customer.Id, customer.UserName, customer.NormalizedUserName, customer.Email, customer.NormalizedEmail, customer.EmailConfirmed, customer.PasswordHash, customer.SecurityStamp, customer.ConcurrencyStamp, customer.PhoneNumber, customer.PhoneNumberConfirmed, customer.TwoFactorEnabled, customer.LockoutEnd, customer.LockoutEnabled, customer.AccessFailedCount, customer.Role },
                    { librarian.Id, librarian.UserName, librarian.NormalizedUserName, librarian.Email, librarian.NormalizedEmail, librarian.EmailConfirmed, librarian.PasswordHash, librarian.SecurityStamp, librarian.ConcurrencyStamp, librarian.PhoneNumber, librarian.PhoneNumberConfirmed, librarian.TwoFactorEnabled, librarian.LockoutEnd, librarian.LockoutEnabled, librarian.AccessFailedCount, librarian.Role }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Title", "Author", "ISBN", "PublishedDate", "Genre", "CoverImageUrl", "NumberOfPages", "Publisher", "Description" },
                values: new object[,]
                {
                    { 1, "Book 1", "Author 1", "1234567890123", new DateTime(2020, 1, 1), "Fiction", "https://example.com/book1.jpg", 300, "Publisher 1", "Description for Book 1" },
                    { 2, "Book 2", "Author 2", "1234567890124", new DateTime(2020, 1, 1), "Fiction", "https://example.com/book2.jpg", 320, "Publisher 2", "Description for Book 2" },
                    { 3, "Book 3", "Author 3", "1234567890125", new DateTime(2020, 1, 1), "Fiction", "https://example.com/book3.jpg", 280, "Publisher 3", "Description for Book 3" },
                    { 4, "Book 4", "Author 4", "1234567890126", new DateTime(2020, 1, 1), "Fiction", "https://example.com/book4.jpg", 310, "Publisher 4", "Description for Book 4" },
                    { 5, "Book 5", "Author 5", "1234567890127", new DateTime(2020, 1, 1), "Fiction", "https://example.com/book5.jpg", 290, "Publisher 5", "Description for Book 5" },
                    { 6, "Book 6", "Author 6", "1234567890128", new DateTime(2020, 1, 1), "Fiction", "https://example.com/book6.jpg", 305, "Publisher 6", "Description for Book 6" },
                    { 7, "Book 7", "Author 7", "1234567890129", new DateTime(2020, 1, 1), "Fiction", "https://example.com/book7.jpg", 315, "Publisher 7", "Description for Book 7" },
                    { 8, "Book 8", "Author 8", "1234567890130", new DateTime(2020, 1, 1), "Fiction", "https://example.com/book8.jpg", 325, "Publisher 8", "Description for Book 8" },
                    { 9, "Book 9", "Author 9", "1234567890131", new DateTime(2020, 1, 1), "Fiction", "https://example.com/book9.jpg", 330, "Publisher 9", "Description for Book 9" },
                    { 10, "Book 10", "Author 10", "1234567890132", new DateTime(2020, 1, 1), "Fiction", "https://example.com/book10.jpg", 340, "Publisher 10", "Description for Book 10" },
                    { 11, "Book 11", "Author 11", "1234567890133", new DateTime(2020, 1, 1), "Fiction", "https://example.com/book11.jpg", 350, "Publisher 11", "Description for Book 11" },
                    { 12, "Book 12", "Author 12", "1234567890134", new DateTime(2020, 1, 1), "Fiction", "https://example.com/book12.jpg", 360, "Publisher 12", "Description for Book 12" },
                    { 13, "Book 13", "Author 13", "1234567890135", new DateTime(2020, 1, 1), "Fiction", "https://example.com/book13.jpg", 370, "Publisher 13", "Description for Book 13" },
                    { 14, "Book 14", "Author 14", "1234567890136", new DateTime(2020, 1, 1), "Fiction", "https://example.com/book14.jpg", 380, "Publisher 14", "Description for Book 14" },
                    { 15, "Book 15", "Author 15", "1234567890137", new DateTime(2020, 1, 1), "Fiction", "https://example.com/book15.jpg", 390, "Publisher 15", "Description for Book 15" },
                    { 16, "Book 16", "Author 16", "1234567890138", new DateTime(2020, 1, 1), "Fiction", "https://example.com/book16.jpg", 400, "Publisher 16", "Description for Book 16" },
                    { 17, "Book 17", "Author 17", "1234567890139", new DateTime(2020, 1, 1), "Fiction", "https://example.com/book17.jpg", 410, "Publisher 17", "Description for Book 17" },
                    { 18, "Book 18", "Author 18", "1234567890140", new DateTime(2020, 1, 1), "Fiction", "https://example.com/book18.jpg", 420, "Publisher 18", "Description for Book 18" },
                    { 19, "Book 19", "Author 19", "1234567890141", new DateTime(2020, 1, 1), "Fiction", "https://example.com/book19.jpg", 430, "Publisher 19", "Description for Book 19" },
                    { 20, "Book 20", "Author 20", "1234567890142", new DateTime(2020, 1, 1), "Fiction", "https://example.com/book20.jpg", 440, "Publisher 20", "Description for Book 20" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValues: new object[] { "1", "2" });

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
        }
    }
}
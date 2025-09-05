﻿using System.ComponentModel.DataAnnotations;

namespace UserRegisteration.DTOs
{
    public class RegisterUserDto
    {
        [Required, MinLength(3)]
        public string Name { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, MinLength(6)]
        [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*\d).+$",
            ErrorMessage = "Password must contain letters and numbers")]
        public string Password { get; set; } = string.Empty;
    }
}

﻿using System.ComponentModel.DataAnnotations;

namespace EduZoneAPI3.Model.Authentication
{
    public class AuthenticateDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

﻿using Microsoft.AspNetCore.Identity;

namespace MarialaTemplate.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}

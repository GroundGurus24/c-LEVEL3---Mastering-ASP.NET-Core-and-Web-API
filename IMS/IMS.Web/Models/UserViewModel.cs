﻿using System.ComponentModel.DataAnnotations;

namespace IMS.Web.Models
{
    public class UserViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}

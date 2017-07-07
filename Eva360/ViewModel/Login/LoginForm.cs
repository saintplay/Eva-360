using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Eva360.Models;

namespace Eva360.ViewModel.Login
{
    public class LoginForm
    {
        [Required]
        public String Usuario { get; set; } = String.Empty;

        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; } = String.Empty;
    }
}
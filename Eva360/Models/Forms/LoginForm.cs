using System;
using System.ComponentModel.DataAnnotations;

namespace Eva360.Models.Forms
{
    public class LoginForm
    {
        [Required]
        public String Usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity.ViewModel
{
    public class NewPassword
    {
        [Required]
        [RegularExpression("^(?=.*[0-9])(?=.*[A-Z])([a-zA-Z0-9]+)$", ErrorMessage = "passwords will require at least one capital letter and one number")]
        [StringLength(maximumLength: 12, ErrorMessage = "passwords will require 6 to 12 character", MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Token { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity.ViewModel
{
    public class Login
    {
        [Required]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string UserName { get; set; }

        [Required]
        [StringLength(maximumLength: 12, ErrorMessage = "passwords will require Minimum 6 character", MinimumLength = 6)]
        public string Password { get; set; }

        
    }
}

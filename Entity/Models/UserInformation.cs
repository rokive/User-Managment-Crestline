
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity.Models
{
    public class UserInformation : Base
    {
        [Required]
        [EmailAddress(ErrorMessage ="Enter a valid email address")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [RegularExpression("^(?=.*[0-9])(?=.*[A-Z])([a-zA-Z0-9]+)$", ErrorMessage = "passwords will require at least one capital letter and one number and ignore special characters like @,# etc ")]
        [StringLength(maximumLength:12,ErrorMessage = "passwords will require 6 to 12 character", MinimumLength =6)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DefaultValue("")]
        public string Address { get; set; }

        [Required]
        [Phone(ErrorMessage ="Enter a valid phone number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Security Question")]
        public string SecurityQuestion { get; set; }

        [Required]
        [StringLength(maximumLength:100,ErrorMessage = "Security answer must be 6 to 100 characters long",MinimumLength =6)]
        public string Answer { get; set; }

        public string Token { get; set; }
        
        public bool isConfirm { get; set; }

    }
}

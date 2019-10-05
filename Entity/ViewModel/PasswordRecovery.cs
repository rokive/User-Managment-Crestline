using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity.ViewModel
{
    public class PasswordRecovery
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string SecurityQuestion { get; set; }
        [Required]
        public string SecurityAnswer { get; set; }
    }
}

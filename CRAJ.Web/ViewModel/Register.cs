using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRAJ.Web.ViewModel
{
    public class Register
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="Password and Confirmation Password don't match")]
        [Display(Name = "Confirmez le mot de passe")]
        public string ConfirmPassword { get; set; }
    }
}

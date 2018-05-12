using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DistributedPartlyCloudDatabase.Web.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please, enter email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid email!")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please, enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me on this computer")]
        public bool RememberMe { get; set; }
    }
}
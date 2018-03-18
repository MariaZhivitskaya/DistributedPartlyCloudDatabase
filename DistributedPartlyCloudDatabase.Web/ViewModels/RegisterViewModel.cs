using System.ComponentModel.DataAnnotations;

namespace DistributedPartlyCloudDatabase.Web.ViewModels
{
    public class RegisterViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please, enter email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid email!")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please, enter password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password need to be at least {1} characters", MinimumLength = 6)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Please, confirm password")]
        [Compare("Password", ErrorMessage = "Passwords and confirmed pasword are different")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Nickname")]
        [Required(ErrorMessage = "Please, enter nickname")]
        public string Nickname { get; set; }

        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Birthdate")]
        [Required(ErrorMessage = "Please, enter birthdate")]
        public string Birthdate { get; set; }

        [Display(Name = "Enter numbers from the image")]
        [Required(ErrorMessage = "Please, enter numbers from the image")]
        public string Captcha { get; set; }
    }
}
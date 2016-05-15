using System.ComponentModel.DataAnnotations;

namespace FASTrack.ViewModel
{
    public class ChangePasswordViewModel
    {
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Current Password")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false)]
        public string PasswordCurrent { get; set; }

        [Display(Name = "New Password")]
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string NewPassword { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string NewConfirmPassword { get; set; }
    }
}
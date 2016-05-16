using System.ComponentModel.DataAnnotations;

namespace FASTrack.ViewModel
{
    public class UserLoginViewModel
    {
        [Required]
        //[EmailAddress]
        [StringLength(150, MinimumLength = 3)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6)]
        [Display(Name = "Password ")]
        public string Password { get; set; }

        [Display(Name = "Remember Me? ")]
        public bool RememberMe { get; set; }

        public bool IsAdmin { get; set; }

        [Display(Name = "User Location")]
        public string uSite { get; set; }

        [Display(Name = "User Type ")]
        public string uType { get; set; }

        public int allowed { get; set; }

        public string ReturnUrl { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace FASTrack.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class UserLoginViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        //[EmailAddress]
        [StringLength(150, MinimumLength = 3)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6)]
        [Display(Name = "Password ")]
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Remember Me? ")]
        public bool RememberMe { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "User Location")]
        public string uSite { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "User Type ")]
        public string uType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int allowed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}
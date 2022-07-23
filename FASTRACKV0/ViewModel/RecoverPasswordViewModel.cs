using System.ComponentModel.DataAnnotations;

namespace FASTrack.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class RecoverPasswordViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Please enter email for recover password")]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
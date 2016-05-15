using System.ComponentModel.DataAnnotations;

namespace FASTrack.ViewModel
{
    public class RecoverPasswordViewModel
    {
        [Required(ErrorMessage = "Please enter email for recover password")]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
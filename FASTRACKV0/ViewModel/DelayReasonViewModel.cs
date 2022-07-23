using FASTrack.Model.DTO;
using System.ComponentModel.DataAnnotations;

namespace FASTrack.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class DelayReasonViewModel : BaseDto
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [StringLength(255, ErrorMessage = "Max length max is 255")]
        public string Description { get; set; }
    }
}
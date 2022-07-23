using FASTrack.Model.DTO;
using System.ComponentModel.DataAnnotations;

namespace FASTrack.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class MSTViewModel : BaseDto
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [StringLength(50, ErrorMessage = "Name length max is 50")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(255, ErrorMessage = "Max length max is 255")]
        public string Description { get; set; }
    }
}
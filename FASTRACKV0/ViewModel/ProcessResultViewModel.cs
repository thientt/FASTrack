using FASTrack.Model.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace FASTrack.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class ProcessResultViewModel : BaseDto
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Display(Name = "FA Code")]
        public int ProcessTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [MaxLength(50)]
        [Display(Name = "FA Value")]
        public string Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Description")]
        [MaxLength(255)]
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<MSTProcessTypesDto> ProcessType { get; set; }

    }
}
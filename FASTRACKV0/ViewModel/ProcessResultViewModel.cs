using FASTrack.Model.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace FASTrack.ViewModel
{
    public class ProcessResultViewModel : BaseDto
    {
        [Required]
        [Display(Name = "FA Code")]
        public int ProcessTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "FA Value")]
        public string Value { get; set; }

        [Display(Name = "Description")]
        [MaxLength(255)]
        public string Description { get; set; }

        public IEnumerable<MSTProcessTypesDto> ProcessType { get; set; }

    }
}
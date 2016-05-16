using FASTrack.Model.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FASTrack.ViewModel
{
    public class LogViewModel : BaseDto
    {
        [Required]
        public int MasterId { get; set; }
        [Required]
        public string Number { get; set; }

        [Required(ErrorMessage="Please option Reason")]
        public int ReasonId { get; set; }
        public IEnumerable<DelayReasonDto> Reason { get; set; }
        public int StatusId { get; set; }
    }
}
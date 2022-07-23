using FASTrack.Model.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FASTrack.ViewModel
{

    /// <summary>
    /// 
    /// </summary>
    public class LogViewModel : BaseDto
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int MasterId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Number { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage="Please option Reason")]
        public int ReasonId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<DelayReasonDto> Reason { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int StatusId { get; set; }
    }
}
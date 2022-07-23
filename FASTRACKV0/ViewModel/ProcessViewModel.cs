using FASTrack.Model.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FASTrack.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class ProcessViewModel : BaseDto
    {
        /// <summary>
        /// 
        /// </summary>
        public int DeviceId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "FA Number")]
        public string FANumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Comment")]
        public string Comment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "ProcessTypeId")]
        [Required]
        public int ProcessTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Process")]
        public IEnumerable<MSTProcessTypesDto> ProcessTypes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Analyst")]
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Analysts")]
        public IEnumerable<SYSUsersDto> Analysts { get; set; }
    }
}
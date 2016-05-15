using FASTrack.Model.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FASTrack.ViewModel
{
    public class ProcessViewModel : BaseDto
    {
        public int DeviceId { get; set; }

        [Display(Name = "FA Number")]
        public string FANumber { get; set; }

        //[Display(Name = "Description")]
        //public string ProcessDesc { get; set; }

        //[Display(Name = "Sequence")]
        //public int Sequence { get; set; }
        [Display(Name = "Comment")]
        public string Comment { get; set; }

        [Display(Name = "ProcessTypeId")]
        [Required]
        public int ProcessTypeId { get; set; }

        [Display(Name = "Process")]
        public IEnumerable<MSTProcessTypesDto> ProcessTypes { get; set; }

        [Display(Name = "Analyst")]
        public string Email { get; set; }

        [Display(Name = "Analysts")]
        public IEnumerable<SYSUsersDto> Analysts { get; set; }
    }
}
using FASTrack.Model.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FASTrack.ViewModel
{
    public class FAReportViewModel : BaseDto
    {
        [Required]
        [Display(Name = "Report Type")]
        public int ReportTypeId { get; set; }

        [Required]
        [Display(Name = "Origin")]
        public int OriginId { get; set; }

        public bool Required { get; set; }

        [MaxLength(255)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public IEnumerable<MSTOriginDto> Origins { get; set; }
        public IEnumerable<ReportTypesDto> ReportTypes { get; set; }
    }
}
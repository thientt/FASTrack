using System.ComponentModel.DataAnnotations;

namespace FASTrack.ViewModel
{
    public class ReportTypeViewModel : MSTViewModel
    {
        [Required(AllowEmptyStrings = false)]
        [Range(0, int.MaxValue)]
        [Display(Name = "Day After")]
        public int DayAfter { get; set; }
    }
}
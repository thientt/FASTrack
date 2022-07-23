using System.ComponentModel.DataAnnotations;

namespace FASTrack.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class ReportTypeViewModel : MSTViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [Range(0, int.MaxValue)]
        [Display(Name = "Day After")]
        public int DayAfter { get; set; }
    }
}
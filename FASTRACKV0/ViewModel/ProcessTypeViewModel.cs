using FASTrack.Model.DTO;
using System.ComponentModel.DataAnnotations;

namespace FASTrack.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class ProcessTypeViewModel : MSTViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Duration")]
        public decimal? Duration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "SeqNumber")]
        public int? SeqNumber { get; set; }
    }
}
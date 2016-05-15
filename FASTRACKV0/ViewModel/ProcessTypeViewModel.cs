using FASTrack.Model.DTO;
using System.ComponentModel.DataAnnotations;

namespace FASTrack.ViewModel
{
    public class ProcessTypeViewModel : MSTViewModel
    {
        [Display(Name = "Duration")]
        public decimal? Duration { get; set; }

        [Display(Name = "SeqNumber")]
        public int? SeqNumber { get; set; }
    }
}
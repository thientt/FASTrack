using System.ComponentModel.DataAnnotations;
namespace FASTrack.ViewModel
{
    public class CustomerViewModel : MSTViewModel
    {
        [Display(Name = "EndCustomer")]
        public bool EndCustomer { get; set; }

        [Display(Name = "Location"), MaxLength(255)]
        public string Location { get; set; }

        [Display(Name = "Strategic")]
        public bool Strategic { get; set; }
    }
}
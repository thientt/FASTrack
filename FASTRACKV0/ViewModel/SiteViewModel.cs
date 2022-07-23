using FASTrack.Model.DTO;
using System.ComponentModel.DataAnnotations;

namespace FASTrack.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class SiteViewModel:BaseDto
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [StringLength(20, ErrorMessage = "Name length max is the 20")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(255, ErrorMessage = "Description length max is the 20")]
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(1024, ErrorMessage = "Address1 Desription length max is the 20")]
        public string Address1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(1024, ErrorMessage = "Address2 Desription length max is the 20")]
        public string Address2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(20, ErrorMessage = "Phone Desription length max is the 20")]
        public string Phone { get; set; }
    }
}
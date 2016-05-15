using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FASTrack.ViewModel
{
    /// <summary>
    /// Bind data to users
    /// </summary>
    public class ProductViewModel : MSTViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [StringLength(150, ErrorMessage = "Max length is the 150")]
        public string MainPerson { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(150, ErrorMessage = "Max length is the 150")]
        public string SecondaryPerson { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(150, ErrorMessage = "Max length is the 150")]
        public string TertiaryPerson { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage="Lab Site is required")]
        public int LabSiteId { get; set; }

        /// <summary>
        /// List Labsite
        /// </summary>
        public IEnumerable<FASTrack.Model.DTO.MSTLabSiteDto> LabSites { get; set; }
    }
}
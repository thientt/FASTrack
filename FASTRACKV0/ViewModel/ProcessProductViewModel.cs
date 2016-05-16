using System.ComponentModel.DataAnnotations;
using FASTrack.Model.DTO;
using System.Collections.Generic;
using System;

namespace FASTrack.ViewModel
{
    public class ProcessProductViewModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the in charge peson.
        /// </summary>
        /// <value>
        /// The in charge peson.
        /// </value>
        [Required(ErrorMessage="The In-Charge Person field is required.")]
        [MaxLength(50)]
        public string InChargePerson { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [Display(Name="Description")]
        [StringLength(150, ErrorMessage = "Max length is the 250")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        [Required(ErrorMessage="The Product field is required.")]
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the process identifier.
        /// </summary>
        /// <value>
        /// The process identifier.
        /// </value>
        [Required(ErrorMessage = "The FA Process field is required.")]
        public int ProcessId { get; set; }

        /// <summary>
        /// Gets or sets the process types.
        /// </summary>
        /// <value>
        /// The process types.
        /// </value>
        [Display(Name="Process Type")]
        public IEnumerable<MSTProcessTypesDto> ProcessTypes { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>
        /// The products.
        /// </value>
        [Display(Name="Product")]
        public IEnumerable<MSTProductDto> Products { get; set; }


        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        [Display(Name = "In-Charge Person")]
        public IEnumerable<SYSUsersDto> Users { get; set; }

        /// <summary>
        /// Gets or sets the last update.
        /// </summary>
        /// <value>
        /// The last update.
        /// </value>
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// Gets or sets the last updated by.
        /// </summary>
        /// <value>
        /// The last updated by.
        /// </value>
        public string LastUpdatedBy { get; set; }
    }
}
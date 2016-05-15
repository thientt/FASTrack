using FASTrack.Model.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/// <summary>
/// 
/// </summary>
namespace FASTrack.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class FAREditRequestViewModel : FARRequestViewModel
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        [Required(ErrorMessage = "Please the option analyst")]
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        [Display(Name = "FA Analyst ")]
        public IEnumerable<SYSUsersDto> Users { get; set; }

        /// <summary>
        /// Gets or sets the initial reason identifier.
        /// </summary>
        /// <value>
        /// The initial reason identifier.
        /// </value>
        public int InitialReasonId { get; set; }
        /// <summary>
        /// Gets or sets the final reason identifier.
        /// </summary>
        /// <value>
        /// The final reason identifier.
        /// </value>
        public int FinalReasonId { get; set; }
        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        /// <value>
        /// The reason.
        /// </value>
        public IEnumerable<DelayReasonDto> Reason { get; set; }

        /// <summary>
        /// Gets or sets the reason close identifier.
        /// </summary>
        /// <value>
        /// The reason close identifier.
        /// </value>
        public int ReasonId { get; set; }
        /// <summary>
        /// Gets or sets the reason close.
        /// </summary>
        /// <value>
        /// The reason close.
        /// </value>
        public IEnumerable<DelayReasonDto> ReasonClose { get; set; }

        /// <summary>
        /// Gets or sets the reports.
        /// </summary>
        /// <value>
        /// The reports.
        /// </value>
        public string Reports { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [enable submit].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable submit]; otherwise, <c>false</c>.
        /// </value>
        public bool EnableSubmit { get; set; }
    }
}
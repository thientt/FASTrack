// ***********************************************************************
// Assembly         : FASTRACKV0
// Author           : tranthiencdsp@gmail.com
// Created          : 11-04-2015
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 04-23-2016
// ***********************************************************************
// <copyright file="ManRequestViewModel.cs" company="Atmel Corporation">
//     Copyright © Atmel 2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using FASTrack.Model.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

/// <summary>
/// The ViewModel namespace.
/// </summary>
namespace FASTrack.ViewModel
{
    /// <summary>
    /// Class ManRequestViewModel.
    /// </summary>
    public class ManRequestViewModel : BaseDto
    {
        /// <summary>
        /// Gets or sets the far number.
        /// </summary>
        /// <value>The far number.</value>
        [Display(Name = "FAR Number")]
        public string FARNumber { get; set; }
       
        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
        [Display(Name = "Reference No.")]
        public int RefNo { get; set; }
        
        /// <summary>
        /// Gets or sets the failure rate.
        /// </summary>
        /// <value>The failure rate.</value>
        [Display(Name = "Failure Rate")]
        public byte FailureRate { get; set; }

        /// <summary>
        /// Gets or sets the request date.
        /// </summary>
        /// <value>The request date.</value>
        [Display(Name = "Request Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime RequestDate { get; set; }

        /// <summary>
        /// Gets or sets the samples arrive date.
        /// </summary>
        /// <value>The samples arrive date.</value>
        [Display(Name = "Samples Arrived Date")]
        public DateTime? SamplesArriveDate { get; set; }

        /// <summary>
        /// Gets or sets the initial report target date.
        /// </summary>
        /// <value>The initial report target date.</value>
        [Display(Name = "Initial Report Target Date")]
        public DateTime? InitialReportTargetDate { get; set; }

        /// <summary>
        /// Gets or sets the final report target date.
        /// </summary>
        /// <value>The final report target date.</value>
        [Display(Name = "Final Report Target Date")]
        public DateTime? FinalReportTargetDate { get; set; }

        /// <summary>
        /// Gets or sets the failure desc.
        /// </summary>
        /// <value>The failure desc.</value>
        [Display(Name = "Failure Description")]
        public string FailureDesc { get; set; }

        /// <summary>
        /// Gets or sets the origin identifier.
        /// </summary>
        /// <value>The origin identifier.</value>
        public int OriginId { get; set; }
        /// <summary>
        /// Gets or sets the origins.
        /// </summary>
        /// <value>The origins.</value>
        public IEnumerable<MSTOriginDto> Origins { get; set; }

        /// <summary>
        /// Gets or sets the status identifier.
        /// </summary>
        /// <value>The status identifier.</value>
        public int StatusId { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [Display(Name = "Status")]
        public IEnumerable<MSTStatusDto> Status { get; set; }

        /// <summary>
        /// Gets or sets the bu identifier.
        /// </summary>
        /// <value>The bu identifier.</value>
        public int BUId { get; set; }
        /// <summary>
        /// Gets or sets the b us.
        /// </summary>
        /// <value>The b us.</value>
        [Display(Name = "Business Unit")]
        public IEnumerable<MSTBuDto> BUs { get; set; }

        /// <summary>
        /// Gets or sets the failure type identifier.
        /// </summary>
        /// <value>The failure type identifier.</value>
        public int FailureTypeId { get; set; }
        /// <summary>
        /// Gets or sets the failure types.
        /// </summary>
        /// <value>The failure types.</value>
        [Display(Name = "Failure Type ")]
        public IEnumerable<MSTFailureTypeDto> FailureTypes { get; set; }

        /// <summary>
        /// Gets or sets the failure origin identifier.
        /// </summary>
        /// <value>The failure origin identifier.</value>
        public int FailureOriginId { get; set; }
        /// <summary>
        /// Gets or sets the failure origins.
        /// </summary>
        /// <value>The failure origins.</value>
        [Display(Name = "Failure Origin")]
        public IEnumerable<MSTFailureOriginDto> FailureOrigins { get; set; }

        //[Display(Name = "Product Line")]
        //public int ProductId { get; set; }
        //public IEnumerable<MSTProductDto> Products { get; set; }
        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>The product.</value>
        [Display(Name = "Product Line"), MaxLength(250)]
        public string Product { get; set; }

        /// <summary>
        /// Gets or sets the priority identifier.
        /// </summary>
        /// <value>The priority identifier.</value>
        [Required(ErrorMessage = "Please the option Priority value!")]
        [Display(Name = "Priority")]
        public int PriorityId { get; set; }
        /// <summary>
        /// Gets or sets the priorities.
        /// </summary>
        /// <value>The priorities.</value>
        public IEnumerable<MSTPriorityDto> Priorities { get; set; }

        /// <summary>
        /// Gets or sets the requestor.
        /// </summary>
        /// <value>The requestor.</value>
        [Display(Name = "Requestor")]
        public string Requestor { get; set; }

        /// <summary>
        /// Gets or sets the site.
        /// </summary>
        /// <value>The site.</value>
        [Display(Name = "Requestor Site")]
        public string Site { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ManRequestViewModel"/> is submitted.
        /// </summary>
        /// <value><c>true</c> if submitted; otherwise, <c>false</c>.</value>
        public bool Submitted { get; set; }

        /// <summary>
        /// Gets or sets the analyst.
        /// </summary>
        /// <value>The analyst.</value>
        [Display(Name = "Analyst")]
        public string Analyst { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        [Required(ErrorMessage = "Please the option analyst")]
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>The users.</value>
        [Display(Name = "FA Analyst ")]
        public IEnumerable<SYSUsersDto> Users { get; set; }

        /// <summary>
        /// Gets or sets the reason identifier.
        /// </summary>
        /// <value>The reason identifier.</value>
        public int ReasonId { get; set; }
        /// <summary>
        /// Gets or sets the reasons.
        /// </summary>
        /// <value>The reasons.</value>
        public IEnumerable<DelayReasonDto> Reasons { get; set; }

        /// <summary>
        /// Gets or sets the reports.
        /// </summary>
        /// <value>The reports.</value>
        public string Reports { get; set; }
        /*Begin Enhancement*/
        /// <summary>
        /// Gets or sets the initial reason identifier.
        /// </summary>
        /// <value>The initial reason identifier.</value>
        public int InitialReasonId { get; set; }
        /// <summary>
        /// Gets or sets the initial reason.
        /// </summary>
        /// <value>
        /// The initial reason.
        /// </value>
        public IEnumerable<DelayReasonDto> InitialReason { get; set; }

        /// <summary>
        /// Gets or sets the final reason identifier.
        /// </summary>
        /// <value>The final reason identifier.</value>
        public int FinalReasonId { get; set; }
        /// <summary>
        /// Gets or sets the final reason.
        /// </summary>
        /// <value>
        /// The final reason.
        /// </value>
        public IEnumerable<DelayReasonDto> FinalReason { get; set; }
        /*End Enhancement*/
    }
}
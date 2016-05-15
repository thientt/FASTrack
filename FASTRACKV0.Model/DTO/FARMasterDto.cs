// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 03-23-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 03-23-2016
// ***********************************************************************
// <copyright file="FARMasterDto.cs" company="Atmel Corporation">
//     Copyright © Atmel Corporation 2015
// </copyright>
// <summary></summary>
// ***********************************************************************

using FASTrack.Model.Types;
using System;

/// <summary>
/// 
/// </summary>
namespace FASTrack.Model.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class FARMasterDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the origin identifier.
        /// </summary>
        /// <value>
        /// The origin identifier.
        /// </value>
        public int OriginId { get; set; }

        /// <summary>
        /// Gets or sets the requestor.
        /// </summary>
        /// <value>
        /// The requestor.
        /// </value>
        public string Requestor { get; set; }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>
        /// The reference no.
        /// </value>
        public int RefNo { get; set; }

        /// <summary>
        /// Gets or sets the failure type identifier.
        /// </summary>
        /// <value>
        /// The failure type identifier.
        /// </value>
        public int FailureTypeId { get; set; }

        /// <summary>
        /// Gets or sets the failure origin identifier.
        /// </summary>
        /// <value>
        /// The failure origin identifier.
        /// </value>
        public int FailureOriginId { get; set; }

        /// <summary>
        /// Gets or sets the failure rate.
        /// </summary>
        /// <value>
        /// The failure rate.
        /// </value>
        public byte FailureRate { get; set; }

        /// <summary>
        /// Gets or sets the status identifier.
        /// </summary>
        /// <value>
        /// The status identifier.
        /// </value>
        public int StatusId { get; set; }

        /// <summary>
        /// Gets or sets the analyst.
        /// </summary>
        /// <value>
        /// The analyst.
        /// </value>
        public string Analyst { get; set; }

        /// <summary>
        /// Gets or sets the request date.
        /// </summary>
        /// <value>
        /// The request date.
        /// </value>
        public DateTime RequestDate { get; set; }

        /// <summary>
        /// Gets or sets the samples arrive date.
        /// </summary>
        /// <value>
        /// The samples arrive date.
        /// </value>
        public DateTime? SamplesArriveDate { get; set; }

        /// <summary>
        /// Gets or sets the priority identifier.
        /// </summary>
        /// <value>
        /// The priority identifier.
        /// </value>
        public int PriorityId { get; set; }

        /// <summary>
        /// Gets or sets the initial report target date.
        /// </summary>
        /// <value>
        /// The initial report target date.
        /// </value>
        public DateTime? InitialReportTargetDate { get; set; }

        /// <summary>
        /// Gets or sets the bu identifier.
        /// </summary>
        /// <value>
        /// The bu identifier.
        /// </value>
        public int BUId { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>The product identifier.</value>
        public string Product { get; set; }

        /// <summary>
        /// Gets or sets the failure desc.
        /// </summary>
        /// <value>
        /// The failure desc.
        /// </value>
        public string FailureDesc { get; set; }

        /// <summary>
        /// Gets or sets the final report target date.
        /// </summary>
        /// <value>
        /// The final report target date.
        /// </value>
        public DateTime? FinalReportTargetDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="FARMasterDto"/> is submitted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if submitted; otherwise, <c>false</c>.
        /// </value>
        public bool Submitted { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>
        /// The customer.
        /// </value>
        public string Customer { get; set; }

        /// <summary>
        /// Gets or sets the lab site.
        /// </summary>
        /// <value>
        /// The lab site.
        /// </value>
        public int LabSiteId { get; set; }

        /// <summary>
        /// Gets or sets the rating identifier.
        /// </summary>
        /// <value>The rating identifier.</value>
        public int? RatingId { get; set; }

        /// <summary>
        /// Gets or sets the bu.
        /// </summary>
        /// <value>
        /// The bu.
        /// </value>
        public MSTBuDto Bu { get; set; }

        /// <summary>
        /// Gets or sets the far failure origin.
        /// </summary>
        /// <value>
        /// The far failure origin.
        /// </value>
        public MSTFailureOriginDto FARFailureOrigin { get; set; }

        /// <summary>
        /// Gets or sets the type of the far failure.
        /// </summary>
        /// <value>
        /// The type of the far failure.
        /// </value>
        public MSTFailureTypeDto FARFailureType { get; set; }

        /// <summary>
        /// Gets or sets the far origin.
        /// </summary>
        /// <value>
        /// The far origin.
        /// </value>
        public MSTOriginDto FAROrigin { get; set; }

        /// <summary>
        /// Gets or sets the far priority.
        /// </summary>
        /// <value>
        /// The far priority.
        /// </value>
        public MSTPriorityDto FARPriority { get; set; }

        /// <summary>
        /// Gets or sets the far product.
        /// </summary>
        /// <value>
        /// The far product.
        /// </value>
        public MSTProductDto FARProduct { get; set; }

        /// <summary>
        /// Gets or sets the far status.
        /// </summary>
        /// <value>
        /// The far status.
        /// </value>
        public MSTStatusDto FARStatus { get; set; }

        /// <summary>
        /// Gets or sets the lab site.
        /// </summary>
        /// <value>
        /// The lab site.
        /// </value>
        public MSTLabSiteDto LabSite { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>The rating.</value>
        public MSTRatingDto Rating { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>The comments.</value>
        public string Comments { get; set; }

        #region Property bind
        /// <summary>
        /// 
        /// </summary>
        public string CurrentProcess { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? OverallCT
        {
            get
            {
                int? result = null;
                if (SamplesArriveDate.HasValue)
                {
                    switch (StatusId)
                    {
                        case (int)StatusType.OPEN:
                            result = (DateTime.Now.Date - SamplesArriveDate.Value).Days;
                            break;
                        case (int)StatusType.REPORTUPLOADED:
                            result = (DateTime.Now.Date - SamplesArriveDate.Value).Days;
                            break;
                        case (int)StatusType.CLOSED:
                            result = (this.LastUpdate - SamplesArriveDate.Value).Days;
                            break;
                        case (int)StatusType.HOLD:
                            result = (this.LastUpdate - SamplesArriveDate.Value).Days;
                            break;
                        default:
                            result = (DateTime.Now.Date - SamplesArriveDate.Value).Days;
                            break;
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int CurrentProcessCT { get; set; }
        #endregion
    }
}
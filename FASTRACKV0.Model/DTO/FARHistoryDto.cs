// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 03-23-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 03-23-2016
// ***********************************************************************
// <copyright file="LOGHistoryDto.cs" company="Atmel Corporation">
//     Copyright © Atmel Corporation 2015
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

/// <summary>
/// 
/// </summary>
namespace FASTrack.Model.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class LOGHistoryDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the master identifier.
        /// </summary>
        /// <value>
        /// The master identifier.
        /// </value>
        public int MasterId { get; set; }
        /// <summary>
        /// Gets or sets the status identifier.
        /// </summary>
        /// <value>
        /// The status identifier.
        /// </value>
        public int StatusId { get; set; }
        /// <summary>
        /// Gets or sets the reason identifier.
        /// </summary>
        /// <value>
        /// The reason identifier.
        /// </value>
        public int ReasonId { get; set; }
        /// <summary>
        /// Gets or sets the log date.
        /// </summary>
        /// <value>
        /// The log date.
        /// </value>
        public DateTime LogDate { get; set; }
        /// <summary>
        /// Gets or sets the master.
        /// </summary>
        /// <value>
        /// The master.
        /// </value>
        public FARMasterDto Master { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public MSTStatusDto Status { get; set; }
        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        /// <value>
        /// The reason.
        /// </value>
        public DelayReasonDto Reason { get; set; }
    }
}

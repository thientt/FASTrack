// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 03-23-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 03-23-2016
// ***********************************************************************
// <copyright file="FARUploadDto.cs" company="Atmel Corporation">
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
    public class FARUploadDto
    {
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the master identifier.
        /// </summary>
        /// <value>
        /// The master identifier.
        /// </value>
        public int MasterId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FAType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the reason identifier.
        /// </summary>
        /// <value>
        /// The reason identifier.
        /// </value>
        public int? ReasonId { get; set; }

        /// <summary>
        /// Gets or sets the log date.
        /// </summary>
        /// <value>
        /// The log date.
        /// </value>
        public DateTime UploadedDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UploadedBy { get; set; }

        /// <summary>
        /// Gets or sets the master.
        /// </summary>
        /// <value>
        /// The master.
        /// </value>
        public FARMasterDto Master { get; set; }

        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        /// <value>
        /// The reason.
        /// </value>
        public DelayReasonDto Reason { get; set; }

    }
}

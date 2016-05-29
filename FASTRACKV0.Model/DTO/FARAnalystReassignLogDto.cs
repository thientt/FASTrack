// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 03-23-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 03-23-2016
// ***********************************************************************
// <copyright file="FARAnalystReassignLogDto.cs" company="Atmel Corporation">
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
    public class FARAnalystReassignLogDto:BaseDto
    {
        /// <summary>
        /// Gets or sets the master identifier.
        /// </summary>
        /// <value>
        /// The master identifier.
        /// </value>
        public int MasterId { get; set; }
        /// <summary>
        /// Gets or sets the analyst from.
        /// </summary>
        /// <value>
        /// The analyst from.
        /// </value>
        public string AnalystFrom { get; set; }
        /// <summary>
        /// Gets or sets the analyst to.
        /// </summary>
        /// <value>
        /// The analyst to.
        /// </value>
        public string AnalystTo { get; set; }
        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>
        /// The updated date.
        /// </value>
        public DateTime? UpdatedDate { get; set; }
    }
}

// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 03-23-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 03-23-2016
// ***********************************************************************
// <copyright file="FARInitialTargetLogDto.cs" company="Atmel Corporation">
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
    public class FARInitialTargetLogDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the master identifier.
        /// </summary>
        /// <value>
        /// The master identifier.
        /// </value>
        public int MasterId { get; set; }

        /// <summary>
        /// Gets or sets the target date.
        /// </summary>
        /// <value>
        /// The target date.
        /// </value>
        public DateTime? TargetDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ReasonId { get; set; }
    }
}

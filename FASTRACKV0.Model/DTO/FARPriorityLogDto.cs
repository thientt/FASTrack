// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 03-23-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 03-23-2016
// ***********************************************************************
// <copyright file="FARPriorityLogDto.cs" company="Atmel Corporation">
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
    public class FARPriorityLogDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the master identifier.
        /// </summary>
        /// <value>
        /// The master identifier.
        /// </value>
        public int MasterId { get; set; }

        public int PriorityIdOld { get; set; }
        public MSTPriorityDto PriorityOld { get; set; }

        public int PriorityIdNew { get; set; }
        public MSTPriorityDto PriorityNew { get; set; }

        public int ReasonId { get; set; }
        public DelayReasonDto Reason { get; set; }
    }
}

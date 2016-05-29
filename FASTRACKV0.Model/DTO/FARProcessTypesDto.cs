// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 03-23-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 03-23-2016
// ***********************************************************************
// <copyright file="MSTProcessTypesDto.cs" company="Atmel Corporation">
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
    public class MSTProcessTypesDto : MSTDto
    {
        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        public Nullable<decimal> Duration { get; set; }
        /// <summary>
        /// Gets or sets the seq number.
        /// </summary>
        /// <value>
        /// The seq number.
        /// </value>
        public Nullable<int> SeqNumber { get; set; }

        /// <summary>
        /// Gets the show.
        /// </summary>
        /// <value>
        /// The show.
        /// </value>
        public string Show
        {
            get
            {
                return String.Format("{0} - {1}", Name, Description);
            }
        }
    }
}

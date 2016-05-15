// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 03-23-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 03-23-2016
// ***********************************************************************
// <copyright file="RecordLock.cs" company="Atmel Corporation">
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
    public class RecordLockDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the master identifier.
        /// </summary>
        /// <value>
        /// The master identifier.
        /// </value>
        public int MasterId { get; set; }
        /// <summary>
        /// Gets or sets the process history identifier.
        /// </summary>
        /// <value>
        /// The process history identifier.
        /// </value>
        public int ProcessHistoryId { get; set; }
        /// <summary>
        /// Gets or sets the lock date.
        /// </summary>
        /// <value>
        /// The lock date.
        /// </value>
        public DateTime LockDate { get; set; }
        /// <summary>
        /// Gets or sets the release date.
        /// </summary>
        /// <value>
        /// The release date.
        /// </value>
        public DateTime? ReleaseDate { get; set; }
        /// <summary>
        /// Gets or sets the lock by.
        /// </summary>
        /// <value>
        /// The lock by.
        /// </value>
        public string LockBy { get; set; }
        /// <summary>
        /// Gets or sets the process history.
        /// </summary>
        /// <value>
        /// The process history.
        /// </value>
        public FARProcessHistoryDto ProcessHistory { get; set; }
        /// <summary>
        /// Gets or sets the master.
        /// </summary>
        /// <value>
        /// The master.
        /// </value>
        public FARMasterDto Master { get; set; }
    }
}

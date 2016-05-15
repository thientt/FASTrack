using FASTrack.Model.DTO;
// ***********************************************************************
// Assembly         : FASTRACKV0
// Author           : tranthiencdsp@gmail.com
// Created          : 11-19-2015
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 04-20-2016
// ***********************************************************************
// <copyright file="FindingViewModel.cs" company="Atmel Corporation">
//     Copyright © Atmel 2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

/// <summary>
/// The ViewModel namespace.
/// </summary>
namespace FASTrack.ViewModel
{
    /// <summary>
    /// Class FindingViewModel.
    /// </summary>
    public class FindingViewModel
    {
        /// <summary>
        /// Gets or sets the device identifier.
        /// </summary>
        /// <value>The device identifier.</value>
        public int DeviceId { get; set; }
        /// <summary>
        /// Gets or sets the mechanism identifier.
        /// </summary>
        /// <value>The mechanism identifier.</value>
        public int MechanismId { get; set; }
        /// <summary>
        /// Gets or sets the mechanism.
        /// </summary>
        /// <value>The mechanism.</value>
        public IEnumerable<FARMechanismDto> Mechanism { get; set; }
        /// <summary>
        /// Gets or sets the failure detail.
        /// </summary>
        /// <value>The failure detail.</value>
        public string FailureDetail { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is same overall.
        /// </summary>
        /// <value><c>true</c> if this instance is same overall; otherwise, <c>false</c>.</value>
        public bool IsSameOverall { get; set; }
    }
}
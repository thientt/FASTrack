// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 03-23-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 03-23-2016
// ***********************************************************************
// <copyright file="MSTProductDto.cs" company="Atmel Corporation">
//     Copyright © Atmel Corporation 2015
// </copyright>
// <summary></summary>
// ***********************************************************************

/// <summary>
/// 
/// </summary>
namespace FASTrack.Model.DTO
{
    /// <summary>
    /// Create a Data Transfer Object Product
    /// </summary>
    public class MSTProductDto : MSTDto
    {
        /// <summary>
        /// Gets or sets the main person.
        /// </summary>
        /// <value>
        /// The main person.
        /// </value>
        public string MainPerson { get; set; }
        /// <summary>
        /// Gets or sets the secondary person.
        /// </summary>
        /// <value>
        /// The secondary person.
        /// </value>
        public string SecondaryPerson { get; set; }
        /// <summary>
        /// Gets or sets the tertiary person.
        /// </summary>
        /// <value>
        /// The tertiary person.
        /// </value>
        public string TertiaryPerson { get; set; }

        /// <summary>
        /// Get or set LabSiteId
        /// </summary>
        /// <remarks>
        /// It is column Id in table MST.LabSite
        /// </remarks>
        /// <see cref="https://mail.google.com/mail/u/0/?tab=wm#inbox/1549ffc4556acdc7"/>
        /// 
        public int LabSiteId { get; set; }
        /// <summary>
        /// Get or set the LabSite (Enhancement 11_May_2016)
        /// </summary>
        /// <see cref="https://mail.google.com/mail/u/0/?tab=wm#inbox/1549ffc4556acdc7"/>
        public MSTLabSiteDto LabSite { get; set; }
    }
}

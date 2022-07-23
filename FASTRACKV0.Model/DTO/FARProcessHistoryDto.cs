// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 03-23-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 03-23-2016
// ***********************************************************************
// <copyright file="FARProcessHistoryDto.cs" company="Atmel Corporation">
//     Copyright © Atmel Corporation 2015
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
namespace FASTrack.Model.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class FARProcessHistoryDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the master identifier.
        /// </summary>
        /// <value>
        /// The master identifier.
        /// </value>
        public int DeviceId { get; set; }

        /// <summary>
        /// Gets or sets the process type identifier.
        /// </summary>
        /// <value>
        /// The process type identifier.
        /// </value>
        public int ProcessTypeId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the seq number.
        /// </summary>
        /// <value>
        /// The seq number.
        /// </value>
        public int SeqNum { get; set; }

        /// <summary>
        /// Gets or sets the iteration.
        /// </summary>
        /// <value>
        /// The iteration.
        /// </value>
        public int? Iteration { get; set; }

        /// <summary>
        /// Gets or sets the analystor.
        /// </summary>
        /// <value>
        /// The analystor.
        /// </value>
        public string Analystor { get; set; }

        /// <summary>
        /// Gets or sets the analyst.
        /// </summary>
        /// <value>
        /// The analyst.
        /// </value>
        public SYSUsersDto Analyst { get; set; }

        /// <summary>
        /// Gets or sets the date in.
        /// </summary>
        /// <value>
        /// The date in.
        /// </value>
        public DateTime? PlannedIn { get; set; }

        /// <summary>
        /// Gets or sets the date out.
        /// </summary>
        /// <value>
        /// The date out.
        /// </value>
        public DateTime? PlannedOut { get; set; }

        /// <summary>
        /// Gets or sets the date in.
        /// </summary>
        /// <value>
        /// The date in.
        /// </value>
        public DateTime? DateIn { get; set; }

        /// <summary>
        /// Gets or sets the date out.
        /// </summary>
        /// <value>
        /// The date out.
        /// </value>
        public DateTime? DateOut { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the locked.
        /// </summary>
        /// <value>
        /// The locked.
        /// </value>
        public bool IsIncluded { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is has photos.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is has photos; otherwise, <c>false</c>.
        /// </value>
        public bool IsHasPhotos { get; set; }

        /// <summary>
        /// Gets or sets the type of the process.
        /// </summary>
        /// <value>
        /// The type of the process.
        /// </value>
        public MSTProcessTypesDto ProcessType { get; set; }

        /// <summary>
        /// Gets or sets the master.
        /// </summary>
        /// <value>
        /// The master.
        /// </value>
        public FARDeviceDetailsDto Device { get; set; }

        /// <summary>
        /// Gets or sets the process history identifier.
        /// </summary>
        /// <value>
        /// The process history identifier.
        /// </value>
        public int? ProcessResultId { get; set; }

        /// <summary>
        /// Gets or sets the process history.
        /// </summary>
        /// <value>
        /// The process history.
        /// </value>
        public MSTProcessResultDto ProcessResult { get; set; }

        //Extend Oct-22-2015
        public string Site { get; set; }

        //Enhancement
        public bool IsRemove { get; set; }

        //Enhancement Report
        public bool IsSelected { get; set; }
        public string SelectPhoto { get; set; }

        private List<string> photos;
        public List<string> Photos
        {
            get
            {
                if (photos == null)
                    photos = new List<string>();

                return photos;
            }
            set
            {
                photos = value;
            }
        }

        //Enhancement Report
        public List<ViewPhoto> ViewPhotos { get; set; }
    }

    public class ViewPhoto
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public bool IsSelected { get; set; }
    }
}

// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 23-07-2022
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 23-07-2022
// ***********************************************************************
// <copyright file="AttachmentViewModel.cs" company="Atmel Corporation">
//     Copyright © Atmel 2015
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System;

namespace FASTrack.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class AttachmentViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FANumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> InitialReport { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> FinalReport { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? InitialDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? FinalDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int InitalReasonId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Model.DTO.DelayReasonDto> InitalReasons { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FinalReasonId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<FASTrack.Model.DTO.DelayReasonDto> FinalReasons { get; set; }
    }
}
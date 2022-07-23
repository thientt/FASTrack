// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 23-07-2022
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 23-07-2022
// ***********************************************************************
// <copyright file="AnaProcessViewModel.cs" company="Atmel Corporation">
//     Copyright © Atmel 2015
// </copyright>
// <summary></summary>
// ***********************************************************************

using FASTrack.Model.DTO;
using System.Collections.Generic;

namespace FASTrack.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class AnaProcessViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int DeviceId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int MasterId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// /
        /// </summary>
        public IEnumerable<SYSUsersDto> Users { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<FARProcessHistoryDto> Process { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ProcessResultId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<MSTProcessResultDto> ProcessResult { get; set; }
    }
}
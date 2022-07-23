//***********************************************************************
// Assembly         : FASTrack
// Author           : tranthiencdsp@gmail.com
// Created          : 11-04-2015
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 08-26-2015
// ***********************************************************************
// <copyright file="DashboardViewModel.cs" company="Atmel Corporation">
//     Copyright © Atmel 2015
// </copyright>
// ***********************************************************************

using FASTrack.Model.DTO;
using System;

namespace FASTrack.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class DashboardViewModel : BaseDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string fanumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string reference { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string overall_incharge { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string bu { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string product { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime last_update { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string last_update_by { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string current_process { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string comments { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal overall_ct { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal current_process_ct { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string submission_status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int with_initial_report { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int with_final_report { get; set; }
    }
}
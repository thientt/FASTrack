// ***********************************************************************
// Assembly         : FASTRACKV0
// Author           : tranthiencdsp@gmail.com
// Created          : 11-04-2015
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 03-23-2016
// ***********************************************************************
// <copyright file="FAReportViewModel.cs" company="">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************

using FASTrack.Model.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FASTrack.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class FAReportViewModel : BaseDto
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Display(Name = "Report Type")]
        public int ReportTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Display(Name = "Origin")]
        public int OriginId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MaxLength(255)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<MSTOriginDto> Origins { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<ReportTypesDto> ReportTypes { get; set; }
    }
}
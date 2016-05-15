// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 03-23-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 03-23-2016
// ***********************************************************************
// <copyright file="MSTFarReportDto.cs" company="Atmel Corporation">
//     Copyright © Atmel Corporation 2015
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace FASTrack.Model.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class MSTFarReportDto : BaseDto
    {
        /// <summary>
        /// 
        /// </summary>
        public int ReportTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int OriginId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MSTOriginDto Origin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReportTypesDto ReportType { get; set; }
    }
}

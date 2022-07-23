// ***********************************************************************
// Assembly         : FASTRACKV0
// Author           : tranthiencdsp@gmail.com
// Created          : 11-04-2015
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 03-23-2016
// ***********************************************************************
// <copyright file="DeviceDetailsViewModel.cs" company="">
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
    /// Class DeviceDetailsViewModel.
    /// </summary>
    public class DeviceDetailsViewModel : BaseDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string FARNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int MasterId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(50, ErrorMessage = "Max length of SerialNo is 50 chars!")]
        public string SerialNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(50, ErrorMessage = "Max length of Sample/WaferNo. is 50 chars!")]
        public string WaferNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "LotNo is required!")]
        [StringLength(20, ErrorMessage = "Max length of Lotno is 20 chars!")]
        public string LotNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(25, ErrorMessage = "Max length of MfgPartNo is 25 chars!")]
        public string MfgPartNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int TechnologyId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<MSTTechnogolyDto> Technogolies { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Please the option Packge type!")]
        public int PackageTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<MSTPackageTypesDto> PackageTypes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Please the option Assembly type!")]
        public int AssembliesTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<MSTAssemblySiteDto> AssembliesTypes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Please the option Fab Site!")]
        public int FabSiteId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<FabSiteDto> FabSites { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Please the option FA Service")]
        public int ServiceId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<MSTServiceDto> Services { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(4, ErrorMessage = "Max length of DateCode is 4 chars!")]
        public string DateCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Quantity { get; set; }

        //[StringLength(10, ErrorMessage = "Max length of Stage is 10 chars!")]
        //public bool Stage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int StageId { get; set; }
    }
}
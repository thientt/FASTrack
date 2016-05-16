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

/// <summary>
/// The ViewModel namespace.
/// </summary>
namespace FASTrack.ViewModel
{
    /// <summary>
    /// Class DeviceDetailsViewModel.
    /// </summary>
    public class DeviceDetailsViewModel : BaseDto
    {
        public string FARNumber { get; set; }

        [Required]
        public int MasterId { get; set; }

        [StringLength(50, ErrorMessage = "Max length of SerialNo is 50 chars!")]
        public string SerialNo { get; set; }

        [StringLength(50, ErrorMessage = "Max length of Sample/WaferNo. is 50 chars!")]
        public string WaferNo { get; set; }

        [Required(ErrorMessage = "LotNo is required!")]
        [StringLength(20, ErrorMessage = "Max length of Lotno is 20 chars!")]
        public string LotNo { get; set; }

        [StringLength(25, ErrorMessage = "Max length of MfgPartNo is 25 chars!")]
        public string MfgPartNo { get; set; }

        [Required]
        public int TechnologyId { get; set; }
        public IEnumerable<MSTTechnogolyDto> Technogolies { get; set; }

        [Required(ErrorMessage = "Please the option Packge type!")]
        public int PackageTypeId { get; set; }
        public IEnumerable<MSTPackageTypesDto> PackageTypes { get; set; }

        [Required(ErrorMessage = "Please the option Assembly type!")]
        public int AssembliesTypeId { get; set; }
        public IEnumerable<MSTAssemblySiteDto> AssembliesTypes { get; set; }

        [Required(ErrorMessage = "Please the option Fab Site!")]
        public int FabSiteId { get; set; }
        public IEnumerable<FabSiteDto> FabSites { get; set; }

        [Required(ErrorMessage = "Please the option FA Service")]
        public int ServiceId { get; set; }
        public IEnumerable<MSTServiceDto> Services { get; set; }

        [StringLength(4, ErrorMessage = "Max length of DateCode is 4 chars!")]
        public string DateCode { get; set; }
        public int? Quantity { get; set; }

        //[StringLength(10, ErrorMessage = "Max length of Stage is 10 chars!")]
        //public bool Stage { get; set; }

        [Required]
        public int StageId { get; set; }
    }
}
// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 03-23-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 03-23-2016
// ***********************************************************************
// <copyright file="FARDeviceDetailsDto.cs" company="Atmel Corporation">
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
    public class FARDeviceDetailsDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the master identifier.
        /// </summary>
        /// <value>
        /// The master identifier.
        /// </value>
        public int MasterId { get; set; }

        /// <summary>
        /// Gets or sets the master.
        /// </summary>
        /// <value>
        /// The master.
        /// </value>
        public FARMasterDto Master { get; set; }

        /// <summary>
        /// Gets or sets the wafer no.
        /// </summary>
        /// <value>The wafer no.</value>
        public string WaferNo { get; set; }

        /// <summary>
        /// Gets or sets the serial no.
        /// </summary>
        /// <value>The serial no.</value>
        public string SerialNo { get; set; }

        /// <summary>
        /// Gets or sets the lot no.
        /// </summary>
        /// <value>
        /// The lot no.
        /// </value>
        public string LotNo { get; set; }

        /// <summary>
        /// Gets or sets the MFG part no.
        /// </summary>
        /// <value>
        /// The MFG part no.
        /// </value>
        public string MfgPartNo { get; set; }

        /// <summary>
        /// Gets or sets the technology.
        /// </summary>
        /// <value>
        /// The technology.
        /// </value>
        public int TechnologyId { get; set; }

        /// <summary>
        /// Gets or sets the package type identifier.
        /// </summary>
        /// <value>
        /// The package type identifier.
        /// </value>
        public int PackageTypeId { get; set; }

        /// <summary>
        /// Gets or sets the mechanism identifier.
        /// </summary>
        /// <value>
        /// The mechanism identifier.
        /// </value>
        public Nullable<int> MechanismId { get; set; }

        /// <summary>
        /// Gets or sets the failure detail.
        /// </summary>
        /// <value>
        /// The failure detail.
        /// </value>
        public string FailureDetail { get; set; }

        /// <summary>
        /// Gets or sets the technogoly.
        /// </summary>
        /// <value>The technogoly.</value>
        public MSTTechnogolyDto Technogoly { get; set; }

        /// <summary>
        /// Gets or sets the type of the package.
        /// </summary>
        /// <value>
        /// The type of the package.
        /// </value>
        public MSTPackageTypesDto PackageType { get; set; }

        /// <summary>
        /// Gets or sets the assembly site identifier.
        /// </summary>
        /// <value>
        /// The assembly site identifier.
        /// </value>
        public int AssemblySiteId { get; set; }

        /// <summary>
        /// Gets or sets the assembly sites.
        /// </summary>
        /// <value>
        /// The assembly sites.
        /// </value>
        public MSTAssemblySiteDto AssemblySites { get; set; }

        /// <summary>
        /// Gets or sets the fab site identifier.
        /// </summary>
        /// <value>
        /// The fab site identifier.
        /// </value>
        public int FabSiteId { get; set; }

        /// <summary>
        /// Gets or sets the fab site.
        /// </summary>
        /// <value>
        /// The fab site.
        /// </value>
        public FabSiteDto FabSite { get; set; }

        /// <summary>
        /// Gets or sets the date code.
        /// </summary>
        /// <value>
        /// The date code.
        /// </value>
        public string DateCode { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public int? Quantity { get; set; }

        /// <summary>
        /// Gets or sets the stage.
        /// </summary>
        /// <value>
        /// The stage.
        /// </value>
        public bool Stage { get; set; }

        /// <summary>
        /// Gets or sets the service identifier.
        /// </summary>
        /// <value>
        /// The service identifier.
        /// </value>
        public int ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the far services.
        /// </summary>
        /// <value>
        /// The far services.
        /// </value>
        public MSTServiceDto FARServices { get; set; }

        /// <summary>
        /// Gets or sets the mechanism.
        /// </summary>
        /// <value>
        /// The mechanism.
        /// </value>
        public FARMechanismDto Mechanism { get; set; }

        private List<FARProcessHistoryDto> processHis;
        /// <summary>
        /// Gets or sets the process his.
        /// </summary>
        /// <value>
        /// The process his.
        /// </value>
        public List<FARProcessHistoryDto> ProcessHis
        {
            get
            {
                if (processHis == null)
                    processHis = new List<FARProcessHistoryDto>();

                return processHis;
            }
            set
            {
                processHis = value;
            }
        }

        /// <summary>
        ///Enhancement Report Generator
        /// </summary>
        public bool IsIncluded { get; set; }

        /// <summary>
        /// Enhancement Report
        /// </summary>
        public bool IsSelected { get; set; }
    }
}

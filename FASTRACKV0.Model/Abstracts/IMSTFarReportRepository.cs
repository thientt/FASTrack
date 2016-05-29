// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 11-04-2015
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 10-25-2015
// ***********************************************************************
// <copyright file="IMSTFarReportRepository.cs" company="Atmel Corporation">
//     Copyright © Atmel 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using FASTrack.Model.DTO;
using FASTrack.Model.Types;

/// <summary>
/// The Abstracts namespace.
/// </summary>
namespace FASTrack.Model.Abstracts
{
    /// <summary>
    /// Interface IMSTFarReportRepository
    /// </summary>
    public interface IMSTFarReportRepository : IRepository<MSTFarReportDto>
    {
        MSTFarReportDto GetBy(int OriginId, ReportType reportType);
    }
}

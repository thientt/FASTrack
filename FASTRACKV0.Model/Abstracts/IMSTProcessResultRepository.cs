// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 11-04-2015
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 10-07-2015
// ***********************************************************************
// <copyright file="IMSTProcessResultRepository.cs" company="Atmel Corporation">
//     Copyright © Atmel 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using FASTrack.Model.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// The Abstracts namespace.
/// </summary>
namespace FASTrack.Model.Abstracts
{
    /// <summary>
    /// Interface IMSTProcessResultRepository
    /// </summary>
    public interface IMSTProcessResultRepository : IRepository<MSTProcessResultDto>
    {
        /// <summary>
        /// Get all Process Result by ProcessTypeId
        /// </summary>
        /// <param name="processTypeId"></param>
        /// <returns></returns>
        IEnumerable<MSTProcessResultDto> GetByProcessTypeId(int processTypeId);

        /// <summary>
        /// Get all the Process Result by ProcessTypeId
        /// </summary>
        /// <param name="processTypeId"></param>
        /// <returns></returns>
        Task<IEnumerable<MSTProcessResultDto>> GetByProcessTypeIdAsync(int processTypeId);
    }
}

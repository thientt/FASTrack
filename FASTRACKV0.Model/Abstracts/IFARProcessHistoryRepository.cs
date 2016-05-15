// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 11-04-2015
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 04-23-2016
// ***********************************************************************
// <copyright file="IFARProcessHistoryRepository.cs" company="Atmel Corporation">
//     Copyright © Atmel Corporation 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using FASTrack.Model.DTO;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
namespace FASTrack.Model.Abstracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFARProcessHistoryRepository : IRepository<FARProcessHistoryDto>
    {
        /// <summary>
        /// Edits the process.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        SaveResult EditProcess(FARProcessHistoryDto entity);

        /// <summary>
        /// Removes the process.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        SaveResult RemoveProcess(int id);

        /// <summary>
        /// Includes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="isIncluded">if set to <c>true</c> [is included].</param>
        /// <returns></returns>
        SaveResult Include(int id, bool isIncluded);

        /// <summary>
        /// Includes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="isIncluded">if set to <c>true</c> [is included].</param>
        /// <returns></returns>
        Task<SaveResult> IncludeAsync(int id, bool isIncluded);

        /// <summary>
        /// Checks the process flow filled.
        /// </summary>
        /// <param name="masterId">The master identifier.</param>
        /// <returns></returns>
        bool CheckProcessFlowFilled(int masterId);

        /// <summary>
        /// Checks the exist process.
        /// </summary>
        /// <param name="masterId">The master identifier.</param>
        /// <returns></returns>
        bool CheckExistProcess(int masterId);

        /// <summary>
        /// Gets the maximum process by master.
        /// </summary>
        /// <param name="masterId">The master identifier.</param>
        /// <returns>FARProcessHistoryDto.</returns>
        FARProcessHistoryDto GetMaxProcessByMaster(int masterId);

        /// <summary>
        /// Checks the exist analyst.
        /// </summary>
        /// <param name="masterId">The master identifier.</param>
        /// <param name="email">The email.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool CheckExistAnalyst(int masterId, string email);
    }
}

// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 11-04-2015
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 08-26-2015
// ***********************************************************************
// <copyright file="IFARMasterRepository.cs" company="Atmel Corporation">
//     Copyright © Atmel 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using FASTrack.Model.DTO;
using System.Threading.Tasks;

/// <summary>
/// The Abstracts namespace.S
/// </summary>
namespace FASTrack.Model.Abstracts
{
    /// <summary>
    /// Interface IFARMasterRepository
    /// </summary>
    public interface IFARMasterRepository : IRepository<FARMasterDto>
    {
        /// <summary>
        /// Counts the record.
        /// </summary>
        /// <returns></returns>
        int CountRecord();

        /// <summary>
        /// Adds the master.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        int AddMaster(FARMasterDto entity);

        /// <summary>
        /// Adds the master asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<int> AddMasterAsync(FARMasterDto entity);
    }
}

// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 11-04-2015
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 11-21-2015
// ***********************************************************************
// <copyright file="IFARDeviceDetailsRepository.cs" company="Atmel Corporation">
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
    /// Interface IFARDeviceDetailsRepository
    /// </summary>
    public interface IFARDeviceDetailsRepository : IRepository<FARDeviceDetailsDto>
    {
        /// <summary>
        /// Finds all Device the by master.
        /// </summary>
        /// <param name="idMaster">The identifier of master.</param>
        /// <returns></returns>
        IEnumerable<FARDeviceDetailsDto> FindBy(int idMaster);

        /// <summary>
        /// Finds all Device the by asynchronous.
        /// </summary>
        /// <param name="idMaster">The identifier master.</param>
        /// <returns></returns>
        Task<IEnumerable<FARDeviceDetailsDto>> FindByAsync(int idMaster);

        /// <summary>
        /// Adds the device.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        FARDeviceDetailsDto AddDevice(FARDeviceDetailsDto entity);

        /// <summary>
        /// Adds the device asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<FARDeviceDetailsDto> AddDeviceAsync(FARDeviceDetailsDto entity);

        /// <summary>
        /// Gets the failure mechanism.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        FARDeviceDetailsDto GetFailureMechanism(int id);

        /// <summary>
        /// Updates the failure mechanism.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="mechanismId">The mechanism identifier.</param>
        /// <param name="failureDetail">The failure detail.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        SaveResult UpdateFailureMechanism(FARDeviceDetailsDto entity, string userName);
    }
}

// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 11-04-2015
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 10-24-2015
// ***********************************************************************
// <copyright file="IMSTCustomerRepository.cs" company="Atmel Corporation">
//     Copyright © Atmel 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using FASTrack.Model.DTO;
using System.Collections.Generic;

/// <summary>
/// The Abstracts namespace.
/// </summary>
namespace FASTrack.Model.Abstracts
{
    /// <summary>
    /// Interface IMSTCustomerRepository
    /// </summary>
    public interface IMSTCustomerRepository : IRepository<MSTCustomerDto>
    {
        /// <summary>
        /// Finds the name of the by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>IEnumerable&lt;MSTCustomerDto&gt;.</returns>
        IEnumerable<MSTCustomerDto> FindByName(string name);

        /// <summary>
        /// Search by name of table Customer
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IEnumerable<string> SearchByName(string name);
    }
}

// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 11-04-2015
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 03-22-2016
// ***********************************************************************
// <copyright file="IMSTProductRepository.cs" company="Atmel Corporation">
//     Copyright © Atmel Corporation 2015
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
    /// Interface IMSTProductRepository
    /// </summary>
    public interface IMSTProductRepository : IRepository<MSTProductDto>
    {
        /// <summary>
        /// Finds all product name with name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Return list product such containing name value</returns>
        IEnumerable<MSTProductDto> FindByName(string name);

        /// <summary>
        /// Find any name such containing name from parammter
        /// </summary>
        /// <param name="name">Name value of product</param>
        /// <returns>Returns list names of product consider with name value</returns>
        IEnumerable<string> GetAnyName(string name);

        /// <summary>
        /// Finds all product name with name and LabSiteID
        /// </summary>
        /// <param name="name">Nam value of product</param>
        /// <param name="LabSiteId">Primary key of LabSite table</param>
        /// <returns></returns>
        IEnumerable<MSTProductDto> FindByNameAndLabSite(string name, int LabSiteId);
    }
}

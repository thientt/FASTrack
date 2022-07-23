// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 23-07-2022
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 23-07-2022
// ***********************************************************************
// <copyright file="FabSiteExtension.cs" company="Atmel Corporation">
//     Copyright © Atmel 2015
// </copyright>
// <summary></summary>
// ***********************************************************************

using FASTrack.Model.DTO;
using FASTrack.Model.Entities;

namespace FASTrack.Model.Extensions
{
    /// <summary>
    /// Fab site extension
    /// </summary>
    public static class FabSiteExtension
    {
        /// <summary>
        /// Convert object FabSite entity to FabSite DTO
        /// </summary>
        /// <param name="fabSites"></param>
        /// <returns></returns>
        public static FabSiteDto ToDto(this FabSites fabSites)
        {
            return new FabSiteDto
            {
                Id = fabSites.Id,
                Name = fabSites.Name,
                Description = fabSites.Description,
                IsDeleted = fabSites.IsDeleted,
                LastUpdatedBy = fabSites.LastUpdatedBy,
                LastUpdate = fabSites.LastUpdate,
            };
        }

        /// <summary>
        /// Convert object FabSite DTO to FabSite entity
        /// </summary>
        /// <param name="fabSites"></param>
        /// <returns></returns>
        public static FabSites ToEntity(this FabSiteDto dto)
        {
            return new FabSites
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                IsDeleted = dto.IsDeleted,
                LastUpdatedBy = dto.LastUpdatedBy,
                LastUpdate = dto.LastUpdate,
            };
        }
    }
}

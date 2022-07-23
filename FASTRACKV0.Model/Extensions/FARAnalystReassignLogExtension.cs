// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 23-07-2022
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 23-07-2022
// ***********************************************************************
// <copyright file="FARAnalystReassignLogExtension.cs" company="Atmel Corporation">
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
    public static class FARAnalystReassignLogExtension
    {
        /// <summary>
        /// Convert object FabSite entity to FabSite DTO
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static FARAnalystReassignLogDto ToDto(this LOG_FARAnalystReassign item)
        {
            return new FARAnalystReassignLogDto
            {
                Id = item.Id,
                MasterId = item.MasterId,
                AnalystFrom = item.AnalystFrom,
                AnalystTo = item.AnalystTo,
                UpdatedDate = item.UpdatedDate,
                IsDeleted = item.IsDeleted,
                LastUpdatedBy = item.LastUpdatedBy,
                LastUpdate = item.LastUpdate,
            };
        }

        /// <summary>
        /// Convert object FabSite DTO to FabSite entity
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static LOG_FARAnalystReassign ToEntity(this FARAnalystReassignLogDto item)
        {
            return new LOG_FARAnalystReassign
            {
                Id = item.Id,
                MasterId = item.MasterId,
                AnalystFrom = item.AnalystFrom,
                AnalystTo = item.AnalystTo,
                UpdatedDate = item.UpdatedDate,
                IsDeleted = item.IsDeleted,
                LastUpdatedBy = item.LastUpdatedBy,
                LastUpdate = item.LastUpdate,
            };
        }
    }
}

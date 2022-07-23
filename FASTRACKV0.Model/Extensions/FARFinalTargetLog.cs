// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 23-07-2022
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 23-07-2022
// ***********************************************************************
// <copyright file="FARFinalTargetLogExtension.cs" company="Atmel Corporation">
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
    public static class FARFinalTargetLogExtension
    {
        /// <summary>
        /// Convert object FabSite entity to FabSite DTO
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static FARFinalTargetLogDto ToDto(this LOG_FARFinalTarget item)
        {
            return new FARFinalTargetLogDto
            {
                Id = item.Id,
                MasterId = item.MasterId,
                ReasonId = item.ReasonId,
                TargetDate = item.TargetDate,
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
        public static LOG_FARFinalTarget ToEntity(this FARFinalTargetLogDto item)
        {
            return new LOG_FARFinalTarget
            {
                Id = item.Id,
                MasterId = item.MasterId,
                ReasonId = item.ReasonId,
                TargetDate = item.TargetDate,
                IsDeleted = item.IsDeleted,
                LastUpdatedBy = item.LastUpdatedBy,
                LastUpdate = item.LastUpdate,
            };
        }
    }
}

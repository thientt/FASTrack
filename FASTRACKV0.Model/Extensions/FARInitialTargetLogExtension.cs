// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 23-07-2022
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 23-07-2022
// ***********************************************************************
// <copyright file="FARInitialTargetLogExtension.cs" company="Atmel Corporation">
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
    public static class FARInitialTargetLogExtension
    {
        /// <summary>
        /// Convert object FabSite entity to FabSite DTO
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static FARInitialTargetLogDto ToDto(this LOG_FARInitialTarget item)
        {
            return new FARInitialTargetLogDto
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
        public static LOG_FARInitialTarget ToEntity(this FARInitialTargetLogDto item)
        {
            return new LOG_FARInitialTarget
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

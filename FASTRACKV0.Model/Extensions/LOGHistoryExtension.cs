// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 23-07-2022
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 23-07-2022
// ***********************************************************************
// <copyright file="LOGHistoryeExtension.cs" company="Atmel Corporation">
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
    public static class LOGHistoryeExtension
    {
        /// <summary>
        /// Convert object FabSite entity to LOGHistoryDto DTO
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static LOGHistoryDto ToDto(this LOG_FARHistory item)
        {
            return new LOGHistoryDto
            {
                Id = item.Id,
                MasterId = item.MasterId,
                StatusId = item.StatusId,
                ReasonId = item.ReasonId,
                LogDate = item.LogDate,
                IsDeleted = item.IsDeleted,
                LastUpdatedBy = item.LastUpdatedBy,
                LastUpdate = item.LastUpdate,
            };
        }

        /// <summary>
        /// Convert object LOGHistoryDto DTO to LOG_FARHistory entity
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static LOG_FARHistory ToEntity(this LOGHistoryDto item)
        {
            return new LOG_FARHistory
            {
                Id = item.Id,
                MasterId = item.MasterId,
                StatusId = item.StatusId,
                ReasonId = item.ReasonId,
                LogDate = item.LogDate,
                IsDeleted = item.IsDeleted,
                LastUpdatedBy = item.LastUpdatedBy,
                LastUpdate = item.LastUpdate,
            };
        }
    }
}

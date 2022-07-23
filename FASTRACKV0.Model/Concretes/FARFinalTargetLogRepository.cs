// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 10-06-2015
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 23-07-2022
// ***********************************************************************
// <copyright file="FARDeviceDetailsRepository.cs" company="Atmel Corporation">
//     Copyright © Atmel 2015
// </copyright>
// <summary></summary>
// ***********************************************************************

using FASTrack.Model.Abstracts;
using FASTrack.Model.DTO;
using FASTrack.Model.Entities;
using FASTrack.Model.Extensions;
using FASTrack.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
namespace FASTrack.Model.Concretes
{
    /// <summary>
    /// 
    /// </summary>
    public class FARFinalTargetLogRepository : IFARFinalTargetLogRepository
    {
        /// <summary>
        /// The _log service
        /// </summary>
        private readonly ILogService _logService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FARFinalTargetLogRepository"/> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public FARFinalTargetLogRepository(ILogService logService)
        {
            _logService = logService;
        }

        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public FARFinalTargetLogDto Single(int id)
        {
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    return (from item in context.LOG_FARFinalTarget
                            where item.IsDeleted == false && item.Id == id
                            select item.ToDto()).Single();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                return null;
            }
        }

        /// <summary>
        /// Finds the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<FARFinalTargetLogDto> SingleAsync(int id)
        {
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    return await (from item in context.LOG_FARFinalTarget
                                  where item.IsDeleted == false && item.Id == id
                                  select item.ToDto()).SingleAsync();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                return null;
            }
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FARFinalTargetLogDto> GetAll()
        {
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    return (from item in context.LOG_FARFinalTarget
                            where item.IsDeleted == false
                            select item.ToDto()).ToList();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                return null;
            }
        }

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<FARFinalTargetLogDto>> GetAllAsync()
        {
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    return await (from item in context.LOG_FARFinalTarget
                                  where item.IsDeleted == false
                                  select item.ToDto()).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                return null;
            }
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public SaveResult Update(FARFinalTargetLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var final = context.LOG_FARFinalTarget.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    _update(context, entity, final);
                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<SaveResult> UpdateAsync(FARFinalTargetLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var final = context.LOG_FARFinalTarget.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    _update(context, entity, final);
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public SaveResult Add(FARFinalTargetLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    _add(context, entity);
                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }
            return result;
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<SaveResult> AddAsync(FARFinalTargetLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    _add(context, entity);
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }
            return result;
        }

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        public SaveResult AddRange(IEnumerable<FARFinalTargetLogDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    foreach (var entity in entities)
                    {
                        _add(context, entity);
                    }
                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }
            return result;
        }

        /// <summary>
        /// Adds the range asynchronous.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        public async Task<SaveResult> AddRangeAsync(IEnumerable<FARFinalTargetLogDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    foreach (var entity in entities)
                    {
                        _add(context, entity);
                    }
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }
            return result;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public SaveResult Delete(FARFinalTargetLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var final = context.LOG_FARFinalTarget.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    final.IsDeleted = true;
                    final.LastUpdatedBy = entity.LastUpdatedBy;
                    final.LastUpdate = entity.LastUpdate;

                    context.Entry(final).State = EntityState.Modified;
                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<SaveResult> DeleteAsync(FARFinalTargetLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var final = context.LOG_FARFinalTarget.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    final.IsDeleted = true;
                    final.LastUpdatedBy = entity.LastUpdatedBy;
                    final.LastUpdate = entity.LastUpdate;

                    context.Entry(final).State = EntityState.Modified;
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        /// <summary>
        /// Deletes the by.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public SaveResult DeleteBy(int Id)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var final = context.LOG_FARFinalTarget.Single(x => x.Id == Id && x.IsDeleted == false);
                    final.IsDeleted = true;
                    final.LastUpdate = DateTime.Now;

                    context.Entry(final).State = EntityState.Modified;
                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        /// <summary>
        /// Deletes the by asynchronous.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public async Task<SaveResult> DeleteByAsync(int Id)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var final = context.LOG_FARFinalTarget.Single(x => x.Id == Id && x.IsDeleted == false);
                    final.IsDeleted = true;
                    final.LastUpdate = DateTime.Now;

                    context.Entry(final).State = EntityState.Modified;
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        /// <summary>
        /// Add entity
        /// </summary>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        private static void _add(FailureAnalysisEntities context, FARFinalTargetLogDto entity)
        {
            LOG_FARFinalTarget add = context.LOG_FARFinalTarget.Create();

            add.TargetDate = entity.TargetDate;
            add.ReasonId = entity.ReasonId;
            add.IsDeleted = entity.IsDeleted;
            add.MasterId = entity.MasterId;
            add.LastUpdatedBy = entity.LastUpdatedBy;
            add.LastUpdate = DateTime.Now;

            context.Entry(add).State = EntityState.Added;
        }

        /// <summary>
        /// Update enity
        /// </summary>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        /// <param name="final"></param>
        private static void _update(FailureAnalysisEntities context, FARFinalTargetLogDto entity, LOG_FARFinalTarget final)
        {
            final.MasterId = entity.MasterId;
            final.ReasonId = entity.ReasonId;
            final.IsDeleted = entity.IsDeleted;
            final.TargetDate = entity.TargetDate;
            final.LastUpdatedBy = entity.LastUpdatedBy;
            final.LastUpdate = DateTime.Now;

            context.Entry(final).State = EntityState.Modified;
        }
    }
}

using FASTrack.Model.Abstracts;
using FASTrack.Model.DTO;
using FASTrack.Model.Entities;
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
        private ILogService _logService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FARFinalTargetLogRepository"/> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public FARFinalTargetLogRepository(ILogService logService)
        {
            this._logService = logService;
        }

        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public FARFinalTargetLogDto Single(int id)
        {
            FARFinalTargetLogDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = (from item in context.LOG_FARFinalTarget
                              where item.IsDeleted == false && item.Id == id
                              select new FARFinalTargetLogDto()
                              {
                                  Id = item.Id,
                                  MasterId = item.MasterId,
                                  ReasonId =item.ReasonId,
                                  TargetDate = item.TargetDate,
                                  IsDeleted = item.IsDeleted,
                                  LastUpdatedBy = item.LastUpdatedBy,
                                  LastUpdate = item.LastUpdate,
                              }).Single();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = null;
            }
            return result;
        }

        /// <summary>
        /// Finds the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<FARFinalTargetLogDto> SingleAsync(int id)
        {
            FARFinalTargetLogDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = await (from item in context.LOG_FARFinalTarget
                                    where item.IsDeleted == false && item.Id == id
                                    select new FARFinalTargetLogDto()
                                    {
                                        Id = item.Id,
                                        MasterId = item.MasterId,
                                        ReasonId = item.ReasonId,
                                        TargetDate = item.TargetDate,
                                        IsDeleted = item.IsDeleted,
                                        LastUpdatedBy = item.LastUpdatedBy,
                                        LastUpdate = item.LastUpdate,
                                    }).SingleAsync();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = null;
            }
            return result;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FARFinalTargetLogDto> GetAll()
        {
            IEnumerable<FARFinalTargetLogDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = (from item in context.LOG_FARFinalTarget
                               where item.IsDeleted == false
                               select new FARFinalTargetLogDto()
                               {
                                   Id = item.Id,
                                   MasterId = item.MasterId,
                                   ReasonId = item.ReasonId,
                                   TargetDate = item.TargetDate,
                                   IsDeleted = item.IsDeleted,
                                   LastUpdatedBy = item.LastUpdatedBy,
                                   LastUpdate = item.LastUpdate,
                               }).ToList();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                return null;
            }
            return results;
        }

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<FARFinalTargetLogDto>> GetAllAsync()
        {
            IEnumerable<FARFinalTargetLogDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = await (from item in context.LOG_FARFinalTarget
                                     where item.IsDeleted == false
                                     select new FARFinalTargetLogDto()
                                     {
                                         Id = item.Id,
                                         MasterId = item.MasterId,
                                         ReasonId = item.ReasonId,
                                         TargetDate = item.TargetDate,
                                         IsDeleted = item.IsDeleted,
                                         LastUpdatedBy = item.LastUpdatedBy,
                                         LastUpdate = item.LastUpdate,
                                     }).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                return null;
            }
            return results;
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

                    final.MasterId = entity.MasterId;
                    final.ReasonId = entity.ReasonId;
                    final.IsDeleted = entity.IsDeleted;
                    final.TargetDate = entity.TargetDate;
                    final.LastUpdatedBy = entity.LastUpdatedBy;
                    final.LastUpdate = DateTime.Now;

                    context.Entry<LOG_FARFinalTarget>(final).State = System.Data.Entity.EntityState.Modified;
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

                    final.MasterId = entity.MasterId;
                    final.ReasonId = entity.ReasonId;
                    final.IsDeleted = entity.IsDeleted;
                    final.TargetDate = entity.TargetDate;
                    final.LastUpdatedBy = entity.LastUpdatedBy;
                    final.LastUpdate = DateTime.Now;

                    context.Entry<LOG_FARFinalTarget>(final).State = System.Data.Entity.EntityState.Modified;
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
                    LOG_FARFinalTarget add = context.LOG_FARFinalTarget.Create();

                    add.TargetDate = entity.TargetDate;
                    add.ReasonId = entity.ReasonId;
                    add.IsDeleted = entity.IsDeleted;
                    add.MasterId = entity.MasterId;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry<LOG_FARFinalTarget>(add).State = System.Data.Entity.EntityState.Added;
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
                    LOG_FARFinalTarget add = context.LOG_FARFinalTarget.Create();

                    add.TargetDate = entity.TargetDate;
                    add.ReasonId = entity.ReasonId;
                    add.MasterId = entity.MasterId;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry<LOG_FARFinalTarget>(add).State = System.Data.Entity.EntityState.Added;
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
                    LOG_FARFinalTarget add = null;
                    foreach (var entity in entities)
                    {
                        add = context.LOG_FARFinalTarget.Create();

                        add.TargetDate = entity.TargetDate;
                        add.ReasonId = entity.ReasonId;
                        add.IsDeleted = entity.IsDeleted;
                        add.MasterId = entity.MasterId;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;

                        context.Entry<LOG_FARFinalTarget>(add).State = System.Data.Entity.EntityState.Added;
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
                    LOG_FARFinalTarget add = null;
                    foreach (var entity in entities)
                    {
                        add = context.LOG_FARFinalTarget.Create();

                        add.TargetDate = entity.TargetDate;
                        add.ReasonId = entity.ReasonId;
                        add.IsDeleted = entity.IsDeleted;
                        add.MasterId = entity.MasterId;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;

                        context.Entry<LOG_FARFinalTarget>(add).State = System.Data.Entity.EntityState.Added;
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

                    context.Entry<LOG_FARFinalTarget>(final).State = System.Data.Entity.EntityState.Modified;
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

                    context.Entry<LOG_FARFinalTarget>(final).State = System.Data.Entity.EntityState.Modified;
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

                    context.Entry<LOG_FARFinalTarget>(final).State = System.Data.Entity.EntityState.Modified;
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

                    context.Entry<LOG_FARFinalTarget>(final).State = System.Data.Entity.EntityState.Modified;
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
    }
}

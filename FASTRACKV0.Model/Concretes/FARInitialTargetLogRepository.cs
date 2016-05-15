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
    public class FARInitialTargetLogRepository : IFARInitialTargetLogRepository
    {
        /// <summary>
        /// The _log service
        /// </summary>
        private ILogService _logService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FARInitialTargetLogRepository"/> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public FARInitialTargetLogRepository(ILogService logService)
        {
            this._logService = logService;
        }

        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public FARInitialTargetLogDto Single(int id)
        {
            FARInitialTargetLogDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = (from item in context.LOG_FARInitialTarget
                              where item.IsDeleted == false && item.Id == id
                              select new FARInitialTargetLogDto()
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
        public async Task<FARInitialTargetLogDto> SingleAsync(int id)
        {
            FARInitialTargetLogDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = await (from item in context.LOG_FARInitialTarget
                                    where item.IsDeleted == false && item.Id == id
                                    select new FARInitialTargetLogDto()
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
        public IEnumerable<FARInitialTargetLogDto> GetAll()
        {
            IEnumerable<FARInitialTargetLogDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = (from item in context.LOG_FARInitialTarget
                               where item.IsDeleted == false
                               select new FARInitialTargetLogDto()
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
        public async Task<IEnumerable<FARInitialTargetLogDto>> GetAllAsync()
        {
            IEnumerable<FARInitialTargetLogDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = await (from item in context.LOG_FARInitialTarget
                                     where item.IsDeleted == false
                                     select new FARInitialTargetLogDto()
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
        public SaveResult Update(FARInitialTargetLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var log = context.LOG_FARInitialTarget.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    log.MasterId = entity.MasterId;
                    log.ReasonId = entity.ReasonId;
                    log.IsDeleted = entity.IsDeleted;
                    log.TargetDate = entity.TargetDate;
                    log.LastUpdatedBy = entity.LastUpdatedBy;
                    log.LastUpdate = DateTime.Now;

                    context.Entry<LOG_FARInitialTarget>(log).State = System.Data.Entity.EntityState.Modified;
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
        public async Task<SaveResult> UpdateAsync(FARInitialTargetLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var log = context.LOG_FARInitialTarget.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    log.MasterId = entity.MasterId;
                    log.ReasonId = entity.ReasonId;
                    log.IsDeleted = entity.IsDeleted;
                    log.TargetDate = entity.TargetDate;
                    log.LastUpdatedBy = entity.LastUpdatedBy;
                    log.LastUpdate = DateTime.Now;

                    context.Entry<LOG_FARInitialTarget>(log).State = System.Data.Entity.EntityState.Modified;
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
        public SaveResult Add(FARInitialTargetLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    LOG_FARInitialTarget add = context.LOG_FARInitialTarget.Create();

                    add.TargetDate = entity.TargetDate;
                    add.ReasonId = entity.ReasonId;
                    add.IsDeleted = false;
                    add.MasterId = entity.MasterId;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry<LOG_FARInitialTarget>(add).State = System.Data.Entity.EntityState.Added;
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
        public async Task<SaveResult> AddAsync(FARInitialTargetLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    LOG_FARInitialTarget add = context.LOG_FARInitialTarget.Create();

                    add.TargetDate = entity.TargetDate;
                    add.ReasonId = entity.ReasonId;
                    add.MasterId = entity.MasterId;
                    add.IsDeleted = false;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry<LOG_FARInitialTarget>(add).State = System.Data.Entity.EntityState.Added;
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
        public SaveResult AddRange(IEnumerable<FARInitialTargetLogDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    LOG_FARInitialTarget add = null;
                    foreach (var entity in entities)
                    {
                        add = context.LOG_FARInitialTarget.Create();

                        add.TargetDate = entity.TargetDate;
                        add.ReasonId = entity.ReasonId;
                        add.IsDeleted = false;
                        add.MasterId = entity.MasterId;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;

                        context.Entry<LOG_FARInitialTarget>(add).State = System.Data.Entity.EntityState.Added;
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
        public async Task<SaveResult> AddRangeAsync(IEnumerable<FARInitialTargetLogDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    LOG_FARInitialTarget add = null;
                    foreach (var entity in entities)
                    {
                        add = context.LOG_FARInitialTarget.Create();

                        add.TargetDate = entity.TargetDate;
                        add.ReasonId = entity.ReasonId;
                        add.IsDeleted = false;
                        add.MasterId = entity.MasterId;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;

                        context.Entry<LOG_FARInitialTarget>(add).State = System.Data.Entity.EntityState.Added;
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
        public SaveResult Delete(FARInitialTargetLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.LOG_FARInitialTarget.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry<LOG_FARInitialTarget>(assembly).State = System.Data.Entity.EntityState.Modified;
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
        public async Task<SaveResult> DeleteAsync(FARInitialTargetLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.LOG_FARInitialTarget.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry<LOG_FARInitialTarget>(assembly).State = System.Data.Entity.EntityState.Modified;
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
                    var assembly = context.LOG_FARInitialTarget.Single(x => x.Id == Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry<LOG_FARInitialTarget>(assembly).State = System.Data.Entity.EntityState.Modified;
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
                    var assembly = context.LOG_FARInitialTarget.Single(x => x.Id == Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry<LOG_FARInitialTarget>(assembly).State = System.Data.Entity.EntityState.Modified;
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

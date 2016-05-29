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
    public class FARHistoryRepository : ILOGHistoryRepository
    {
        /// <summary>
        /// The _log service
        /// </summary>
        private ILogService _logService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FARHistoryRepository"/> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public FARHistoryRepository(ILogService logService)
        {
            this._logService = logService;
        }

        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public LOGHistoryDto Single(int id)
        {
            LOGHistoryDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = (from item in context.LOG_FARHistory
                              where item.IsDeleted == false && item.Id == id
                              select new LOGHistoryDto()
                              {
                                  Id = item.Id,
                                  MasterId = item.MasterId,
                                  StatusId = item.StatusId,
                                  ReasonId = item.ReasonId,
                                  LogDate = item.LogDate,
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
        public async Task<LOGHistoryDto> SingleAsync(int id)
        {
            LOGHistoryDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = await (from item in context.LOG_FARHistory
                                    where item.IsDeleted == false && item.Id == id
                                    select new LOGHistoryDto()
                                    {
                                        Id = item.Id,
                                        MasterId = item.MasterId,
                                        StatusId = item.StatusId,
                                        ReasonId = item.ReasonId,
                                        LogDate = item.LogDate,
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
        public IEnumerable<LOGHistoryDto> GetAll()
        {
            IEnumerable<LOGHistoryDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = (from item in context.LOG_FARHistory
                               where item.IsDeleted == false
                               select new LOGHistoryDto()
                               {
                                   Id = item.Id,
                                   MasterId = item.MasterId,
                                   StatusId = item.StatusId,
                                   ReasonId = item.ReasonId,
                                   LogDate = item.LogDate,
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
        public async Task<IEnumerable<LOGHistoryDto>> GetAllAsync()
        {
            IEnumerable<LOGHistoryDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = await (from item in context.LOG_FARHistory
                                     where item.IsDeleted == false
                                     select new LOGHistoryDto()
                                     {
                                         Id = item.Id,
                                         MasterId = item.MasterId,
                                         StatusId = item.StatusId,
                                         ReasonId = item.ReasonId,
                                         LogDate = item.LogDate,
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
        public SaveResult Update(LOGHistoryDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.LOG_FARHistory.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    assembly.StatusId = entity.StatusId;
                    assembly.MasterId = entity.MasterId;
                    assembly.ReasonId = entity.ReasonId;
                    assembly.IsDeleted = entity.IsDeleted;
                    assembly.LogDate = entity.LogDate;
                    assembly.ReasonId = entity.ReasonId;
                    assembly.LastUpdatedBy = entity.LastUpdatedBy;
                    assembly.LastUpdate = DateTime.Now;

                    context.Entry<LOG_FARHistory>(assembly).State = System.Data.Entity.EntityState.Modified;
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
        public async Task<SaveResult> UpdateAsync(LOGHistoryDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.LOG_FARHistory.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    assembly.Id = entity.Id;
                    assembly.MasterId = entity.MasterId;
                    assembly.StatusId = entity.StatusId;
                    assembly.ReasonId = entity.ReasonId;
                    assembly.LogDate = entity.LogDate;
                    assembly.IsDeleted = entity.IsDeleted;
                    assembly.ReasonId = entity.ReasonId;
                    assembly.LastUpdatedBy = entity.LastUpdatedBy;
                    assembly.LastUpdate = DateTime.Now;

                    context.Entry<LOG_FARHistory>(assembly).State = System.Data.Entity.EntityState.Modified;
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
        public SaveResult Add(LOGHistoryDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    LOG_FARHistory add = context.LOG_FARHistory.Create();

                    add.StatusId = entity.StatusId;
                    add.MasterId = entity.MasterId;
                    add.ReasonId = entity.ReasonId;
                    add.LogDate = entity.LogDate;
                    add.IsDeleted = entity.IsDeleted;
                    add.ReasonId = entity.ReasonId;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry<LOG_FARHistory>(add).State = System.Data.Entity.EntityState.Added;
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
        public async Task<SaveResult> AddAsync(LOGHistoryDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    LOG_FARHistory add = context.LOG_FARHistory.Create();

                    add.StatusId = entity.StatusId;
                    add.MasterId = entity.MasterId;
                    add.ReasonId = entity.ReasonId;
                    add.LogDate = entity.LogDate;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry<LOG_FARHistory>(add).State = System.Data.Entity.EntityState.Added;
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
        public SaveResult AddRange(IEnumerable<LOGHistoryDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    LOG_FARHistory add = null;
                    foreach (var entity in entities)
                    {
                        add = context.LOG_FARHistory.Create();

                        add.StatusId = entity.StatusId;
                        add.MasterId = entity.MasterId;
                        add.ReasonId = entity.ReasonId;
                        add.LogDate = entity.LogDate;
                        add.IsDeleted = entity.IsDeleted;
                        add.ReasonId = entity.ReasonId;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;

                        context.Entry<LOG_FARHistory>(add).State = System.Data.Entity.EntityState.Added;
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
        public async Task<SaveResult> AddRangeAsync(IEnumerable<LOGHistoryDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    LOG_FARHistory add = null;
                    foreach (var entity in entities)
                    {
                        add = context.LOG_FARHistory.Create();

                        add.StatusId = entity.StatusId;
                        add.MasterId = entity.MasterId;
                        add.ReasonId = entity.ReasonId;
                        add.LogDate = entity.LogDate;
                        add.IsDeleted = entity.IsDeleted;
                        add.ReasonId = entity.ReasonId;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;

                        context.Entry<LOG_FARHistory>(add).State = System.Data.Entity.EntityState.Added;
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
        public SaveResult Delete(LOGHistoryDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.LOG_FARHistory.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry<LOG_FARHistory>(assembly).State = System.Data.Entity.EntityState.Modified;
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
        public async Task<SaveResult> DeleteAsync(LOGHistoryDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.LOG_FARHistory.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry<LOG_FARHistory>(assembly).State = System.Data.Entity.EntityState.Modified;
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
                    var assembly = context.LOG_FARHistory.Single(x => x.Id == Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry<LOG_FARHistory>(assembly).State = System.Data.Entity.EntityState.Modified;
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
                    var assembly = context.LOG_FARHistory.Single(x => x.Id == Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry<LOG_FARHistory>(assembly).State = System.Data.Entity.EntityState.Modified;
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

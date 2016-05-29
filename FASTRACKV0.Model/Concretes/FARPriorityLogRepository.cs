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
    public class FARPriorityLogRepository : IFARPriorityLogRepository
    {
        /// <summary>
        /// The _log service
        /// </summary>
        private ILogService _logService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FARInitialTargetLogRepository"/> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public FARPriorityLogRepository(ILogService logService)
        {
            this._logService = logService;
        }

        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public FARPriorityLogDto Single(int id)
        {
            FARPriorityLogDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = (from item in context.LOG_FARPriority
                              where item.IsDeleted == false && item.Id == id
                              select new FARPriorityLogDto()
                              {
                                  Id = item.Id,
                                  MasterId = item.MasterId,
                                  PriorityIdNew = item.PriorityNew,
                                  PriorityNew = new MSTPriorityDto { Name = item.MST_Priority1.Name },
                                  PriorityOld = new MSTPriorityDto { Name = item.MST_Priority.Name },
                                  ReasonId = item.ReasonId,
                                  Reason = new DelayReasonDto { Description = item.MST_Reason.Description },
                                  PriorityIdOld = item.PriorityOld,
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
        public async Task<FARPriorityLogDto> SingleAsync(int id)
        {
            FARPriorityLogDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = await (from item in context.LOG_FARPriority
                                    where item.IsDeleted == false && item.Id == id
                                    select new FARPriorityLogDto()
                                    {
                                        Id = item.Id,
                                        MasterId = item.MasterId,
                                        PriorityIdNew = item.PriorityNew,
                                        PriorityIdOld = item.PriorityOld,
                                        PriorityNew = new MSTPriorityDto { Name = item.MST_Priority1.Name },
                                        PriorityOld = new MSTPriorityDto { Name = item.MST_Priority.Name },
                                        ReasonId = item.ReasonId,
                                        Reason = new DelayReasonDto { Description = item.MST_Reason.Description },
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
        public IEnumerable<FARPriorityLogDto> GetAll()
        {
            IEnumerable<FARPriorityLogDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = (from item in context.LOG_FARPriority
                               where item.IsDeleted == false
                               select new FARPriorityLogDto()
                               {
                                   Id = item.Id,
                                   MasterId = item.MasterId,
                                   PriorityIdNew = item.PriorityNew,
                                   PriorityIdOld = item.PriorityOld,
                                   PriorityNew = new MSTPriorityDto { Name = item.MST_Priority1.Name },
                                   PriorityOld = new MSTPriorityDto { Name = item.MST_Priority.Name },
                                   ReasonId = item.ReasonId,
                                   Reason = new DelayReasonDto { Description = item.MST_Reason.Description },
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
        public async Task<IEnumerable<FARPriorityLogDto>> GetAllAsync()
        {
            IEnumerable<FARPriorityLogDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = await (from item in context.LOG_FARPriority
                                     where item.IsDeleted == false
                                     select new FARPriorityLogDto()
                                     {
                                         Id = item.Id,
                                         MasterId = item.MasterId,
                                         PriorityIdNew = item.PriorityNew,
                                         PriorityIdOld = item.PriorityOld,
                                         PriorityNew = new MSTPriorityDto { Name = item.MST_Priority1.Name },
                                         PriorityOld = new MSTPriorityDto { Name = item.MST_Priority.Name },
                                         ReasonId = item.ReasonId,
                                         Reason = new DelayReasonDto { Description = item.MST_Reason.Description },
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
        public SaveResult Update(FARPriorityLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var his = context.LOG_FARPriority.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    his.MasterId = entity.MasterId;
                    his.IsDeleted = entity.IsDeleted;
                    his.PriorityOld = entity.PriorityIdOld;
                    his.PriorityNew = entity.PriorityIdNew;
                    his.ReasonId = entity.ReasonId;
                    his.LastUpdatedBy = entity.LastUpdatedBy;
                    his.LastUpdate = DateTime.Now;

                    context.Entry<LOG_FARPriority>(his).State = System.Data.Entity.EntityState.Modified;
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
        public async Task<SaveResult> UpdateAsync(FARPriorityLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var his = context.LOG_FARPriority.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    his.Id = entity.Id;
                    his.MasterId = entity.MasterId;
                    his.IsDeleted = entity.IsDeleted;
                    his.PriorityOld = entity.PriorityIdOld;
                    his.ReasonId = entity.ReasonId;
                    his.PriorityNew = entity.PriorityIdNew;
                    his.LastUpdatedBy = entity.LastUpdatedBy;
                    his.LastUpdate = DateTime.Now;

                    context.Entry<LOG_FARPriority>(his).State = System.Data.Entity.EntityState.Modified;
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
        public SaveResult Add(FARPriorityLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    LOG_FARPriority add = context.LOG_FARPriority.Create();

                    add.PriorityOld = entity.PriorityIdOld;
                    add.PriorityNew = entity.PriorityIdNew;
                    add.ReasonId = entity.ReasonId;
                    add.IsDeleted = false;
                    add.MasterId = entity.MasterId;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry<LOG_FARPriority>(add).State = System.Data.Entity.EntityState.Added;
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
        public async Task<SaveResult> AddAsync(FARPriorityLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    LOG_FARPriority add = context.LOG_FARPriority.Create();

                    add.PriorityOld = entity.PriorityIdOld;
                    add.PriorityNew = entity.PriorityIdNew;
                    add.MasterId = entity.MasterId;
                    add.ReasonId = entity.ReasonId;
                    add.IsDeleted = false;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry<LOG_FARPriority>(add).State = System.Data.Entity.EntityState.Added;
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
        public SaveResult AddRange(IEnumerable<FARPriorityLogDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    LOG_FARPriority add = null;
                    foreach (var entity in entities)
                    {
                        add = context.LOG_FARPriority.Create();

                        add.PriorityOld = entity.PriorityIdOld;
                        add.PriorityNew = entity.PriorityIdNew;
                        add.ReasonId = entity.ReasonId;
                        add.IsDeleted = false;
                        add.MasterId = entity.MasterId;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;

                        context.Entry<LOG_FARPriority>(add).State = System.Data.Entity.EntityState.Added;
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
        public async Task<SaveResult> AddRangeAsync(IEnumerable<FARPriorityLogDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    LOG_FARPriority add = null;
                    foreach (var entity in entities)
                    {
                        add = context.LOG_FARPriority.Create();

                        add.PriorityOld = entity.PriorityIdOld;
                        add.PriorityNew = entity.PriorityIdNew;
                        add.ReasonId = entity.ReasonId;
                        add.IsDeleted = false;
                        add.MasterId = entity.MasterId;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;

                        context.Entry<LOG_FARPriority>(add).State = System.Data.Entity.EntityState.Added;
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
        public SaveResult Delete(FARPriorityLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.LOG_FARPriority.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry<LOG_FARPriority>(assembly).State = System.Data.Entity.EntityState.Modified;
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
        public async Task<SaveResult> DeleteAsync(FARPriorityLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.LOG_FARPriority.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry<LOG_FARPriority>(assembly).State = System.Data.Entity.EntityState.Modified;
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
                    var assembly = context.LOG_FARPriority.Single(x => x.Id == Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry<LOG_FARPriority>(assembly).State = System.Data.Entity.EntityState.Modified;
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
                    var assembly = context.LOG_FARPriority.Single(x => x.Id == Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry<LOG_FARPriority>(assembly).State = System.Data.Entity.EntityState.Modified;
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

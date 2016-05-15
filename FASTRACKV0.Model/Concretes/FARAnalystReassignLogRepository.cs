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
    public class FARAnalystReassignLogRepository : IFARAnalystReassignLogRepository
    {
        /// <summary>
        /// The _log service
        /// </summary>
        private ILogService _logService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FARAnalystReassignLogRepository"/> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public FARAnalystReassignLogRepository(ILogService logService)
        {
            this._logService = logService;
        }

        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public FARAnalystReassignLogDto Single(int id)
        {
            FARAnalystReassignLogDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = (from item in context.LOG_FARAnalystReassign
                              where item.IsDeleted == false && item.Id == id
                              select new FARAnalystReassignLogDto()
                              {
                                  Id = item.Id,
                                  MasterId = item.MasterId,
                                  AnalystFrom = item.AnalystFrom,
                                  AnalystTo = item.AnalystTo,
                                  UpdatedDate = item.UpdatedDate,
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
        public async Task<FARAnalystReassignLogDto> SingleAsync(int id)
        {
            FARAnalystReassignLogDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = await (from item in context.LOG_FARAnalystReassign
                                    where item.IsDeleted == false && item.Id == id
                                    select new FARAnalystReassignLogDto()
                                    {
                                        Id = item.Id,
                                        MasterId = item.MasterId,
                                        AnalystFrom = item.AnalystFrom,
                                        AnalystTo = item.AnalystTo,
                                        UpdatedDate = item.UpdatedDate,
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
        public IEnumerable<FARAnalystReassignLogDto> GetAll()
        {
            IEnumerable<FARAnalystReassignLogDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = (from item in context.LOG_FARAnalystReassign
                               where item.IsDeleted == false
                               select new FARAnalystReassignLogDto()
                               {
                                   Id = item.Id,
                                   MasterId = item.MasterId,
                                   AnalystFrom = item.AnalystFrom,
                                   AnalystTo = item.AnalystTo,
                                   UpdatedDate = item.UpdatedDate,
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
        public async Task<IEnumerable<FARAnalystReassignLogDto>> GetAllAsync()
        {
            IEnumerable<FARAnalystReassignLogDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = await (from item in context.LOG_FARAnalystReassign
                                     where item.IsDeleted == false
                                     select new FARAnalystReassignLogDto()
                                     {
                                         Id = item.Id,
                                         MasterId = item.MasterId,
                                         AnalystFrom = item.AnalystFrom,
                                         AnalystTo = item.AnalystTo,
                                         UpdatedDate = item.UpdatedDate,
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
        public SaveResult Update(FARAnalystReassignLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.LOG_FARAnalystReassign.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    assembly.MasterId = entity.MasterId;
                    assembly.IsDeleted = entity.IsDeleted;
                    assembly.AnalystFrom = entity.AnalystFrom;
                    assembly.AnalystTo = entity.AnalystTo;
                    assembly.LastUpdatedBy = entity.LastUpdatedBy;
                    assembly.UpdatedDate = DateTime.Now;

                    context.Entry<LOG_FARAnalystReassign>(assembly).State = System.Data.Entity.EntityState.Modified;
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
        public async Task<SaveResult> UpdateAsync(FARAnalystReassignLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.LOG_FARAnalystReassign.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    assembly.MasterId = entity.MasterId;
                    assembly.IsDeleted = entity.IsDeleted;
                    assembly.AnalystFrom = entity.AnalystFrom;
                    assembly.AnalystTo = entity.AnalystTo;
                    assembly.LastUpdatedBy = entity.LastUpdatedBy;
                    assembly.UpdatedDate = DateTime.Now;

                    context.Entry<LOG_FARAnalystReassign>(assembly).State = System.Data.Entity.EntityState.Modified;
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
        public SaveResult Add(FARAnalystReassignLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    LOG_FARAnalystReassign add = context.LOG_FARAnalystReassign.Create();

                    add.MasterId = entity.MasterId;
                    add.AnalystFrom = entity.AnalystFrom;
                    add.AnalystTo = entity.AnalystTo;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry<LOG_FARAnalystReassign>(add).State = System.Data.Entity.EntityState.Added;
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
        public async Task<SaveResult> AddAsync(FARAnalystReassignLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    LOG_FARAnalystReassign add = context.LOG_FARAnalystReassign.Create();

                    add.MasterId = entity.MasterId;
                    add.AnalystFrom = entity.AnalystFrom;
                    add.AnalystTo = entity.AnalystTo;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry<LOG_FARAnalystReassign>(add).State = System.Data.Entity.EntityState.Added;
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
        public SaveResult AddRange(IEnumerable<FARAnalystReassignLogDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    LOG_FARAnalystReassign add = null;
                    foreach (var entity in entities)
                    {
                        add = context.LOG_FARAnalystReassign.Create();

                        add.MasterId = entity.MasterId;
                        add.AnalystFrom = entity.AnalystFrom;
                        add.AnalystTo = entity.AnalystTo;
                        add.IsDeleted = entity.IsDeleted;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;

                        context.Entry<LOG_FARAnalystReassign>(add).State = System.Data.Entity.EntityState.Added;
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
        public async Task<SaveResult> AddRangeAsync(IEnumerable<FARAnalystReassignLogDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    LOG_FARAnalystReassign add = null;
                    foreach (var entity in entities)
                    {
                        add = context.LOG_FARAnalystReassign.Create();

                        add.MasterId = entity.MasterId;
                        add.AnalystFrom = entity.AnalystFrom;
                        add.AnalystTo = entity.AnalystTo;
                        add.IsDeleted = entity.IsDeleted;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;

                        context.Entry<LOG_FARAnalystReassign>(add).State = System.Data.Entity.EntityState.Added;
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
        public SaveResult Delete(FARAnalystReassignLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.LOG_FARAnalystReassign.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry<LOG_FARAnalystReassign>(assembly).State = System.Data.Entity.EntityState.Modified;
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
        public async Task<SaveResult> DeleteAsync(FARAnalystReassignLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var reassign = context.LOG_FARAnalystReassign.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    reassign.IsDeleted = true;
                    reassign.LastUpdate = DateTime.Now;
                    reassign.LastUpdatedBy = entity.LastUpdatedBy;

                    context.Entry<LOG_FARAnalystReassign>(reassign).State = System.Data.Entity.EntityState.Modified;
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
                    var reassign = context.LOG_FARAnalystReassign.Single(x => x.Id == Id && x.IsDeleted == false);
                    reassign.IsDeleted = true;
                    reassign.LastUpdate = DateTime.Now;

                    context.Entry<LOG_FARAnalystReassign>(reassign).State = System.Data.Entity.EntityState.Modified;
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
                    var reassign = context.LOG_FARAnalystReassign.Single(x => x.Id == Id && x.IsDeleted == false);
                    reassign.IsDeleted = true;
                    reassign.LastUpdate = DateTime.Now;

                    context.Entry<LOG_FARAnalystReassign>(reassign).State = System.Data.Entity.EntityState.Modified;
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

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
    public class FARRecordLockRepository : IFARRecordLockRepository
    {
        /// <summary>
        /// The _log service
        /// </summary>
        private ILogService _logService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MSTBuRepository"/> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public FARRecordLockRepository(ILogService logService)
        {
            this._logService = logService;
        }

        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public RecordLockDto Single(int id)
        {
            RecordLockDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = (from item in context.FAR_RecordLock
                              where item.IsDeleted == false && item.Id == id
                              select new RecordLockDto()
                              {
                                  Id = item.Id,
                                  ProcessHistoryId = item.ProcessHistoryId,
                                  LockBy = item.LockBy,
                                  LockDate = item.LockDate,
                                  MasterId = item.MasterId,
                                  ReleaseDate = item.ReleaseDate,
                                  LastUpdatedBy = item.LastUpdatedBy,
                                  LastUpdate = item.LastUpdate,
                              }).Single();
                }
            }
            catch (Exception ex)
            {
                result = null;
                _logService.Error(ex.Message, ex);
            }
            return result;
        }

        /// <summary>
        /// Finds the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<RecordLockDto> SingleAsync(int id)
        {
            RecordLockDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = await (from item in context.FAR_RecordLock
                                    where item.IsDeleted == false && item.Id == id
                                    select new RecordLockDto()
                                    {
                                        Id = item.Id,
                                        ProcessHistoryId = item.ProcessHistoryId,
                                        LockBy = item.LockBy,
                                        LockDate = item.LockDate,
                                        MasterId = item.MasterId,
                                        ReleaseDate = item.ReleaseDate,
                                        LastUpdatedBy = item.LastUpdatedBy,
                                        LastUpdate = item.LastUpdate,
                                    }).SingleAsync();
                }
            }
            catch (Exception ex)
            {
                result = null;
                _logService.Error(ex.Message, ex);
            }
            return result;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RecordLockDto> GetAll()
        {
            IEnumerable<RecordLockDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = (from item in context.FAR_RecordLock
                               where item.IsDeleted == false
                               select new RecordLockDto()
                               {
                                   Id = item.Id,
                                   ProcessHistoryId = item.ProcessHistoryId,
                                   LockBy = item.LockBy,
                                   LockDate = item.LockDate,
                                   MasterId = item.MasterId,
                                   ReleaseDate = item.ReleaseDate,
                                   LastUpdatedBy = item.LastUpdatedBy,
                                   LastUpdate = item.LastUpdate,
                               }).ToList();
                }
            }
            catch (Exception ex)
            {
                results = null;
                _logService.Error(ex.Message, ex);
            }
            return results;
        }

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<RecordLockDto>> GetAllAsync()
        {
            IEnumerable<RecordLockDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = await (from item in context.FAR_RecordLock
                                     where item.IsDeleted == false
                                     select new RecordLockDto()
                                     {
                                         Id = item.Id,
                                         ProcessHistoryId = item.ProcessHistoryId,
                                         LockBy = item.LockBy,
                                         LockDate = item.LockDate,
                                         MasterId = item.MasterId,
                                         ReleaseDate = item.ReleaseDate,
                                         LastUpdatedBy = item.LastUpdatedBy,
                                         LastUpdate = item.LastUpdate,
                                     }).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                results = null;
                _logService.Error(ex.Message, ex);
            }
            return results;
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public SaveResult Update(RecordLockDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var update = context.FAR_RecordLock.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.ProcessHistoryId = entity.ProcessHistoryId;
                    update.LockBy = entity.LockBy;
                    update.LockDate = entity.LockDate;
                    update.MasterId = entity.MasterId;
                    update.ReleaseDate = entity.ReleaseDate;
                    update.LastUpdatedBy = entity.LastUpdatedBy;
                    update.LastUpdate = DateTime.Now;

                    context.Entry<FAR_RecordLock>(update).State = System.Data.Entity.EntityState.Modified;
                    result = context.SaveChanges() > 0 ? SaveResult.SUCESS : SaveResult.FAILURE;
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
        public async Task<SaveResult> UpdateAsync(RecordLockDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var update = context.FAR_RecordLock.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.ProcessHistoryId = entity.ProcessHistoryId;
                    update.LockBy = entity.LockBy;
                    update.LockDate = entity.LockDate;
                    update.MasterId = entity.MasterId;
                    update.ReleaseDate = entity.ReleaseDate;
                    update.LastUpdatedBy = entity.LastUpdatedBy;
                    update.LastUpdate = DateTime.Now;

                    context.Entry<FAR_RecordLock>(update).State = System.Data.Entity.EntityState.Modified;
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCESS : SaveResult.FAILURE;
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
        public SaveResult Add(RecordLockDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    FAR_RecordLock add = context.FAR_RecordLock.Create();

                    add.ProcessHistoryId = entity.ProcessHistoryId;
                    add.LockBy = entity.LockBy;
                    add.LockDate = entity.LockDate;
                    add.MasterId = entity.MasterId;
                    add.ReleaseDate = entity.ReleaseDate;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry<FAR_RecordLock>(add).State = System.Data.Entity.EntityState.Added;
                    result = context.SaveChanges() > 0 ? SaveResult.SUCESS : SaveResult.FAILURE;
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
        public async Task<SaveResult> AddAsync(RecordLockDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    FAR_RecordLock add = context.FAR_RecordLock.Create();

                    add.ProcessHistoryId = entity.ProcessHistoryId;
                    add.LockBy = entity.LockBy;
                    add.LockDate = entity.LockDate;
                    add.MasterId = entity.MasterId;
                    add.ReleaseDate = entity.ReleaseDate;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry<FAR_RecordLock>(add).State = System.Data.Entity.EntityState.Added;
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCESS : SaveResult.FAILURE;
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
        public SaveResult AddRange(IEnumerable<RecordLockDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    foreach (var entity in entities)
                    {
                        FAR_RecordLock add = context.FAR_RecordLock.Create();

                        add.ProcessHistoryId = entity.ProcessHistoryId;
                        add.LockBy = entity.LockBy;
                        add.LockDate = entity.LockDate;
                        add.MasterId = entity.MasterId;
                        add.ReleaseDate = entity.ReleaseDate;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;

                        context.Entry<FAR_RecordLock>(add).State = System.Data.Entity.EntityState.Added;
                    }
                    result = context.SaveChanges() > 0 ? SaveResult.SUCESS : SaveResult.FAILURE;
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
        public async Task<SaveResult> AddRangeAsync(IEnumerable<RecordLockDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    foreach (var entity in entities)
                    {
                        FAR_RecordLock add = context.FAR_RecordLock.Create();

                        add.ProcessHistoryId = entity.ProcessHistoryId;
                        add.LockBy = entity.LockBy;
                        add.LockDate = entity.LockDate;
                        add.MasterId = entity.MasterId;
                        add.ReleaseDate = entity.ReleaseDate;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;

                        context.Entry<FAR_RecordLock>(add).State = System.Data.Entity.EntityState.Added;
                    }
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCESS : SaveResult.FAILURE;
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
        public SaveResult Delete(RecordLockDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var record = context.FAR_RecordLock.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    record.IsDeleted = true;
                    record.LastUpdate = DateTime.Now;
                    record.LastUpdatedBy = entity.LastUpdatedBy;

                    context.Entry<FAR_RecordLock>(record).State = System.Data.Entity.EntityState.Modified;
                    result = context.SaveChanges() > 0 ? SaveResult.SUCESS : SaveResult.FAILURE;
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
        public async Task<SaveResult> DeleteAsync(RecordLockDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var record = context.FAR_RecordLock.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    record.IsDeleted = true;
                    record.LastUpdate = DateTime.Now;
                    record.LastUpdatedBy = entity.LastUpdatedBy;

                    context.Entry<FAR_RecordLock>(record).State = System.Data.Entity.EntityState.Modified;
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCESS : SaveResult.FAILURE;
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
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public SaveResult DeleteBy(int id)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var record = context.FAR_RecordLock.Single(x => x.Id == id && x.IsDeleted == false);
                    record.IsDeleted = true;
                    record.LastUpdate = DateTime.Now;

                    context.Entry<FAR_RecordLock>(record).State = System.Data.Entity.EntityState.Modified;
                    result = context.SaveChanges() > 0 ? SaveResult.SUCESS : SaveResult.FAILURE;
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
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<SaveResult> DeleteByAsync(int id)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var record = context.FAR_RecordLock.Single(x => x.Id == id && x.IsDeleted == false);
                    record.IsDeleted = true;
                    record.LastUpdate = DateTime.Now;

                    context.Entry<FAR_RecordLock>(record).State = System.Data.Entity.EntityState.Modified;
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCESS : SaveResult.FAILURE;
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

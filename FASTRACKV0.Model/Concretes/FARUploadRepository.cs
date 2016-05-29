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
    public class FARUploadRepository : IFARUploadRepository
    {
        /// <summary>
        /// The _log service
        /// </summary>
        private ILogService _logService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FARUploadRepository"/> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public FARUploadRepository(ILogService logService)
        {
            this._logService = logService;
        }

        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public FARUploadDto Single(int id)
        {
            FARUploadDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = (from item in context.LOG_FARUpload
                              where item.Id == id
                              select new FARUploadDto()
                              {
                                  Id = item.Id,
                                  MasterId = item.MasterId,
                                  FAType = item.FAType,
                                  FileName = item.FileName,
                                  ReasonId = item.ReasonId,
                                  UploadedDate = item.UploadedDate,
                                  UploadedBy = item.UploadedBy
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
        public async Task<FARUploadDto> SingleAsync(int id)
        {
            FARUploadDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = await (from item in context.LOG_FARUpload
                                    where item.Id == id
                                    select new FARUploadDto()
                                    {
                                        Id = item.Id,
                                        MasterId = item.MasterId,
                                        FAType = item.FAType,
                                        FileName = item.FileName,
                                        ReasonId = item.ReasonId,
                                        UploadedDate = item.UploadedDate,
                                        UploadedBy = item.UploadedBy
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
        public IEnumerable<FARUploadDto> GetAll()
        {
            IEnumerable<FARUploadDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = (from item in context.LOG_FARUpload
                               select new FARUploadDto()
                               {
                                   Id = item.Id,
                                   MasterId = item.MasterId,
                                   FAType = item.FAType,
                                   FileName = item.FileName,
                                   ReasonId = item.ReasonId,
                                   UploadedDate = item.UploadedDate,
                                   UploadedBy = item.UploadedBy
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
        public async Task<IEnumerable<FARUploadDto>> GetAllAsync()
        {
            IEnumerable<FARUploadDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = await (from item in context.LOG_FARUpload
                                     select new FARUploadDto()
                                     {
                                         Id = item.Id,
                                         MasterId = item.MasterId,
                                         FAType = item.FAType,
                                         FileName = item.FileName,
                                         ReasonId = item.ReasonId,
                                         UploadedDate = item.UploadedDate,
                                         UploadedBy = item.UploadedBy
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
        public SaveResult Update(FARUploadDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var upload = context.LOG_FARUpload.Single(x => x.Id == entity.Id);

                    upload.FileName = entity.FileName;
                    upload.MasterId = entity.MasterId;
                    upload.ReasonId = entity.ReasonId;
                    upload.FAType = entity.FAType;
                    upload.UploadedBy = entity.UploadedBy;
                    upload.UploadedDate = DateTime.Now;

                    context.Entry<LOG_FARUpload>(upload).State = System.Data.Entity.EntityState.Modified;
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
        public async Task<SaveResult> UpdateAsync(FARUploadDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var upload = context.LOG_FARUpload.Single(x => x.Id == entity.Id);

                    upload.FileName = entity.FileName;
                    upload.MasterId = entity.MasterId;
                    upload.ReasonId = entity.ReasonId;
                    upload.FAType = entity.FAType;
                    upload.UploadedBy = entity.UploadedBy;
                    upload.UploadedDate = DateTime.Now;

                    context.Entry<LOG_FARUpload>(upload).State = System.Data.Entity.EntityState.Modified;
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
        public SaveResult Add(FARUploadDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    LOG_FARUpload add = context.LOG_FARUpload.Create();

                    add.FileName = entity.FileName;
                    add.MasterId = entity.MasterId;
                    add.ReasonId = entity.ReasonId;
                    add.FAType = entity.FAType;
                    add.UploadedBy = entity.UploadedBy;
                    add.UploadedDate = DateTime.Now;

                    context.Entry<LOG_FARUpload>(add).State = System.Data.Entity.EntityState.Added;
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
        public async Task<SaveResult> AddAsync(FARUploadDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    LOG_FARUpload add = context.LOG_FARUpload.Create();
                    add.FileName = entity.FileName;
                    add.MasterId = entity.MasterId;
                    add.ReasonId = entity.ReasonId;
                    add.FAType = entity.FAType;
                    add.UploadedBy = entity.UploadedBy;
                    add.UploadedDate = DateTime.Now;

                    context.Entry<LOG_FARUpload>(add).State = System.Data.Entity.EntityState.Added;
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
        public SaveResult AddRange(IEnumerable<FARUploadDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    LOG_FARUpload add = null;
                    foreach (var entity in entities)
                    {
                        add = context.LOG_FARUpload.Create();

                        add.FileName = entity.FileName;
                        add.MasterId = entity.MasterId;
                        add.ReasonId = entity.ReasonId;
                        add.FAType = entity.FAType;
                        add.UploadedBy = entity.UploadedBy;
                        add.UploadedDate = DateTime.Now;

                        context.Entry<LOG_FARUpload>(add).State = System.Data.Entity.EntityState.Added;
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
        public async Task<SaveResult> AddRangeAsync(IEnumerable<FARUploadDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    LOG_FARUpload add = null;
                    foreach (var entity in entities)
                    {
                        add = context.LOG_FARUpload.Create();

                        add.FileName = entity.FileName;
                        add.MasterId = entity.MasterId;
                        add.ReasonId = entity.ReasonId;
                        add.FAType = entity.FAType;
                        add.UploadedBy = entity.UploadedBy;
                        add.UploadedDate = DateTime.Now;

                        context.Entry<LOG_FARUpload>(add).State = System.Data.Entity.EntityState.Added;
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
        public SaveResult Delete(FARUploadDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.LOG_FARUpload.Single(x => x.Id == entity.Id);

                    context.Entry<LOG_FARUpload>(assembly).State = System.Data.Entity.EntityState.Deleted;
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
        public async Task<SaveResult> DeleteAsync(FARUploadDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.LOG_FARUpload.Single(x => x.Id == entity.Id);

                    context.Entry<LOG_FARUpload>(assembly).State = System.Data.Entity.EntityState.Deleted;
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
                    var assembly = context.LOG_FARUpload.Single(x => x.Id == Id);

                    context.Entry<LOG_FARUpload>(assembly).State = System.Data.Entity.EntityState.Deleted;
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
                    var assembly = context.LOG_FARUpload.Single(x => x.Id == Id);

                    context.Entry<LOG_FARUpload>(assembly).State = System.Data.Entity.EntityState.Deleted;
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

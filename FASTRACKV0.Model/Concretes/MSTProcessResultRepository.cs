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
    public class MSTProcessResultRepository : IMSTProcessResultRepository
    {
        /// <summary>
        /// The _log service
        /// </summary>
        private readonly ILogService _logService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MSTProcessResultRepository"/> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public MSTProcessResultRepository(ILogService logService)
        {
            _logService = logService;
        }

        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public MSTProcessResultDto Single(int id)
        {
            MSTProcessResultDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = (from item in context.MST_ProcessResult
                              where item.IsDeleted == false && item.Id == id
                              select new MSTProcessResultDto()
                              {
                                  Id = item.Id,
                                  ProcessTypeId = item.ProcessTypeId,
                                  ProcessType = new MSTProcessTypesDto
                                  {
                                      Id = item.MST_ProcessTypes.Id,
                                      Name = item.MST_ProcessTypes.Name,
                                      Description = item.MST_ProcessTypes.Description,
                                  },
                                  Value = item.Value,
                                  Description = item.Description,
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
        /// INIds the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<MSTProcessResultDto> SingleAsync(int id)
        {
            MSTProcessResultDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = await (from item in context.MST_ProcessResult
                                    where item.IsDeleted == false && item.Id == id
                                    select new MSTProcessResultDto()
                                    {
                                        Id = item.Id,
                                        ProcessTypeId = item.ProcessTypeId,
                                        ProcessType = new MSTProcessTypesDto
                                        {
                                            Id = item.MST_ProcessTypes.Id,
                                            Name = item.MST_ProcessTypes.Name,
                                            Description = item.MST_ProcessTypes.Description,
                                        },
                                        Value = item.Value,
                                        Description = item.Description,
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
        public IEnumerable<MSTProcessResultDto> GetAll()
        {
            IEnumerable<MSTProcessResultDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = (from item in context.MST_ProcessResult
                               where item.IsDeleted == false
                               select new MSTProcessResultDto()
                               {
                                   Id = item.Id,
                                   ProcessTypeId = item.ProcessTypeId,
                                   ProcessType = new MSTProcessTypesDto
                                   {
                                       Id = item.MST_ProcessTypes.Id,
                                       Name = item.MST_ProcessTypes.Name,
                                       Description = item.MST_ProcessTypes.Description,
                                   },
                                   Value = item.Value,
                                   Description = item.Description,
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
        public async Task<IEnumerable<MSTProcessResultDto>> GetAllAsync()
        {
            IEnumerable<MSTProcessResultDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = await (from item in context.MST_ProcessResult
                                     where item.IsDeleted == false
                                     select new MSTProcessResultDto()
                                     {
                                         Id = item.Id,
                                         ProcessTypeId = item.ProcessTypeId,
                                         ProcessType = new MSTProcessTypesDto
                                         {
                                             Id = item.MST_ProcessTypes.Id,
                                             Name = item.MST_ProcessTypes.Name,
                                             Description = item.MST_ProcessTypes.Description,
                                         },
                                         Value = item.Value,
                                         Description = item.Description,
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
        /// Gets all process results by process type Id.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MSTProcessResultDto> GetByProcessTypeId(int processTypeId)
        {
            IEnumerable<MSTProcessResultDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = (from item in context.MST_ProcessResult
                               where item.IsDeleted == false &&
                               item.ProcessTypeId == processTypeId
                               select new MSTProcessResultDto()
                               {
                                   Id = item.Id,
                                   ProcessTypeId = item.ProcessTypeId,
                                   ProcessType = new MSTProcessTypesDto
                                   {
                                       Id = item.MST_ProcessTypes.Id,
                                       Name = item.MST_ProcessTypes.Name,
                                       Description = item.MST_ProcessTypes.Description,
                                   },
                                   Value = item.Value,
                                   Description = item.Description,
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
        /// Gets all asynchronous process result by process type id.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<MSTProcessResultDto>> GetByProcessTypeIdAsync(int processTypeId)
        {
            IEnumerable<MSTProcessResultDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = await (from item in context.MST_ProcessResult
                                     where item.IsDeleted == false &&
                                       item.ProcessTypeId == processTypeId
                                     select new MSTProcessResultDto()
                                     {
                                         Id = item.Id,
                                         ProcessTypeId = item.ProcessTypeId,
                                         ProcessType = new MSTProcessTypesDto
                                         {
                                             Id = item.MST_ProcessTypes.Id,
                                             Name = item.MST_ProcessTypes.Name,
                                             Description = item.MST_ProcessTypes.Description,
                                         },
                                         Value = item.Value,
                                         Description = item.Description,
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
        public SaveResult Update(MSTProcessResultDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var update = context.MST_ProcessResult.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.ProcessTypeId = entity.ProcessTypeId;
                    update.Value = entity.Value;
                    update.Description = entity.Description;
                    update.LastUpdatedBy = entity.LastUpdatedBy;
                    update.LastUpdate = DateTime.Now;

                    context.Entry<MST_ProcessResult>(update).State = EntityState.Modified;
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
        public async Task<SaveResult> UpdateAsync(MSTProcessResultDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var update = context.MST_ProcessResult.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.ProcessTypeId = entity.ProcessTypeId;
                    update.Value = entity.Value;
                    update.Description = entity.Description;
                    update.LastUpdatedBy = entity.LastUpdatedBy;
                    update.LastUpdate = DateTime.Now;

                    context.Entry<MST_ProcessResult>(update).State = EntityState.Modified;
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
        public SaveResult Add(MSTProcessResultDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    MST_ProcessResult add = context.MST_ProcessResult.Create();

                    add.Value = entity.Value;
                    add.ProcessTypeId = entity.ProcessTypeId;
                    add.Description = entity.Description;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry<MST_ProcessResult>(add).State = EntityState.Added;
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
        public async Task<SaveResult> AddAsync(MSTProcessResultDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    MST_ProcessResult add = context.MST_ProcessResult.Create();

                    add.ProcessTypeId = entity.ProcessTypeId;
                    add.Value = entity.Value;
                    add.Description = entity.Description;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry<MST_ProcessResult>(add).State = EntityState.Added;
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
        public SaveResult AddRange(IEnumerable<MSTProcessResultDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    foreach (var entity in entities)
                    {
                        MST_ProcessResult add = context.MST_ProcessResult.Create();

                        add.ProcessTypeId = entity.ProcessTypeId;
                        add.Value = entity.Value;
                        add.Description = entity.Description;
                        add.IsDeleted = entity.IsDeleted;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;

                        context.Entry<MST_ProcessResult>(add).State = EntityState.Added;
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
        public async Task<SaveResult> AddRangeAsync(IEnumerable<MSTProcessResultDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    foreach (var entity in entities)
                    {
                        MST_ProcessResult add = context.MST_ProcessResult.Create();

                        add.ProcessTypeId = entity.ProcessTypeId;
                        add.Value = entity.Value;
                        add.Description = entity.Description;
                        add.IsDeleted = entity.IsDeleted;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;

                        context.Entry<MST_ProcessResult>(add).State = EntityState.Added;
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
        public SaveResult Delete(MSTProcessResultDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var del = context.MST_ProcessResult.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    del.IsDeleted = true;

                    context.Entry<MST_ProcessResult>(del).State = EntityState.Modified;
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
        public async Task<SaveResult> DeleteAsync(MSTProcessResultDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var del = context.MST_ProcessResult.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    del.IsDeleted = true;

                    context.Entry<MST_ProcessResult>(del).State = EntityState.Modified;
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
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public SaveResult DeleteBy(int id)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var del = context.MST_ProcessResult.Single(x => x.Id == id && x.IsDeleted == false);
                    del.IsDeleted = true;

                    context.Entry<MST_ProcessResult>(del).State = EntityState.Modified;
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
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<SaveResult> DeleteByAsync(int id)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var del = context.MST_ProcessResult.Single(x => x.Id == id && x.IsDeleted == false);
                    del.IsDeleted = true;

                    context.Entry<MST_ProcessResult>(del).State = EntityState.Modified;
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

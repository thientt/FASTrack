using FASTrack.Model.Abstracts;
using FASTrack.Model.DTO;
using FASTrack.Model.Entities;
using FASTrack.Model.Types;
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
    public class MSTFarReportRepository : IMSTFarReportRepository
    {
        /// <summary>
        /// The _log service
        /// </summary>
        private ILogService _logService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MSTFarReportRepository"/> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public MSTFarReportRepository(ILogService logService)
        {
            this._logService = logService;
        }

        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public MSTFarReportDto Single(int id)
        {
            MSTFarReportDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = (from item in context.MST_FARReport
                              where item.IsDeleted == false && item.Id == id
                              select new MSTFarReportDto()
                              {
                                  Id = item.Id,
                                  ReportTypeId = item.ReportTypeId,
                                  OriginId = item.OriginId,
                                  Required = item.Required,
                                  ReportType = new ReportTypesDto { Id = item.MST_ReportTypes.Id, Name = item.MST_ReportTypes.Name, Description = item.MST_ReportTypes.Description },
                                  Origin = new MSTOriginDto { Id = item.MST_Origin.Id, Name = item.MST_Origin.Name, Description = item.MST_Origin.Description },
                                  Description = item.Description,
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
        public async Task<MSTFarReportDto> SingleAsync(int id)
        {
            MSTFarReportDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = await (from item in context.MST_FARReport
                                    where item.IsDeleted == false && item.Id == id
                                    select new MSTFarReportDto()
                                    {
                                        Id = item.Id,
                                        ReportTypeId = item.ReportTypeId,
                                        OriginId = item.OriginId,
                                        Required = item.Required,
                                        ReportType = new ReportTypesDto { Id = item.MST_ReportTypes.Id, Name = item.MST_ReportTypes.Name, Description = item.MST_ReportTypes.Description },
                                        Origin = new MSTOriginDto { Id = item.MST_Origin.Id, Name = item.MST_Origin.Name, Description = item.MST_Origin.Description },
                                        Description = item.Description,
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
        public IEnumerable<MSTFarReportDto> GetAll()
        {
            IEnumerable<MSTFarReportDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = (from item in context.MST_FARReport
                               where item.IsDeleted == false
                               select new MSTFarReportDto()
                               {
                                   Id = item.Id,
                                   ReportTypeId = item.ReportTypeId,
                                   OriginId = item.OriginId,
                                   Required = item.Required,
                                   ReportType = new ReportTypesDto { Id = item.MST_ReportTypes.Id, Name = item.MST_ReportTypes.Name, Description = item.MST_ReportTypes.Description },
                                   Origin = new MSTOriginDto { Id = item.MST_Origin.Id, Name = item.MST_Origin.Name, Description = item.MST_Origin.Description },
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
        public async Task<IEnumerable<MSTFarReportDto>> GetAllAsync()
        {
            IEnumerable<MSTFarReportDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = await (from item in context.MST_FARReport
                                     where item.IsDeleted == false
                                     select new MSTFarReportDto()
                                     {
                                         Id = item.Id,
                                         ReportTypeId = item.ReportTypeId,
                                         OriginId = item.OriginId,
                                         Required = item.Required,
                                         ReportType = new ReportTypesDto { Id = item.MST_ReportTypes.Id, Name = item.MST_ReportTypes.Name, Description = item.MST_ReportTypes.Description },
                                         Origin = new MSTOriginDto { Id = item.MST_Origin.Id, Name = item.MST_Origin.Name, Description = item.MST_Origin.Description },
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
        public SaveResult Update(MSTFarReportDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var report = context.MST_FARReport.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    report.OriginId = entity.OriginId;
                    report.ReportTypeId = entity.ReportTypeId;
                    report.Required = entity.Required;
                    report.Description = entity.Description;
                    report.LastUpdatedBy = entity.LastUpdatedBy;
                    report.LastUpdate = DateTime.Now;

                    context.Entry<MST_FARReport>(report).State = System.Data.Entity.EntityState.Modified;
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
        public async Task<SaveResult> UpdateAsync(MSTFarReportDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var report = context.MST_FARReport.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    report.OriginId = entity.OriginId;
                    report.ReportTypeId = entity.ReportTypeId;
                    report.Required = entity.Required;
                    report.Description = entity.Description;
                    report.LastUpdatedBy = entity.LastUpdatedBy;
                    report.LastUpdate = DateTime.Now;

                    context.Entry<MST_FARReport>(report).State = System.Data.Entity.EntityState.Modified;
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
        public SaveResult Add(MSTFarReportDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    MST_FARReport add = context.MST_FARReport.Create();

                    add.OriginId = entity.OriginId;
                    add.ReportTypeId = entity.ReportTypeId;
                    add.Required = entity.Required;
                    add.Description = entity.Description;
                    add.IsDeleted = false;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry<MST_FARReport>(add).State = System.Data.Entity.EntityState.Added;
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
        public async Task<SaveResult> AddAsync(MSTFarReportDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    MST_FARReport add = context.MST_FARReport.Create();

                    add.OriginId = entity.OriginId;
                    add.ReportTypeId = entity.ReportTypeId;
                    add.Required = entity.Required;
                    add.Description = entity.Description;
                    add.IsDeleted = false;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry<MST_FARReport>(add).State = System.Data.Entity.EntityState.Added;
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
        public SaveResult AddRange(IEnumerable<MSTFarReportDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    foreach (var entity in entities)
                    {
                        MST_FARReport add = context.MST_FARReport.Create();

                        add.OriginId = entity.OriginId;
                        add.ReportTypeId = entity.ReportTypeId;
                        add.Required = entity.Required;
                        add.Description = entity.Description;
                        add.IsDeleted = false;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;

                        context.Entry<MST_FARReport>(add).State = System.Data.Entity.EntityState.Added;
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
        public async Task<SaveResult> AddRangeAsync(IEnumerable<MSTFarReportDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    foreach (var entity in entities)
                    {
                        MST_FARReport add = context.MST_FARReport.Create();

                        add.OriginId = entity.OriginId;
                        add.ReportTypeId = entity.ReportTypeId;
                        add.Required = entity.Required;
                        add.Description = entity.Description;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;
                        context.Entry<MST_FARReport>(add).State = System.Data.Entity.EntityState.Added;
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
        public SaveResult Delete(MSTFarReportDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var report = context.MST_FARReport.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    report.IsDeleted = true;

                    context.Entry<MST_FARReport>(report).State = System.Data.Entity.EntityState.Modified;
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
        public async Task<SaveResult> DeleteAsync(MSTFarReportDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var report = context.MST_FARReport.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    report.IsDeleted = true;

                    context.Entry<MST_FARReport>(report).State = System.Data.Entity.EntityState.Modified;
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
                    var report = context.MST_FARReport.Single(x => x.Id == id && x.IsDeleted == false);
                    report.IsDeleted = true;

                    context.Entry<MST_FARReport>(report).State = System.Data.Entity.EntityState.Modified;
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
                    var report = context.MST_FARReport.Single(x => x.Id == id && x.IsDeleted == false);
                    report.IsDeleted = true;

                    context.Entry<MST_FARReport>(report).State = System.Data.Entity.EntityState.Modified;
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
        /// Gets the by.
        /// </summary>
        /// <param name="OriginId">The origin identifier.</param>
        /// <param name="ReportTypeId">The report type identifier.</param>
        /// <returns></returns>
        public MSTFarReportDto GetBy(int OriginId, ReportType reportType)
        {
            MSTFarReportDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = (from item in context.MST_FARReport
                              where item.IsDeleted == false &&
                              item.OriginId == OriginId &&
                              item.ReportTypeId == (int)reportType
                              select new MSTFarReportDto()
                              {
                                  Id = item.Id,
                                  ReportTypeId = item.ReportTypeId,
                                  OriginId = item.OriginId,
                                  Required = item.Required,
                                  ReportType = new ReportTypesDto { Id = item.MST_ReportTypes.Id, Name = item.MST_ReportTypes.Name, Description = item.MST_ReportTypes.Description },
                                  Origin = new MSTOriginDto { Id = item.MST_Origin.Id, Name = item.MST_Origin.Name, Description = item.MST_Origin.Description },
                                  Description = item.Description,
                                  LastUpdatedBy = item.LastUpdatedBy,
                                  LastUpdate = item.LastUpdate,
                              }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result = null;
                _logService.Error(ex.Message, ex);
            }
            return result;
        }
    }
}

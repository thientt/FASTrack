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
    /// <summary>
    /// 
    /// </summary>
    public class LOGProcessHistoryRepository : ILOGProcessHistoryRepository
    {
        /// <summary>
        /// The _log service
        /// </summary>
        private readonly ILogService _logService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FARHistoryRepository"/> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public LOGProcessHistoryRepository(ILogService logService)
        {
            _logService = logService;
        }

        #region Implment Single
        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public LOGProcessHistoryDto Single(int id)
        {
            LOGProcessHistoryDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = (from item in context.LOG_ProcessHistory
                              where item.Id == id
                              select new LOGProcessHistoryDto()
                              {
                                  Id = item.Id,
                                  ProcessHisId = item.ProcessHisId,
                                  FARProcessHistory = new FARProcessHistoryDto()
                                  {
                                      Id = item.FAR_ProcessHistory.Id,
                                      Analystor = item.FAR_ProcessHistory.Analystor,
                                      Comment = item.FAR_ProcessHistory.Comment,
                                      DateIn = item.FAR_ProcessHistory.DateIn,
                                      DateOut = item.FAR_ProcessHistory.DateOut,
                                      Description = item.FAR_ProcessHistory.Description,
                                      PlannedIn = item.FAR_ProcessHistory.PlannedIN,
                                      PlannedOut = item.FAR_ProcessHistory.PlannedOUT,
                                      SeqNum = item.FAR_ProcessHistory.SeqNum,
                                  },
                                  InsertedBy = item.InsertedBy,
                                  InsertedDate = item.InsertedDate,
                                  PlanFrom = item.PlanFrom,
                                  PlanTo = item.PlanTo,
                                  PlanType = (PlanType)item.PlanType,
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
        public async Task<LOGProcessHistoryDto> SingleAsync(int id)
        {
            LOGProcessHistoryDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = await (from item in context.LOG_ProcessHistory
                                    where item.Id == id
                                    select new LOGProcessHistoryDto()
                                    {
                                        Id = item.Id,
                                        ProcessHisId = item.ProcessHisId,
                                        FARProcessHistory = new FARProcessHistoryDto()
                                        {
                                            Id = item.FAR_ProcessHistory.Id,
                                            Analystor = item.FAR_ProcessHistory.Analystor,
                                            Comment = item.FAR_ProcessHistory.Comment,
                                            DateIn = item.FAR_ProcessHistory.DateIn,
                                            DateOut = item.FAR_ProcessHistory.DateOut,
                                            Description = item.FAR_ProcessHistory.Description,
                                            PlannedIn = item.FAR_ProcessHistory.PlannedIN,
                                            PlannedOut = item.FAR_ProcessHistory.PlannedOUT,
                                            SeqNum = item.FAR_ProcessHistory.SeqNum,
                                        },
                                        InsertedBy = item.InsertedBy,
                                        InsertedDate = item.InsertedDate,
                                        PlanFrom = item.PlanFrom,
                                        PlanTo = item.PlanTo,
                                        PlanType = (PlanType)item.PlanType,
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
        #endregion

        #region Implement GetAll
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LOGProcessHistoryDto> GetAll()
        {
            IEnumerable<LOGProcessHistoryDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = (from item in context.LOG_ProcessHistory
                               select new LOGProcessHistoryDto()
                               {
                                   Id = item.Id,
                                   ProcessHisId = item.ProcessHisId,
                                   FARProcessHistory = new FARProcessHistoryDto()
                                   {
                                       Id = item.FAR_ProcessHistory.Id,
                                       Analystor = item.FAR_ProcessHistory.Analystor,
                                       Comment = item.FAR_ProcessHistory.Comment,
                                       DateIn = item.FAR_ProcessHistory.DateIn,
                                       DateOut = item.FAR_ProcessHistory.DateOut,
                                       Description = item.FAR_ProcessHistory.Description,
                                       PlannedIn = item.FAR_ProcessHistory.PlannedIN,
                                       PlannedOut = item.FAR_ProcessHistory.PlannedOUT,
                                       SeqNum = item.FAR_ProcessHistory.SeqNum,
                                   },
                                   InsertedBy = item.InsertedBy,
                                   InsertedDate = item.InsertedDate,
                                   PlanFrom = item.PlanFrom,
                                   PlanTo = item.PlanTo,
                                   PlanType = (PlanType)item.PlanType,
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
        public async Task<IEnumerable<LOGProcessHistoryDto>> GetAllAsync()
        {
            IEnumerable<LOGProcessHistoryDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = await (from item in context.LOG_ProcessHistory
                                     select new LOGProcessHistoryDto()
                                     {
                                         Id = item.Id,
                                         ProcessHisId = item.ProcessHisId,
                                         FARProcessHistory = new FARProcessHistoryDto()
                                         {
                                             Id = item.FAR_ProcessHistory.Id,
                                             Analystor = item.FAR_ProcessHistory.Analystor,
                                             Comment = item.FAR_ProcessHistory.Comment,
                                             DateIn = item.FAR_ProcessHistory.DateIn,
                                             DateOut = item.FAR_ProcessHistory.DateOut,
                                             Description = item.FAR_ProcessHistory.Description,
                                             PlannedIn = item.FAR_ProcessHistory.PlannedIN,
                                             PlannedOut = item.FAR_ProcessHistory.PlannedOUT,
                                             SeqNum = item.FAR_ProcessHistory.SeqNum,
                                         },
                                         InsertedBy = item.InsertedBy,
                                         InsertedDate = item.InsertedDate,
                                         PlanFrom = item.PlanFrom,
                                         PlanTo = item.PlanTo,
                                         PlanType = (PlanType)item.PlanType,
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
        #endregion

        #region Implement Add
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public SaveResult Add(LOGProcessHistoryDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    LOG_ProcessHistory add = context.LOG_ProcessHistory.Create();

                    add.ProcessHisId = entity.ProcessHisId;
                    add.InsertedBy = entity.InsertedBy;
                    add.PlanTo = entity.PlanTo;
                    add.PlanFrom = entity.PlanFrom;
                    add.PlanType = (byte)entity.PlanType;
                    add.Description = entity.Description;
                    add.InsertedDate = DateTime.Now;

                    context.Entry<LOG_ProcessHistory>(add).State = EntityState.Added;
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
        public async Task<SaveResult> AddAsync(LOGProcessHistoryDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    LOG_ProcessHistory add = context.LOG_ProcessHistory.Create();

                    add.ProcessHisId = entity.ProcessHisId;
                    add.InsertedBy = entity.InsertedBy;
                    add.PlanTo = entity.PlanTo;
                    add.PlanFrom = entity.PlanFrom;
                    add.PlanType = (byte)entity.PlanType;
                    add.Description = entity.Description;
                    add.InsertedDate = DateTime.Now;

                    context.Entry<LOG_ProcessHistory>(add).State = EntityState.Added;
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

        public SaveResult AddRange(IEnumerable<LOGProcessHistoryDto> entities)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResult> AddRangeAsync(IEnumerable<LOGProcessHistoryDto> entities)
        {
            throw new NotImplementedException();
        }
        #endregion Add

        #region Implement Update
        public SaveResult Update(LOGProcessHistoryDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResult> UpdateAsync(LOGProcessHistoryDto entity)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Implement Delete
        public SaveResult Delete(LOGProcessHistoryDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResult> DeleteAsync(LOGProcessHistoryDto entity)
        {
            throw new NotImplementedException();
        }

        public SaveResult DeleteBy(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<SaveResult> DeleteByAsync(int Id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

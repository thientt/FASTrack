// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 11-04-2015
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 11-15-2015
// ***********************************************************************
// <copyright file="FARProcessHistoryRepository.cs" company="Atmel Corporation">
//     Copyright © Atmel Corporation 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
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
/// The Concretes namespace.
/// </summary>
namespace FASTrack.Model.Concretes
{
    /// <summary>
    /// Class FARProcessHistoryRepository.
    /// </summary>
    public class FARProcessHistoryRepository : IFARProcessHistoryRepository
    {
        /// <summary>
        /// The _log service
        /// </summary>
        private ILogService _logService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FARProcessHistoryRepository"/> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public FARProcessHistoryRepository(ILogService logService)
        {
            this._logService = logService;
        }

        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public FARProcessHistoryDto Single(int id)
        {
            FARProcessHistoryDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = (from item in context.FAR_ProcessHistory
                              where item.IsDeleted == false && item.Id == id
                              select new FARProcessHistoryDto()
                              {
                                  Id = item.Id,
                                  DeviceId = item.DeviceId,
                                  Device = new FARDeviceDetailsDto()
                                  {
                                      Id = item.FAR_DeviceDetails.Id,
                                      DateCode = item.FAR_DeviceDetails.DateCode,
                                      LastUpdate = item.FAR_DeviceDetails.LastUpdate,
                                      LastUpdatedBy = item.FAR_DeviceDetails.LastUpdatedBy,
                                      LotNo = item.FAR_DeviceDetails.LotNo,
                                      Stage = item.FAR_DeviceDetails.Stage,
                                      TechnologyId = item.FAR_DeviceDetails.TechnologyId,
                                      Master = new FARMasterDto
                                      {
                                          Id = item.FAR_DeviceDetails.FAR_Master.Id,
                                          Number = item.FAR_DeviceDetails.FAR_Master.Number
                                      }
                                  },
                                  ProcessTypeId = item.ProcessTypeId,
                                  ProcessType = new MSTProcessTypesDto()
                                  {
                                      Id = item.MST_ProcessTypes.Id,
                                      Name = item.MST_ProcessTypes.Name,
                                      Description = item.MST_ProcessTypes.Description,
                                      SeqNumber = item.MST_ProcessTypes.SeqNumber,
                                      Duration = item.MST_ProcessTypes.Duration
                                  },
                                  ProcessResultId = item.ProcessResultId,
                                  ProcessResult = new MSTProcessResultDto
                                  {
                                      Id = (item.MST_ProcessResult != null) ? item.MST_ProcessResult.Id : 0,
                                      ProcessTypeId = (item.MST_ProcessResult != null) ? item.MST_ProcessResult.ProcessTypeId : 0,
                                      Value = (item.MST_ProcessResult != null) ? item.MST_ProcessResult.Value : "",
                                      Description = (item.MST_ProcessResult != null) ? item.MST_ProcessResult.Description : "",
                                  },
                                  Description = item.Description,
                                  SeqNum = item.SeqNum,
                                  Iteration = item.Iteration,
                                  Analystor = item.Analystor,
                                  Comment = item.Comment,
                                  PlannedIn = item.PlannedIN,
                                  PlannedOut = item.PlannedOUT,
                                  DateIn = item.DateIn,
                                  DateOut = item.DateOut,
                                  IsIncluded = item.IsIncluded,
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
        public async Task<FARProcessHistoryDto> SingleAsync(int id)
        {
            FARProcessHistoryDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = await (from item in context.FAR_ProcessHistory
                                    where item.IsDeleted == false && item.Id == id
                                    select new FARProcessHistoryDto()
                                    {
                                        Id = item.Id,
                                        DeviceId = item.DeviceId,
                                        Device = new FARDeviceDetailsDto()
                                        {
                                            Id = item.FAR_DeviceDetails.Id,
                                            DateCode = item.FAR_DeviceDetails.DateCode,
                                            LastUpdate = item.FAR_DeviceDetails.LastUpdate,
                                            LastUpdatedBy = item.FAR_DeviceDetails.LastUpdatedBy,
                                            LotNo = item.FAR_DeviceDetails.LotNo,
                                            Stage = item.FAR_DeviceDetails.Stage,
                                            TechnologyId = item.FAR_DeviceDetails.TechnologyId,
                                            Master = new FARMasterDto
                                            {
                                                Id = item.FAR_DeviceDetails.FAR_Master.Id,
                                                Number = item.FAR_DeviceDetails.FAR_Master.Number
                                            }
                                        },
                                        ProcessTypeId = item.ProcessTypeId,
                                        ProcessType = new MSTProcessTypesDto()
                                        {
                                            Id = item.MST_ProcessTypes.Id,
                                            Name = item.MST_ProcessTypes.Name,
                                            Description = item.MST_ProcessTypes.Description,
                                            SeqNumber = item.MST_ProcessTypes.SeqNumber,
                                            Duration = item.MST_ProcessTypes.Duration
                                        },
                                        ProcessResultId = item.ProcessResultId,
                                        ProcessResult = new MSTProcessResultDto
                                        {
                                            Id = (item.MST_ProcessResult != null) ? item.MST_ProcessResult.Id : 0,
                                            ProcessTypeId = (item.MST_ProcessResult != null) ? item.MST_ProcessResult.ProcessTypeId : 0,
                                            Value = (item.MST_ProcessResult != null) ? item.MST_ProcessResult.Value : "",
                                            Description = (item.MST_ProcessResult != null) ? item.MST_ProcessResult.Description : "",
                                        },
                                        Description = item.Description,
                                        SeqNum = item.SeqNum,
                                        Iteration = item.Iteration,
                                        Analystor = item.Analystor,
                                        Comment = item.Comment,
                                        PlannedIn = item.PlannedIN,
                                        PlannedOut = item.PlannedOUT,
                                        DateIn = item.DateIn,
                                        DateOut = item.DateOut,
                                        IsIncluded = item.IsIncluded,
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
        public IEnumerable<FARProcessHistoryDto> GetAll()
        {
            IEnumerable<FARProcessHistoryDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = (from item in context.FAR_ProcessHistory
                               where item.IsDeleted == false
                               select new FARProcessHistoryDto()
                               {
                                   Id = item.Id,
                                   DeviceId = item.DeviceId,
                                   Device = new FARDeviceDetailsDto()
                                   {
                                       Id = item.FAR_DeviceDetails.Id,
                                       DateCode = item.FAR_DeviceDetails.DateCode,
                                       LastUpdate = item.FAR_DeviceDetails.LastUpdate,
                                       LastUpdatedBy = item.FAR_DeviceDetails.LastUpdatedBy,
                                       LotNo = item.FAR_DeviceDetails.LotNo,
                                       Stage = item.FAR_DeviceDetails.Stage,
                                       TechnologyId = item.FAR_DeviceDetails.TechnologyId,
                                       Master = new FARMasterDto { Id = item.FAR_DeviceDetails.FAR_Master.Id, Number = item.FAR_DeviceDetails.FAR_Master.Number }
                                   },
                                   ProcessTypeId = item.ProcessTypeId,
                                   ProcessType = new MSTProcessTypesDto()
                                   {
                                       Id = item.MST_ProcessTypes.Id,
                                       Name = item.MST_ProcessTypes.Name,
                                       Description = item.MST_ProcessTypes.Description,
                                       SeqNumber = item.MST_ProcessTypes.SeqNumber,
                                       Duration = item.MST_ProcessTypes.Duration
                                   },
                                   ProcessResultId = item.ProcessResultId,
                                   ProcessResult = new MSTProcessResultDto
                                   {
                                       Id = (item.MST_ProcessResult != null) ? item.MST_ProcessResult.Id : 0,
                                       ProcessTypeId = (item.MST_ProcessResult != null) ? item.MST_ProcessResult.ProcessTypeId : 0,
                                       Value = (item.MST_ProcessResult != null) ? item.MST_ProcessResult.Value : "",
                                       Description = (item.MST_ProcessResult != null) ? item.MST_ProcessResult.Description : "",
                                   },
                                   Description = item.Description,
                                   SeqNum = item.SeqNum,
                                   Iteration = item.Iteration,
                                   Analystor = item.Analystor,
                                   Comment = item.Comment,
                                   PlannedIn = item.PlannedIN,
                                   PlannedOut = item.PlannedOUT,
                                   DateIn = item.DateIn,
                                   DateOut = item.DateOut,
                                   IsIncluded = item.IsIncluded,
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
        public async Task<IEnumerable<FARProcessHistoryDto>> GetAllAsync()
        {
            IEnumerable<FARProcessHistoryDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = await (from item in context.FAR_ProcessHistory
                                     where item.IsDeleted == false
                                     select new FARProcessHistoryDto()
                                     {
                                         Id = item.Id,
                                         DeviceId = item.DeviceId,
                                         Device = new FARDeviceDetailsDto()
                                         {
                                             Id = item.FAR_DeviceDetails.Id,
                                             DateCode = item.FAR_DeviceDetails.DateCode,
                                             LastUpdate = item.FAR_DeviceDetails.LastUpdate,
                                             LastUpdatedBy = item.FAR_DeviceDetails.LastUpdatedBy,
                                             LotNo = item.FAR_DeviceDetails.LotNo,
                                             Stage = item.FAR_DeviceDetails.Stage,
                                             TechnologyId = item.FAR_DeviceDetails.TechnologyId,
                                             MasterId = item.FAR_DeviceDetails.MasterId,
                                             Master = new FARMasterDto
                                             {
                                                 Id = item.FAR_DeviceDetails.FAR_Master.Id,
                                                 Number = item.FAR_DeviceDetails.FAR_Master.Number
                                             }
                                         },
                                         ProcessTypeId = item.ProcessTypeId,
                                         ProcessType = new MSTProcessTypesDto()
                                         {
                                             Id = item.MST_ProcessTypes.Id,
                                             Name = item.MST_ProcessTypes.Name,
                                             Description = item.MST_ProcessTypes.Description,
                                             SeqNumber = item.MST_ProcessTypes.SeqNumber,
                                             Duration = item.MST_ProcessTypes.Duration
                                         },
                                         ProcessResultId = item.ProcessResultId,
                                         ProcessResult = new MSTProcessResultDto
                                         {
                                             Id = (item.MST_ProcessResult != null) ? item.MST_ProcessResult.Id : 0,
                                             ProcessTypeId = (item.MST_ProcessResult != null) ? item.MST_ProcessResult.ProcessTypeId : 0,
                                             Value = (item.MST_ProcessResult != null) ? item.MST_ProcessResult.Value : "",
                                             Description = (item.MST_ProcessResult != null) ? item.MST_ProcessResult.Description : "",
                                         },
                                         Analyst = new SYSUsersDto { },
                                         Description = item.Description,
                                         SeqNum = item.SeqNum,
                                         Iteration = item.Iteration,
                                         Analystor = item.Analystor,
                                         Comment = item.Comment,
                                         PlannedIn = item.PlannedIN,
                                         PlannedOut = item.PlannedOUT,
                                         DateIn = item.DateIn,
                                         DateOut = item.DateOut,
                                         IsIncluded = item.IsIncluded,
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
        public SaveResult Update(FARProcessHistoryDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var updated = context.FAR_ProcessHistory.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    updated.DeviceId = entity.DeviceId;
                    updated.ProcessResultId = entity.ProcessResultId;
                    updated.ProcessTypeId = entity.ProcessTypeId;
                    updated.Description = entity.Description;
                    updated.SeqNum = entity.SeqNum;
                    updated.Iteration = entity.Iteration;
                    updated.Analystor = entity.Analystor;
                    updated.Comment = entity.Comment;
                    updated.PlannedOUT = entity.PlannedOut;
                    updated.PlannedIN = entity.PlannedIn;
                    updated.DateIn = entity.DateIn;
                    updated.DateOut = entity.DateOut;
                    updated.IsIncluded = entity.IsIncluded;
                    updated.IsDeleted = entity.IsDeleted;
                    updated.LastUpdate = DateTime.Now;
                    updated.LastUpdatedBy = entity.LastUpdatedBy;

                    context.Entry<FAR_ProcessHistory>(updated).State = System.Data.Entity.EntityState.Modified;
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
        public async Task<SaveResult> UpdateAsync(FARProcessHistoryDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var update = context.FAR_ProcessHistory.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.DeviceId = entity.DeviceId;
                    update.ProcessResultId = entity.ProcessResultId;
                    update.ProcessTypeId = entity.ProcessTypeId;
                    update.Description = entity.Description;
                    update.SeqNum = entity.SeqNum;
                    update.Iteration = entity.Iteration;
                    update.Analystor = entity.Analystor;
                    update.Comment = entity.Comment;
                    update.PlannedOUT = entity.PlannedOut;
                    update.PlannedIN = entity.PlannedIn;
                    update.DateIn = entity.DateIn;
                    update.DateOut = entity.DateOut;
                    update.IsIncluded = entity.IsIncluded;
                    update.IsDeleted = entity.IsDeleted;
                    update.LastUpdate = DateTime.Now;
                    update.LastUpdatedBy = entity.LastUpdatedBy;

                    context.Entry<FAR_ProcessHistory>(update).State = System.Data.Entity.EntityState.Modified;
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
        /// Edits the process.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public SaveResult EditProcess(FARProcessHistoryDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var updated = context.FAR_ProcessHistory.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    updated.ProcessTypeId = entity.ProcessTypeId;
                    updated.Analystor = entity.Analystor;
                    updated.Comment = entity.Comment;
                    updated.LastUpdate = DateTime.Now;
                    updated.LastUpdatedBy = entity.LastUpdatedBy;

                    context.Entry<FAR_ProcessHistory>(updated).State = System.Data.Entity.EntityState.Modified;
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
        /// Removes the process.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public SaveResult RemoveProcess(int id)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var history = context.FAR_ProcessHistory.Single(x => x.Id == id && x.IsDeleted == false);

                    context.Entry<FAR_ProcessHistory>(history).State = System.Data.Entity.EntityState.Deleted;
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
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public SaveResult Add(FARProcessHistoryDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    FAR_ProcessHistory add = context.FAR_ProcessHistory.Create();

                    add.DeviceId = entity.DeviceId;
                    add.ProcessResultId = entity.ProcessResultId;
                    add.ProcessTypeId = entity.ProcessTypeId;
                    add.Description = entity.Description;
                    add.SeqNum = entity.SeqNum;
                    add.Iteration = entity.Iteration;
                    add.Analystor = entity.Analystor;
                    add.Comment = entity.Comment;
                    add.PlannedIN = entity.PlannedIn;
                    add.PlannedOUT = entity.PlannedOut;
                    add.DateIn = entity.DateIn;
                    add.DateOut = entity.DateOut;
                    add.IsIncluded = entity.IsIncluded;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdate = DateTime.Now;
                    add.LastUpdatedBy = entity.LastUpdatedBy;

                    context.Entry<FAR_ProcessHistory>(add).State = System.Data.Entity.EntityState.Added;
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
        public async Task<SaveResult> AddAsync(FARProcessHistoryDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    FAR_ProcessHistory add = context.FAR_ProcessHistory.Create();

                    add.DeviceId = entity.DeviceId;
                    add.ProcessResultId = entity.ProcessResultId;
                    add.ProcessTypeId = entity.ProcessTypeId;
                    add.Description = entity.Description;
                    add.SeqNum = entity.SeqNum;
                    add.Iteration = entity.Iteration;
                    add.Analystor = entity.Analystor;
                    add.Comment = entity.Comment;
                    add.PlannedIN = entity.PlannedIn;
                    add.PlannedOUT = entity.PlannedOut;
                    add.DateIn = entity.DateIn;
                    add.DateOut = entity.DateOut;
                    add.IsIncluded = entity.IsIncluded;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdate = DateTime.Now;
                    add.LastUpdatedBy = entity.LastUpdatedBy;

                    context.Entry<FAR_ProcessHistory>(add).State = System.Data.Entity.EntityState.Added;
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
        public SaveResult AddRange(IEnumerable<FARProcessHistoryDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    FAR_ProcessHistory add = null;
                    foreach (var entity in entities)
                    {
                        add = context.FAR_ProcessHistory.Create();

                        add.DeviceId = entity.DeviceId;
                        add.ProcessResultId = entity.ProcessResultId;
                        add.ProcessTypeId = entity.ProcessTypeId;
                        add.Description = entity.Description;
                        add.SeqNum = entity.SeqNum;
                        add.Iteration = entity.Iteration;
                        add.Analystor = entity.Analystor;
                        add.Comment = entity.Comment;
                        add.PlannedIN = entity.PlannedIn;
                        add.PlannedOUT = entity.PlannedOut;
                        add.DateIn = entity.DateIn;
                        add.DateOut = entity.DateOut;
                        add.IsIncluded = entity.IsIncluded;
                        add.IsDeleted = entity.IsDeleted;
                        add.LastUpdate = DateTime.Now;
                        add.LastUpdatedBy = entity.LastUpdatedBy;

                        context.Entry<FAR_ProcessHistory>(add).State = System.Data.Entity.EntityState.Added;
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
        public async Task<SaveResult> AddRangeAsync(IEnumerable<FARProcessHistoryDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    FAR_ProcessHistory add = null;
                    foreach (var entity in entities)
                    {
                        add = context.FAR_ProcessHistory.Create();

                        add.DeviceId = entity.DeviceId;
                        add.ProcessResultId = entity.ProcessResultId;
                        add.ProcessTypeId = entity.ProcessTypeId;
                        add.Description = entity.Description;
                        add.SeqNum = entity.SeqNum;
                        add.Iteration = entity.Iteration;
                        add.Analystor = entity.Analystor;
                        add.Comment = entity.Comment;
                        add.PlannedIN = entity.PlannedIn;
                        add.PlannedOUT = entity.PlannedOut;
                        add.DateIn = entity.DateIn;
                        add.DateOut = entity.DateOut;
                        add.IsIncluded = entity.IsIncluded;
                        add.IsDeleted = entity.IsDeleted;
                        add.LastUpdate = DateTime.Now;
                        add.LastUpdatedBy = entity.LastUpdatedBy;

                        context.Entry<FAR_ProcessHistory>(add).State = System.Data.Entity.EntityState.Added;
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
        public SaveResult Delete(FARProcessHistoryDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var history = context.FAR_ProcessHistory.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    history.IsDeleted = true;
                    history.LastUpdate = DateTime.Now;
                    history.LastUpdatedBy = entity.LastUpdatedBy;

                    context.Entry<FAR_ProcessHistory>(history).State = System.Data.Entity.EntityState.Modified;
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
        public async Task<SaveResult> DeleteAsync(FARProcessHistoryDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var history = context.FAR_ProcessHistory.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    history.IsDeleted = true;
                    history.LastUpdate = DateTime.Now;
                    history.LastUpdatedBy = entity.LastUpdatedBy;

                    context.Entry<FAR_ProcessHistory>(history).State = System.Data.Entity.EntityState.Modified;
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
                    var history = context.FAR_ProcessHistory.Single(x => x.Id == Id && x.IsDeleted == false);
                    history.IsDeleted = true;
                    history.LastUpdate = DateTime.Now;

                    context.Entry<FAR_ProcessHistory>(history).State = System.Data.Entity.EntityState.Modified;
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
                    var history = context.FAR_ProcessHistory.Single(x => x.Id == Id && x.IsDeleted == false);
                    history.IsDeleted = true;
                    history.LastUpdate = DateTime.Now;

                    context.Entry<FAR_ProcessHistory>(history).State = System.Data.Entity.EntityState.Modified;
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
        /// Includes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="isIncluded">if set to <c>true</c> [is included].</param>
        /// <returns></returns>
        public SaveResult Include(int id, bool isIncluded)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var updated = context.FAR_ProcessHistory.Single(x => x.Id == id && x.IsDeleted == false);
                    updated.IsIncluded = isIncluded;

                    context.Entry<FAR_ProcessHistory>(updated).State = System.Data.Entity.EntityState.Modified;
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
        /// Includes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="isIncluded">if set to <c>true</c> [is included].</param>
        /// <returns></returns>
        public async Task<SaveResult> IncludeAsync(int id, bool isIncluded)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var updated = context.FAR_ProcessHistory.Single(x => x.Id == id && x.IsDeleted == false);
                    updated.IsIncluded = isIncluded;

                    context.Entry<FAR_ProcessHistory>(updated).State = System.Data.Entity.EntityState.Modified;
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
        /// Checks the process flow filled.
        /// </summary>
        /// <param name="masterId">The master identifier.</param>
        /// <returns></returns>
        public bool CheckProcessFlowFilled(int masterId)
        {
            var result = false;

            using (FailureAnalysisEntities context = new FailureAnalysisEntities())
            {
                var temp = context.FAR_ProcessHistory.Where(x => x.FAR_DeviceDetails.FAR_Master.Id == masterId &&
                                x.IsIncluded &&
                                x.FAR_DeviceDetails.FAR_Master.StatusId != (int)StatusType.REPORTUPLOADED).ToList();

                if (temp.Count > 0)
                    //result = !temp.Any(x => x.DateIn == null || x.DateOut == null || (x.Analystor == String.Empty || x.Analystor == null));
                    result = !temp.Any(x => x.DateIn == null || x.DateOut == null);

            }

            return result;
        }

        /// <summary>
        /// Checks the exist process.
        /// </summary>
        /// <param name="masterId">The master identifier.</param>
        /// <returns></returns>
        public bool CheckExistProcess(int masterId)
        {
            var result = false;

            using (FailureAnalysisEntities context = new FailureAnalysisEntities())
            {
                var temp = context.FAR_ProcessHistory.Any(x => x.FAR_DeviceDetails.FAR_Master.Id == masterId &&
                                x.IsIncluded);

                result = temp;
            }

            return result;
        }

        public FARProcessHistoryDto GetMaxProcessByMaster(int masterId)
        {
            FARProcessHistoryDto result = null;

            using (FailureAnalysisEntities context = new FailureAnalysisEntities())
            {
                var temp = (from item in context.FAR_ProcessHistory
                            where item.FAR_DeviceDetails.FAR_Master.Id == masterId &&
                            item.IsIncluded
                            orderby item.LastUpdate descending
                            select new FARProcessHistoryDto
                            {
                                Id = item.Id,
                                DeviceId = item.DeviceId,
                                ProcessTypeId = item.ProcessTypeId,
                                ProcessType = new MSTProcessTypesDto()
                                {
                                    Id = item.MST_ProcessTypes.Id,
                                    Name = item.MST_ProcessTypes.Name,
                                    Description = item.MST_ProcessTypes.Description,
                                    SeqNumber = item.MST_ProcessTypes.SeqNumber,
                                    Duration = item.MST_ProcessTypes.Duration
                                },
                                Description = item.Description,
                                SeqNum = item.SeqNum,
                                Iteration = item.Iteration,
                                Analystor = item.Analystor,
                                Comment = item.Comment,
                                PlannedOut = item.PlannedOUT,
                                PlannedIn = item.PlannedIN,
                                DateIn = item.DateIn,
                                DateOut = item.DateOut,
                                IsIncluded = item.IsIncluded,
                                IsDeleted = item.IsDeleted,
                                LastUpdatedBy = item.LastUpdatedBy,
                                LastUpdate = item.LastUpdate,
                            }).FirstOrDefault();

                result = temp;
            }

            return result;
        }

        public bool CheckExistAnalyst(int masterId, string email)
        {
            bool result = false;
            using (FailureAnalysisEntities context = new FailureAnalysisEntities())
            {
                var temp = (from item in context.FAR_ProcessHistory
                            where item.FAR_DeviceDetails.FAR_Master.Id == masterId &&
                            item.IsIncluded
                            select item).
                            Any(x => x.Analystor == email);

                result = temp;
            }

            return result;
        }
    }
}

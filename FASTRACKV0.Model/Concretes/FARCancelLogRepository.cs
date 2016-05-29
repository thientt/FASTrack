using FASTrack.Model.Abstracts;
using FASTrack.Model.DTO;
using FASTrack.Model.Entities;
using FASTrack.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;

namespace FASTrack.Model.Concretes
{
    public class FARCancelLogRepository : IFARCancelLogRepository
    {
        private ILogService _logService;

        public FARCancelLogRepository(ILogService logService)
        {
            this._logService = logService;
        }

        public FARCancelLogDto Single(int id)
        {
            FARCancelLogDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = (from item in context.LOG_FARCancel
                              where item.IsDeleted == false && item.Id == id
                              select new FARCancelLogDto()
                              {
                                  Id = item.Id,
                                  MasterId = item.MasterId,
                                  StatusId = item.StatusId,
                                  ReasonId = item.ReasonId,
                                  CancelledDate = item.CancelledDate,
                                  IsDeleted = item.IsDeleted,
                                  InsertedBy = item.InsertedBy,
                                  InsertedOn = item.InsertedOn,
                                  UpdatedBy = item.UpdatedBy,
                                  UpdatedOn = item.UpdatedOn,
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

        public async Task<FARCancelLogDto> SingleAsync(int id)
        {
            FARCancelLogDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = await (from item in context.LOG_FARCancel
                                    where item.IsDeleted == false && item.Id == id
                                    select new FARCancelLogDto()
                                    {
                                        Id = item.Id,
                                        MasterId = item.MasterId,
                                        StatusId = item.StatusId,
                                        ReasonId = item.ReasonId,
                                        CancelledDate = item.CancelledDate,
                                        IsDeleted = item.IsDeleted,
                                        InsertedBy = item.InsertedBy,
                                        InsertedOn = item.InsertedOn,
                                        UpdatedBy = item.UpdatedBy,
                                        UpdatedOn = item.UpdatedOn,
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

        public IEnumerable<FARCancelLogDto> GetAll()
        {
            IEnumerable<FARCancelLogDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = (from item in context.LOG_FARCancel
                               where item.IsDeleted == false
                               select new FARCancelLogDto()
                               {
                                   Id = item.Id,
                                   MasterId = item.MasterId,
                                   StatusId = item.StatusId,
                                   ReasonId = item.ReasonId,
                                   CancelledDate = item.CancelledDate,
                                   IsDeleted = item.IsDeleted,
                                   InsertedBy = item.InsertedBy,
                                   InsertedOn = item.InsertedOn,
                                   UpdatedBy = item.UpdatedBy,
                                   UpdatedOn = item.UpdatedOn,
                               }).ToList();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
            }
            return results;
        }

        public async Task<IEnumerable<FARCancelLogDto>> GetAllAsync()
        {
            IEnumerable<FARCancelLogDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = await (from item in context.LOG_FARCancel
                                     where item.IsDeleted == false
                                     select new FARCancelLogDto()
                                     {
                                         Id = item.Id,
                                         MasterId = item.MasterId,
                                         StatusId = item.StatusId,
                                         ReasonId = item.ReasonId,
                                         CancelledDate = item.CancelledDate,
                                         IsDeleted = item.IsDeleted,
                                         InsertedBy = item.InsertedBy,
                                         InsertedOn = item.InsertedOn,
                                         UpdatedBy = item.UpdatedBy,
                                         UpdatedOn = item.UpdatedOn,
                                     }).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
            }
            return results;
        }

        public SaveResult Update(FARCancelLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.LOG_FARCancel.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    assembly.StatusId = entity.StatusId;
                    assembly.MasterId = entity.MasterId;
                    assembly.IsDeleted = entity.IsDeleted;
                    assembly.ReasonId = entity.ReasonId;
                    assembly.CancelledDate = entity.CancelledDate;
                    assembly.UpdatedBy = entity.UpdatedBy;
                    assembly.UpdatedOn = DateTime.Now;

                    context.Entry<LOG_FARCancel>(assembly).State = System.Data.Entity.EntityState.Modified;
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

        public async Task<SaveResult> UpdateAsync(FARCancelLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.LOG_FARCancel.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    assembly.Id = entity.Id;
                    assembly.MasterId = entity.MasterId;
                    assembly.StatusId = entity.StatusId;
                    assembly.IsDeleted = entity.IsDeleted;
                    assembly.ReasonId = entity.ReasonId;
                    assembly.CancelledDate = entity.CancelledDate;
                    assembly.UpdatedBy = entity.UpdatedBy;
                    assembly.UpdatedOn = DateTime.Now;

                    context.Entry<LOG_FARCancel>(assembly).State = System.Data.Entity.EntityState.Modified;
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

        public SaveResult Add(FARCancelLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    LOG_FARCancel add = context.LOG_FARCancel.Create();

                    add.StatusId = entity.StatusId;
                    add.MasterId = entity.MasterId;
                    add.IsDeleted = entity.IsDeleted;
                    add.ReasonId = entity.ReasonId;
                    add.CancelledDate = entity.CancelledDate;
                    add.InsertedBy = entity.InsertedBy;
                    add.InsertedOn = DateTime.Now;

                    context.Entry<LOG_FARCancel>(add).State = System.Data.Entity.EntityState.Added;
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

        public async Task<SaveResult> AddAsync(FARCancelLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    LOG_FARCancel add = context.LOG_FARCancel.Create();

                    add.StatusId = entity.StatusId;
                    add.MasterId = entity.MasterId;
                    add.ReasonId = entity.ReasonId;
                    add.CancelledDate = entity.CancelledDate;
                    add.IsDeleted = entity.IsDeleted;
                    add.InsertedBy = entity.InsertedBy;
                    add.InsertedOn = DateTime.Now;

                    context.Entry<LOG_FARCancel>(add).State = System.Data.Entity.EntityState.Added;
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

        public SaveResult AddRange(IEnumerable<FARCancelLogDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    LOG_FARCancel add = null;
                    foreach (var entity in entities)
                    {
                        add = context.LOG_FARCancel.Create();

                        add.StatusId = entity.StatusId;
                        add.MasterId = entity.MasterId;
                        add.IsDeleted = entity.IsDeleted;
                        add.ReasonId = entity.ReasonId;
                        add.CancelledDate = entity.CancelledDate;
                        add.InsertedBy = entity.InsertedBy;
                        add.InsertedOn = DateTime.Now;

                        context.Entry<LOG_FARCancel>(add).State = System.Data.Entity.EntityState.Added;
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

        public async Task<SaveResult> AddRangeAsync(IEnumerable<FARCancelLogDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    LOG_FARCancel add = null;
                    foreach (var entity in entities)
                    {
                        add = context.LOG_FARCancel.Create();

                        add.StatusId = entity.StatusId;
                        add.MasterId = entity.MasterId;
                        add.IsDeleted = entity.IsDeleted;
                        add.ReasonId = entity.ReasonId;
                        add.CancelledDate = entity.CancelledDate;
                        add.InsertedBy = entity.InsertedBy;
                        add.InsertedOn = DateTime.Now;

                        context.Entry<LOG_FARCancel>(add).State = System.Data.Entity.EntityState.Added;
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

        public SaveResult Delete(FARCancelLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.LOG_FARCancel.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry<LOG_FARCancel>(assembly).State = System.Data.Entity.EntityState.Modified;
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

        public async Task<SaveResult> DeleteAsync(FARCancelLogDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.LOG_FARCancel.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry<LOG_FARCancel>(assembly).State = System.Data.Entity.EntityState.Modified;
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

        public SaveResult DeleteBy(int Id)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.LOG_FARCancel.Single(x => x.Id == Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry<LOG_FARCancel>(assembly).State = System.Data.Entity.EntityState.Modified;
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

        public async Task<SaveResult> DeleteByAsync(int Id)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.LOG_FARCancel.Single(x => x.Id == Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry<LOG_FARCancel>(assembly).State = System.Data.Entity.EntityState.Modified;
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

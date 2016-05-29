using FASTrack.Model.Abstracts;
using FASTrack.Model.DTO;
using FASTrack.Model.Entities;
using FASTrack.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FASTrack.Model.Concretes
{
    /// <summary>
    /// 
    /// </summary>
    public class MSTProcessProductRepository : IMSTProcessProductRepository
    {
        /// <summary>
        /// The _log service
        /// </summary>
        private ILogService _logService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MSTProcessProductRepository"/> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public MSTProcessProductRepository(ILogService logService)
        {
            this._logService = logService;
        }

        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public MSTProcessProductDto Single(int id)
        {
            MSTProcessProductDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = (from item in context.MST_ProcessProduct
                              where item.IsDeleted == false && item.Id == id
                              select new MSTProcessProductDto()
                              {
                                  Id = item.Id,
                                  InChargePerson = item.InChargePerson,
                                  ProcessTypeId = item.ProcessTypeId,
                                  ProcessType = new MSTProcessTypesDto
                                  {
                                      Name = item.MST_ProcessTypes.Name,
                                      Description = item.MST_ProcessTypes.Description,
                                  },
                                  ProductId = item.ProductId,
                                  Product = new MSTProductDto
                                  {
                                      Name = item.MST_Product.Name,
                                      Description = item.MST_Product.Description,
                                  },
                                  Description = item.Description,
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
        public async Task<MSTProcessProductDto> SingleAsync(int id)
        {
            MSTProcessProductDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = await (from item in context.MST_ProcessProduct
                                    where item.IsDeleted == false && item.Id == id
                                    select new MSTProcessProductDto()
                                    {
                                        Id = item.Id,
                                        InChargePerson = item.InChargePerson,
                                        ProcessTypeId = item.ProcessTypeId,
                                        ProcessType = new MSTProcessTypesDto
                                        {
                                            Name = item.MST_ProcessTypes.Name,
                                            Description = item.MST_ProcessTypes.Description,
                                        },
                                        ProductId = item.ProductId,
                                        Product = new MSTProductDto
                                        {
                                            Name = item.MST_Product.Name,
                                            Description = item.MST_Product.Description,
                                        },
                                        Description = item.Description,
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
        public IEnumerable<MSTProcessProductDto> GetAll()
        {
            IEnumerable<MSTProcessProductDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = (from item in context.MST_ProcessProduct
                               where item.IsDeleted == false
                               orderby item.ProcessTypeId
                               select new MSTProcessProductDto()
                               {
                                   Id = item.Id,
                                   InChargePerson = item.InChargePerson,
                                   ProcessTypeId = item.ProcessTypeId,
                                   ProcessType = new MSTProcessTypesDto
                                   {
                                       Name = item.MST_ProcessTypes.Name,
                                       Description = item.MST_ProcessTypes.Description,
                                   },
                                   ProductId = item.ProductId,
                                   Product = new MSTProductDto
                                   {
                                       Name = item.MST_Product.Name,
                                       Description = item.MST_Product.Description,
                                   },
                                   Description = item.Description,
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
        public async Task<IEnumerable<MSTProcessProductDto>> GetAllAsync()
        {
            IEnumerable<MSTProcessProductDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = await (from item in context.MST_ProcessProduct
                                     where item.IsDeleted == false
                                     orderby item.ProcessTypeId
                                     select new MSTProcessProductDto()
                                     {
                                         Id = item.Id,
                                         InChargePerson = item.InChargePerson,
                                         ProcessTypeId = item.ProcessTypeId,
                                         ProcessType = new MSTProcessTypesDto
                                         {
                                             Name = item.MST_ProcessTypes.Name,
                                             Description = item.MST_ProcessTypes.Description,
                                         },
                                         ProductId = item.ProductId,
                                         Product = new MSTProductDto
                                         {
                                             Name = item.MST_Product.Name,
                                             Description = item.MST_Product.Description,
                                         },
                                         Description = item.Description,
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
        public SaveResult Update(MSTProcessProductDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var update = context.MST_ProcessProduct.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.InChargePerson = entity.InChargePerson;
                    update.IsDeleted = entity.IsDeleted;
                    update.Description = entity.Description;
                    update.LastUpdatedBy = entity.LastUpdatedBy;
                    update.LastUpdate = DateTime.Now;

                    context.Entry<MST_ProcessProduct>(update).State = System.Data.Entity.EntityState.Modified;
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
        public async Task<SaveResult> UpdateAsync(MSTProcessProductDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var update = context.MST_ProcessProduct.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.InChargePerson = entity.InChargePerson;
                    update.IsDeleted = entity.IsDeleted;
                    update.Description = entity.Description;
                    update.LastUpdatedBy = entity.LastUpdatedBy;
                    update.LastUpdate = DateTime.Now;

                    context.Entry<MST_ProcessProduct>(update).State = System.Data.Entity.EntityState.Modified;
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
        public SaveResult Add(MSTProcessProductDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    MST_ProcessProduct add = context.MST_ProcessProduct.Create();

                    //Check productId and ProcessTypeId exits record?
                    var checkExits = context.MST_ProcessProduct.Where(x => x.ProcessTypeId == entity.ProcessTypeId && x.ProductId == entity.ProductId).FirstOrDefault();
                    if (checkExits != null)
                    {
                        checkExits.InChargePerson = entity.InChargePerson;
                        checkExits.IsDeleted = false;
                        checkExits.LastUpdatedBy = entity.LastUpdatedBy;
                        checkExits.LastUpdate = DateTime.Now;

                        context.Entry<MST_ProcessProduct>(checkExits).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        add.Description = entity.Description;
                        add.ProductId = entity.ProductId;
                        add.ProcessTypeId = entity.ProcessTypeId;
                        add.InChargePerson = entity.InChargePerson;
                        add.IsDeleted = false;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;

                        context.Entry<MST_ProcessProduct>(add).State = System.Data.Entity.EntityState.Added;
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
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<SaveResult> AddAsync(MSTProcessProductDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    MST_ProcessProduct add = context.MST_ProcessProduct.Create();

                    //Check productId and ProcessTypeId exits record?
                    var checkExits = context.MST_ProcessProduct.Where(x => x.ProcessTypeId == entity.ProcessTypeId && x.ProductId == entity.ProductId).FirstOrDefault();
                    if (checkExits != null)
                    {
                        checkExits.InChargePerson = entity.InChargePerson;
                        checkExits.IsDeleted = false;
                        checkExits.LastUpdatedBy = entity.LastUpdatedBy;
                        checkExits.LastUpdate = DateTime.Now;

                        context.Entry<MST_ProcessProduct>(checkExits).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        add.Description = entity.Description;
                        add.ProductId = entity.ProductId;
                        add.ProcessTypeId = entity.ProcessTypeId;
                        add.InChargePerson = entity.InChargePerson;
                        add.IsDeleted = false;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;

                        context.Entry<MST_ProcessProduct>(add).State = System.Data.Entity.EntityState.Added;
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
        /// Adds the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        public SaveResult AddRange(IEnumerable<MSTProcessProductDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    MST_ProcessProduct add = null;
                    foreach (var entity in entities)
                    {
                        add = context.MST_ProcessProduct.Create();

                        add.Description = entity.Description;
                        add.ProductId = entity.ProductId;
                        add.ProcessTypeId = entity.ProcessTypeId;
                        add.InChargePerson = entity.InChargePerson;
                        add.IsDeleted = false;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;

                        context.Entry<MST_ProcessProduct>(add).State = System.Data.Entity.EntityState.Added;
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
        public async Task<SaveResult> AddRangeAsync(IEnumerable<MSTProcessProductDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    MST_ProcessProduct add = null;
                    foreach (var entity in entities)
                    {
                        add = context.MST_ProcessProduct.Create();

                        add.Description = entity.Description;
                        add.ProductId = entity.ProductId;
                        add.ProcessTypeId = entity.ProcessTypeId;
                        add.InChargePerson = entity.InChargePerson;
                        add.IsDeleted = false;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;

                        context.Entry<MST_ProcessProduct>(add).State = System.Data.Entity.EntityState.Added;
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
        public SaveResult Delete(MSTProcessProductDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.MST_ProcessProduct.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry<MST_ProcessProduct>(assembly).State = System.Data.Entity.EntityState.Modified;
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
        public async Task<SaveResult> DeleteAsync(MSTProcessProductDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.MST_ProcessProduct.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry<MST_ProcessProduct>(assembly).State = System.Data.Entity.EntityState.Modified;
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
                    var assembly = context.MST_ProcessProduct.Single(x => x.Id == Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry<MST_ProcessProduct>(assembly).State = System.Data.Entity.EntityState.Modified;
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
                    var assembly = context.MST_ProcessProduct.Single(x => x.Id == Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry<MST_ProcessProduct>(assembly).State = System.Data.Entity.EntityState.Modified;
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

        public MSTProcessProductDto FindBy(int processTypeId, int productId)
        {
            MSTProcessProductDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = (from item in context.MST_ProcessProduct
                              where item.IsDeleted == false &&
                              item.ProcessTypeId == processTypeId &&
                              item.ProductId == productId
                              select new MSTProcessProductDto()
                              {
                                  Id = item.Id,
                                  InChargePerson = item.InChargePerson,
                                  ProcessTypeId = item.ProcessTypeId,
                                  ProcessType = new MSTProcessTypesDto
                                  {
                                      Name = item.MST_ProcessTypes.Name,
                                      Description = item.MST_ProcessTypes.Description,
                                  },
                                  ProductId = item.ProductId,
                                  Product = new MSTProductDto
                                  {
                                      Name = item.MST_Product.Name,
                                      Description = item.MST_Product.Description,
                                  },
                                  Description = item.Description,
                                  IsDeleted = item.IsDeleted,
                                  LastUpdatedBy = item.LastUpdatedBy,
                                  LastUpdate = item.LastUpdate,
                              }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                return null;
            }
            return result;
        }

        public MSTProcessProductDto FindBy(int processTypeId, string productName)
        {
            MSTProcessProductDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = (from item in context.MST_ProcessProduct
                              where item.IsDeleted == false &&
                              item.ProcessTypeId == processTypeId &&
                              item.MST_Product.Name.Contains(productName)
                              select new MSTProcessProductDto()
                              {
                                  Id = item.Id,
                                  InChargePerson = item.InChargePerson,
                                  ProcessTypeId = item.ProcessTypeId,
                                  ProcessType = new MSTProcessTypesDto
                                  {
                                      Name = item.MST_ProcessTypes.Name,
                                      Description = item.MST_ProcessTypes.Description,
                                  },
                                  ProductId = item.ProductId,
                                  Product = new MSTProductDto
                                  {
                                      Name = item.MST_Product.Name,
                                      Description = item.MST_Product.Description,
                                  },
                                  Description = item.Description,
                                  IsDeleted = item.IsDeleted,
                                  LastUpdatedBy = item.LastUpdatedBy,
                                  LastUpdate = item.LastUpdate,
                              }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                return null;
            }
            return result;
        }
    }
}

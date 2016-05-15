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
    public class MSTCustomerRepository : IMSTCustomerRepository
    {
        /// <summary>
        /// The _log service
        /// </summary>
        private ILogService _logService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MSTProductRepository"/> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public MSTCustomerRepository(ILogService logService)
        {
            this._logService = logService;
        }

        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public MSTCustomerDto Single(int id)
        {
            MSTCustomerDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = (from item in context.MST_Customer
                              where item.IsDeleted == false && item.Id == id
                              select new MSTCustomerDto()
                              {
                                  Id = item.Id,
                                  CustomerName = item.CustomerName,
                                  EndCustomer = item.EndCustomer,
                                  Location = item.Location,
                                  Strategic = item.Strategic,
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
        public async Task<MSTCustomerDto> SingleAsync(int id)
        {
            MSTCustomerDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = await (from item in context.MST_Customer
                                    where item.IsDeleted == false && item.Id == id
                                    select new MSTCustomerDto()
                                    {
                                        Id = item.Id,
                                        CustomerName = item.CustomerName,
                                        EndCustomer = item.EndCustomer,
                                        Location = item.Location,
                                        Strategic = item.Strategic,
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
        public IEnumerable<MSTCustomerDto> GetAll()
        {
            IEnumerable<MSTCustomerDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = (from item in context.MST_Customer
                               where item.IsDeleted == false
                               orderby item.CustomerName
                               select new MSTCustomerDto()
                               {
                                   Id = item.Id,
                                   CustomerName = item.CustomerName,
                                   EndCustomer = item.EndCustomer,
                                   Location = item.Location,
                                   Strategic = item.Strategic,
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
        public async Task<IEnumerable<MSTCustomerDto>> GetAllAsync()
        {
            IEnumerable<MSTCustomerDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = await (from item in context.MST_Customer
                                     where item.IsDeleted == false
                                     orderby item.CustomerName
                                     select new MSTCustomerDto()
                                     {
                                         Id = item.Id,
                                         CustomerName = item.CustomerName,
                                         EndCustomer = item.EndCustomer,
                                         Location = item.Location,
                                         Strategic = item.Strategic,
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
        public SaveResult Update(MSTCustomerDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var cus = context.MST_Customer.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    cus.CustomerName = entity.CustomerName;
                    cus.EndCustomer = entity.EndCustomer;
                    cus.Location = entity.Location;
                    cus.Strategic = entity.Strategic;
                    cus.IsDeleted = entity.IsDeleted;
                    cus.LastUpdatedBy = entity.LastUpdatedBy;
                    cus.LastUpdate = DateTime.Now;

                    context.Entry<MST_Customer>(cus).State = System.Data.Entity.EntityState.Modified;
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
        public async Task<SaveResult> UpdateAsync(MSTCustomerDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var cus = context.MST_Customer.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    cus.CustomerName = entity.CustomerName;
                    cus.EndCustomer = entity.EndCustomer;
                    cus.Location = entity.Location;
                    cus.Strategic = entity.Strategic;
                    cus.IsDeleted = entity.IsDeleted;
                    cus.LastUpdatedBy = entity.LastUpdatedBy;
                    cus.LastUpdate = DateTime.Now;

                    context.Entry<MST_Customer>(cus).State = System.Data.Entity.EntityState.Modified;
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
        public SaveResult Add(MSTCustomerDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    MST_Customer add = context.MST_Customer.Create();

                    add.CustomerName = entity.CustomerName;
                    add.EndCustomer = entity.EndCustomer;
                    add.Location = entity.Location;
                    add.Strategic = entity.Strategic;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry<MST_Customer>(add).State = System.Data.Entity.EntityState.Added;
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
        public async Task<SaveResult> AddAsync(MSTCustomerDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    MST_Customer add = context.MST_Customer.Create();

                    add.CustomerName = entity.CustomerName;
                    add.EndCustomer = entity.EndCustomer;
                    add.Location = entity.Location;
                    add.Strategic = entity.Strategic;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry<MST_Customer>(add).State = System.Data.Entity.EntityState.Added;
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
        public SaveResult AddRange(IEnumerable<MSTCustomerDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    MST_Customer add = null;
                    foreach (var entity in entities)
                    {
                        add = context.MST_Customer.Create();

                        add.CustomerName = entity.CustomerName;
                        add.EndCustomer = entity.EndCustomer;
                        add.Location = entity.Location;
                        add.Strategic = entity.Strategic;
                        add.IsDeleted = entity.IsDeleted;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;

                        context.Entry<MST_Customer>(add).State = System.Data.Entity.EntityState.Added;
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
        public async Task<SaveResult> AddRangeAsync(IEnumerable<MSTCustomerDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    MST_Customer add = null;
                    foreach (var entity in entities)
                    {
                        add = context.MST_Customer.Create();

                        add.CustomerName = entity.CustomerName;
                        add.EndCustomer = entity.EndCustomer;
                        add.Location = entity.Location;
                        add.Strategic = entity.Strategic;
                        add.IsDeleted = entity.IsDeleted;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;

                        context.Entry<MST_Customer>(add).State = System.Data.Entity.EntityState.Added;
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
        public SaveResult Delete(MSTCustomerDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var cus = context.MST_Customer.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    cus.IsDeleted = true;

                    context.Entry<MST_Customer>(cus).State = System.Data.Entity.EntityState.Modified;
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
        public async Task<SaveResult> DeleteAsync(MSTCustomerDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var cus = context.MST_Customer.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    cus.IsDeleted = true;

                    context.Entry<MST_Customer>(cus).State = System.Data.Entity.EntityState.Modified;
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
                    var cus = context.MST_Customer.Single(x => x.Id == Id && x.IsDeleted == false);
                    cus.IsDeleted = true;

                    context.Entry<MST_Customer>(cus).State = System.Data.Entity.EntityState.Modified;
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
                    var cus = context.MST_Customer.Single(x => x.Id == Id && x.IsDeleted == false);
                    cus.IsDeleted = true;

                    context.Entry<MST_Customer>(cus).State = System.Data.Entity.EntityState.Modified;
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
        /// Finds the name of the by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public IEnumerable<MSTCustomerDto> FindByName(string name)
        {
            IEnumerable<MSTCustomerDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = (from item in context.MST_Customer
                               where item.IsDeleted == false && item.CustomerName.Contains(name)
                               orderby item.CustomerName
                               select new MSTCustomerDto()
                               {
                                   Id = item.Id,
                                   CustomerName = item.CustomerName,
                                   EndCustomer = item.EndCustomer,
                                   Location = item.Location,
                                   Strategic = item.Strategic,
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

        public IEnumerable<string> SearchByName(string name)
        {
            IEnumerable<string> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = (from item in context.MST_Customer
                               where item.IsDeleted == false && item.CustomerName.Contains(name)
                               orderby item.CustomerName
                               select item.CustomerName).ToList();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                return null;
            }
            return results;
        }

    }
}

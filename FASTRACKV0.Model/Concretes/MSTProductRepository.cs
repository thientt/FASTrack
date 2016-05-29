// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 11-04-2015
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 03-22-2016
// ***********************************************************************
// <copyright file="IMSTProductRepository.cs" company="Atmel Corporation">
//     Copyright © Atmel Corporation 2015
// </copyright>
// <summary></summary>
// ***********************************************************************

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
    /// Implement IMSTProductRepository interface
    /// </summary>
    public class MSTProductRepository : IMSTProductRepository
    {
        /// <summary>
        /// The _log service
        /// </summary>
        private ILogService _logService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MSTProductRepository"/> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public MSTProductRepository(ILogService logService)
        {
            this._logService = logService;
        }

        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public MSTProductDto Single(int id)
        {
            MSTProductDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = (from item in context.MST_Product
                              where item.IsDeleted == false && item.Id == id
                              select new MSTProductDto()
                              {
                                  Id = item.Id,
                                  Name = item.Name,
                                  Description = item.Description,
                                  MainPerson = item.MainPerson,
                                  SecondaryPerson = item.SecondaryPerson,
                                  TertiaryPerson = item.TertiaryPerson,
                                  LabSiteId = item.LabSiteId,
                                  LabSite = new MSTLabSiteDto
                                  {
                                      Id = item.MST_LabSite.Id,
                                      Name = item.MST_LabSite.Name
                                  },
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
        public async Task<MSTProductDto> SingleAsync(int id)
        {
            MSTProductDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = await (from item in context.MST_Product
                                    where item.IsDeleted == false && item.Id == id
                                    select new MSTProductDto()
                                    {
                                        Id = item.Id,
                                        Name = item.Name,
                                        MainPerson = item.MainPerson,
                                        SecondaryPerson = item.SecondaryPerson,
                                        TertiaryPerson = item.TertiaryPerson,
                                        Description = item.Description,
                                        LabSiteId = item.LabSiteId,
                                        LabSite = new MSTLabSiteDto
                                        {
                                            Id = item.MST_LabSite.Id,
                                            Name = item.MST_LabSite.Name
                                        },
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
        public IEnumerable<MSTProductDto> GetAll()
        {
            IEnumerable<MSTProductDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = (from item in context.MST_Product
                               where item.IsDeleted == false
                               orderby item.Name
                               select new MSTProductDto()
                               {
                                   Id = item.Id,
                                   Name = item.Name,
                                   Description = item.Description,
                                   MainPerson = item.MainPerson,
                                   SecondaryPerson = item.SecondaryPerson,
                                   TertiaryPerson = item.TertiaryPerson,
                                   LabSiteId = item.LabSiteId,
                                   LabSite = new MSTLabSiteDto
                                   {
                                       Id = item.MST_LabSite.Id,
                                       Name = item.MST_LabSite.Name
                                   },
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
        public async Task<IEnumerable<MSTProductDto>> GetAllAsync()
        {
            IEnumerable<MSTProductDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = await (from item in context.MST_Product
                                     where item.IsDeleted == false
                                     orderby item.Name
                                     select new MSTProductDto()
                                     {
                                         Id = item.Id,
                                         Name = item.Name,
                                         MainPerson = item.MainPerson,
                                         SecondaryPerson = item.SecondaryPerson,
                                         TertiaryPerson = item.TertiaryPerson,
                                         Description = item.Description,
                                         LabSiteId = item.LabSiteId,
                                         LabSite = new MSTLabSiteDto
                                         {
                                             Id = item.MST_LabSite.Id,
                                             Name = item.MST_LabSite.Name
                                         },
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
        public SaveResult Update(MSTProductDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var product = context.MST_Product.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    product.Name = entity.Name;
                    product.MainPerson = entity.MainPerson;
                    product.SecondaryPerson = entity.SecondaryPerson;
                    product.TertiaryPerson = entity.TertiaryPerson;
                    product.LabSiteId = entity.LabSiteId;
                    product.IsDeleted = entity.IsDeleted;
                    product.Description = entity.Description;
                    product.LastUpdatedBy = entity.LastUpdatedBy;
                    product.LastUpdate = DateTime.Now;

                    context.Entry<MST_Product>(product).State = System.Data.Entity.EntityState.Modified;
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
        public async Task<SaveResult> UpdateAsync(MSTProductDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var product = context.MST_Product.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    product.Name = entity.Name;
                    product.MainPerson = entity.MainPerson;
                    product.SecondaryPerson = entity.SecondaryPerson;
                    product.TertiaryPerson = entity.TertiaryPerson;
                    product.LabSiteId = entity.LabSiteId;
                    product.IsDeleted = entity.IsDeleted;
                    product.Description = entity.Description;
                    product.LastUpdatedBy = entity.LastUpdatedBy;
                    product.LastUpdate = DateTime.Now;

                    context.Entry<MST_Product>(product).State = System.Data.Entity.EntityState.Modified;
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
        public SaveResult Add(MSTProductDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    MST_Product add = context.MST_Product.Create();

                    add.Description = entity.Description;
                    add.MainPerson = entity.MainPerson;
                    add.SecondaryPerson = entity.SecondaryPerson;
                    add.TertiaryPerson = entity.TertiaryPerson;
                    add.LabSiteId = entity.LabSiteId;
                    add.IsDeleted = false;
                    add.Name = entity.Name;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry<MST_Product>(add).State = System.Data.Entity.EntityState.Added;
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
        public async Task<SaveResult> AddAsync(MSTProductDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    MST_Product add = context.MST_Product.Create();

                    add.Description = entity.Description;
                    add.MainPerson = entity.MainPerson;
                    add.SecondaryPerson = entity.SecondaryPerson;
                    add.TertiaryPerson = entity.TertiaryPerson;
                    add.LabSiteId = entity.LabSiteId;
                    add.Name = entity.Name;
                    add.IsDeleted = false;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry<MST_Product>(add).State = System.Data.Entity.EntityState.Added;
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
        public SaveResult AddRange(IEnumerable<MSTProductDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    MST_Product add = null;
                    foreach (var entity in entities)
                    {
                        add = context.MST_Product.Create();

                        add.MainPerson = entity.MainPerson;
                        add.SecondaryPerson = entity.SecondaryPerson;
                        add.TertiaryPerson = entity.TertiaryPerson;
                        add.Description = entity.Description;
                        add.LabSiteId = entity.LabSiteId;
                        add.IsDeleted = false;
                        add.Name = entity.Name;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;

                        context.Entry<MST_Product>(add).State = System.Data.Entity.EntityState.Added;
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
        public async Task<SaveResult> AddRangeAsync(IEnumerable<MSTProductDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    MST_Product add = null;
                    foreach (var entity in entities)
                    {
                        add = context.MST_Product.Create();

                        add.MainPerson = entity.MainPerson;
                        add.SecondaryPerson = entity.SecondaryPerson;
                        add.TertiaryPerson = entity.TertiaryPerson;
                        add.Description = entity.Description;
                        add.LabSiteId = entity.LabSiteId;
                        add.IsDeleted = false;
                        add.Name = entity.Name;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;

                        context.Entry<MST_Product>(add).State = System.Data.Entity.EntityState.Added;
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
        public SaveResult Delete(MSTProductDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.MST_Product.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry<MST_Product>(assembly).State = System.Data.Entity.EntityState.Modified;
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
        public async Task<SaveResult> DeleteAsync(MSTProductDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var assembly = context.MST_Product.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry<MST_Product>(assembly).State = System.Data.Entity.EntityState.Modified;
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
                    var assembly = context.MST_Product.Single(x => x.Id == Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry<MST_Product>(assembly).State = System.Data.Entity.EntityState.Modified;
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
                    var assembly = context.MST_Product.Single(x => x.Id == Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry<MST_Product>(assembly).State = System.Data.Entity.EntityState.Modified;
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
        /// Finds all product name with name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Return list product such containing name value</returns>
        public IEnumerable<MSTProductDto> FindByName(string name)
        {
            IEnumerable<MSTProductDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = (from item in context.MST_Product
                               where item.IsDeleted == false && item.Name.Contains(name)
                               orderby item.Name
                               select new MSTProductDto()
                               {
                                   Id = item.Id,
                                   Name = item.Name,
                                   Description = item.Description,
                                   MainPerson = item.MainPerson,
                                   TertiaryPerson = item.TertiaryPerson,
                                   SecondaryPerson = item.SecondaryPerson,
                                   LabSiteId = item.LabSiteId,
                                   LabSite = new MSTLabSiteDto
                                   {
                                       Id = item.MST_LabSite.Id,
                                       Name = item.MST_LabSite.Name
                                   },
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
        /// Find any name such containing name from parammter
        /// </summary>
        /// <param name="name">Name value of product</param>
        /// <returns>Returns list names of product consider with name value</returns>
        public IEnumerable<string> GetAnyName(string name)
        {
            IEnumerable<string> results = null;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = (from item in context.MST_Product
                               where item.IsDeleted == false && item.Name.Contains(name)
                               orderby item.Name
                               select item.Name).ToList();
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
        /// Finds all product name with name and LabSiteID
        /// </summary>
        /// <param name="name">Nam value of product</param>
        /// <param name="labSiteId">Primary key of LabSite table</param>
        /// <returns></returns>
        public IEnumerable<MSTProductDto> FindByNameAndLabSite(string name, int labSiteId)
        {
            IEnumerable<MSTProductDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = (from item in context.MST_Product
                               where item.IsDeleted == false &&
                               item.LabSiteId == labSiteId &&
                               item.Name.Contains(name)
                               orderby item.Name
                               select new MSTProductDto()
                               {
                                   Id = item.Id,
                                   Name = item.Name,
                                   Description = item.Description,
                                   MainPerson = item.MainPerson,
                                   TertiaryPerson = item.TertiaryPerson,
                                   SecondaryPerson = item.SecondaryPerson,
                                   LabSiteId = item.LabSiteId,
                                   LabSite = new MSTLabSiteDto
                                   {
                                       Id = item.MST_LabSite.Id,
                                       Name = item.MST_LabSite.Name
                                   },
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
    }
}

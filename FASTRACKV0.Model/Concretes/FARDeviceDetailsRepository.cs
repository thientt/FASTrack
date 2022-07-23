// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 10-06-2015
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 23-07-2022
// ***********************************************************************
// <copyright file="FARDeviceDetailsRepository.cs" company="Atmel Corporation">
//     Copyright © Atmel 2015
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

/// <summary>
/// 
/// </summary>
namespace FASTrack.Model.Concretes
{
    /// <summary>
    /// 
    /// </summary>
    public class FARDeviceDetailsRepository : IFARDeviceDetailsRepository
    {
        /// <summary>
        /// The _log service
        /// </summary>
        private readonly ILogService _logService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FARDeviceDetailsRepository"/> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public FARDeviceDetailsRepository(ILogService logService)
        {
            _logService = logService;
        }

        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public FARDeviceDetailsDto Single(int id)
        {
            FARDeviceDetailsDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = (from item in context.FAR_DeviceDetails
                              where item.IsDeleted == false && item.Id == id
                              select new FARDeviceDetailsDto()
                              {
                                  Id = item.Id,
                                  MasterId = item.MasterId,
                                  Master = new FARMasterDto()
                                  {
                                      Id = item.FAR_Master.Id,
                                      Number = item.FAR_Master.Number,
                                      Analyst = item.FAR_Master.Analyst,
                                      Requestor = item.FAR_Master.Requestor,
                                      RefNo = item.FAR_Master.RefNo,
                                      StatusId = item.FAR_Master.StatusId,
                                      Product = item.FAR_Master.Product,
                                      Customer = item.FAR_Master.Customer,
                                      FailureRate = item.FAR_Master.FailureRate,
                                      RequestDate = item.FAR_Master.RequestDate,
                                      FailureDesc = item.FAR_Master.FailureDesc,
                                  },
                                  FailureDetail = item.FailureDetail,
                                  WaferNo = item.WaferNo,
                                  SerialNo = item.SerialNo,
                                  LotNo = item.LotNo,
                                  MfgPartNo = item.MfgPartNo,
                                  TechnologyId = item.TechnologyId,
                                  Technogoly = new MSTTechnogolyDto() { Id = item.MST_Technology.Id, Name = item.MST_Technology.Name, Description = item.MST_Technology.Description, },
                                  PackageTypeId = item.PackageTypeId,
                                  PackageType = new MSTPackageTypesDto() { Id = item.MST_PackageTypes.Id, Name = item.MST_PackageTypes.Name, Description = item.MST_PackageTypes.Description, },
                                  AssemblySiteId = item.AssembliesSiteId,
                                  AssemblySites = new MSTAssemblySiteDto() { Id = item.MST_AssemblySites.Id, Name = item.MST_AssemblySites.Code, Description = item.MST_AssemblySites.Description, },
                                  FabSiteId = item.FabSiteId,
                                  FabSite = new FabSiteDto() { Id = item.FabSites.Id, Name = item.FabSites.Name, Description = item.FabSites.Description, },
                                  ServiceId = item.ServiceId,
                                  FARServices = new MSTServiceDto() { Id = item.MST_Services.Id, Name = item.MST_Services.Name, Description = item.MST_Services.Description },
                                  DateCode = item.DateCode,
                                  Quantity = item.Quantity,
                                  Stage = item.Stage,
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
        public async Task<FARDeviceDetailsDto> SingleAsync(int id)
        {
            FARDeviceDetailsDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = await (from item in context.FAR_DeviceDetails
                                    where item.IsDeleted == false && item.Id == id
                                    select new FARDeviceDetailsDto()
                                    {
                                        Id = item.Id,
                                        MasterId = item.MasterId,
                                        Master = new FARMasterDto() { Id = item.FAR_Master.Id, Number = item.FAR_Master.Number, Analyst = item.FAR_Master.Analyst, Requestor = item.FAR_Master.Requestor, RefNo = item.FAR_Master.RefNo, StatusId = item.FAR_Master.StatusId },
                                        WaferNo = item.WaferNo,
                                        SerialNo = item.SerialNo,
                                        LotNo = item.LotNo,
                                        MfgPartNo = item.MfgPartNo,
                                        TechnologyId = item.TechnologyId,
                                        Technogoly = new MSTTechnogolyDto() { Id = item.MST_Technology.Id, Name = item.MST_Technology.Name, Description = item.MST_Technology.Description, },
                                        PackageTypeId = item.PackageTypeId,
                                        PackageType = new MSTPackageTypesDto() { Id = item.MST_PackageTypes.Id, Name = item.MST_PackageTypes.Name, Description = item.MST_PackageTypes.Description, },
                                        AssemblySiteId = item.AssembliesSiteId,
                                        AssemblySites = new MSTAssemblySiteDto() { Id = item.MST_AssemblySites.Id, Name = item.MST_AssemblySites.Code, Description = item.MST_AssemblySites.Description, },
                                        FabSiteId = item.FabSiteId,
                                        FabSite = new FabSiteDto() { Id = item.FabSites.Id, Name = item.FabSites.Name, Description = item.FabSites.Description, },
                                        ServiceId = item.ServiceId,
                                        FARServices = new MSTServiceDto() { Id = item.MST_Services.Id, Name = item.MST_Services.Name, Description = item.MST_Services.Description },
                                        DateCode = item.DateCode,
                                        Quantity = item.Quantity,
                                        Stage = item.Stage,
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
        public IEnumerable<FARDeviceDetailsDto> GetAll()
        {
            IEnumerable<FARDeviceDetailsDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = (from item in context.FAR_DeviceDetails
                               where item.IsDeleted == false
                               select new FARDeviceDetailsDto()
                               {
                                   Id = item.Id,
                                   MasterId = item.MasterId,
                                   Master = new FARMasterDto() { Id = item.FAR_Master.Id, Number = item.FAR_Master.Number, Analyst = item.FAR_Master.Analyst, Requestor = item.FAR_Master.Requestor, RefNo = item.FAR_Master.RefNo },
                                   WaferNo = item.WaferNo,
                                   SerialNo = item.SerialNo,
                                   LotNo = item.LotNo,
                                   MfgPartNo = item.MfgPartNo,
                                   TechnologyId = item.TechnologyId,
                                   Technogoly = new MSTTechnogolyDto() { Id = item.MST_Technology.Id, Name = item.MST_Technology.Name, Description = item.MST_Technology.Description, },
                                   PackageTypeId = item.PackageTypeId,
                                   PackageType = new MSTPackageTypesDto() { Id = item.MST_PackageTypes.Id, Name = item.MST_PackageTypes.Name, Description = item.MST_PackageTypes.Description, },
                                   AssemblySiteId = item.AssembliesSiteId,
                                   AssemblySites = new MSTAssemblySiteDto() { Id = item.MST_AssemblySites.Id, Name = item.MST_AssemblySites.Code, Description = item.MST_AssemblySites.Description, },
                                   FabSiteId = item.FabSiteId,
                                   FabSite = new FabSiteDto() { Id = item.FabSites.Id, Name = item.FabSites.Name, Description = item.FabSites.Description, },
                                   ServiceId = item.ServiceId,
                                   FARServices = new MSTServiceDto() { Id = item.MST_Services.Id, Name = item.MST_Services.Name, Description = item.MST_Services.Description },
                                   DateCode = item.DateCode,
                                   Quantity = item.Quantity,
                                   Stage = item.Stage,
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
        public async Task<IEnumerable<FARDeviceDetailsDto>> GetAllAsync()
        {
            IEnumerable<FARDeviceDetailsDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = await (from item in context.FAR_DeviceDetails
                                     where item.IsDeleted == false
                                     select new FARDeviceDetailsDto()
                                     {
                                         Id = item.Id,
                                         MasterId = item.MasterId,
                                         Master = new FARMasterDto() { Id = item.FAR_Master.Id, Number = item.FAR_Master.Number, Analyst = item.FAR_Master.Analyst, Requestor = item.FAR_Master.Requestor, RefNo = item.FAR_Master.RefNo },
                                         WaferNo = item.WaferNo,
                                         SerialNo = item.SerialNo,
                                         LotNo = item.LotNo,
                                         MfgPartNo = item.MfgPartNo,
                                         TechnologyId = item.TechnologyId,
                                         Technogoly = new MSTTechnogolyDto() { Id = item.MST_Technology.Id, Name = item.MST_Technology.Name, Description = item.MST_Technology.Description, },
                                         PackageTypeId = item.PackageTypeId,
                                         PackageType = new MSTPackageTypesDto() { Id = item.MST_PackageTypes.Id, Name = item.MST_PackageTypes.Name, Description = item.MST_PackageTypes.Description, },
                                         AssemblySiteId = item.AssembliesSiteId,
                                         AssemblySites = new MSTAssemblySiteDto() { Id = item.MST_AssemblySites.Id, Name = item.MST_AssemblySites.Code, Description = item.MST_AssemblySites.Description, },
                                         FabSiteId = item.FabSiteId,
                                         FabSite = new FabSiteDto() { Id = item.FabSites.Id, Name = item.FabSites.Name, Description = item.FabSites.Description, },
                                         ServiceId = item.ServiceId,
                                         FARServices = new MSTServiceDto() { Id = item.MST_Services.Id, Name = item.MST_Services.Name, Description = item.MST_Services.Description },
                                         DateCode = item.DateCode,
                                         Quantity = item.Quantity,
                                         Stage = item.Stage,
                                         IsDeleted = item.IsDeleted,
                                         LastUpdatedBy = item.LastUpdatedBy,
                                         LastUpdate = item.LastUpdate
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
        public SaveResult Update(FARDeviceDetailsDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var device = context.FAR_DeviceDetails.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    device.MasterId = entity.MasterId;
                    device.ServiceId = entity.ServiceId;
                    device.WaferNo = entity.WaferNo;
                    device.SerialNo = entity.SerialNo;
                    device.LotNo = entity.LotNo;
                    device.MfgPartNo = entity.MfgPartNo;
                    device.TechnologyId = entity.TechnologyId;
                    device.PackageTypeId = entity.PackageTypeId;
                    device.AssembliesSiteId = entity.AssemblySiteId;
                    device.FabSiteId = entity.FabSiteId;
                    device.DateCode = entity.DateCode;
                    device.Quantity = entity.Quantity;
                    device.Stage = entity.Stage;
                    device.IsDeleted = entity.IsDeleted;
                    device.LastUpdatedBy = entity.LastUpdatedBy;
                    device.LastUpdate = DateTime.Now;

                    context.Entry(device).State = EntityState.Modified;
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
        public async Task<SaveResult> UpdateAsync(FARDeviceDetailsDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var device = context.FAR_DeviceDetails.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    device.MasterId = entity.MasterId;
                    device.ServiceId = entity.ServiceId;
                    device.WaferNo = entity.WaferNo;
                    device.SerialNo = entity.SerialNo;
                    device.LotNo = entity.LotNo;
                    device.MfgPartNo = entity.MfgPartNo;
                    device.TechnologyId = entity.TechnologyId;
                    device.PackageTypeId = entity.PackageTypeId;
                    device.AssembliesSiteId = entity.AssemblySiteId;
                    device.FabSiteId = entity.FabSiteId;
                    device.DateCode = entity.DateCode;
                    device.Quantity = entity.Quantity;
                    device.Stage = entity.Stage;
                    device.IsDeleted = entity.IsDeleted;
                    device.LastUpdatedBy = entity.LastUpdatedBy;
                    device.LastUpdate = DateTime.Now;

                    context.Entry(device).State = EntityState.Modified;
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
        public SaveResult Add(FARDeviceDetailsDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    FAR_DeviceDetails add = context.FAR_DeviceDetails.Create();

                    add.MasterId = entity.MasterId;
                    add.ServiceId = entity.ServiceId;
                    add.WaferNo = entity.WaferNo;
                    add.SerialNo = entity.SerialNo;
                    add.LotNo = entity.LotNo;
                    add.MfgPartNo = entity.MfgPartNo;
                    add.TechnologyId = entity.TechnologyId;
                    add.PackageTypeId = entity.PackageTypeId;
                    add.AssembliesSiteId = entity.AssemblySiteId;
                    add.FabSiteId = entity.FabSiteId;
                    add.DateCode = entity.DateCode;
                    add.Quantity = entity.Quantity;
                    add.Stage = entity.Stage;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;
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
        public FARDeviceDetailsDto AddDevice(FARDeviceDetailsDto entity)
        {
            FARDeviceDetailsDto result = entity;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    FAR_DeviceDetails add = context.FAR_DeviceDetails.Create();

                    add.MasterId = entity.MasterId;
                    add.ServiceId = entity.ServiceId;
                    add.WaferNo = entity.WaferNo;
                    add.SerialNo = entity.SerialNo;
                    add.LotNo = entity.LotNo;
                    add.MfgPartNo = entity.MfgPartNo;
                    add.TechnologyId = entity.TechnologyId;
                    add.PackageTypeId = entity.PackageTypeId;
                    add.AssembliesSiteId = entity.AssemblySiteId;
                    add.FabSiteId = entity.FabSiteId;
                    add.DateCode = entity.DateCode;
                    add.Quantity = entity.Quantity;
                    add.Stage = entity.Stage;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;
                    context.SaveChanges();

                    result.Id = add.Id;
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
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<SaveResult> AddAsync(FARDeviceDetailsDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    FAR_DeviceDetails add = context.FAR_DeviceDetails.Create();

                    add.MasterId = entity.MasterId;
                    add.ServiceId = entity.ServiceId;
                    add.WaferNo = entity.WaferNo;
                    add.SerialNo = entity.SerialNo;
                    add.LotNo = entity.LotNo;
                    add.MfgPartNo = entity.MfgPartNo;
                    add.TechnologyId = entity.TechnologyId;
                    add.PackageTypeId = entity.PackageTypeId;
                    add.AssembliesSiteId = entity.AssemblySiteId;
                    add.FabSiteId = entity.FabSiteId;
                    add.DateCode = entity.DateCode;
                    add.Quantity = entity.Quantity;
                    add.Stage = entity.Stage;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;
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

        public async Task<FARDeviceDetailsDto> AddDeviceAsync(FARDeviceDetailsDto entity)
        {
            FARDeviceDetailsDto result = entity;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    FAR_DeviceDetails add = context.FAR_DeviceDetails.Create();

                    add.MasterId = entity.MasterId;
                    add.ServiceId = entity.ServiceId;
                    add.WaferNo = entity.WaferNo;
                    add.SerialNo = entity.SerialNo;
                    add.LotNo = entity.LotNo;
                    add.MfgPartNo = entity.MfgPartNo;
                    add.TechnologyId = entity.TechnologyId;
                    add.PackageTypeId = entity.PackageTypeId;
                    add.AssembliesSiteId = entity.AssemblySiteId;
                    add.FabSiteId = entity.FabSiteId;
                    add.DateCode = entity.DateCode;
                    add.Quantity = entity.Quantity;
                    add.Stage = entity.Stage;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;
                    await context.SaveChangesAsync();

                    result.Id = add.Id;
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
        /// Adds the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        public SaveResult AddRange(IEnumerable<FARDeviceDetailsDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    FAR_DeviceDetails add = null;
                    foreach (var entity in entities)
                    {
                        add = context.FAR_DeviceDetails.Create();

                        add.MasterId = entity.MasterId;
                        add.ServiceId = entity.ServiceId;
                        add.WaferNo = entity.WaferNo;
                        add.SerialNo = entity.SerialNo;
                        add.LotNo = entity.LotNo;
                        add.MfgPartNo = entity.MfgPartNo;
                        add.TechnologyId = entity.TechnologyId;
                        add.PackageTypeId = entity.PackageTypeId;
                        add.AssembliesSiteId = entity.AssemblySiteId;
                        add.FabSiteId = entity.FabSiteId;
                        add.DateCode = entity.DateCode;
                        add.Quantity = entity.Quantity;
                        add.Stage = entity.Stage;
                        add.IsDeleted = entity.IsDeleted;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;
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
        public async Task<SaveResult> AddRangeAsync(IEnumerable<FARDeviceDetailsDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    FAR_DeviceDetails add = null;
                    foreach (var entity in entities)
                    {
                        add = context.FAR_DeviceDetails.Create();

                        add.MasterId = entity.MasterId;
                        add.ServiceId = entity.ServiceId;
                        add.WaferNo = entity.WaferNo;
                        add.SerialNo = entity.SerialNo;
                        add.LotNo = entity.LotNo;
                        add.MfgPartNo = entity.MfgPartNo;
                        add.TechnologyId = entity.TechnologyId;
                        add.PackageTypeId = entity.PackageTypeId;
                        add.AssembliesSiteId = entity.AssemblySiteId;
                        add.FabSiteId = entity.FabSiteId;
                        add.DateCode = entity.DateCode;
                        add.Quantity = entity.Quantity;
                        add.Stage = entity.Stage;
                        add.IsDeleted = entity.IsDeleted;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;
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
        public SaveResult Delete(FARDeviceDetailsDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var device = context.FAR_DeviceDetails.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    device.IsDeleted = true;
                    device.LastUpdate = DateTime.Now;
                    device.LastUpdatedBy = entity.LastUpdatedBy;

                    context.Entry(device).State = EntityState.Modified;
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
        public async Task<SaveResult> DeleteAsync(FARDeviceDetailsDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var device = context.FAR_DeviceDetails.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    device.IsDeleted = true;
                    device.LastUpdate = DateTime.Now;
                    device.LastUpdatedBy = entity.LastUpdatedBy;

                    context.Entry(device).State = EntityState.Modified;
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
                    var device = context.FAR_DeviceDetails.Single(x => x.Id == Id && x.IsDeleted == false);
                    device.IsDeleted = true;
                    device.LastUpdate = DateTime.Now;

                    context.Entry(device).State = EntityState.Modified;
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
                    var device = context.FAR_DeviceDetails.Single(x => x.Id == Id && x.IsDeleted == false);
                    device.IsDeleted = true;
                    device.LastUpdate = DateTime.Now;

                    context.Entry(device).State = EntityState.Modified;
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
        /// Finds all device the by Master.
        /// </summary>
        /// <param name="idMaster">The identifier master.</param>
        /// <returns></returns>
        public IEnumerable<FARDeviceDetailsDto> FindBy(int idMaster)
        {
            IEnumerable<FARDeviceDetailsDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = (from item in context.FAR_DeviceDetails
                               where item.IsDeleted == false && item.MasterId == idMaster
                               select new FARDeviceDetailsDto()
                               {
                                   Id = item.Id,
                                   MasterId = item.MasterId,
                                   Master = new FARMasterDto() { Id = item.FAR_Master.Id, Analyst = item.FAR_Master.Analyst, Requestor = item.FAR_Master.Requestor, RefNo = item.FAR_Master.RefNo },
                                   LotNo = item.LotNo,
                                   MfgPartNo = item.MfgPartNo,
                                   TechnologyId = item.TechnologyId,
                                   Technogoly = new MSTTechnogolyDto() { Id = item.MST_Technology.Id, Name = item.MST_Technology.Name, Description = item.MST_Technology.Description, },
                                   PackageType = new MSTPackageTypesDto() { Id = item.MST_PackageTypes.Id, Name = item.MST_PackageTypes.Name, Description = item.MST_PackageTypes.Description, },
                                   AssemblySites = new MSTAssemblySiteDto() { Id = item.MST_AssemblySites.Id, Name = item.MST_AssemblySites.Code, Description = item.MST_AssemblySites.Description, },
                                   FabSite = new FabSiteDto() { Id = item.FabSites.Id, Name = item.FabSites.Name, Description = item.FabSites.Description, },
                                   ServiceId = item.ServiceId,
                                   FARServices = new MSTServiceDto { Id = item.ServiceId, Name = item.MST_Services.Name, Description = item.MST_Services.Description },
                                   MechanismId = item.MechanismId,
                                   Mechanism = new FARMechanismDto()
                                   {
                                       Id = item.FAR_Mechanism != null ? item.FAR_Mechanism.Id : 0,
                                       Name = item.FAR_Mechanism != null ? item.FAR_Mechanism.Name : "",
                                       Description = item.FAR_Mechanism != null ? item.FAR_Mechanism.Description : ""
                                   },
                                   FailureDetail = item.FailureDetail,
                                   DateCode = item.DateCode,
                                   Quantity = item.Quantity,
                                   Stage = item.Stage,
                                   IsDeleted = item.IsDeleted,
                                   LastUpdatedBy = item.LastUpdatedBy,
                                   LastUpdate = item.LastUpdate,
                               }).ToList();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                results = null;
            }
            return results;
        }

        /// <summary>
        /// Finds the by asynchronous.
        /// </summary>
        /// <param name="idMaster">The identifier master.</param>
        /// <returns></returns>
        public async Task<IEnumerable<FARDeviceDetailsDto>> FindByAsync(int idMaster)
        {
            IEnumerable<FARDeviceDetailsDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = await (from item in context.FAR_DeviceDetails
                                     where item.IsDeleted == false && item.MasterId == idMaster
                                     select new FARDeviceDetailsDto()
                                     {
                                         Id = item.Id,
                                         MasterId = item.MasterId,
                                         Master = new FARMasterDto() { Id = item.FAR_Master.Id, Analyst = item.FAR_Master.Analyst, Requestor = item.FAR_Master.Requestor, RefNo = item.FAR_Master.RefNo },
                                         WaferNo = item.WaferNo,
                                         SerialNo = item.SerialNo,
                                         LotNo = item.LotNo,
                                         MfgPartNo = item.MfgPartNo,
                                         TechnologyId = item.TechnologyId,
                                         Technogoly = new MSTTechnogolyDto() { Id = item.MST_Technology.Id, Name = item.MST_Technology.Name, Description = item.MST_Technology.Description, },
                                         PackageType = new MSTPackageTypesDto() { Id = item.MST_PackageTypes.Id, Name = item.MST_PackageTypes.Name, Description = item.MST_PackageTypes.Description, },
                                         AssemblySites = new MSTAssemblySiteDto() { Id = item.MST_AssemblySites.Id, Name = item.MST_AssemblySites.Code, Description = item.MST_AssemblySites.Description, },
                                         FabSite = new FabSiteDto() { Id = item.FabSites.Id, Name = item.FabSites.Name, Description = item.FabSites.Description, },
                                         ServiceId = item.ServiceId,
                                         FARServices = new MSTServiceDto() { Id = item.MST_Services.Id, Name = item.MST_Services.Name, Description = item.MST_Services.Description },
                                         DateCode = item.DateCode,
                                         Quantity = item.Quantity,
                                         Stage = item.Stage,
                                         MechanismId = item.MechanismId,
                                         Mechanism = new FARMechanismDto()
                                         {
                                             Id = item.FAR_Mechanism != null ? item.FAR_Mechanism.Id : 0,
                                             Name = item.FAR_Mechanism != null ? item.FAR_Mechanism.Name : "",
                                             Description = item.FAR_Mechanism != null ? item.FAR_Mechanism.Description : ""
                                         },
                                         FailureDetail = item.FailureDetail,
                                         IsDeleted = item.IsDeleted,
                                         LastUpdatedBy = item.LastUpdatedBy,
                                         LastUpdate = item.LastUpdate,
                                     }).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                results = null;
            }
            return results;
        }

        /// <summary>
        /// Updates the failure mechanism.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public SaveResult UpdateFailureMechanism(FARDeviceDetailsDto entity, string userName)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var device = context.FAR_DeviceDetails.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    device.MechanismId = entity.MechanismId;
                    device.FailureDetail = entity.FailureDetail;
                    device.LastUpdatedBy = userName;
                    device.LastUpdate = DateTime.Now;

                    context.Entry(device).State = EntityState.Modified;
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
        /// Gets the failure mechanism.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public FARDeviceDetailsDto GetFailureMechanism(int id)
        {
            FARDeviceDetailsDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = (from item in context.FAR_DeviceDetails
                              where item.IsDeleted == false && item.Id == id
                              select new FARDeviceDetailsDto()
                              {
                                  Id = item.Id,
                                  MechanismId = item.MechanismId,
                                  FailureDetail = item.FailureDetail,
                                  Mechanism = new FARMechanismDto
                                  {
                                      Id = item.FAR_Mechanism.Id,
                                      Name = item.FAR_Mechanism.Name,
                                  }
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
    }
}

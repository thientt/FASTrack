// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 02-25-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 05-16-2016
// ***********************************************************************
// <copyright file="FARMasterRepository.cs" company="Atmel">
//     Copyright © Atmel 2016
// </copyright>
// <summary></summary>
// **********************************************************************

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
    public class FARMasterRepository : IFARMasterRepository
    {
        /// <summary>
        /// The _log service
        /// </summary>
        private readonly ILogService _logService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FARMasterRepository"/> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public FARMasterRepository(ILogService logService)
        {
            _logService = logService;
        }

        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public FARMasterDto Single(int id)
        {
            FARMasterDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = (from item in context.FAR_Master
                              where item.IsDeleted == false && item.Id == id
                              select new FARMasterDto()
                              {
                                  Id = item.Id,
                                  Number = item.Number,
                                  OriginId = item.OriginId,
                                  FAROrigin = new MSTOriginDto() { Id = item.MST_Origin.Id, Name = item.MST_Origin.Name, Description = item.MST_Origin.Description },
                                  Requestor = item.Requestor,
                                  RefNo = item.RefNo,
                                  FailureTypeId = item.FailureTypeId,
                                  FARFailureType = new MSTFailureTypeDto() { Id = item.MST_FailureType.Id, Name = item.MST_FailureType.Name, Description = item.MST_FailureType.Description },
                                  FailureOriginId = item.FailureOriginId,
                                  FARFailureOrigin = new MSTFailureOriginDto() { Id = item.MST_FailureOrigin.Id, Name = item.MST_FailureOrigin.Name, Description = item.MST_FailureOrigin.Description },
                                  FailureRate = item.FailureRate,
                                  StatusId = item.StatusId,
                                  FARStatus = new MSTStatusDto() { Id = item.MST_Status.Id, Name = item.MST_Status.Name, Description = item.MST_Status.Description },
                                  Analyst = item.Analyst,
                                  RequestDate = item.RequestDate,
                                  SamplesArriveDate = item.SamplesArriveDate,
                                  PriorityId = item.PriorityId,
                                  FARPriority = new MSTPriorityDto() { Id = item.MST_Priority.Id, Name = item.MST_Priority.Name, Description = item.MST_Priority.Description },
                                  InitialReportTargetDate = item.InitialReportTargetDate,
                                  BUId = item.BUId,
                                  Bu = new MSTBuDto() { Id = item.MST_BU.Id, Name = item.MST_BU.Name, Description = item.MST_BU.Description },
                                  Product = item.Product,
                                  FailureDesc = item.FailureDesc,
                                  FinalReportTargetDate = item.FinalReportTargetDate,
                                  Submitted = item.Submitted,
                                  Customer = item.Customer,
                                  LabSiteId = item.LabSiteId,
                                  LabSite = new MSTLabSiteDto { Id = item.MST_LabSite.Id, Name = item.MST_LabSite.Name, Description = item.MST_LabSite.Description },
                                  RatingId = item.RatingId,
                                  Rating = new MSTRatingDto { Id = item.MST_Rating != null ? item.MST_Rating.Id : 0, Name = item.MST_Rating != null ? item.MST_Rating.Name : "", Description = item.MST_Rating != null ? item.MST_Rating.Description : "" },
                                  Comments = item.Comments,
                                  IsDeleted = item.IsDeleted,
                                  LastUpdatedBy = item.LastUpdatedBy,
                                  LastUpdate = item.LastUpdate,
                              }).Single();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                return null;
            }
            return result;
        }

        /// <summary>
        /// Finds the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<FARMasterDto> SingleAsync(int id)
        {
            FARMasterDto result = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    result = await (from item in context.FAR_Master
                                    where item.IsDeleted == false && item.Id == id
                                    select new FARMasterDto()
                                    {
                                        Id = item.Id,
                                        Number = item.Number,
                                        OriginId = item.OriginId,
                                        FAROrigin = new MSTOriginDto() { Id = item.MST_Origin.Id, Name = item.MST_Origin.Name, Description = item.MST_Origin.Description },
                                        Requestor = item.Requestor,
                                        RefNo = item.RefNo,
                                        FailureTypeId = item.FailureTypeId,
                                        FARFailureType = new MSTFailureTypeDto() { Id = item.MST_FailureType.Id, Name = item.MST_FailureType.Name, Description = item.MST_FailureType.Description },
                                        FailureOriginId = item.FailureOriginId,
                                        FARFailureOrigin = new MSTFailureOriginDto() { Id = item.MST_FailureOrigin.Id, Name = item.MST_FailureOrigin.Name, Description = item.MST_FailureOrigin.Description },
                                        FailureRate = item.FailureRate,
                                        StatusId = item.StatusId,
                                        FARStatus = new MSTStatusDto() { Id = item.MST_Status.Id, Name = item.MST_Status.Name, Description = item.MST_Status.Description },
                                        Analyst = item.Analyst,
                                        RequestDate = item.RequestDate,
                                        SamplesArriveDate = item.SamplesArriveDate,
                                        PriorityId = item.PriorityId,
                                        FARPriority = new MSTPriorityDto() { Id = item.MST_Priority.Id, Name = item.MST_Priority.Name, Description = item.MST_Priority.Description },
                                        InitialReportTargetDate = item.InitialReportTargetDate,
                                        BUId = item.BUId,
                                        Bu = new MSTBuDto() { Id = item.MST_BU.Id, Name = item.MST_BU.Name, Description = item.MST_BU.Description },
                                        Product = item.Product,
                                        FailureDesc = item.FailureDesc,
                                        FinalReportTargetDate = item.FinalReportTargetDate,
                                        Submitted = item.Submitted,
                                        Customer = item.Customer,
                                        LabSiteId = item.LabSiteId,
                                        RatingId = item.RatingId,
                                        Rating = new MSTRatingDto { Id = item.MST_Rating != null ? item.MST_Rating.Id : 0, Name = item.MST_Rating != null ? item.MST_Rating.Name : "", Description = item.MST_Rating != null ? item.MST_Rating.Description : "" },
                                        Comments = item.Comments,
                                        LabSite = new MSTLabSiteDto { Id = item.MST_LabSite.Id, Name = item.MST_LabSite.Name, Description = item.MST_LabSite.Description },
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
        public IEnumerable<FARMasterDto> GetAll()
        {
            IEnumerable<FARMasterDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = (from item in context.FAR_Master
                               where item.IsDeleted == false
                               select new FARMasterDto()
                               {
                                   Id = item.Id,
                                   Number = item.Number,
                                   OriginId = item.OriginId,
                                   FAROrigin = new MSTOriginDto() { Id = item.MST_Origin.Id, Name = item.MST_Origin.Name, Description = item.MST_Origin.Description },
                                   Requestor = item.Requestor,
                                   RefNo = item.RefNo,
                                   FailureTypeId = item.FailureTypeId,
                                   FARFailureType = new MSTFailureTypeDto() { Id = item.MST_FailureType.Id, Name = item.MST_FailureType.Name, Description = item.MST_FailureType.Description },
                                   FailureOriginId = item.FailureOriginId,
                                   FARFailureOrigin = new MSTFailureOriginDto() { Id = item.MST_FailureOrigin.Id, Name = item.MST_FailureOrigin.Name, Description = item.MST_FailureOrigin.Description },
                                   FailureRate = item.FailureRate,
                                   StatusId = item.StatusId,
                                   FARStatus = new MSTStatusDto() { Id = item.MST_Status.Id, Name = item.MST_Status.Name, Description = item.MST_Status.Description },
                                   Analyst = item.Analyst,
                                   RequestDate = item.RequestDate,
                                   SamplesArriveDate = item.SamplesArriveDate,
                                   PriorityId = item.PriorityId,
                                   FARPriority = new MSTPriorityDto() { Id = item.MST_Priority.Id, Name = item.MST_Priority.Name, Description = item.MST_Priority.Description },
                                   InitialReportTargetDate = item.InitialReportTargetDate,
                                   BUId = item.BUId,
                                   Bu = new MSTBuDto() { Id = item.MST_BU.Id, Name = item.MST_BU.Name, Description = item.MST_BU.Description },
                                   Product = item.Product,
                                   FailureDesc = item.FailureDesc,
                                   FinalReportTargetDate = item.FinalReportTargetDate,
                                   Submitted = item.Submitted,
                                   Customer = item.Customer,
                                   LabSiteId = item.LabSiteId,
                                   LabSite = new MSTLabSiteDto { Id = item.MST_LabSite.Id, Name = item.MST_LabSite.Name, Description = item.MST_LabSite.Description },
                                   RatingId = item.RatingId,
                                   Rating = new MSTRatingDto { Id = item.MST_Rating != null ? item.MST_Rating.Id : 0, Name = item.MST_Rating != null ? item.MST_Rating.Name : "", Description = item.MST_Rating != null ? item.MST_Rating.Description : "" },
                                   Comments = item.Comments,
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
        public async Task<IEnumerable<FARMasterDto>> GetAllAsync()
        {
            IEnumerable<FARMasterDto> results = null;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    results = await (from item in context.FAR_Master
                                     where item.IsDeleted == false
                                     select new FARMasterDto()
                                     {
                                         Id = item.Id,
                                         Number = item.Number,
                                         OriginId = item.OriginId,
                                         FAROrigin = new MSTOriginDto() { Id = item.MST_Origin.Id, Name = item.MST_Origin.Name, Description = item.MST_Origin.Description },
                                         Requestor = item.Requestor,
                                         RefNo = item.RefNo,
                                         FailureTypeId = item.FailureTypeId,
                                         FARFailureType = new MSTFailureTypeDto() { Id = item.MST_FailureType.Id, Name = item.MST_FailureType.Name, Description = item.MST_FailureType.Description },
                                         FailureOriginId = item.FailureOriginId,
                                         FARFailureOrigin = new MSTFailureOriginDto() { Id = item.MST_FailureOrigin.Id, Name = item.MST_FailureOrigin.Name, Description = item.MST_FailureOrigin.Description },
                                         FailureRate = item.FailureRate,
                                         StatusId = item.StatusId,
                                         FARStatus = new MSTStatusDto() { Id = item.MST_Status.Id, Name = item.MST_Status.Name, Description = item.MST_Status.Description },
                                         Analyst = item.Analyst,
                                         RequestDate = item.RequestDate,
                                         SamplesArriveDate = item.SamplesArriveDate,
                                         PriorityId = item.PriorityId,
                                         FARPriority = new MSTPriorityDto() { Id = item.MST_Priority.Id, Name = item.MST_Priority.Name, Description = item.MST_Priority.Description },
                                         InitialReportTargetDate = item.InitialReportTargetDate,
                                         BUId = item.BUId,
                                         Bu = new MSTBuDto() { Id = item.MST_BU.Id, Name = item.MST_BU.Name, Description = item.MST_BU.Description },
                                         Product = item.Product,
                                         FailureDesc = item.FailureDesc,
                                         FinalReportTargetDate = item.FinalReportTargetDate,
                                         Submitted = item.Submitted,
                                         Customer = item.Customer,
                                         LabSiteId = item.LabSiteId,
                                         LabSite = new MSTLabSiteDto { Id = item.MST_LabSite.Id, Name = item.MST_LabSite.Name, Description = item.MST_LabSite.Description },
                                         RatingId = item.RatingId,
                                         Rating = new MSTRatingDto { Id = item.MST_Rating != null ? item.MST_Rating.Id : 0, Name = item.MST_Rating != null ? item.MST_Rating.Name : "", Description = item.MST_Rating != null ? item.MST_Rating.Description : "" },
                                         Comments = item.Comments,
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
        public SaveResult Update(FARMasterDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var entry = context.FAR_Master.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    entry.Number = entity.Number;
                    entry.OriginId = entity.OriginId;
                    entry.Requestor = entity.Requestor;
                    entry.RefNo = entity.RefNo;
                    entry.FailureTypeId = entity.FailureTypeId;
                    entry.FailureOriginId = entity.FailureOriginId;
                    entry.FailureRate = entity.FailureRate;
                    entry.StatusId = entity.StatusId;
                    entry.Analyst = entity.Analyst;
                    entry.RequestDate = entity.RequestDate;
                    entry.SamplesArriveDate = entity.SamplesArriveDate;
                    entry.PriorityId = entity.PriorityId;
                    entry.InitialReportTargetDate = entity.InitialReportTargetDate;
                    entry.BUId = entity.BUId;
                    entry.Product = entity.Product;
                    entry.FailureDesc = entity.FailureDesc;
                    entry.FinalReportTargetDate = entity.FinalReportTargetDate;
                    entry.Submitted = entity.Submitted;
                    entry.Customer = entity.Customer;
                    entry.LabSiteId = entity.LabSiteId;
                    entry.RatingId = entity.RatingId;
                    entry.Comments = entity.Comments;
                    entry.IsDeleted = entity.IsDeleted;
                    entry.LastUpdatedBy = entity.LastUpdatedBy;
                    entry.LastUpdate = DateTime.Now;

                    context.Entry<FAR_Master>(entry).State = EntityState.Modified;
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
        public async Task<SaveResult> UpdateAsync(FARMasterDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var entry = context.FAR_Master.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    entry.Number = entity.Number;
                    entry.OriginId = entity.OriginId;
                    entry.Requestor = entity.Requestor;
                    entry.RefNo = entity.RefNo;
                    entry.FailureTypeId = entity.FailureTypeId;
                    entry.FailureOriginId = entity.FailureOriginId;
                    entry.FailureRate = entity.FailureRate;
                    entry.StatusId = entity.StatusId;
                    entry.Analyst = entity.Analyst;
                    entry.RequestDate = entity.RequestDate;
                    entry.SamplesArriveDate = entity.SamplesArriveDate;
                    entry.PriorityId = entity.PriorityId;
                    entry.InitialReportTargetDate = entity.InitialReportTargetDate;
                    entry.BUId = entity.BUId;
                    entry.Product = entity.Product;
                    entry.FailureDesc = entity.FailureDesc;
                    entry.FinalReportTargetDate = entity.FinalReportTargetDate;
                    entry.Submitted = entity.Submitted;
                    entry.Customer = entity.Customer;
                    entry.LabSiteId = entity.LabSiteId;
                    entry.RatingId = entity.RatingId;
                    entry.Comments = entity.Comments;
                    entry.IsDeleted = entity.IsDeleted;
                    entry.LastUpdatedBy = entity.LastUpdatedBy;
                    entry.LastUpdate = DateTime.Now;

                    context.Entry<FAR_Master>(entry).State = EntityState.Modified;
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
        public SaveResult Add(FARMasterDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    FAR_Master add = context.FAR_Master.Create();

                    add.Number = entity.Number;
                    add.OriginId = entity.OriginId;
                    add.Requestor = entity.Requestor;
                    add.RefNo = entity.RefNo;
                    add.FailureTypeId = entity.FailureTypeId;
                    add.FailureOriginId = entity.FailureOriginId;
                    add.FailureRate = entity.FailureRate;
                    add.StatusId = entity.StatusId;
                    add.Analyst = entity.Analyst;
                    add.RequestDate = entity.RequestDate;
                    add.SamplesArriveDate = entity.SamplesArriveDate;
                    add.PriorityId = entity.PriorityId;
                    add.InitialReportTargetDate = entity.InitialReportTargetDate;
                    add.BUId = entity.BUId;
                    add.Product = entity.Product;
                    add.FailureDesc = entity.FailureDesc;
                    add.FinalReportTargetDate = entity.FinalReportTargetDate;
                    add.Submitted = entity.Submitted;
                    add.Customer = entity.Customer;
                    add.LabSiteId = entity.LabSiteId;
                    add.RatingId = entity.RatingId;
                    add.Comments = entity.Comments;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry<FAR_Master>(add).State = EntityState.Added;
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
        public async Task<SaveResult> AddAsync(FARMasterDto entity)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    FAR_Master add = context.FAR_Master.Create();

                    add.Number = entity.Number;
                    add.OriginId = entity.OriginId;
                    add.Requestor = entity.Requestor;
                    add.RefNo = entity.RefNo;
                    add.FailureTypeId = entity.FailureTypeId;
                    add.FailureOriginId = entity.FailureOriginId;
                    add.FailureRate = entity.FailureRate;
                    add.StatusId = entity.StatusId;
                    add.Analyst = entity.Analyst;
                    add.RequestDate = entity.RequestDate;
                    add.SamplesArriveDate = entity.SamplesArriveDate;
                    add.PriorityId = entity.PriorityId;
                    add.InitialReportTargetDate = entity.InitialReportTargetDate;
                    add.BUId = entity.BUId;
                    add.Product = entity.Product;
                    add.FailureDesc = entity.FailureDesc;
                    add.FinalReportTargetDate = entity.FinalReportTargetDate;
                    add.Submitted = entity.Submitted;
                    add.Customer = entity.Customer;
                    add.LabSiteId = entity.LabSiteId;
                    add.RatingId = entity.RatingId;
                    add.Comments = entity.Comments;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry<FAR_Master>(add).State = EntityState.Added;
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
        /// Adds the master.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int AddMaster(FARMasterDto entity)
        {
            int result = 0;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    FAR_Master add = context.FAR_Master.Create();

                    add.Number = entity.Number;
                    add.OriginId = entity.OriginId;
                    add.Requestor = entity.Requestor;
                    add.RefNo = entity.RefNo;
                    add.FailureTypeId = entity.FailureTypeId;
                    add.FailureOriginId = entity.FailureOriginId;
                    add.FailureRate = entity.FailureRate;
                    add.StatusId = entity.StatusId;
                    add.Analyst = entity.Analyst;
                    add.RequestDate = entity.RequestDate;
                    add.SamplesArriveDate = entity.SamplesArriveDate;
                    add.PriorityId = entity.PriorityId;
                    add.InitialReportTargetDate = entity.InitialReportTargetDate;
                    add.BUId = entity.BUId;
                    add.Product = entity.Product;
                    add.FailureDesc = entity.FailureDesc;
                    add.FinalReportTargetDate = entity.FinalReportTargetDate;
                    add.Submitted = entity.Submitted;
                    add.Customer = entity.Customer;
                    add.LabSiteId = entity.LabSiteId;
                    add.RatingId = entity.RatingId;
                    add.Comments = entity.Comments;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry<FAR_Master>(add).State = EntityState.Added;
                    context.SaveChanges();

                    result = add.Id;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = 0;
            }
            return result;
        }

        /// <summary>
        /// Adds the master asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<int> AddMasterAsync(FARMasterDto entity)
        {
            int result = 0;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    FAR_Master add = context.FAR_Master.Create();

                    add.Number = entity.Number;
                    add.OriginId = entity.OriginId;
                    add.Requestor = entity.Requestor;
                    add.RefNo = entity.RefNo;
                    add.FailureTypeId = entity.FailureTypeId;
                    add.FailureOriginId = entity.FailureOriginId;
                    add.FailureRate = entity.FailureRate;
                    add.StatusId = entity.StatusId;
                    add.Analyst = entity.Analyst;
                    add.RequestDate = entity.RequestDate;
                    add.SamplesArriveDate = entity.SamplesArriveDate;
                    add.PriorityId = entity.PriorityId;
                    add.InitialReportTargetDate = entity.InitialReportTargetDate;
                    add.BUId = entity.BUId;
                    add.Product = entity.Product;
                    add.FailureDesc = entity.FailureDesc;
                    add.FinalReportTargetDate = entity.FinalReportTargetDate;
                    add.Submitted = entity.Submitted;
                    add.Customer = entity.Customer;
                    add.LabSiteId = entity.LabSiteId;
                    add.RatingId = entity.RatingId;
                    add.Comments = entity.Comments;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdate = DateTime.Now;

                    context.Entry<FAR_Master>(add).State = EntityState.Added;
                    await context.SaveChangesAsync();
                    result = add.Id;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = 0;
            }
            return result;
        }

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        public SaveResult AddRange(IEnumerable<FARMasterDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    FAR_Master add = null;
                    foreach (var entity in entities)
                    {
                        add = context.FAR_Master.Create();

                        add.Number = entity.Number;
                        add.OriginId = entity.OriginId;
                        add.Requestor = entity.Requestor;
                        add.RefNo = entity.RefNo;
                        add.FailureTypeId = entity.FailureTypeId;
                        add.FailureOriginId = entity.FailureOriginId;
                        add.FailureRate = entity.FailureRate;
                        add.StatusId = entity.StatusId;
                        add.Analyst = entity.Analyst;
                        add.RequestDate = entity.RequestDate;
                        add.SamplesArriveDate = entity.SamplesArriveDate;
                        add.PriorityId = entity.PriorityId;
                        add.InitialReportTargetDate = entity.InitialReportTargetDate;
                        add.BUId = entity.BUId;
                        add.Product = entity.Product;
                        add.FailureDesc = entity.FailureDesc;
                        add.FinalReportTargetDate = entity.FinalReportTargetDate;
                        add.Submitted = entity.Submitted;
                        add.Customer = entity.Customer;
                        add.LabSiteId = entity.LabSiteId;
                        add.RatingId = entity.RatingId;
                        add.Comments = entity.Comments;
                        add.IsDeleted = entity.IsDeleted;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;

                        context.Entry<FAR_Master>(add).State = EntityState.Added;
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
        public async Task<SaveResult> AddRangeAsync(IEnumerable<FARMasterDto> entities)
        {
            SaveResult result = SaveResult.FAILURE;
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    FAR_Master add = null;
                    foreach (var entity in entities)
                    {
                        add = context.FAR_Master.Create();

                        add.Number = entity.Number;
                        add.OriginId = entity.OriginId;
                        add.Requestor = entity.Requestor;
                        add.RefNo = entity.RefNo;
                        add.FailureTypeId = entity.FailureTypeId;
                        add.FailureOriginId = entity.FailureOriginId;
                        add.FailureRate = entity.FailureRate;
                        add.StatusId = entity.StatusId;
                        add.Analyst = entity.Analyst;
                        add.RequestDate = entity.RequestDate;
                        add.SamplesArriveDate = entity.SamplesArriveDate;
                        add.PriorityId = entity.PriorityId;
                        add.InitialReportTargetDate = entity.InitialReportTargetDate;
                        add.BUId = entity.BUId;
                        add.Product = entity.Product;
                        add.FailureDesc = entity.FailureDesc;
                        add.FinalReportTargetDate = entity.FinalReportTargetDate;
                        add.Submitted = entity.Submitted;
                        add.Customer = entity.Customer;
                        add.LabSiteId = entity.LabSiteId;
                        add.RatingId = entity.RatingId;
                        add.Comments = entity.Comments;
                        add.IsDeleted = entity.IsDeleted;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdate = DateTime.Now;

                        context.Entry<FAR_Master>(add).State = EntityState.Added;
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
        public SaveResult Delete(FARMasterDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var master = context.FAR_Master.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    master.IsDeleted = true;
                    master.LastUpdate = DateTime.Now;
                    master.LastUpdatedBy = entity.LastUpdatedBy;

                    context.Entry<FAR_Master>(master).State = EntityState.Modified;
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
        public async Task<SaveResult> DeleteAsync(FARMasterDto entity)
        {
            SaveResult result = SaveResult.FAILURE;

            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    var master = context.FAR_Master.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    master.IsDeleted = true;
                    master.LastUpdate = DateTime.Now;
                    master.LastUpdatedBy = entity.LastUpdatedBy;

                    context.Entry<FAR_Master>(master).State = EntityState.Modified;
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
                    var master = context.FAR_Master.Single(x => x.Id == Id && x.IsDeleted == false);
                    master.IsDeleted = true;
                    master.LastUpdate = DateTime.Now;

                    context.Entry<FAR_Master>(master).State = EntityState.Modified;
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
                    var master = context.FAR_Master.Single(x => x.Id == Id && x.IsDeleted == false);
                    master.IsDeleted = true;
                    master.LastUpdate = DateTime.Now;

                    context.Entry<FAR_Master>(master).State = EntityState.Modified;
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
        /// Counts the record.
        /// </summary>
        /// <returns></returns>
        public int CountRecord()
        {
            try
            {
                using (FailureAnalysisEntities context = new FailureAnalysisEntities())
                {
                    return context.FAR_Master.Count();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                return 0;
            }
        }
    }
}

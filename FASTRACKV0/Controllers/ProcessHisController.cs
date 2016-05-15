// ***********************************************************************
// Assembly         : FASTRACKV0
// Author           : tranthiencdsp@gmail.com
// Created          : 11-14-2015
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 04-23-2016
// ***********************************************************************
// <copyright file="ProcessHisController.cs" company="Atmel Corporation">
//     Copyright © Atmel 2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using FASTrack.Model.Abstracts;
using FASTrack.Model.DTO;
using FASTrack.Model.Types;
using FASTrack.ViewModel;
using Ninject;
using System.Linq;
using System.Net;
using System.Web.Mvc;

/// <summary>
/// The Controllers namespace.
/// </summary>
namespace FASTrack.Controllers
{
    /// <summary>
    /// Class ProcessHisController.
    /// </summary>
    public class ProcessHisController : AppController
    {
        /// <summary>
        /// Adds the process.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns>PartialViewResult.</returns>
        [HttpGet]
        public PartialViewResult AddProcess(int deviceId)
        {
            ProcessViewModel viewmodel = new ProcessViewModel();
            viewmodel.DeviceId = deviceId;
            viewmodel.Analysts = UserRes.GetAll().Where(x => x.RoleId == (int)RoleType.ANALYST || x.RoleId == (int)RoleType.MANAGER).ToList();
            viewmodel.ProcessTypes = ProcessTypeRes.GetAll();

            return PartialView("_PartialPageAddProcess", viewmodel);
        }

        /// <summary>
        /// Confirms the add process.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="viewmodel">The viewmodel.</param>
        /// <returns>JsonResult.</returns>
        [HttpPost, ActionName("AddProcess")]
        public JsonResult ConfirmAddProcess(int deviceId, ProcessViewModel viewmodel)
        {
            FARProcessHistoryDto his = new FARProcessHistoryDto()
            {
                DeviceId = deviceId,
                Analystor = viewmodel.Email,
                Comment = viewmodel.Comment,
                ProcessTypeId = viewmodel.ProcessTypeId,
                LastUpdatedBy = this.CurrentName,
                IsIncluded = true,
                SeqNum = 0,
            };
            var result = ProcessHisRep.Add(his);
            switch (result)
            {
                case Model.SaveResult.SUCCESS:
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return new JsonResult
                    {
                        Data = new { code = "SB01", Id = deviceId },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                case Model.SaveResult.FAILURE:
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return new JsonResult
                    {
                        Data = new { code = "SB02", Id = deviceId },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return new JsonResult
            {
                Data = new { code = "SB02", Id = deviceId },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        /// <summary>
        /// Inserts the process.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns>PartialViewResult.</returns>
        [HttpGet]
        public PartialViewResult InsertProcess(int deviceId)
        {
            ProcessViewModel viewmodel = new ProcessViewModel();
            viewmodel.DeviceId = deviceId;
            viewmodel.Analysts = UserRes.GetAll().Where(x => x.RoleId == (int)RoleType.ANALYST || x.RoleId == (int)RoleType.MANAGER).ToList();
            viewmodel.ProcessTypes = ProcessTypeRes.GetAll();

            return PartialView("_PartialPageInsertProcess", viewmodel);
        }

        /// <summary>
        /// Confirms the insert process.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="viewmodel">The viewmodel.</param>
        /// <returns>JsonResult.</returns>
        [HttpPost, ActionName("InsertProcess")]
        public JsonResult ConfirmInsertProcess(int deviceId, ProcessViewModel viewmodel)
        {
            FARProcessHistoryDto his = new FARProcessHistoryDto()
            {
                DeviceId = deviceId,
                Analystor = viewmodel.Email,
                Comment = viewmodel.Comment,
                ProcessTypeId = viewmodel.ProcessTypeId,
                LastUpdatedBy = this.CurrentName,
                IsIncluded = true,
                SeqNum = 0,
            };
            var result = ProcessHisRep.Add(his);
            switch (result)
            {
                case Model.SaveResult.SUCCESS:
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return new JsonResult
                    {
                        Data = new { code = "SB01", Id = deviceId },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                case Model.SaveResult.FAILURE:
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return new JsonResult
                    {
                        Data = new { code = "SB02", Id = deviceId },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return new JsonResult
            {
                Data = new { code = "SB02", Id = deviceId },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        /// <summary>
        /// Edits the process.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>PartialViewResult.</returns>
        [HttpGet]
        public PartialViewResult EditProcess(int id)
        {
            ProcessViewModel viewmodel = new ProcessViewModel();
            var single = ProcessHisRep.Single(id);
            viewmodel.DeviceId = single.DeviceId;
            viewmodel.ProcessTypeId = single.ProcessTypeId;
            viewmodel.Email = single.Analystor;
            viewmodel.Comment = single.Comment;
            viewmodel.Analysts = UserRes.GetAll().Where(x => x.RoleId == (int)RoleType.ANALYST || x.RoleId == (int)RoleType.MANAGER).ToList();
            viewmodel.ProcessTypes = ProcessTypeRes.GetAll();

            return PartialView("_PartialPageEditProcess", viewmodel);
        }

        /// <summary>
        /// Confirms the edit process.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="viewmodel">The viewmodel.</param>
        /// <returns>JsonResult.</returns>
        [HttpPost, ActionName("EditProcess")]
        public JsonResult ConfirmEditProcess(int id, ProcessViewModel viewmodel)
        {
            FARProcessHistoryDto his = new FARProcessHistoryDto()
            {
                Id = id,
                Analystor = viewmodel.Email,
                Comment = viewmodel.Comment,
                ProcessTypeId = viewmodel.ProcessTypeId,
                LastUpdatedBy = this.CurrentName,
            };
            var result = ProcessHisRep.EditProcess(his);
            switch (result)
            {
                case Model.SaveResult.SUCCESS:
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return new JsonResult
                    {
                        Data = new { code = "SB01", Id = viewmodel.DeviceId },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                case Model.SaveResult.FAILURE:
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return new JsonResult
                    {
                        Data = new { code = "SB02", Id = viewmodel.DeviceId },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return new JsonResult
            {
                Data = new { code = "SB02", Id = viewmodel.DeviceId },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        /// <summary>
        /// Deletes the process.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>PartialViewResult.</returns>
        [HttpGet]
        public PartialViewResult DeleteProcess(int id)
        {
            return PartialView("_PartialPageDeleteProcess", id);
        }

        /// <summary>
        /// Confirms the delete process.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>JsonResult.</returns>
        [HttpPost, ActionName("DeleteProcess")]
        public JsonResult ConfirmDeleteProcess(int id)
        {
            var result = ProcessHisRep.RemoveProcess(id);
            switch (result)
            {
                case Model.SaveResult.SUCCESS:
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return new JsonResult
                    {
                        Data = new { code = "SB01" },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                case Model.SaveResult.FAILURE:
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return new JsonResult
                    {
                        Data = new { code = "SB02" },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return new JsonResult
            {
                Data = new { code = "SB02" },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        /// <summary>
        /// Gets or sets the user resource.
        /// </summary>
        /// <value>The user resource.</value>
        [Inject]
        public ISYSUsersRepository UserRes { get; set; }

        /// <summary>
        /// Gets or sets the process type resource.
        /// </summary>
        /// <value>The process type resource.</value>
        [Inject]
        public IMSTProcessTypesRepository ProcessTypeRes { get; set; }

        /// <summary>
        /// Gets or sets the process his rep.
        /// </summary>
        /// <value>The process his rep.</value>
        [Inject]
        public IFARProcessHistoryRepository ProcessHisRep { get; set; }
    }
}
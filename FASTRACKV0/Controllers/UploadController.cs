// ***********************************************************************
// Assembly         : FASTrack
// Author           : tranthiencdsp@gmail.com
// Created          : 02-25-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 05-16-2016
// ***********************************************************************
// <copyright file="UploadController.cs" company="Atmel">
//     Copyright © Atmel 2016
// </copyright>
// <summary></summary>
// **********************************************************************

using FASTrack.Model.Abstracts;
using FASTrack.Model.Types;
using FASTrack.Utilities;
using FASTrack.Model.DTO;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using FASTrack.ViewModel;

/// <summary>
/// 
/// </summary>
namespace FASTrack.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class UploadController : AppController
    {

        /// <summary>
        /// Res the attach.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="Number">The number.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ViewAttach(int id, string Number)
        {
            var item = new FASTrack.ViewModel.AttachmentViewModel();
            item.Id = id;
            item.InitalReasons = ReasonINI.GetAll();// ReasonRes.GetAll();
            item.FinalReasons = ReasonFIN.GetAll();// item.InitalReasons;
            item.FANumber = Number;

            string folderINT = Path.Combine(Server.MapPath("~/Upload"), id.ToString().PadLeft(10, '0'), "INT");
            string folderFIN = Path.Combine(Server.MapPath("~/Upload"), id.ToString().PadLeft(10, '0'), "FIN");
            if (Directory.Exists(folderINT))
            {
                string[] files = Directory.GetFiles(folderINT);
                item.InitialReport = new List<string>();
                foreach (var file in files)
                {
                    item.InitialReport.Add(Path.GetFileName(file));
                }
            }
            if (Directory.Exists(folderFIN))
            {
                string[] files = Directory.GetFiles(folderFIN);
                item.FinalReport = new List<string>();
                foreach (var file in files)
                {
                    item.FinalReport.Add(Path.GetFileName(file));
                }
            }
            return View(item);
        }

        /// <summary>
        /// Anas the attach.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="Number">The number.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AnaAttach(int id, string Number)//idMaster
        {
            var master = MasterRep.Single(id);
            if (master == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return View();
            }
           
            var item = new FASTrack.ViewModel.AttachmentViewModel();
            item.Id = id;
            item.InitalReasons = ReasonINI.GetAll();// ReasonRes.GetAll();
            item.FinalReasons = ReasonFIN.GetAll();// item.InitalReasons;
            item.FANumber = Number;
            item.FinalDate = master.FinalReportTargetDate;
            item.InitialDate = master.InitialReportTargetDate;

            string folderINT = Path.Combine(Server.MapPath("~/Upload"), id.ToString().PadLeft(10, '0'), "INT");
            string folderFIN = Path.Combine(Server.MapPath("~/Upload"), id.ToString().PadLeft(10, '0'), "FIN");
            if (Directory.Exists(folderINT))
            {
                string[] files = Directory.GetFiles(folderINT);
                item.InitialReport = new List<string>();
                foreach (var file in files)
                {
                    item.InitialReport.Add(Path.GetFileName(file));
                }
            }
            if (Directory.Exists(folderFIN))
            {
                string[] files = Directory.GetFiles(folderFIN);
                item.FinalReport = new List<string>();
                foreach (var file in files)
                {
                    item.FinalReport.Add(Path.GetFileName(file));
                }
            }
            //ViewBag.ShowButtonReportUploaded = 0;
            //bool checkFilled = ProcessHistoryRep.CheckProcessFlowFilled(id);
            //if (item.InitialReport == null || item.FinalReport == null)
            //    ViewBag.ShowButtonReportUploaded = 0;
            //else if (checkFilled && item.InitialReport.Count > 0 && item.FinalReport.Count > 0)
            //    ViewBag.ShowButtonReportUploaded = 1;

            var final = ReportRepository.GetBy(master.OriginId, ReportType.FINAL);
            ViewBag.EnableFinal = final.Required;

            var initial = ReportRepository.GetBy(master.OriginId, ReportType.INITIAL);
            ViewBag.EnableInitial = initial.Required;

            return View(item);
        }

        /// <summary>
        /// Anas the attach report.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        [HttpPost, ActionName("AnaAttach")]
        public ContentResult AnaAttachReport(int id, string type, int ReasonId)//Id master
        {
            string saveFolder = Path.Combine(Server.MapPath("~/Upload"), id.ToString().PadLeft(10, '0'), type);
            if (!Directory.Exists(saveFolder))
                Directory.CreateDirectory(saveFolder);
            //Remove all file in folder saveFolder
            string[] files = Directory.GetFiles(saveFolder);
            foreach (string file in files)
                System.IO.File.Delete(file);

            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                    continue;

                string savedFileName = Path.Combine(saveFolder, Path.GetFileName(hpf.FileName));
                hpf.SaveAs(savedFileName); // Save the file

                //Log history upload file
                FARUploadDto uploadFile = new FARUploadDto
                {
                    FAType = type,
                    FileName = hpf.FileName,
                    MasterId = id,
                    UploadedBy = this.CurrentName,
                    ReasonId = ReasonId
                };
                UploadRep.Add(uploadFile);
            }
            // Returns json
            files = Directory.GetFiles(saveFolder);
            string json = string.Empty;
            foreach (string file in files)
            {
                json += "<a href=" + Url.Action("Download", new { id = id, file = Path.GetFileName(file), type = type }) + ">" + Path.GetFileName(file) + "</a>" + "<br/>";
            }
            return Content(json, "application/html");
        }

        /// <summary>
        /// Mans the attach.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="Number">The number.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ManAttach(int id, string Number)
        {
            var master = MasterRep.Single(id);
            if (master == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return View();
            }

            var item = new FASTrack.ViewModel.AttachmentViewModel();
            item.Id = id;
            item.InitalReasons = ReasonINI.GetAll();// ReasonRes.GetAll();
            item.FinalReasons = ReasonFIN.GetAll(); //item.InitalReasons;
            item.FANumber = Number;
            item.FinalDate = master.FinalReportTargetDate;
            item.InitialDate = master.InitialReportTargetDate;

            string folderINT = Path.Combine(Server.MapPath("~/Upload"), id.ToString().PadLeft(10, '0'), "INT");
            string folderFIN = Path.Combine(Server.MapPath("~/Upload"), id.ToString().PadLeft(10, '0'), "FIN");
            if (Directory.Exists(folderINT))
            {
                string[] files = Directory.GetFiles(folderINT);
                item.InitialReport = new List<string>();
                foreach (var file in files)
                {
                    item.InitialReport.Add(Path.GetFileName(file));
                }
            }
            if (Directory.Exists(folderFIN))
            {
                string[] files = Directory.GetFiles(folderFIN);
                item.FinalReport = new List<string>();
                foreach (var file in files)
                {
                    item.FinalReport.Add(Path.GetFileName(file));
                }
            }

            var final = ReportRepository.GetBy(master.OriginId, ReportType.FINAL);
            ViewBag.EnableFinal = final.Required;

            var initial = ReportRepository.GetBy(master.OriginId, ReportType.INITIAL);
            ViewBag.EnableInitial = initial.Required;

            return View(item);
        }

        /// <summary>
        /// Mans the attach report.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        [HttpPost, ActionName("ManAttach")]
        public ContentResult ManAttachReport(int id, string type, int ReasonId)
        {
            string saveFolder = Path.Combine(Server.MapPath("~/Upload"), id.ToString().PadLeft(10, '0'), type);
            if (!Directory.Exists(saveFolder))
                Directory.CreateDirectory(saveFolder);
            //Remove all file in folder saveFolder
            string[] files = Directory.GetFiles(saveFolder);
            foreach (string file in files)
                System.IO.File.Delete(file);
            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                    continue;

                string savedFileName = Path.Combine(saveFolder, Path.GetFileName(hpf.FileName));
                hpf.SaveAs(savedFileName); // Save the file

                //Log history upload file
                FARUploadDto uploadFile = new FARUploadDto
                {
                    FAType = type,
                    FileName = hpf.FileName,
                    MasterId = id,
                    UploadedBy = this.CurrentName,
                    ReasonId = ReasonId
                };
                UploadRep.Add(uploadFile);
            }
            // Returns json
            files = Directory.GetFiles(saveFolder);
            string json = string.Empty;
            foreach (string file in files)
            {
                json += "<a href=" + Url.Action("Download", new { id = id, file = Path.GetFileName(file), type = type }) + ">" + Path.GetFileName(file) + "</a>" + "<br/>";
            }
            return Content(json, "application/html");
        }

        /// <summary>
        /// Res the attach.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="Number">The number.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ReAttach(int id, string Number)
        {
            var item = new FASTrack.ViewModel.AttachmentViewModel();
            item.Id = id;
            item.InitalReasons = ReasonINI.GetAll();// ReasonRes.GetAll();
            item.FinalReasons = ReasonFIN.GetAll();// item.InitalReasons;
            item.FANumber = Number;

            string folderINT = Path.Combine(Server.MapPath("~/Upload"), id.ToString().PadLeft(10, '0'), "INT");
            string folderFIN = Path.Combine(Server.MapPath("~/Upload"), id.ToString().PadLeft(10, '0'), "FIN");
            if (Directory.Exists(folderINT))
            {
                string[] files = Directory.GetFiles(folderINT);
                item.InitialReport = new List<string>();
                foreach (var file in files)
                {
                    item.InitialReport.Add(Path.GetFileName(file));
                }
            }
            if (Directory.Exists(folderFIN))
            {
                string[] files = Directory.GetFiles(folderFIN);
                item.FinalReport = new List<string>();
                foreach (var file in files)
                {
                    item.FinalReport.Add(Path.GetFileName(file));
                }
            }
            return View(item);
        }

        /// <summary>
        /// Res the attach report.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        [HttpPost, ActionName("ReAttach")]
        public ContentResult ReAttachReport(int id, string type)
        {
            string saveFolder = Path.Combine(Server.MapPath("~/Upload"), id.ToString().PadLeft(10, '0'), type);
            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                    continue;

                string savedFileName = Path.Combine(saveFolder, Path.GetFileName(hpf.FileName));
                hpf.SaveAs(savedFileName); // Save the file
            }
            // Returns json
            string[] files = Directory.GetFiles(saveFolder);
            string json = string.Empty;
            foreach (string file in files)
            {
                json += "<a href=" + Url.Action("Download", new { id = id, file = Path.GetFileName(file), type = type }) + ">" + Path.GetFileName(file) + "</a>" + "<br/>";
            }
            return Content(json, "application/html");
        }

        /// <summary>
        /// Res the upload files.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="guid">The unique identifier.</param>
        /// <returns></returns>
        [HttpPost]
        public ContentResult ReUploadFiles(int id, string guid)
        {
            string saveFolder = string.Empty;
            if (id == 0)
                saveFolder = Path.Combine(Server.MapPath("~/Upload/Temp"), guid);
            else
                saveFolder = Path.Combine(Server.MapPath("~/Upload"), id.ToString().PadLeft(10, '0'));

            if (!Directory.Exists(saveFolder))
                Directory.CreateDirectory(saveFolder);

            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                    continue;

                string savedFileName = Path.Combine(saveFolder, Path.GetFileName(hpf.FileName));
                hpf.SaveAs(savedFileName); // Save the file
            }

            // Returns json
            string[] files = Directory.GetFiles(saveFolder);
            string json = string.Empty;
            foreach (string file in files)
            {
                json += "<a href=" + Url.Action("DownloadTemp", new { id = id, guid = guid, file = Path.GetFileName(file) }) + ">" + Path.GetFileName(file) + "</a>" + "<br/>";
            }
            // Returns json
            return Content(json, "application/html");
        }

        /// <summary>
        /// Downloads the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="file">The file.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        [HttpGet]
        public FileResult Download(int id, string file, string type)
        {
            string folder = Path.Combine(Server.MapPath("~/Upload"), id.ToString().PadLeft(10, '0'), type, file);
            return File(folder, System.Net.Mime.MediaTypeNames.Application.Octet, file);
        }

        /// <summary>
        /// Downloads the temporary.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="file">The file.</param>
        /// <param name="guid">The unique identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public FileResult DownloadTemp(int id, string file, string guid = null)
        {
            string folder = string.Empty;
            if (id != 0)
                folder = Path.Combine(Server.MapPath("~/Upload"), id.ToString().PadLeft(10, '0'), file);
            else
                folder = Path.Combine(Server.MapPath("~/Upload/Temp"), guid, file);

            return File(folder, System.Net.Mime.MediaTypeNames.Application.Octet, file);
        }

        /// <summary>
        /// Reports the uploaded.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ReportUploaded(int id)
        {
            if (id == 0)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Bad Request", JsonRequestBehavior.AllowGet);
            }

            var master = MasterRep.Single(id);
            if (master == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json("Not Found", JsonRequestBehavior.AllowGet);
            }

            master.StatusId = (int)StatusType.REPORTUPLOADED;
            var result = MasterRep.Update(master);

            if (result == Model.SaveResult.SUCCESS)
            {
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json("SUCCESS", JsonRequestBehavior.AllowGet);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("FAILURE", JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Photoes the attach.
        /// </summary>
        /// <param name="masterid">The masterid.</param>
        /// <param name="deviceid">The deviceid.</param>
        /// <param name="processid">The processid.</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult PhotoAttach(int masterid, int deviceid, int processid)
        {
            try
            {
                foreach (string file in Request.Files)
                {
                    HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                    if (hpf.ContentLength == 0)
                        continue;
                    string folderMaster = Path.Combine(Server.MapPath("~/Upload"), masterid.ToString().PadLeft(10, '0'));
                    string folderDevice = Path.Combine(folderMaster, "DEVICE");
                    if (!Directory.Exists(folderDevice))
                        Directory.CreateDirectory(folderDevice);

                    string folderDeviceDetail = Path.Combine(folderDevice, deviceid.ToString().PadLeft(10, '0'));
                    if (!Directory.Exists(folderDeviceDetail))
                        Directory.CreateDirectory(folderDeviceDetail);

                    string folderProcess = Path.Combine(folderDeviceDetail, processid.ToString().PadLeft(10, '0'));
                    if (!Directory.Exists(folderProcess))
                        Directory.CreateDirectory(folderProcess);

                    string savedFileName = Path.Combine(folderProcess, Path.GetFileName(hpf.FileName));
                    hpf.SaveAs(savedFileName); // Save the file
                }
                return Json("SUCESS", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogService.Error(ex.Message, ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("ERROR", JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Views the photos.
        /// </summary>
        /// <param name="masterid">The masterid.</param>
        /// <param name="deviceid">The deviceid.</param>
        /// <param name="processid">The processid.</param>
        /// <returns></returns>
        [HttpGet]
        public PartialViewResult ViewPhotos(int masterid, int deviceid, int processid)
        {
            string folderMaster = Path.Combine(Server.MapPath("~/Upload"), masterid.ToString().PadLeft(10, '0'));
            string folderDevice = Path.Combine(folderMaster, "DEVICE");
            string folderDeviceDetail = Path.Combine(folderDevice, deviceid.ToString().PadLeft(10, '0'));
            string folderProcess = Path.Combine(folderDeviceDetail, processid.ToString().PadLeft(10, '0'));
            List<ViewPhoto> photos = new List<ViewPhoto>();
            if (Directory.Exists(folderProcess))
            {
                //Get all files
                string[] files = Directory.GetFiles(folderProcess);
                folderProcess = Path.Combine("Upload", masterid.ToString().PadLeft(10, '0'), "DEVICE", deviceid.ToString().PadLeft(10, '0'), processid.ToString().PadLeft(10, '0'));
                foreach (string file in files)
                {
                    photos.Add(new ViewPhoto
                    {
                        FilePath = Path.Combine(folderProcess, Path.GetFileName(file)),
                        FileName = Path.GetFileName(file),
                    });
                }
            }
            if (photos.Count > 0)
            {
                ViewPhotoViewModel result = new ViewPhotoViewModel
                {
                    Photos = photos,
                    Default = photos.First().FilePath
                };
                return PartialView("_PartialPageViewPhotos", result);
            }

            return PartialView("_PartialPageViewPhotos", null);
        }

        /// <summary>
        /// Gets or sets the reason resource.
        /// </summary>
        /// <value>
        /// The reason resource.
        /// </value>
        [Inject]
        public IHSTReasonRepository ReasonRes { get; set; }

        /// <summary>
        /// Gets or sets the reason ini.
        /// </summary>
        /// <value>
        /// The reason ini.
        /// </value>
        [Inject]
        public IMSTReasonINIRepository ReasonINI { get; set; }

        /// <summary>
        /// Gets or sets the reason fin.
        /// </summary>
        /// <value>
        /// The reason fin.
        /// </value>
        [Inject]
        public IMSTReasonFINRepository ReasonFIN { get; set; }

        /// <summary>
        /// Gets or sets the process history repository.
        /// </summary>
        /// <value>
        /// The process history repository.
        /// </value>
        [Inject]
        public IFARProcessHistoryRepository ProcessHistoryRep { get; set; }

        /// <summary>
        /// Gets or sets the master repository.
        /// </summary>
        /// <value>
        /// The master repository.
        /// </value>
        [Inject]
        public IFARMasterRepository MasterRep { get; set; }

        /// <summary>
        /// Gets or sets the log service.
        /// </summary>
        /// <value>
        /// The log service.
        /// </value>
        [Inject]
        public ILogService LogService { get; set; }

        /// <summary>
        /// Gets or sets the upload rep.
        /// </summary>
        /// <value>
        /// The upload rep.
        /// </value>
        [Inject]
        public IFARUploadRepository UploadRep { get; set; }

        /// <summary>
        /// Gets or sets the report repository.
        /// </summary>
        /// <value>
        /// The report repository.
        /// </value>
        [Inject]
        public IMSTFarReportRepository ReportRepository { get; set; }
    }
}
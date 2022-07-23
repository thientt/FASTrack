// ***********************************************************************
// Assembly         : FASTRACKV0
// Author           : tranthiencdsp@gmail.com
// Created          : 11-04-2015
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 04-14-2016
// ***********************************************************************
// <copyright file="DashboardController.cs" company="Atmel Corporation">
//     Copyright © Atmel 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using FASTrack.Infrastructure;
using FASTrack.Model.Abstracts;
using FASTrack.Model.DTO;
using FASTrack.Model.Types;
using FASTrack.Utilities;
using FASTrack.ViewModel;
using Ninject;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FASTrack.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class DashboardController : AppController
    {
        #region Begin Dashboard
        /// <summary>
        /// Exports the excel.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        [HttpGet, Authorize]
        public JsonResult ExportExcel(string type)
        {
            string path = Server.MapPath("~");

            FASTrack.Infrastructure.ExportExcel excel = new ExportExcel(path);
            List<FARMasterDto> dashboard = null;
            switch (type)
            {
                case "RE":
                    dashboard = (MasterRepository.GetAll()).
                       Where(x => x.Requestor == CurrentName &&
                           x.StatusId != (int)StatusType.CLOSED).
                       OrderBy(x => x.Number).ToList();
                    break;
                case "ANA":
                    dashboard = (MasterRepository.GetAll()).
                          Where(x => x.Submitted && (x.StatusId != (int)StatusType.CLOSED) && (x.Analyst == this.CurrentName)).
                          OrderBy(x => x.Number).ToList();
                    break;
                case "CLO":
                    dashboard = (MasterRepository.GetAll()).
                          Where(x => x.Submitted && (x.StatusId == (int)StatusType.CLOSED)).
                          OrderBy(x => x.Number).ToList();
                    break;
                //case "MAN":
                default:
                    dashboard = (MasterRepository.GetAll()).
                        Where(x => x.Submitted && (x.StatusId != (int)StatusType.CLOSED)).OrderBy(x => x.Number).ToList();
                    break;
            }
            if (dashboard != null)
            {
                List<ExcelViewModel> excelModel = new List<ExcelViewModel>();
                dashboard.ForEach(x =>
                    {
                        var process = ProcessHisRep.GetMaxProcessByMaster(x.Id);
                        string currentProcess = String.Empty;
                        int currentProcessCT = 0;
                        if (process != null)
                        {
                            currentProcess = process.ProcessType.Name;
                            if (process.DateOut.HasValue && process.DateIn.HasValue)
                            {
                                currentProcessCT = (process.DateOut.Value.Date - process.DateIn.Value.Date).Days;
                            }
                        }
                        excelModel.Add(new ExcelViewModel
                        {
                            BU = x.Bu.Name,
                            Comment = x.FailureDesc,
                            CurrentProcess = currentProcess,
                            CurrentProcessCT = currentProcessCT,
                            FARNumber = x.Number,
                            LastUpdate = x.LastUpdate.ToString("MM/dd/yyyy"),
                            LastUpdatedBy = x.LastUpdatedBy,
                            OverallCT = x.OverallCT,
                            OverallFAInCharge = x.Analyst,
                            Priority = x.FARPriority.Name,
                            Product = x.Product,
                            RefNo = x.RefNo,
                            RequestBy = x.Requestor,
                            Status = x.FARStatus.Name,
                            SubmissionOrStatus = x.Submitted ? "Submitted" : "Saved"
                        });
                    });
                excel.Content = excelModel;

                excel.CreateHeader();
                excel.CreateTitle();
                excel.CreateContent();
                string filename = excel.SaveFile();
                string fullPath = System.IO.Path.Combine(path, "Reports", filename);

                return Json(fullPath, JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        /// <summary>
        /// Downloads the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        [HttpGet, Authorize]
        public FileResult Download(string file)
        {
            var bytes = System.IO.File.ReadAllBytes(file);
            System.IO.File.Delete(file);
            string contentType = "application/vnd.ms-excel";
            string fileName = "Dashboard.xlsx";
            return File(bytes, contentType, fileName);
        }

        /// <summary>
        /// Lists as requestor.
        /// </summary>
        /// <returns></returns>
        [HttpGet, Authorize(Roles = AuthRole.Requestor)]
        public ActionResult AsRequestor(int? page, string sortOrder = "FaNumberSortOrder", string SearchAll = null)
        {
            FilterPage obj = new FilterPage
            {
                SortOrder = sortOrder,
                Page = page,
                SearchAll = SearchAll
            };
            return View(obj);
        }

        /// <summary>
        ///  Requestses the specified page.
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="page"></param>
        /// <param name="SearchAll"></param>
        /// <returns></returns>
        [Authorize(Roles = AuthRole.Requestor)]
        public PartialViewResult AsRequests(string sortOrder, int? page, string SearchAll = null)
        {
            ViewBag.Search = SearchAll;
            ViewBag.FaNumberSortOrder = sortOrder == "FaNumberSortOrder" ? "FaNumberSortOrder_Desc" : "FaNumberSortOrder";
            ViewBag.PrioritySortOrder = sortOrder == "PrioritySortOrder" ? "PrioritySortOrder_Desc" : "PrioritySortOrder";
            ViewBag.OverallFASortOrder = sortOrder == "OverallFASortOrder" ? "OverallFASortOrder_Desc" : "OverallFASortOrder";
            ViewBag.StatusSortOrder = sortOrder == "StatusSortOrder" ? "StatusSortOrder_Desc" : "StatusSortOrder";
            ViewBag.LabSiteSortOrder = sortOrder == "LabSiteSortOrder" ? "LabSiteSortOrder_Desc" : "LabSiteSortOrder";
            ViewBag.CurrentSort = sortOrder;

            var dashboards = (MasterRepository.GetAll()).
                   Where(x => x.Requestor == CurrentName &&
                       x.StatusId != (int)StatusType.CLOSED).ToList();

            dashboards = SortOrder(sortOrder, dashboards);

            //Get last process flow by masterId
            foreach (var m in dashboards)
            {
                var process = ProcessHisRep.GetMaxProcessByMaster(m.Id);
                if (process != null)
                {
                    m.CurrentProcess = process.ProcessType.Name;
                    if (process.DateOut.HasValue && process.DateIn.HasValue)
                    {
                        m.CurrentProcessCT = (process.DateOut.Value.Date - process.DateIn.Value.Date).Days;
                    }
                }
            }

            if (!String.IsNullOrEmpty(SearchAll))
            {
                var filter = dashboards.Where(x => Contains(x.Number, SearchAll) ||
                            Contains((x.RefNo + ""), SearchAll) ||
                            Contains(x.FARPriority.Name, SearchAll) ||
                            Contains(x.Analyst, (SearchAll)) ||
                            Contains(x.FARStatus.Name, SearchAll) ||
                            Contains(x.Bu.Name, SearchAll) ||
                            Contains(x.Product, SearchAll) ||
                            Contains(x.CurrentProcess, SearchAll) ||
                            Contains(x.LastUpdate.ToString("MM/dd/yyyy"), SearchAll) ||
                            Contains(x.LastUpdatedBy, SearchAll) ||
                            Contains(x.FailureDesc, SearchAll));
                if (filter != null)
                    dashboards = filter.ToList();
            }

            int pageNumber = page ?? 1;
            return PartialView(dashboards.ToPagedList(pageNumber, FastrackConfig.PAGESIZE));
        }

        /// <summary>
        /// Lists as analyst.
        /// </summary>
        /// <returns></returns>
        [HttpGet, Authorize(Roles = AuthRole.Manager)]
        public ActionResult AsManager(int? page, string sortOrder = "FaNumberSortOrder", string SearchAll = null)
        {
            FilterPage obj = new FilterPage
            {
                SortOrder = sortOrder,
                Page = page,
                SearchAll = SearchAll
            };
            return View(obj);
        }

        /// <summary>
        /// Analysises the specified page.
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="page"></param>
        /// <param name="searchAll"></param>
        /// <returns></returns>
        [Authorize(Roles = AuthRole.Manager)]
        public PartialViewResult AsManagement(string sortOrder, int? page, string searchAll = null)
        {
            ViewBag.Search = searchAll;
            ViewBag.FaNumberSortOrder = sortOrder == "FaNumberSortOrder" ? "FaNumberSortOrder_Desc" : "FaNumberSortOrder";
            ViewBag.PrioritySortOrder = sortOrder == "PrioritySortOrder" ? "PrioritySortOrder_Desc" : "PrioritySortOrder";
            ViewBag.OverallFASortOrder = sortOrder == "OverallFASortOrder" ? "OverallFASortOrder_Desc" : "OverallFASortOrder";
            ViewBag.StatusSortOrder = sortOrder == "StatusSortOrder" ? "StatusSortOrder_Desc" : "StatusSortOrder";
            ViewBag.LabSiteSortOrder = sortOrder == "LabSiteSortOrder" ? "LabSiteSortOrder_Desc" : "LabSiteSortOrder";
            ViewBag.CurrentSort = sortOrder;

            var dashboards = (MasterRepository.GetAll()).
               Where(x => x.StatusId != (int)StatusType.CLOSED).
               OrderBy(x => x.Analyst).ToList();

            dashboards = SortOrder(sortOrder, dashboards);

            //Get last process flow by masterId
            foreach (var m in dashboards)
            {
                var process = ProcessHisRep.GetMaxProcessByMaster(m.Id);
                if (process != null)
                {
                    m.CurrentProcess = process.ProcessType.Name;
                    if (process.DateOut.HasValue && process.DateIn.HasValue)
                    {
                        m.CurrentProcessCT = (process.DateOut.Value.Date - process.DateIn.Value.Date).Days;
                    }
                }
            }

            if (!String.IsNullOrEmpty(searchAll))
            {
                var filter = dashboards.Where(x => Contains(x.Number, searchAll) ||
                            Contains((x.RefNo + ""), searchAll) ||
                            Contains(x.Requestor, searchAll) ||
                            Contains(x.FARPriority.Name, searchAll) ||
                            Contains(x.Analyst, (searchAll)) ||
                            Contains(x.FARStatus.Name, searchAll) ||
                            Contains(x.Bu.Name, searchAll) ||
                             Contains(x.Product, searchAll) ||
                            Contains(x.CurrentProcess, searchAll) ||
                            Contains(x.LastUpdate.ToString("MM/dd/yyyy"), searchAll) ||
                            Contains(x.LastUpdatedBy, searchAll) ||
                            Contains(x.FailureDesc, searchAll));
                if (filter != null)
                    dashboards = filter.ToList();
            }

            int pageNumber = page ?? 1;
            return PartialView(dashboards.ToPagedList(pageNumber, FASTrack.Infrastructure.FastrackConfig.PAGESIZE));
        }

        /// <summary>
        /// Lists as analyst.
        /// </summary>
        /// <returns></returns>
        [HttpGet, Authorize(Roles = (AuthRole.Analyst))]
        public ActionResult AsAnalyst(int? page, string sortOrder = "FaNumberSortOrder", string SearchAll = null)
        {
            FilterPage obj = new FilterPage
            {
                SortOrder = sortOrder,
                Page = page,
                SearchAll = SearchAll
            };
            return View(obj);
        }

        /// <summary>
        /// Analysises the specified page.
        /// </summary>
        /// <param name="sortOrder">The viewmodel.</param>
        /// <param name="page">The viewmodel.</param>
        /// <param name="SearchAll">The page.</param>
        /// <returns></returns>
        [Authorize(Roles = (AuthRole.Analyst))]
        public PartialViewResult AsAnalysis(string sortOrder, int? page, string SearchAll = null)
        {
            ViewBag.Search = SearchAll;
            ViewBag.FaNumberSortOrder = sortOrder == "FaNumberSortOrder" ? "FaNumberSortOrder_Desc" : "FaNumberSortOrder";
            ViewBag.PrioritySortOrder = sortOrder == "PrioritySortOrder" ? "PrioritySortOrder_Desc" : "PrioritySortOrder";
            ViewBag.OverallFASortOrder = sortOrder == "OverallFASortOrder" ? "OverallFASortOrder_Desc" : "OverallFASortOrder";
            ViewBag.StatusSortOrder = sortOrder == "StatusSortOrder" ? "StatusSortOrder_Desc" : "StatusSortOrder";
            ViewBag.LabSiteSortOrder = sortOrder == "LabSiteSortOrder" ? "LabSiteSortOrder_Desc" : "LabSiteSortOrder";
            ViewBag.CurrentSort = sortOrder;

            //Get all master
            var dashboards = (MasterRepository.GetAll()).
               Where(x => x.Submitted && (x.StatusId != (int)StatusType.CLOSED)).ToList();

            dashboards = SortOrder(sortOrder, dashboards);

            var exceptDashboard = new List<FARMasterDto>();
            for (int i = 0; i < dashboards.Count; i++)
            {
                var master = dashboards[i];
                //Check analyst in Process has exist with currentName?
                var exist = ProcessHisRep.CheckExistAnalyst(master.Id, this.CurrentName);
                var assign = master.Analyst == (this.CurrentName);
                if (!exist && !assign)
                    //remove item out dashboard
                    exceptDashboard.Add(master);
            }

            if (exceptDashboard != null && exceptDashboard.Count > 0)
                dashboards = dashboards.Except(exceptDashboard).ToList();

            //Get last process flow by masterId
            foreach (var master in dashboards)
            {
                var process = ProcessHisRep.GetMaxProcessByMaster(master.Id);
                if (process != null)
                {
                    master.CurrentProcess = process.ProcessType.Name;
                    if (process.DateOut.HasValue && process.DateIn.HasValue)
                    {
                        master.CurrentProcessCT = (process.DateOut.Value.Date - process.DateIn.Value.Date).Days;
                    }
                }
            }

            if (!String.IsNullOrEmpty(SearchAll))
            {
                var filter = dashboards.Where(x => Contains(x.Number, SearchAll) ||
                            Contains((x.RefNo + ""), SearchAll) ||
                            Contains(x.Requestor, SearchAll) ||
                            Contains(x.FARPriority.Name, SearchAll) ||
                            Contains(x.FARStatus.Name, SearchAll) ||
                            Contains(x.Bu.Name, SearchAll) ||
                             Contains(x.Product, SearchAll) ||
                            Contains(x.CurrentProcess, SearchAll) ||
                            Contains(x.LastUpdate.ToString("MM/dd/yyyy"), SearchAll) ||
                            Contains(x.LastUpdatedBy, SearchAll) ||
                            Contains(x.FailureDesc, SearchAll));
                if (filter != null)
                    dashboards = filter.ToList();
            }

            int pageNumber = page ?? 1;
            return PartialView(dashboards.ToPagedList(pageNumber, FastrackConfig.PAGESIZE));
        }

        /// <summary>
        /// Lists as analyst.
        /// </summary>
        /// <returns></returns>
        [HttpGet, Authorize(Roles = (AuthRole.Admin))]
        public ActionResult AsAdministrator(int? page, string sortOrder = "FaNumberSortOrder", string SearchAll = null)
        {
            FilterPage obj = new FilterPage
            {
                SortOrder = sortOrder,
                Page = page,
                SearchAll = SearchAll
            };
            return View(obj);
        }

        /// <summary>
        ///  Analysises the specified page.
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="page"></param>
        /// <param name="searchAll"></param>
        /// <returns></returns>
        [Authorize(Roles = (AuthRole.Admin))]
        public PartialViewResult AsAdministrators(string sortOrder, int? page, string searchAll = null)
        {
            ViewBag.Search = searchAll;
            ViewBag.FaNumberSortOrder = sortOrder == "FaNumberSortOrder" ? "FaNumberSortOrder_Desc" : "FaNumberSortOrder";
            ViewBag.PrioritySortOrder = sortOrder == "PrioritySortOrder" ? "PrioritySortOrder_Desc" : "PrioritySortOrder";
            ViewBag.OverallFASortOrder = sortOrder == "OverallFASortOrder" ? "OverallFASortOrder_Desc" : "OverallFASortOrder";
            ViewBag.StatusSortOrder = sortOrder == "StatusSortOrder" ? "StatusSortOrder_Desc" : "StatusSortOrder";
            ViewBag.LabSiteSortOrder = sortOrder == "LabSiteSortOrder" ? "LabSiteSortOrder_Desc" : "LabSiteSortOrder";
            ViewBag.CurrentSort = sortOrder;
            //Get all master
            var dashboards = (MasterRepository.GetAll()).
               Where(x => x.Submitted && (x.StatusId != (int)StatusType.CLOSED)).ToList();
            dashboards = SortOrder(sortOrder, dashboards);

            //Get last process flow by masterId
            foreach (var master in dashboards)
            {
                var process = ProcessHisRep.GetMaxProcessByMaster(master.Id);
                if (process != null)
                {
                    master.CurrentProcess = process.ProcessType.Name;
                    if (process.DateOut.HasValue && process.DateIn.HasValue)
                    {
                        master.CurrentProcessCT = (process.DateOut.Value.Date - process.DateIn.Value.Date).Days;
                    }
                }
            }

            if (!String.IsNullOrEmpty(searchAll))
            {
                var filter = dashboards.Where(x => Contains(x.Number, searchAll) ||
                            Contains((x.RefNo + ""), searchAll) ||
                            Contains(x.Requestor, searchAll) ||
                            Contains(x.FARPriority.Name, searchAll) ||
                            Contains(x.FARStatus.Name, searchAll) ||
                            Contains(x.Bu.Name, searchAll) ||
                             //Contains(x.FARProduct.Name, SearchAll) ||
                             Contains(x.Product, searchAll) ||
                            Contains(x.CurrentProcess, searchAll) ||
                            Contains(x.LastUpdate.ToString("MM/dd/yyyy"), searchAll) ||
                            Contains(x.LastUpdatedBy, searchAll) ||
                            Contains(x.FailureDesc, searchAll));
                if (filter != null)
                    dashboards = filter.ToList();
            }

            int pageNumber = page ?? 1;
            return PartialView(dashboards.ToPagedList(pageNumber, FastrackConfig.PAGESIZE));
        }

        /// <summary>
        /// Closeds the request.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="sortOrder">The sort order.</param>
        /// <param name="SearchAll">The search all.</param>
        /// <returns>ActionResult.</returns>
        [HttpGet, Authorize]
        public ActionResult ClosedRequest(int? page, string sortOrder = "FaNumberSortOrder", string SearchAll = null)
        {
            FilterPage obj = new FilterPage
            {
                Page = page,
                SearchAll = SearchAll
            };
            return View(obj);
        }

        /// <summary>
        /// Lists the closed request.
        /// </summary>
        /// <param name="sortOrder">The sort order.</param>
        /// <param name="page">The page.</param>
        /// <param name="searcAll">The page.</param>
        /// <returns>PartialViewResult.</returns>
        public PartialViewResult ListClosedRequest(string sortOrder, int? page, string searcAll = null)
        {
            ViewBag.FaNumberSortOrder = sortOrder == "FaNumberSortOrder" ? "FaNumberSortOrder_Desc" : "FaNumberSortOrder";
            ViewBag.PrioritySortOrder = sortOrder == "PrioritySortOrder" ? "PrioritySortOrder_Desc" : "PrioritySortOrder";
            ViewBag.OverallFASortOrder = sortOrder == "OverallFASortOrder" ? "OverallFASortOrder_Desc" : "OverallFASortOrder";
            ViewBag.StatusSortOrder = sortOrder == "StatusSortOrder" ? "StatusSortOrder_Desc" : "StatusSortOrder";
            ViewBag.LabSiteSortOrder = sortOrder == "LabSiteSortOrder" ? "LabSiteSortOrder_Desc" : "LabSiteSortOrder";
            ViewBag.CurrentSort = sortOrder;

            var dashboards = (MasterRepository.GetAll()).
             Where(x => x.StatusId == (int)StatusType.CLOSED).ToList();

            dashboards = SortOrder(sortOrder, dashboards);
            //Get last process flow by masterId
            foreach (var master in dashboards)
            {
                var process = ProcessHisRep.GetMaxProcessByMaster(master.Id);
                if (process != null)
                {
                    master.CurrentProcess = process.ProcessType.Name;
                    if (process.DateOut.HasValue && process.DateIn.HasValue)
                    {
                        master.CurrentProcessCT = (process.DateOut.Value.Date - process.DateIn.Value.Date).Days;
                    }
                }
            }

            if (!String.IsNullOrEmpty(searcAll))
            {
                var filter = dashboards.Where(x => Contains(x.Number, searcAll) ||
                            Contains((x.RefNo + ""), searcAll) ||
                            Contains(x.Requestor, searcAll) ||
                            Contains(x.FARPriority.Name, searcAll) ||
                            Contains(x.FARStatus.Name, searcAll) ||
                            Contains(x.Bu.Name, searcAll) ||
                            Contains(x.Product, searcAll) ||
                            Contains(x.CurrentProcess, searcAll) ||
                            Contains(x.LastUpdate.ToString("MM/dd/yyyy"), searcAll) ||
                            Contains(x.LastUpdatedBy, searcAll) ||
                            Contains(x.FailureDesc, searcAll));
                if (filter != null)
                    dashboards = filter.ToList();
            }

            int pageNumber = page ?? 1;
            return PartialView(dashboards.ToPagedList(pageNumber, FastrackConfig.PAGESIZE));
        }
        #endregion End Dashboard

        #region Begin Device/Sample only Requestor execute

        /// <summary>
        /// News the request.
        /// </summary>
        /// <returns></returns>
        [HttpGet, Authorize(Roles = AuthRole.Requestor)]
        public async Task<ActionResult> NewRequest()
        {
            var bind = await BindRequestDashboard();
            bind.Gu = Guid.NewGuid().ToString();
            return View(bind);
        }

        /// <summary>
        /// News the request.
        /// </summary>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <param name="viewmodel">The viewmodel.</param>
        /// <returns>Task&lt;JsonResult&gt;.</returns>
        [HttpPost, Authorize(Roles = AuthRole.Requestor)]
        public async Task<JsonResult> NewRequest(string btnSubmit, FARRequestViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                var bind = await BindRequestDashboard();
                bind.BUId = viewmodel.BUId;
                bind.OriginId = viewmodel.OriginId;
                bind.FailureTypeId = viewmodel.FailureTypeId;
                bind.StatusId = viewmodel.StatusId;
                bind.PriorityId = viewmodel.PriorityId;
                bind.LabSiteId = viewmodel.LabSiteId;
                Response.StatusCode = (int)HttpStatusCode.NotAcceptable;
                return new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { result = "invalidate" }
                };
            }

            string suffix = (await OriginRepository.SingleAsync(viewmodel.OriginId)).Name;
            var newFARNumber = GeneralFARNumber(suffix);
            bool isSubmit = false;
            switch (btnSubmit)
            {
                case "Save":
                    isSubmit = false;
                    break;
                case "Submit":
                    isSubmit = true;
                    break;
            }
            FARMasterDto master = new FARMasterDto()
            {
                Number = newFARNumber,
                OriginId = viewmodel.OriginId,
                Requestor = viewmodel.Requestor,
                RefNo = viewmodel.RefNo,
                FailureTypeId = viewmodel.FailureTypeId,
                FailureOriginId = viewmodel.FailureOriginId,
                FailureRate = viewmodel.FailureRate,
                StatusId = (int)StatusType.OPEN,
                LabSiteId = viewmodel.LabSiteId,
                RequestDate = viewmodel.RequestDate,
                SamplesArriveDate = viewmodel.SamplesArriveDate,
                PriorityId = viewmodel.PriorityId,
                BUId = viewmodel.BUId,
                Product = viewmodel.Product,
                FailureDesc = viewmodel.FailureDesc,
                Customer = viewmodel.Customer,
                LastUpdatedBy = this.CurrentName,
                Submitted = isSubmit,

                //Enhancement
                Comments = String.Empty
            };

            //Enhancement
            if (!String.IsNullOrEmpty(viewmodel.Product))
            {
                try
                {
                    //var products = ProductRepository.FindByName(viewmodel.Product);
                    //Enhacement https://mail.google.com/mail/u/0/?tab=wm#inbox/1549ffc4556acdc7
                    var products = ProductRepository.FindByNameAndLabSite(viewmodel.Product, viewmodel.LabSiteId);
                    if (products != null && products.Count() > 0)
                    {
                        var product = products.First();
                        if (!String.IsNullOrEmpty(product.MainPerson))
                            master.Analyst = product.MainPerson;
                        else
                            if (!String.IsNullOrEmpty(product.SecondaryPerson))
                            master.Analyst = product.SecondaryPerson;
                        else
                                if (!String.IsNullOrEmpty(product.TertiaryPerson))
                            master.Analyst = product.TertiaryPerson;
                    }
                }
                catch (Exception ex)
                {
                    LogService.Error(ex.Message, ex);
                }
            }
            //End Enhancement #18

            var result = await MasterRepository.AddMasterAsync(master);
            if (result > 0)
            {

                if (!String.IsNullOrEmpty(master.Analyst))
                {
                    //SendMail
                    string emailSubject = "FA Request " + master.Number + " has been assigned to you";
                    string ebody = "You have been assigned by " + this.CurrentName + " to oversee FA Number: " + master.Number + ". Please login to FA DB to update its details.";
                    string emailBody = string.Format("{0}<br><br>{1}", ebody, DateTime.Now.ToShortDateString());
                    Mail.Send(master.Analyst, emailSubject, ebody);
                }

                //Copy all files temp tp folder id master, and remove all file temp
                string filesTemp = System.IO.Path.Combine(Server.MapPath("~/Upload/Temp"), viewmodel.Gu);
                if (System.IO.Directory.Exists(filesTemp))
                {
                    //get all files
                    string[] files = System.IO.Directory.GetFiles(filesTemp);
                    string folderMaster = System.IO.Path.Combine(Server.MapPath("~/Upload"), result.ToString().PadLeft(10, '0'));
                    if (!System.IO.Directory.Exists(folderMaster))
                        System.IO.Directory.CreateDirectory(folderMaster);

                    foreach (string file in files)
                    {
                        System.IO.File.Copy(file, System.IO.Path.Combine(folderMaster, System.IO.Path.GetFileName(file)));
                        System.IO.File.Delete(file);
                    }

                    //Remove all file temp
                    System.IO.Directory.Delete(filesTemp);
                }
                Response.StatusCode = (int)HttpStatusCode.OK;
                return new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { code = result }
                };
            }
            else
            {
                var bind = await BindRequestDashboard();
                bind.BUId = viewmodel.BUId;
                bind.OriginId = viewmodel.OriginId;
                bind.FailureTypeId = viewmodel.FailureTypeId;
                bind.StatusId = viewmodel.StatusId;
                bind.PriorityId = viewmodel.PriorityId;
                bind.LabSiteId = viewmodel.LabSiteId;

                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { result = "Failure" }
                };
            }
        }

        /// <summary>
        /// Sampleses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet, Authorize]
        public async Task<ActionResult> ViewSamples(int id)
        {
            ViewBag.MasterId = id;
            var master = (await MasterRepository.SingleAsync(id));

            ViewBag.MasterNumber = master.Number;

            var bind = await DeviceDetailsRepository.FindByAsync(id);
            return View(bind);
        }

        /// <summary>
        /// Sampleses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet, Authorize(Roles = AuthRole.Requestor)]
        public async Task<ActionResult> Samples(int id)
        {
            ViewBag.MasterId = id;
            var master = (await MasterRepository.SingleAsync(id));

            ViewBag.MasterNumber = master.Number;

            var fa_status = (StatusType)master.StatusId;
            var send_status = master.Submitted;

            ViewBag.AddLot = 0;
            if (fa_status == StatusType.OPEN && send_status == false)
                ViewBag.AddLot = 1;

            var bind = await DeviceDetailsRepository.FindByAsync(id);
            return View(bind);
        }

        /// <summary>
        /// Adds the sample.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet, Authorize(Roles = AuthRole.Requestor)]
        public async Task<ActionResult> AddSample(int id)
        {
            ViewBag.Id = id;
            var master = await MasterRepository.SingleAsync(id);
            DeviceDetailsViewModel bind = await BindDeviceDetail();
            bind.MasterId = id;
            bind.FARNumber = master.Number;
            return View(bind);
        }

        /// <summary>
        /// Adds the sample.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="device">The viewmodel.</param>
        /// <returns></returns>
        [HttpPost, Authorize(Roles = AuthRole.Requestor)]
        public async Task<JsonResult> AddSample(int id, DeviceDetailsViewModel device)
        {
            FARDeviceDetailsDto add = new FARDeviceDetailsDto
            {
                MasterId = id,
                ServiceId = device.ServiceId,
                WaferNo = device.WaferNo,
                SerialNo = device.SerialNo,
                LotNo = device.LotNo,
                MfgPartNo = device.MfgPartNo,
                TechnologyId = device.TechnologyId,
                PackageTypeId = device.PackageTypeId,
                AssemblySiteId = device.AssembliesTypeId,
                FabSiteId = device.FabSiteId,
                DateCode = device.DateCode,
                Quantity = device.Quantity,
                Stage = device.StageId == 1 ? true : false,
                LastUpdatedBy = this.CurrentName,
            };
            var result = await DeviceDetailsRepository.AddDeviceAsync(add);
            if (result != null)
            {
                FARMasterDto master = MasterRepository.Single(id);

                if (device.ServiceId == (int)ServiceType.FULL_FA)//Full Service
                    await AddProcess(result.Id, master.Product, true);

                Response.StatusCode = (int)HttpStatusCode.OK;
                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { code = "SV01" }
                };
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { code = "SV02" }
                };
            }
        }

        /// <summary>
        /// Edits the sample.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet, Authorize(Roles = AuthRole.Requestor)]
        public async Task<ActionResult> EditSample(int id)
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var device = await DeviceDetailsRepository.SingleAsync(id);

            if (device == null)
                return HttpNotFound();

            var bind = await BindDeviceDetail();
            bind.Id = id;
            bind.MasterId = device.MasterId;
            bind.PackageTypeId = device.PackageTypeId;
            bind.AssembliesTypeId = device.AssemblySiteId;
            bind.FabSiteId = device.FabSiteId;
            bind.WaferNo = device.WaferNo;
            bind.SerialNo = device.SerialNo;
            bind.FARNumber = device.Master.Number;
            bind.LotNo = device.LotNo;
            bind.MfgPartNo = device.MfgPartNo;
            bind.TechnologyId = device.TechnologyId;
            bind.DateCode = device.DateCode;
            bind.Quantity = device.Quantity;
            bind.StageId = device.Stage ? 1 : 0;
            bind.ServiceId = device.ServiceId;
            return View(bind);
        }

        /// <summary>
        /// Edits the sample.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="deviceDetail">The viewmodel.</param>
        /// <returns></returns>
        [HttpPost, Authorize(Roles = AuthRole.Requestor)]
        public async Task<JsonResult> EditSample(int id, DeviceDetailsViewModel deviceDetail)
        {

            var device = await DeviceDetailsRepository.SingleAsync(id);
            if (device != null)
            {
                device.PackageTypeId = deviceDetail.PackageTypeId;
                device.AssemblySiteId = deviceDetail.AssembliesTypeId;
                device.FabSiteId = deviceDetail.FabSiteId;
                device.SerialNo = deviceDetail.SerialNo;
                device.WaferNo = deviceDetail.WaferNo;
                device.MfgPartNo = deviceDetail.MfgPartNo;
                device.Quantity = deviceDetail.Quantity;
                device.Stage = deviceDetail.StageId == 1 ? true : false;
                device.TechnologyId = deviceDetail.TechnologyId;
                device.DateCode = deviceDetail.DateCode;
                device.LastUpdatedBy = this.CurrentName;
                device.ServiceId = deviceDetail.ServiceId;

                var result = await DeviceDetailsRepository.UpdateAsync(device);
                if (result == Model.SaveResult.SUCCESS)
                {
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { code = deviceDetail.MasterId }
                    };
                }
            }
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new { code = deviceDetail.MasterId }
            };
            //return View(bind);
        }

        /// <summary>
        /// Deletes the sample.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet, Authorize(Roles = AuthRole.Requestor)]
        public async Task<ActionResult> DeleteSample(int id)
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var device = await DeviceDetailsRepository.SingleAsync(id);

            return View(device);
        }

        /// <summary>
        /// Deletes the sample.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="device">The device.</param>
        /// <returns></returns>
        [HttpPost, Authorize(Roles = AuthRole.Requestor)]
        public async Task<JsonResult> DeleteSample(int id, FARDeviceDetailsDto device)
        {
            var result = await DeviceDetailsRepository.DeleteByAsync(id);
            if (result == Model.SaveResult.SUCCESS)
            {
                Response.StatusCode = (int)HttpStatusCode.OK;
                return new JsonResult
                {
                    JsonRequestBehavior = System.Web.Mvc.JsonRequestBehavior.AllowGet,
                    Data = new { code = device.MasterId }
                };
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { code = device.MasterId }
                };
                //return View(device);
            }
        }

        /// <summary>
        /// Views the samples.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet, Authorize(Roles = AuthRole.Analyst)]
        public ActionResult AnaSamples(int id)
        {
            ViewBag.Id = id;
            var master = MasterRepository.Single(id);
            if (master != null)
                ViewBag.Number = master.Number;

            return View();
        }

        /// <summary>
        /// Anas the sample list.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        [HttpGet, Authorize(Roles = AuthRole.Analyst)]
        public ActionResult AnaSampleList(int id, int? page)
        {
            var bind = (DeviceDetailsRepository.GetAll()).Where(w => w.MasterId == id);
            int pageNumber = page ?? 1;
            return View(bind.ToPagedList(pageNumber, FastrackConfig.PAGESIZE));
        }

        /// <summary>
        /// Views the samples.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet, Authorize(Roles = AuthRole.Manager)]
        public ActionResult ManSamples(int id)
        {
            var master = MasterRepository.Single(id);
            if (master == null)
                Response.StatusCode = (int)HttpStatusCode.BadRequest;

            FilterSample filter = new FilterSample
            {
                Id = id,
                FANumber = master.Number,
                Page = null,
            };
            return View(filter);
        }

        /// <summary>
        /// Mans the sample list.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        [HttpGet, Authorize(Roles = AuthRole.Manager)]
        public PartialViewResult ManSampleList(int id, int? page)
        {
            var bind = (DeviceDetailsRepository.GetAll()).Where(w => w.MasterId == id);
            int pageNumber = page ?? 1;
            return PartialView(bind.ToPagedList(pageNumber, FastrackConfig.PAGESIZE));
        }

        #endregion End Device/Sample

        #region Begin FAProcess
        /// <summary>
        /// Mans the process.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet, Authorize(Roles = AuthRole.Manager)]
        public async Task<ActionResult> ManProcess(int id)//idDevice
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var users = UserRepository.GetAll().Where(x => (x.RoleId == (int)RoleType.ANALYST || x.RoleId == (int)RoleType.MANAGER) && x.IsLocked == false);
            var device = await DeviceDetailsRepository.SingleAsync(id);
            var process = new ProcessHistoryViewModel();
            if (device == null)
                return HttpNotFound();
            else
            {
                process.DeviceId = id;
                process.Device = device;
                process.MasterId = device.MasterId;
                process.Number = device.Master.Number;
                process.Users = users;
            }

            var items = (await ProcessHisRep.GetAllAsync()).Where(x => x.DeviceId == id).OrderBy(x => x.Id).ToList();
            foreach (var item in items)
            {
                item.IsHasPhotos = CheckExistPhoto(item);
            }
            process.Process = items;

            return View(process);
        }

        /// <summary>
        /// Mans the process.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="process">The process.</param>
        /// <param name="history">The history.</param>
        /// <returns>Task&lt;JsonResult&gt;.</returns>
        [HttpPost, Authorize(Roles = AuthRole.Manager)]
        public async Task<JsonResult> ManProcess(int id, ProcessHistoryViewModel process, List<FARProcessHistoryDto> history)
        {
            if (id == 0)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { code = "SB02" }
                };
            }

            var result = FASTrack.Model.SaveResult.FAILURE;
            foreach (var item in history)
            {
                if (item.IsRemove)
                    result = await ProcessHisRep.DeleteByAsync(item.Id);
            }
            switch (result)
            {
                case Model.SaveResult.SUCCESS:
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { code = "SB01" }
                    };
                default:
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { code = "SB03" }
                    };
            }
        }

        /// <summary>
        /// Edits the process.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="viewmodel">The viewmodel.</param>
        /// <returns></returns>
        [HttpPost, Authorize(Roles = AuthRole.Manager)]
        public ActionResult ManEditProcess(int id, FARProcessViewModel viewmodel)
        {
            if (!ModelState.IsValid)
                return View(viewmodel);

            var result = ProcessHisRep.Single(id);

            if (result != null)
            {
                if (viewmodel.ProcessResultId != 0)
                    result.ProcessResultId = viewmodel.ProcessResultId;

                var planInOld = result.PlannedIn;
                var planOutOld = result.PlannedOut;

                result.PlannedIn = viewmodel.PlannedIn;
                result.PlannedOut = viewmodel.PlannedOut;
                result.DateIn = viewmodel.DateIn;
                result.DateOut = viewmodel.DateOut;
                result.LastUpdatedBy = this.CurrentName;
                result.Comment = viewmodel.Comment;

                Model.SaveResult saveResult = ProcessHisRep.Update(result);
                if (saveResult == Model.SaveResult.SUCCESS)
                {
                    try
                    {
                        if (planInOld != viewmodel.PlannedIn)
                            LogProHisRep.Add(new LOGProcessHistoryDto()
                            {
                                ProcessHisId = id,
                                Description = "Add auto",
                                PlanFrom = planInOld,
                                PlanTo = viewmodel.PlannedIn,
                                PlanType = PlanType.IN,
                                InsertedBy = CurrentName,
                            });

                        if (planOutOld != viewmodel.PlannedOut)
                        {
                            LogProHisRep.Add(new LOGProcessHistoryDto()
                            {
                                ProcessHisId = id,
                                Description = "Add auto",
                                PlanFrom = planOutOld,
                                PlanTo = viewmodel.PlannedOut,
                                PlanType = PlanType.OUT,
                                InsertedBy = CurrentName,
                            });
                        }
                    }
                    catch { }
                }
            }

            return RedirectToAction("ManProcess", new { id = viewmodel.DeviceId });
        }

        /// <summary>
        /// Processes the list.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet, Authorize]
        public async Task<ActionResult> ViewProcessList(int id)//idDevice
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var device = await DeviceDetailsRepository.SingleAsync(id);
            var process = new ProcessHistoryViewModel();
            if (device == null)
                return HttpNotFound();
            else
            {
                process.DeviceId = id;
                process.Device = device;
                process.MasterId = device.MasterId;
                process.Number = device.Master.Number;
            }

            var items = (await ProcessHisRep.GetAllAsync()).Where(x => x.DeviceId == id).OrderBy(x => x.Id).ToList();

            foreach (var item in items)
            {
                item.IsHasPhotos = CheckExistPhoto(item);
                var existUser = UserRepository.CheckExistEmail(item.Analystor);
                if (existUser != null)
                    item.Analyst.Sites = existUser.Sites;
            }
            process.Process = items;

            return View(process);
        }

        /// <summary>
        /// Processes the list.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet, Authorize(Roles = AuthRole.Requestor)]
        public async Task<ActionResult> ProcessList(int id)//idDevice
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var device = await DeviceDetailsRepository.SingleAsync(id);
            var process = new ProcessHistoryViewModel();
            if (device == null)
                return HttpNotFound();
            else
            {
                process.DeviceId = id;
                process.Device = device;
                process.MasterId = device.MasterId;
                process.Number = device.Master.Number;
            }

            //var items = (await ProcessHistoryRepository.GetAllAsync()).Where(x => x.DeviceId == id).OrderBy(x => x.SeqNum).ToList();
            var items = (await ProcessHisRep.GetAllAsync()).Where(x => x.DeviceId == id).OrderBy(x => x.Id).ToList();

            foreach (var item in items)
            {
                item.IsHasPhotos = CheckExistPhoto(item);
                var existUser = UserRepository.CheckExistEmail(item.Analystor);
                if (existUser != null)
                    item.Analyst.Sites = existUser.Sites;
            }
            process.Process = items;

            return View(process);
        }

        /// <summary>
        /// Processes the list.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="process">The process.</param>
        /// <param name="history">The history.</param>
        /// <returns></returns>
        [HttpPost, Authorize(Roles = AuthRole.Requestor)]
        public async Task<JsonResult> ProcessList(int id, ProcessHistoryViewModel process, List<FARProcessHistoryDto> history)
        {
            if (id == 0)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { code = "SV02" }
                };
            }

            var result = FASTrack.Model.SaveResult.FAILURE;
            foreach (var item in history)
            {
                if (item.IsRemove)
                    result = await ProcessHisRep.DeleteByAsync(item.Id);
            }
            switch (result)
            {
                case Model.SaveResult.SUCCESS:
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { code = "SV01" }
                    };
                default:
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { code = "SV03" }
                    };
            }
        }

        /// <summary>
        /// Processes the list.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet, Authorize(Roles = AuthRole.Analyst)]
        public async Task<ActionResult> AnaProcess(int id)//idDevice
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var device = await DeviceDetailsRepository.SingleAsync(id);
            var user = UserRepository.GetAll().Where(x => (x.RoleId == (int)RoleType.ANALYST || x.RoleId == (int)RoleType.MANAGER) && x.IsLocked == false);
            var process = new AnaProcessViewModel();
            if (device == null || user == null)
                return HttpNotFound();
            else
            {
                process.DeviceId = id;
                process.MasterId = device.MasterId;
                process.Number = device.Master.Number;
                process.Users = user;
            }

            var proHistory = (await ProcessHisRep.GetAllAsync()).Where(x => x.DeviceId == id).OrderBy(x => x.Id).ToList();
            if (proHistory != null)
            {
                foreach (FARProcessHistoryDto item in proHistory)
                {
                    var existUser = UserRepository.CheckExistEmail(item.Analystor);
                    if (existUser != null)
                        item.Site = existUser.Sites.Name;
                }
            }
            process.Process = proHistory;
            var proResult = (await ProcessResultRepository.GetAllAsync());
            process.ProcessResult = proResult;

            return View(process);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="process"></param>
        /// <param name="history"></param>
        /// <returns></returns>
        [HttpPost, Authorize(Roles = AuthRole.Analyst)]
        public async Task<JsonResult> AnaProcess(int id, ProcessHistoryViewModel process, List<FARProcessHistoryDto> history)
        {
            if (id == 0)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { code = "SB02" }
                };
            }

            var result = FASTrack.Model.SaveResult.FAILURE;
            foreach (var item in history)
            {
                if (item.IsRemove)
                    result = await ProcessHisRep.DeleteByAsync(item.Id);
            }
            switch (result)
            {
                case Model.SaveResult.SUCCESS:
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { code = "SB01" }
                    };
                default:
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { code = "SB03" }
                    };
            }
        }

        /// <summary>
        /// Edits the process.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="viewmodel">The viewmodel.</param>
        /// <returns></returns>
        [HttpPost, Authorize(Roles = AuthRole.Analyst)]
        public ActionResult EditProcess(int id, FARProcessViewModel viewmodel)
        {
            if (!ModelState.IsValid)
                return View(viewmodel);

            var result = ProcessHisRep.Single(id);

            if (result != null)
            {
                if (viewmodel.ProcessResultId != 0)
                    result.ProcessResultId = viewmodel.ProcessResultId;

                var planInOld = result.PlannedIn;
                var planOutOld = result.PlannedOut;

                result.PlannedIn = viewmodel.PlannedIn;
                result.PlannedOut = viewmodel.PlannedOut;
                result.DateIn = viewmodel.DateIn;
                result.DateOut = viewmodel.DateOut;
                result.LastUpdatedBy = this.CurrentName;
                result.Comment = viewmodel.Comment;

                Model.SaveResult saveResult = ProcessHisRep.Update(result);
                if (saveResult == Model.SaveResult.SUCCESS)
                {
                    try
                    {
                        if (planInOld != viewmodel.PlannedIn)
                            LogProHisRep.Add(new LOGProcessHistoryDto()
                            {
                                ProcessHisId = id,
                                Description = "Add auto",
                                PlanFrom = planInOld,
                                PlanTo = viewmodel.PlannedIn,
                                PlanType = PlanType.IN,
                                InsertedBy = CurrentName,
                            });

                        if (planOutOld != viewmodel.PlannedOut)
                        {
                            LogProHisRep.Add(new LOGProcessHistoryDto()
                            {
                                ProcessHisId = id,
                                Description = "Add auto",
                                PlanFrom = planOutOld,
                                PlanTo = viewmodel.PlannedOut,
                                PlanType = PlanType.OUT,
                                InsertedBy = CurrentName,
                            });
                        }
                    }
                    catch { }
                }
            }

            return RedirectToAction("AnaProcess", new { id = viewmodel.DeviceId });
        }

        /// <summary>
        /// Gets the process.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetProcess(int id)
        {
            var processHistotry = ProcessHisRep.Single(id);
            var processResult = ProcessResultRepository.GetByProcessTypeId(processHistotry.ProcessTypeId);
            int duration = 0;
            if (processHistotry.DateIn.HasValue && processHistotry.DateOut.HasValue)
            {
                duration = (processHistotry.DateOut.Value - processHistotry.DateIn.Value).Days;
            }
            var bind = new
            {
                DeviceId = processHistotry.DeviceId,
                ProcessResultId = processHistotry.ProcessResultId,
                Number = processHistotry.Device.Master.Number,
                Analystor = processHistotry.Analystor,
                Comment = processHistotry.Comment,
                PlannedIn = processHistotry.PlannedIn.HasValue ? processHistotry.PlannedIn.Value.ToString("MM/dd/yyyy") : "",
                PlannedOut = processHistotry.PlannedOut.HasValue ? processHistotry.PlannedOut.Value.ToString("MM/dd/yyyy") : "",
                DateIn = processHistotry.DateIn.HasValue ? processHistotry.DateIn.Value.ToString("MM/dd/yyyy") : "",
                DateOut = processHistotry.DateOut.HasValue ? processHistotry.DateOut.Value.ToString("MM/dd/yyyy") : "",
                Description = processHistotry.ProcessType.Description,
                LastUpdatedBy = processHistotry.LastUpdatedBy,
                LastUpdate = processHistotry.LastUpdate,
                Iteration = processHistotry.Iteration,
                IsIncluded = processHistotry.IsIncluded,
                SeqNum = processHistotry.SeqNum,
                Duration = duration,
                Accept = FastrackConfig.FILEEXTENSION,
                ProcessResults = processResult
            };

            return Json(bind, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Sets the anayst.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <param name="ProcessId">The process identifier.</param>
        /// <param name="DeviceId">The device identifier.</param>
        /// <returns></returns>
        [HttpPost, Authorize]
        public ActionResult SetAnayst(string Email, int ProcessId, int DeviceId)
        {
            var item = ProcessHisRep.Single(ProcessId);
            if (item != null)
            {
                item.Analystor = Email;
                item.LastUpdatedBy = this.CurrentName;

                ProcessHisRep.Update(item);
            }
            return RedirectToAction("AnaProcess", new { id = DeviceId });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="ProcessId"></param>
        /// <param name="DeviceId"></param>
        /// <returns></returns>
        [HttpPost, Authorize]
        public ActionResult AssignAnalyst(string Email, int ProcessId, int DeviceId)
        {
            var item = ProcessHisRep.Single(ProcessId);
            if (item != null)
            {
                item.Analystor = Email;
                item.LastUpdatedBy = this.CurrentName;

                ProcessHisRep.Update(item);
            }
            return RedirectToAction("ManProcess", new { id = DeviceId });
        }

        #endregion End FAProcess

        #region Action FA
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Authorize]
        public async Task<ActionResult> ViewFA(int id)//id of the Id Maser
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            FAREditRequestViewModel farRequest = await BindEditFA(id);
            if (farRequest == null)
                return HttpNotFound();

            return View(farRequest);
        }

        /// <summary>
        /// Edits the fa.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet, Authorize(Roles = AuthRole.Requestor)]
        public async Task<ActionResult> ReEditFA(int id)//id of the Id Maser
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            FAREditRequestViewModel farRequest = await BindEditFA(id);
            if (farRequest == null)
                return HttpNotFound();

            return View(farRequest);
        }

        /// <summary>
        /// Edits the fa.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="farRequest">The far request.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        [HttpPost, Authorize(Roles = AuthRole.Requestor)]
        public async Task<JsonResult> ReEditFA(int id, FAREditRequestViewModel farRequest, string btnSubmit)
        {
            var bind = await BindEditFA(id);

            #region Execute button Recall
            if (btnSubmit == "Recall")
            {
                //Find master by id
                var master = MasterRepository.Single(id);
                master.Submitted = false;
                var updateResult = MasterRepository.Update(master);
                if (updateResult == Model.SaveResult.SUCCESS)
                {
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { code = "RE01" }
                    };
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { code = "RE02" }
                    };
                }
            }
            #endregion

            bool isSubmit = false;
            farRequest.Id = id;
            switch (btnSubmit)
            {
                case "Save":
                    break;
                case "Submit":
                    isSubmit = ProcessHisRep.CheckExistProcess(id);
                    break;
            }

            #region button Save or Submit execute
            FARMasterDto add = new FARMasterDto
            {
                Id = id,
                Number = farRequest.FARNumber,
                OriginId = farRequest.OriginId,
                Requestor = farRequest.Requestor,
                RefNo = farRequest.RefNo,
                FailureTypeId = farRequest.FailureTypeId,
                FailureOriginId = farRequest.FailureOriginId,
                FailureRate = farRequest.FailureRate,
                RequestDate = farRequest.RequestDate,
                SamplesArriveDate = null,
                PriorityId = farRequest.PriorityId,
                BUId = farRequest.BUId,
                Product = farRequest.Product,
                LabSiteId = farRequest.LabSiteId,
                InitialReportTargetDate = farRequest.InitialReportTargetDate,
                FinalReportTargetDate = farRequest.FinalReportTargetDate,
                FailureDesc = farRequest.FailureDesc,
                Analyst = bind.Analyst,
                StatusId = farRequest.StatusId,
                Customer = farRequest.Customer,
                Comments = String.Empty,
                LastUpdatedBy = this.CurrentName,
                Submitted = isSubmit,
            };

            var result = await MasterRepository.UpdateAsync(add);
            if (result == Model.SaveResult.SUCCESS)
            {
                if (isSubmit)
                {
                    string emailToAddress = GetManagers();
                    string emailSubject = "New FA Request";
                    string ebody = "FA Number: " + farRequest.FARNumber + " has been added to your queue. Please login to FA DB for your review and Analyst assignment.";
                    string emailBody = string.Format("{0}<br><br>{1}", ebody, DateTime.Now.ToShortDateString());
                    try
                    {
                        Mail.Send(emailToAddress, emailSubject, ebody);
                    }
                    catch (Exception ex)
                    {
                        LogService.Error(ex.Message, ex);
                    }
                }

                Response.StatusCode = (int)HttpStatusCode.OK;
                if (btnSubmit == "Submit")
                {
                    if (isSubmit)
                    {
                        return new JsonResult
                        {
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                            Data = new { code = "SB01" }
                        };
                    }
                    else
                    {
                        return new JsonResult
                        {
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                            Data = new { code = "SB02" }
                        };
                    }
                }

                if (btnSubmit == "Save")
                {
                    return new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { code = "SV01" }
                    };
                }
            }
            #endregion

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new { code = "04" }
            };
        }

        /// <summary>
        /// Cancels the fa.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost, Authorize(Roles = AuthRole.Requestor)]
        public async Task<JsonResult> CancelFA(int id)
        {
            //update master Status is Cancelled
            //Update Master is Open 
            var master = await MasterRepository.SingleAsync(id);
            master.StatusId = (int)StatusType.CANCEL;
            master.LastUpdatedBy = this.CurrentName;

            var saveResult = await MasterRepository.UpdateAsync(master);
            if (saveResult == Model.SaveResult.SUCCESS)
            {
                Response.StatusCode = (int)HttpStatusCode.OK;
                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { code = "CA01" }
                };
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { code = "CA02" }
                };
            }
        }

        /// <summary>
        /// Closes the fa.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="RatingId">The viewmodel.</param>
        /// <param name="Comments">The viewmodel.</param>
        /// <returns></returns>
        [HttpPost, Authorize(Roles = AuthRole.Requestor)]
        public async Task<JsonResult> CloseFA(int id, int RatingId, string Comments)
        {
            var master = await MasterRepository.SingleAsync(id);
            master.StatusId = (int)StatusType.CLOSED;
            master.LastUpdatedBy = this.CurrentName;
            master.RatingId = RatingId;
            master.Comments = Comments;

            var saveResult = await MasterRepository.UpdateAsync(master);
            if (saveResult == Model.SaveResult.SUCCESS)
            {
                Response.StatusCode = (int)HttpStatusCode.OK;
                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { code = "CL01" }
                };
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { code = "CL02" }
                };
            }
        }

        /// <summary>
        /// Views the fa.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet, Authorize(Roles = AuthRole.Manager)]
        public async Task<ActionResult> ManEditFA(int id)
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ViewBag.Hold = 0;
            ViewBag.Release = 0;
            ManRequestViewModel bind = await BindMangerDashboard(id);
            ViewBag.IsManager = User.IsInRole(AuthRole.Manager) ? 1 : 0;
            if (((bind.Analyst == this.CurrentName) || User.IsInRole(AuthRole.Manager)) &&
               ((bind.StatusId == (int)StatusType.ONGOING) || (bind.StatusId == (int)StatusType.OPEN)))
            {
                ViewBag.Hold = 1;
            }

            if ((User.IsInRole(AuthRole.Manager) || (bind.Analyst == this.CurrentName)) &&
              (bind.StatusId == (int)StatusType.HOLD))
            {
                ViewBag.Release = 1;
            }
            ViewBag.Editable = 0;
            if (bind.StatusId == (int)StatusType.ONGOING && this.CurrentName == bind.Analyst)
                ViewBag.Editable = 1;
            return View(bind);
        }

        /// <summary>
        /// Views the fa.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="request">The viewmodel.</param>
        /// <returns></returns>
        [HttpPost, Authorize(Roles = AuthRole.Manager)]
        public async Task<JsonResult> ManEditFA(int id, ManRequestViewModel request)
        {
            var master = await MasterRepository.SingleAsync(id);
            string oldAnalyst = master.Analyst;

            if (master != null)
            {
                string currentName = this.CurrentName;
                if (master.PriorityId != request.PriorityId)
                {
                    FARPriorityLogDto logPriority = new FARPriorityLogDto
                    {
                        MasterId = id,
                        PriorityIdOld = master.PriorityId,
                        PriorityIdNew = request.PriorityId,
                        ReasonId = request.ReasonId,
                        LastUpdatedBy = currentName,
                        IsDeleted = false,
                    };
                    //Log Priority
                    PriorityLogRepository.Add(logPriority);
                }
                var user = UserRepository.Single(request.UserId);
                if (user != null)
                {
                    master.Analyst = user.Email;
                }
                master.PriorityId = request.PriorityId;
                master.LastUpdatedBy = currentName;
                master.StatusId = (int)request.StatusId;
                master.SamplesArriveDate = request.SamplesArriveDate;

                if (request.InitialReportTargetDate != master.InitialReportTargetDate)
                {
                    //Write log
                    FARInitialTargetLogDto logIni = new FARInitialTargetLogDto
                    {
                        MasterId = id,
                        ReasonId = request.InitialReasonId,
                        TargetDate = request.InitialReportTargetDate,
                        LastUpdatedBy = this.CurrentName,
                    };
                    InitialTargetLogRepository.Add(logIni);
                }

                if (request.FinalReportTargetDate != master.FinalReportTargetDate)
                {
                    //Write log
                    FARFinalTargetLogDto logFinal = new FARFinalTargetLogDto
                    {
                        MasterId = id,
                        ReasonId = request.FinalReasonId,
                        TargetDate = request.FinalReportTargetDate,
                        LastUpdatedBy = this.CurrentName,
                    };
                    FinalTargetLogRepository.Add(logFinal);
                }
                if (request.SamplesArriveDate.HasValue)
                {
                    var reportType = ReportTypesRepository.GetAll();
                    if (request.InitialReportTargetDate == null)
                        master.InitialReportTargetDate = request.SamplesArriveDate.Value.AddDays(reportType.Single(x => x.Id == (int)ReportType.INITIAL).DaysAfter);
                    else
                        master.InitialReportTargetDate = request.InitialReportTargetDate;
                    if (request.FinalReportTargetDate == null)
                        master.FinalReportTargetDate = request.SamplesArriveDate.Value.AddDays(reportType.Single(x => x.Id == (int)ReportType.FINAL).DaysAfter);
                    else
                        master.FinalReportTargetDate = request.FinalReportTargetDate;
                }

                var result = await MasterRepository.UpdateAsync(master);
                if (result == Model.SaveResult.SUCCESS)
                {
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    if (oldAnalyst != master.Analyst)
                    {
                        //Add Analyst Reassign Log
                        FARAnalystReassignLogDto analystReassign = new FARAnalystReassignLogDto
                        {
                            MasterId = id,
                            AnalystFrom = oldAnalyst,
                            AnalystTo = master.Analyst,
                            LastUpdatedBy = currentName,
                        };

                        //Log Analyst reassign
                        AnalystReassignLogRepository.Add(analystReassign);
                        //SendMail
                        string emailSubject = "FA Request " + request.FARNumber + " has been assigned to you";
                        string ebody = "You have been assigned by " + currentName + " to oversee FA Number: " + request.FARNumber + ". Please login to FA DB to update its details.";
                        string emailBody = string.Format("{0}<br><br>{1}", ebody, DateTime.Now.ToShortDateString());
                        try
                        {
                            Mail.Send(master.Analyst, emailSubject, ebody);
                        }
                        catch (Exception ex)
                        {
                            LogService.Error(ex.Message, ex);
                        }
                    }

                    return new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new
                        {
                            code = "ED01",
                            initialDate = master.InitialReportTargetDate.HasValue ? master.InitialReportTargetDate.Value.ToString("MM/dd/yyyy") : "",
                            finalDate = master.FinalReportTargetDate.HasValue ? master.FinalReportTargetDate.Value.ToString("MM/dd/yyyy") : ""
                        }
                    };
                }
            }
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new { code = "ED02" }
            };
        }

        /// <summary>
        /// Gets the history priorities.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet, Authorize]
        public PartialViewResult GetHistoryPriorities(int id)
        {
            var model = PriorityLogRepository.GetAll().Where(x => x.MasterId == id);
            return PartialView("_PartialPageHistoryPriorities", model);
        }

        /// <summary>
        /// Views the fa.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet, Authorize(Roles = AuthRole.Analyst)]
        public async Task<ActionResult> AnaEditFA(int id)
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ViewBag.Hold = 0;
            ViewBag.Release = 0;
            AnaRequestViewModel bind = await BindAnalystDashboard(id);
            if ((bind.Analyst == this.CurrentName) &&
              (bind.StatusId == (int)StatusType.ONGOING))
                ViewBag.Hold = 1;

            if ((bind.Analyst == this.CurrentName) && bind.StatusId == (int)StatusType.HOLD)
                ViewBag.Release = 1;

            return View(bind);
        }

        /// <summary>
        /// Views the fa.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="btnSubmit">The viewmodel.</param>
        /// <param name="viewmodel">The viewmodel.</param>
        /// <returns></returns>
        [HttpPost, Authorize(Roles = AuthRole.Analyst)]
        public async Task<JsonResult> AnaEditFA(int id, string btnSubmit, AnaRequestViewModel viewmodel)
        {
            var master = await MasterRepository.SingleAsync(id);

            if (btnSubmit == "Release")
            {
                master.StatusId = (int)StatusType.ONGOING;
                var update = MasterRepository.Update(master);
                if (update == Model.SaveResult.SUCCESS)
                {
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { code = "RL01" }
                    };
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { code = "RL02" }
                    };
                }
            }

            if (master != null)
            {
                if (viewmodel.InitialReportTargetDate != master.InitialReportTargetDate)
                {
                    //Write log
                    FARInitialTargetLogDto logIni = new FARInitialTargetLogDto
                    {
                        MasterId = id,
                        ReasonId = viewmodel.InitialReasonId,
                        TargetDate = viewmodel.InitialReportTargetDate,
                        LastUpdatedBy = this.CurrentName,
                    };
                    InitialTargetLogRepository.Add(logIni);
                }

                if (viewmodel.FinalReportTargetDate != master.FinalReportTargetDate)
                {
                    //Write log
                    FARFinalTargetLogDto logFinal = new FARFinalTargetLogDto
                    {
                        MasterId = id,
                        ReasonId = viewmodel.FinalReasonId,
                        TargetDate = viewmodel.FinalReportTargetDate,
                        LastUpdatedBy = this.CurrentName,
                    };
                    FinalTargetLogRepository.Add(logFinal);
                }
                master.SamplesArriveDate = viewmodel.SamplesArriveDate;
                var reportType = ReportTypesRepository.GetAll();
                if (viewmodel.InitialReportTargetDate == null)
                    master.InitialReportTargetDate = viewmodel.SamplesArriveDate.Value.AddDays(reportType.Single(x => x.Id == (int)ReportType.INITIAL).DaysAfter);
                else
                    master.InitialReportTargetDate = viewmodel.InitialReportTargetDate;
                if (viewmodel.FinalReportTargetDate == null)
                    master.FinalReportTargetDate = viewmodel.SamplesArriveDate.Value.AddDays(reportType.Single(x => x.Id == (int)ReportType.FINAL).DaysAfter);
                else
                    master.FinalReportTargetDate = viewmodel.FinalReportTargetDate;
                master.LastUpdatedBy = this.CurrentName;

                var result = await MasterRepository.UpdateAsync(master);
                if (result == Model.SaveResult.SUCCESS)
                {
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new
                        {
                            code = "ED01",
                            initialDate = master.InitialReportTargetDate.HasValue ? master.InitialReportTargetDate.Value.ToString("MM/dd/yyyy") : "",
                            finalDate = master.FinalReportTargetDate.HasValue ? master.FinalReportTargetDate.Value.ToString("MM/dd/yyyy") : ""
                        }
                    };
                }
            }
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new { code = "ED02" }
            };
        }

        /// <summary>
        /// Anas the report upload.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet, Authorize(Roles = AuthRole.Analyst)]
        public ActionResult AnaReportUpload(int id)
        {
            ReportUpload(id);
            return RedirectToAction("AnaEditFA", routeValues: new { id = id });
        }

        /// <summary>
        /// Mans the report upload.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet, Authorize(Roles = AuthRole.Manager)]
        public ActionResult ManReportUpload(int id)
        {
            ReportUpload(id);
            return RedirectToAction("ManEditFA", routeValues: new { id = id });
        }

        /// <summary>
        /// Reports the upload.
        /// </summary>
        /// <param name="id">The identifier.</param>
        private void ReportUpload(int id)
        {
            string folderData = System.IO.Path.Combine(Server.MapPath("~/Upload"), id.ToString().PadLeft(10, '0'));
            string folderINT = System.IO.Path.Combine(folderData, "INT");
            string folderFIN = System.IO.Path.Combine(folderData, "FIN");

            string[] filesINT = null;
            string[] filesFIN = null;
            if (System.IO.Directory.Exists(folderINT))
                filesINT = System.IO.Directory.GetFiles(folderINT);
            if (System.IO.Directory.Exists(folderFIN))
                filesFIN = System.IO.Directory.GetFiles(folderFIN);

            //Enhancement 13-Oct-15 rev01
            var master = MasterRepository.Single(id);
            var final = ReportRepository.GetBy(master.OriginId, ReportType.FINAL);
            var initial = ReportRepository.GetBy(master.OriginId, ReportType.INITIAL);

            //bool checkFIN = ((filesFIN != null && filesFIN.Length > 0) || (final != null && final.Required == false));
            bool checkFIN = filesFIN != null && filesFIN.Length > 0;
            if (checkFIN)
                master.StatusId = (int)StatusType.FINAL_REPORT_UPLOADED;

            //bool checkINI = ((filesINT != null && filesINT.Length > 0) || (initial != null && initial.Required == false));
            bool checkINI = filesINT != null && filesINT.Length > 0;
            if (checkINI)
                master.StatusId = (int)StatusType.INITIAL_REPORT_UPLOADED;

            if (checkFIN && checkINI)
                //Update status
                master.StatusId = (int)StatusType.REPORTUPLOADED;

            MasterRepository.Update(master);
        }

        /// <summary>
        /// Onholds the specified log.
        /// </summary>
        /// <param name="log">The log.</param>
        /// <returns></returns>
        [HttpPost, Authorize(Roles = AuthRole.Analyst)]
        public async Task<JsonResult> Onhold(LogViewModel log)
        {
            LOGHistoryDto hrl = new LOGHistoryDto();
            hrl.MasterId = log.MasterId;
            hrl.ReasonId = log.ReasonId;
            hrl.StatusId = (int)StatusType.HOLD; //"H";
            hrl.LastUpdatedBy = this.CurrentName;
            hrl.LogDate = DateTime.Now;

            var result = await LogHisRep.AddAsync(hrl);
            if (result == Model.SaveResult.SUCCESS)
            {
                //Update status Master is Hold
                var master = await MasterRepository.SingleAsync(hrl.MasterId);
                if (master == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { code = "OH02" }
                    };
                }

                if (master != null)
                {
                    master.StatusId = (int)StatusType.HOLD;
                    result = await MasterRepository.UpdateAsync(master);
                    if (result == Model.SaveResult.SUCCESS)
                    {
                        Response.StatusCode = (int)HttpStatusCode.OK;
                        return new JsonResult
                        {
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                            Data = new { code = "OH01" }
                        };
                    }
                    else
                    {
                        Response.StatusCode = (int)HttpStatusCode.BadGateway;
                        return new JsonResult
                        {
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                            Data = new { code = "OH02" }
                        };
                    }
                }
            }
            Response.StatusCode = (int)HttpStatusCode.BadGateway;
            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new { code = "OH02" }
            };
        }

        /// <summary>
        /// Releases the fa.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet, Authorize(Roles = AuthRole.Analyst)]
        public async Task<ActionResult> AnaReleaseFA(int id)
        {
            LogViewModel hrl = new LogViewModel();
            var result = await MasterRepository.SingleAsync(id);
            if (result != null)
            {
                hrl.Number = result.Number;
                hrl.ReasonId = 0;
                hrl.StatusId = (int)StatusType.RELEASE;// "G";
                hrl.MasterId = id;
                hrl.Reason = ReasonRepository.GetAll();
            }

            return View(hrl);
        }

        /// <summary>
        /// Releases the fa.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="log">The log.</param>
        /// <returns></returns>
        [HttpPost, Authorize(Roles = AuthRole.Analyst)]
        public async Task<ActionResult> AnaReleaseFA(int id, LogViewModel log)
        {
            ViewBag.RedMessage = null;
            log.Reason = ReasonRepository.GetAll();

            if (!ModelState.IsValid)
                return View(log);

            LOGHistoryDto hrl = new LOGHistoryDto();
            hrl.MasterId = id;
            hrl.ReasonId = log.ReasonId;
            hrl.StatusId = (int)StatusType.ONGOING;// "G";
            hrl.LastUpdatedBy = this.CurrentName;
            hrl.LogDate = DateTime.Now;

            var result = await LogHisRep.AddAsync(hrl);
            if (result == Model.SaveResult.SUCCESS)
            {
                //Upate master field status is Ongoing
                var master = await MasterRepository.SingleAsync(id);
                if (master != null)
                {
                    master.StatusId = (int)StatusType.RELEASE;
                    await MasterRepository.UpdateAsync(master);
                }
            }
            else
            {
                ViewBag.RedMessage = "Has error while Release FA!";
                return View(log);
            }
            return RedirectToAction("AnaEditFA", "Dashboard", new { id = id });
        }

        /// <summary>
        /// Prints the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet, Authorize]
        public ActionResult Print(int id)
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            var master = MasterRepository.Single(id);
            var sample = DeviceDetailsRepository.FindBy(id);
            var lstProcess = new List<FARProcessHistoryDto>();
            foreach (var item in sample)
            {
                var process = ProcessHisRep.GetAll().Where(x => x.DeviceId == item.Id);
                item.ProcessHis = process.ToList();
                //lstProcess.AddRange(process);
            }

            var model = new PrintViewModel
            {
                Master = master,
                Samples = sample,
                Process = lstProcess,
                Site = this.Site,
            };
            return PartialView(model);
        }

        /// <summary>
        /// Res the open fa.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet, Authorize(Roles = AuthRole.Admin)]
        public async Task<ActionResult> ReOpenFA(int id)
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var master = await MasterRepository.SingleAsync(id);
            LogViewModel bind = new LogViewModel();
            if (master != null)
            {
                bind = new LogViewModel
                {
                    MasterId = id,
                    Number = master.Number,
                    ReasonId = 0,
                    StatusId = (int)StatusType.OPEN,// "O",
                    LastUpdatedBy = this.CurrentName,
                    LastUpdate = DateTime.Now,
                };
            }
            return View(bind);
        }

        /// <summary>
        /// Res the open fa.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="viewmodel">The viewmodel.</param>
        /// <returns></returns>
        [HttpPost, Authorize(Roles = AuthRole.Admin)]
        public async Task<ActionResult> ReOpenFA(int id, LogViewModel viewmodel)
        {
            ViewBag.RedMessage = null;
            viewmodel.Reason = ReasonRepository.GetAll();

            if (!ModelState.IsValid)
                return View(viewmodel);

            LOGHistoryDto hrl = new LOGHistoryDto();
            hrl.MasterId = id;
            hrl.ReasonId = viewmodel.ReasonId;
            hrl.StatusId = (int)StatusType.OPEN;// "O";
            hrl.LogDate = DateTime.Now;
            hrl.LastUpdatedBy = this.CurrentName;

            var result = await LogHisRep.AddAsync(hrl);
            if (result == Model.SaveResult.SUCCESS)
            {
                //Update Master is Open 
                var master = await MasterRepository.SingleAsync(id);
                master.StatusId = (int)StatusType.OPEN;
                master.LastUpdatedBy = this.CurrentName;

                await MasterRepository.UpdateAsync(master);
            }
            else
            {
                ViewBag.RedMessage = "Has error while ReOpened FA!";
                return View(viewmodel);
            }

            return RedirectToAction("Index", "ReOpen", new { id = id });
        }
        #endregion

        /// <summary>
        /// Gets the customer.
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns></returns>
        public JsonResult GetCustomer(string term)
        {
            var result = CustomerRepository.SearchByName(term);
            //IEnumerable<String> result = null;
            //if (cus != null)
            //    result = cus.Select(x => x.CustomerName);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns>JsonResult.</returns>
        public JsonResult GetProduct(string term)
        {
            var result = ProductRepository.GetAnyName(term);
            //IEnumerable<String> result = null;
            //if (cus != null)
            //    result = cus.Select(x => x.Name);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #region Function private
        /// <summary>
        /// Binds the request dashboard.
        /// </summary>
        /// <returns></returns>
        private async Task<FARRequestViewModel> BindRequestDashboard()
        {
            var reqOrigin = await OriginRepository.GetAllAsync();
            var reqStat = (await StatusRepository.GetAllAsync()).Where(w => w.Id == (int)StatusType.OPEN);
            var reqBu = await BuRepository.GetAllAsync();
            var reqFailType = await FailureTypeRepository.GetAllAsync();
            var reqProdLine = await ProductRepository.GetAllAsync();
            var reqFailureOrigin = await FailureOriginRepository.GetAllAsync();
            var reqPriority = await PriorityRepository.GetAllAsync();
            var labsites = await LabSiteRepository.GetAllAsync();
            var requestor = this.CurrentName;
            var requestorSite = this.Site;

            FARRequestViewModel bind = new FARRequestViewModel
            {
                Origins = reqOrigin,
                Status = reqStat,
                BUs = reqBu,
                FailureTypes = reqFailType,
                FailureOrigins = reqFailureOrigin,
                Priorities = reqPriority,
                Requestor = requestor,
                Site = requestorSite,
                LabSites = labsites
            };

            return bind;
        }

        /// <summary>
        /// Binds the analyst dashboard.
        /// </summary>
        /// <param name="masterId">The identifier master.</param>
        /// <returns></returns>
        private async Task<AnaRequestViewModel> BindAnalystDashboard(int masterId)
        {
            FARMasterDto master = await MasterRepository.SingleAsync(masterId);

            if (master == null)
                return null;

            var request = await BindRequestDashboard();

            var farRequest = new AnaRequestViewModel
            {
                Id = masterId,
                Analyst = master.Analyst,
                BUId = master.BUId,
                FailureDesc = master.FailureDesc,
                FailureOriginId = master.FailureOriginId,
                FailureRate = master.FailureRate,
                FailureTypeId = master.FailureTypeId,
                FARNumber = master.Number,
                FinalReportTargetDate = master.FinalReportTargetDate,
                InitialReportTargetDate = master.InitialReportTargetDate,
                OriginId = master.OriginId,
                PriorityId = master.PriorityId,
                Product = master.Product,
                RefNo = master.RefNo,
                RequestDate = master.RequestDate,
                Requestor = master.Requestor,
                SamplesArriveDate = master.SamplesArriveDate,
                StatusId = master.StatusId,
                Submitted = master.Submitted,
                Origins = request.Origins,
                Status = request.Status,
                BUs = request.BUs,
                FailureTypes = request.FailureTypes,
                FailureOrigins = request.FailureOrigins,
                Priorities = request.Priorities,
                Site = request.Site,
                InitialReason = await ReasonChangingINITargetRepository.GetAllAsync(), //reason;
                FinalReason = await ReasonChangingFINTargetRepository.GetAllAsync(),// reason;
                OnHoldReason = await ReasonFAROnHoldRepository.GetAllAsync()
            };

            var userRequestor = UserRepository.CheckExistEmail(request.Requestor);
            if (userRequestor != null)
                farRequest.Site = userRequestor.Sites.Name;
            var userAnalyst = UserRepository.CheckExistEmail(master.Analyst);
            if (userAnalyst != null)
                farRequest.UserId = userAnalyst.Id;

            farRequest.Users = (await UserRepository.GetAllAsync()).Where(w => w.RoleId == (int)RoleType.ANALYST || w.RoleId == (int)RoleType.MANAGER);
            farRequest.Status = await StatusRepository.GetAllAsync();

            //Get all files in folder master with id
            string folderMaster = System.IO.Path.Combine(Server.MapPath("~/Upload"), masterId.ToString().PadLeft(10, '0'));
            if (System.IO.Directory.Exists(folderMaster))
            {
                string[] files = System.IO.Directory.GetFiles(folderMaster);
                string json = string.Empty;
                foreach (string file in files)
                {
                    json += "<a href=" + Url.Action("DownloadTemp", "Upload", new { id = masterId, file = System.IO.Path.GetFileName(file) }) + ">" + System.IO.Path.GetFileName(file) + "</a>" + "<br/>";
                }
                farRequest.Reports = json;
            }

            if (farRequest.Reports == null)
                farRequest.Reports = String.Empty;

            return farRequest;
        }

        /// <summary>
        /// Binds the manger dashboard.
        /// </summary>
        /// <param name="masterId">The master identifier.</param>
        /// <returns></returns>
        private async Task<ManRequestViewModel> BindMangerDashboard(int masterId)
        {
            FARMasterDto master = await MasterRepository.SingleAsync(masterId);

            if (master == null)
                return null;

            var request = await BindRequestDashboard();
            var reason = await ReasonPriorityRepository.GetAllAsync();

            var farRequest = new ManRequestViewModel();
            farRequest.Id = masterId;
            farRequest.Analyst = master.Analyst;
            farRequest.BUId = master.BUId;
            farRequest.FailureDesc = master.FailureDesc;
            farRequest.FailureOriginId = master.FailureOriginId;
            farRequest.FailureRate = master.FailureRate;
            farRequest.FailureTypeId = master.FailureTypeId;
            farRequest.FARNumber = master.Number;
            farRequest.FinalReportTargetDate = master.FinalReportTargetDate;
            farRequest.InitialReportTargetDate = master.InitialReportTargetDate;
            farRequest.OriginId = master.OriginId;
            farRequest.PriorityId = master.PriorityId;
            farRequest.Product = master.Product;
            farRequest.RefNo = master.RefNo;
            farRequest.RequestDate = master.RequestDate;
            farRequest.Requestor = master.Requestor;
            farRequest.SamplesArriveDate = master.SamplesArriveDate;
            farRequest.StatusId = master.StatusId;
            farRequest.Submitted = master.Submitted;
            farRequest.Origins = request.Origins;
            farRequest.Status = request.Status;
            farRequest.BUs = request.BUs;
            farRequest.FailureTypes = request.FailureTypes;
            farRequest.FailureOrigins = request.FailureOrigins;
            farRequest.Priorities = request.Priorities;
            farRequest.Site = request.Site;
            farRequest.Reasons = reason;
            farRequest.InitialReason = await ReasonChangingINITargetRepository.GetAllAsync(); //reason;
            farRequest.FinalReason = await ReasonChangingFINTargetRepository.GetAllAsync();// reason;

            var userRequestor = UserRepository.CheckExistEmail(request.Requestor);
            if (userRequestor != null)
                farRequest.Site = userRequestor.Sites.Name;
            var userAnalyst = UserRepository.CheckExistEmail(master.Analyst);
            if (userAnalyst != null)
                farRequest.UserId = userAnalyst.Id;

            //Get user with the roles is Analyst or manager and not locked;
            farRequest.Users = (await UserRepository.GetAllAsync()).Where(w => w.RoleId == (int)RoleType.ANALYST || w.RoleId == (int)RoleType.MANAGER).Where(w => w.IsLocked == false);
            farRequest.Status = await StatusRepository.GetAllAsync();

            //Get all files in folder master with id
            string folderMaster = System.IO.Path.Combine(Server.MapPath("~/Upload"), masterId.ToString().PadLeft(10, '0'));
            if (System.IO.Directory.Exists(folderMaster))
            {
                string[] files = System.IO.Directory.GetFiles(folderMaster);
                string json = string.Empty;
                foreach (string file in files)
                {
                    json += "<a href=" + Url.Action("DownloadTemp", "Upload", new { id = masterId, file = System.IO.Path.GetFileName(file) }) + ">" + System.IO.Path.GetFileName(file) + "</a>" + "<br/>";
                }
                farRequest.Reports = json;
            }
            if (farRequest.Reports == null)
                farRequest.Reports = String.Empty;

            return farRequest;
        }

        /// <summary>
        /// Binds the device detail.
        /// </summary>
        /// <returns></returns>
        private async Task<DeviceDetailsViewModel> BindDeviceDetail()
        {
            var pkgType = await PackageTypesRepository.GetAllAsync();
            var assSite = await AssembliesSiteRepository.GetAllAsync();
            var fabSite = await FabSiteRepository.GetAllAsync();
            var services = await ServiceRepository.GetAllAsync();
            var technogoly = await TechnogolyRepository.GetAllAsync();

            DeviceDetailsViewModel bind = new DeviceDetailsViewModel
            {
                PackageTypes = pkgType,
                AssembliesTypes = assSite,
                FabSites = fabSite,
                Services = services,
                Technogolies = technogoly,
            };

            return bind;
        }

        /// <summary>
        /// Binds the edit fa.
        /// </summary>
        /// <param name="masterId">The master identifier.</param>
        /// <returns></returns>
        private async Task<FAREditRequestViewModel> BindEditFA(int masterId)
        {
            FAREditRequestViewModel farRequest = new FAREditRequestViewModel();
            var master = await MasterRepository.SingleAsync(masterId);

            if (master != null)
            {
                farRequest.Analyst = master.Analyst;
                farRequest.BUId = master.BUId;
                farRequest.FARNumber = master.Number;
                farRequest.FailureDesc = master.FailureDesc;
                farRequest.FailureOriginId = master.FailureOriginId;
                farRequest.FailureRate = master.FailureRate;
                farRequest.FailureTypeId = master.FailureTypeId;
                farRequest.Id = masterId;
                farRequest.InitialReportTargetDate = master.InitialReportTargetDate;
                farRequest.FinalReportTargetDate = master.FinalReportTargetDate;
                farRequest.OriginId = master.OriginId;
                farRequest.PriorityId = master.PriorityId;
                farRequest.Product = master.Product;
                farRequest.RefNo = master.RefNo;
                farRequest.RequestDate = master.RequestDate;
                farRequest.Requestor = master.Requestor;
                farRequest.SamplesArriveDate = master.SamplesArriveDate;
                farRequest.StatusId = master.StatusId;
                farRequest.Customer = master.Customer;
                farRequest.LabSiteId = master.LabSiteId;
                farRequest.Submitted = master.Submitted;
                farRequest.Site = this.Site;
                farRequest.LastUpdate = master.LastUpdate;
            }
            farRequest.Users = (await UserRepository.GetAllAsync()).Where(w => w.RoleId == (int)RoleType.ANALYST);
            farRequest.Origins = await OriginRepository.GetAllAsync();
            farRequest.Status = await StatusRepository.GetAllAsync();
            farRequest.BUs = await BuRepository.GetAllAsync();
            farRequest.FailureTypes = await FailureTypeRepository.GetAllAsync();
            farRequest.FailureOrigins = await FailureOriginRepository.GetAllAsync();
            farRequest.Priorities = await PriorityRepository.GetAllAsync();
            farRequest.ReasonClose = await ReasonFARCloseRepository.GetAllAsync();
            farRequest.LabSites = await LabSiteRepository.GetAllAsync();
            farRequest.Rates = await RatingRep.GetAllAsync();

            //Get all files in folder master with id
            string folderMaster = System.IO.Path.Combine(Server.MapPath("~/Upload"), masterId.ToString().PadLeft(10, '0'));
            if (System.IO.Directory.Exists(folderMaster))
            {
                string[] files = System.IO.Directory.GetFiles(folderMaster);
                string json = string.Empty;
                foreach (string file in files)
                {
                    json += "<a href=" + Url.Action("DownloadTemp", "Upload", new { id = masterId, file = System.IO.Path.GetFileName(file) }) + ">" + System.IO.Path.GetFileName(file) + "</a>" + "<br/>";
                }
                farRequest.Reports = json;
            }

            if (farRequest.Reports == null)
                farRequest.Reports = String.Empty;

            farRequest.EnableSubmit = ProcessHisRep.CheckExistProcess(masterId);
            return farRequest;
        }

        /// <summary>
        /// Gets the managers.
        /// </summary>
        /// <returns></returns>
        private string GetManagers()
        {
            var retval = "";
            var items = UserRepository.GetAll().Where(x => x.RoleId == (int)RoleType.MANAGER);

            foreach (var item in items)
            {
                retval += item.Email.Trim() + ";";
            }
            return retval;
        }

        /// <summary>
        /// Checks the submit.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private int CheckSubmit(int id)
        {
            int retval = 0;
            var mast = MasterRepository.Single(id);

            if (mast != null)
            {
                var samp = DeviceDetailsRepository.GetAll().Where(w => w.MasterId == id).Count();
                var proc = ProcessHisRep.GetAll().Where(w => w.DeviceId == id).Count();
            }
            return retval;
        }

        /// <summary>
        /// Gets the user location.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        private string GetUserLocation(string email)
        {
            var retval = "";
            var user = UserRepository.CheckExistEmail(email);
            if (user != null)
                retval = user.Sites.Name;

            return retval;
        }

        /// <summary>
        /// Generals the far number.
        /// </summary>
        /// <param name="suffix">The suffix.</param>
        /// <returns></returns>
        private string GeneralFARNumber(string suffix)
        {
            int farRecordNumber = MasterRepository.CountRecord() + 1;
            string farNumber = String.Format("{0}{1}{2}", DateTime.Now.ToString("yy"), farRecordNumber.ToString().PadLeft(4, '0'), suffix.Substring(0, 1));

            return farNumber;
        }

        /// <summary>
        /// Loads the processes.
        /// </summary>
        /// <param name="idDevice">The identifier.</param>
        /// <param name="product">The identifier.</param>
        /// <param name="isInclude">The identifier.</param>
        /// <returns></returns>
        private async Task<Model.SaveResult> AddProcess(int idDevice, string product, bool isInclude)
        {
            //insert all records from Process Types
            var proTypes = (await ProcessTypesRepository.GetAllAsync()).OrderBy(q => q.SeqNumber);
            List<FARProcessHistoryDto> lstProcess = new List<FARProcessHistoryDto>();
            foreach (var item in proTypes)
            {
                var fph = new FARProcessHistoryDto();
                var pp = ProProRes.FindBy(item.Id, product);
                if (pp != null)
                    fph.Analystor = pp.InChargePerson;
                else
                    fph.Analystor = "";

                fph.DeviceId = idDevice;
                fph.ProcessTypeId = item.Id;
                fph.Description = item.Description;
                fph.SeqNum = item.SeqNumber ?? 0;
                fph.IsDeleted = false;
                fph.LastUpdatedBy = this.CurrentName;
                fph.IsIncluded = isInclude;
                lstProcess.Add(fph);
            }
            return await ProcessHisRep.AddRangeAsync(lstProcess);
        }

        /// <summary>
        /// Determines whether [contains] [the specified pro].
        /// </summary>
        /// <param name="pro">The pro.</param>
        /// <param name="search">The search.</param>
        /// <returns></returns>
        private bool Contains(string pro, string search)
        {
            if (!String.IsNullOrEmpty(pro))
                return pro.ToLower().Contains(search.ToLower());
            return false;
        }

        /// <summary>
        /// Checks the exist photo.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        private bool CheckExistPhoto(FARProcessHistoryDto item)
        {
            string master = item.Device.MasterId.ToString().PadLeft(10, '0');
            string device = item.DeviceId.ToString().PadLeft(10, '0');
            string process = item.Id.ToString().PadLeft(10, '0');

            string folderProcess = System.IO.Path.Combine(Server.MapPath("~/Upload"), master, "DEVICE", device, process);

            if (System.IO.Directory.Exists(folderProcess))
            {
                //Get all files
                string[] files = System.IO.Directory.GetFiles(folderProcess);
                if (files.Length > 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="masters"></param>
        /// <returns></returns>
        private List<FARMasterDto> SortOrder(string sortOrder, List<FARMasterDto> masters)
        {
            switch (sortOrder)
            {
                case "FaNumberSortOrder":
                    return masters.OrderBy(x => x.Number).ToList();
                case "FaNumberSortOrder_Desc":
                    return masters.OrderByDescending(x => x.Number).ToList();
                case "PrioritySortOrder":
                    return masters.OrderBy(x => x.FARPriority.Name).ToList();
                case "PrioritySortOrder_Desc":
                    return masters.OrderByDescending(x => x.FARPriority.Name).ToList();
                case "OverallFASortOrder":
                    return masters.OrderBy(x => x.OverallCT).ToList();
                case "OverallFASortOrder_Desc":
                    return masters.OrderByDescending(x => x.OverallCT).ToList();
                case "StatusSortOrder":
                    return masters.OrderBy(x => x.FARStatus.Name).ToList();
                case "StatusSortOrder_Desc":
                    return masters.OrderByDescending(x => x.FARStatus.Name).ToList();
                case "LabSiteSortOrder":
                    return masters.OrderBy(x => x.LabSite.Name).ToList();
                case "LabSiteSortOrder_Desc":
                    return masters.OrderByDescending(x => x.LabSite.Name).ToList();
                default:
                    return masters;
            }
        }
        #endregion Func private

        #region Injection Dependecy
        /// <summary>
        /// Gets or sets the log service.
        /// </summary>
        /// <value>
        /// The log service.
        /// </value>
        [Inject]
        public ILogService LogService { get; set; }

        /// <summary>
        /// Gets or sets the master repository.
        /// </summary>
        /// <value>
        /// The master repository.
        /// </value>
        [Inject]
        public IFARMasterRepository MasterRepository { get; set; }

        /// <summary>
        /// Gets or sets the user repository.
        /// </summary>
        /// <value>
        /// The user repository.
        /// </value>
        [Inject]
        public ISYSUsersRepository UserRepository { get; set; }

        /// <summary>
        /// Gets or sets the service repository.
        /// </summary>
        /// <value>
        /// The service repository.
        /// </value>
        [Inject]
        public IMSTServiceRepository ServiceRepository { get; set; }

        /// <summary>
        /// Gets or sets the origin repository.
        /// </summary>
        /// <value>
        /// The origin repository.
        /// </value>
        [Inject]
        public IMSTOriginRepository OriginRepository { get; set; }

        /// <summary>
        /// Gets or sets the status respository.
        /// </summary>
        /// <value>
        /// The status respository.
        /// </value>
        [Inject]
        public IMSTStatusRepository StatusRepository { get; set; }

        /// <summary>
        /// Gets or sets the bu repository.
        /// </summary>
        /// <value>
        /// The bu repository.
        /// </value>
        [Inject]
        public IMSTBuRepository BuRepository { get; set; }

        /// <summary>
        /// Gets or sets the failure type repository.
        /// </summary>
        /// <value>
        /// The failure type repository.
        /// </value>
        [Inject]
        public IMSTFailureTypeRepository FailureTypeRepository { get; set; }

        /// <summary>
        /// Gets or sets the failure origin repository.
        /// </summary>
        /// <value>
        /// The failure origin repository.
        /// </value>
        [Inject]
        public IMSTFailureOriginRepository FailureOriginRepository { get; set; }

        /// <summary>
        /// Gets or sets the priority repository.
        /// </summary>
        /// <value>
        /// The priority repository.
        /// </value>
        [Inject]
        public IMSTPriorityRepository PriorityRepository { get; set; }

        /// <summary>
        /// Gets or sets the product repository.
        /// </summary>
        /// <value>
        /// The product repository.
        /// </value>
        [Inject]
        public IMSTProductRepository ProductRepository { get; set; }

        /// <summary>
        /// Gets or sets the report types repository.
        /// </summary>
        /// <value>
        /// The report types repository.
        /// </value>
        [Inject]
        public IMSTReportTypesRepository ReportTypesRepository { get; set; }

        /// <summary>
        /// Gets or sets the device details repository.
        /// </summary>
        /// <value>
        /// The device details repository.
        /// </value>
        [Inject]
        public IFARDeviceDetailsRepository DeviceDetailsRepository { get; set; }

        /// <summary>
        /// Gets or sets the package types repository.
        /// </summary>
        /// <value>
        /// The package types repository.
        /// </value>
        [Inject]
        public IMSTPackageTypesRepository PackageTypesRepository { get; set; }

        /// <summary>
        /// Gets or sets the assemblies site repository.
        /// </summary>
        /// <value>
        /// The assemblies site repository.
        /// </value>
        [Inject]
        public IMSTAssembliesSiteRepository AssembliesSiteRepository { get; set; }

        /// <summary>
        /// Gets or sets the fab site repository.
        /// </summary>
        /// <value>
        /// The fab site repository.
        /// </value>
        [Inject]
        public IFabSiteRepository FabSiteRepository { get; set; }

        /// <summary>
        /// Gets or sets the process history repository.
        /// </summary>
        /// <value>
        /// The process history repository.
        /// </value>
        [Inject]
        public IFARProcessHistoryRepository ProcessHisRep { get; set; }

        /// <summary>
        /// Gets or sets the log pro his rep.
        /// </summary>
        /// <value>The log pro his rep.</value>
        [Inject]
        public ILOGProcessHistoryRepository LogProHisRep { get; set; }

        /// <summary>
        /// Gets or sets the record lock repository.
        /// </summary>
        /// <value>
        /// The record lock repository.
        /// </value>

        /// <summary>
        /// Gets or sets the analyst reassign log repository.
        /// </summary>
        /// <value>
        /// The analyst reassign log repository.
        /// </value>
        [Inject]
        public IFARAnalystReassignLogRepository AnalystReassignLogRepository { get; set; }

        /// <summary>
        /// Gets or sets the process types repository.
        /// </summary>
        /// <value>
        /// The process types repository.
        /// </value>
        [Inject]
        public IMSTProcessTypesRepository ProcessTypesRepository { get; set; }

        /// <summary>
        /// Gets or sets the history repository.
        /// </summary>
        /// <value>
        /// The history repository.
        /// </value>
        [Inject]
        public ILOGHistoryRepository LogHisRep { get; set; }

        /// <summary>
        /// Gets or sets the process result repository.
        /// </summary>
        /// <value>
        /// The process result repository.
        /// </value>
        [Inject]
        public IMSTProcessResultRepository ProcessResultRepository { get; set; }
        /// <summary>
        /// Gets or sets the reason repository.
        /// </summary>
        /// <value>
        /// The reason repository.
        /// </value>
        [Inject]
        public IHSTReasonRepository ReasonRepository { get; set; }

        /// <summary>
        /// Gets or sets the reason changing ini target repository.
        /// </summary>
        /// <value>
        /// The reason changing ini target repository.
        /// </value>
        [Inject]
        public IMSTReasonChangingINITargetRepository ReasonChangingINITargetRepository { get; set; }

        /// <summary>
        /// Gets or sets the reason changing fin target repository.
        /// </summary>
        /// <value>
        /// The reason changing fin target repository.
        /// </value>
        [Inject]
        public IMSTReasonChangingFINTargetRepository ReasonChangingFINTargetRepository { get; set; }

        /// <summary>
        /// Gets or sets the reason priority repository.
        /// </summary>
        /// <value>
        /// The reason priority repository.
        /// </value>
        [Inject]
        public IMSTReasonChangingPriorityRepository ReasonPriorityRepository { get; set; }

        /// <summary>
        /// Gets or sets the reason far on hold repository.
        /// </summary>
        /// <value>
        /// The reason far on hold repository.
        /// </value>
        [Inject]
        public IMSTReasonFAROnHoldRepository ReasonFAROnHoldRepository { get; set; }

        /// <summary>
        /// Gets or sets the reason far close repository.
        /// </summary>
        /// <value>
        /// The reason far close repository.
        /// </value>
        [Inject]
        public IMSTReasonFARCloseRepository ReasonFARCloseRepository { get; set; }

        /// <summary>
        /// Gets or sets the priority log repository.
        /// </summary>
        /// <value>
        /// The priority log repository.
        /// </value>
        [Inject]
        public IFARPriorityLogRepository PriorityLogRepository { get; set; }

        /// <summary>
        /// Gets or sets the initial target log repository.
        /// </summary>
        /// <value>
        /// The initial target log repository.
        /// </value>
        [Inject]
        public IFARInitialTargetLogRepository InitialTargetLogRepository { get; set; }

        /// <summary>
        /// Gets or sets the final target log repository.
        /// </summary>
        /// <value>
        /// The final target log repository.
        /// </value>
        [Inject]
        public IFARFinalTargetLogRepository FinalTargetLogRepository { get; set; }

        /// <summary>
        /// Gets or sets the customer repository.
        /// </summary>
        /// <value>
        /// The customer repository.
        /// </value>
        [Inject]
        public IMSTCustomerRepository CustomerRepository { get; set; }

        /// <summary>
        /// Gets or sets the report repository.
        /// </summary>
        /// <value>
        /// The report repository.
        /// </value>
        [Inject]
        public IMSTFarReportRepository ReportRepository { get; set; }

        /// <summary>
        /// Gets or sets the pro pro resource.
        /// </summary>
        /// <value>
        /// The pro pro resource.
        /// </value>
        [Inject]
        public IMSTProcessProductRepository ProProRes { get; set; }

        /// <summary>
        /// Gets or sets the lab site repository.
        /// </summary>
        /// <value>
        /// The lab site repository.
        /// </value>
        [Inject]
        public IMSTLabSiteRepository LabSiteRepository { get; set; }

        /// <summary>
        /// Gets or sets the rating rep.
        /// </summary>
        /// <value>The rating rep.</value>
        [Inject]
        public IMSTRatingRepository RatingRep { get; set; }

        /// <summary>
        /// Gets or sets the technogoly repository.
        /// </summary>
        /// <value>The technogoy repository.</value>
        [Inject]
        public IMSTTechnogolyRepository TechnogolyRepository { get; set; }
        #endregion
    }
}
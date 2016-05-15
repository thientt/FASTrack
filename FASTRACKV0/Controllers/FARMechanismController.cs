// ***********************************************************************
// Assembly         : FASTRACKV0
// Author           : tranthiencdsp@gmail.com
// Created          : 11-16-2015
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 04-20-2016
// ***********************************************************************
// <copyright file="FARMechanismController.cs" company="Atmel Corporation">
//     Copyright © Atmel 2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using FASTrack.Infrastructure;
using FASTrack.Model.Abstracts;
using FASTrack.Model.DTO;
using FASTrack.ViewModel;
using Ninject;
using PagedList;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

/// <summary>
/// The Controllers namespace.
/// </summary>
namespace FASTrack.Controllers
{
    /// <summary>
    /// Class FARMechanismController.
    /// </summary>
    [Authorize]
    public class FARMechanismController : AppController
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Lists the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        [HttpGet]
        public PartialViewResult List(int? page)
        {
            var items = MechanismRep.GetAll();
            int pageNumber = page ?? 1;
            return PartialView(items.ToPagedList(pageNumber, FastrackConfig.PAGESIZE));
        }

        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var fs = await MechanismRep.SingleAsync(id);
            if (fs == null)
                return HttpNotFound();

            return View(fs);
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View(new MSTViewModel());
        }

        /// <summary>
        /// Creates the specified viewmodel.
        /// </summary>
        /// <param name="viewmodel">The viewmodel.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create(MSTViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                FARMechanismDto mechanism = new FARMechanismDto
                {
                    Name = viewmodel.Name,
                    Description = viewmodel.Description,
                    LastUpdatedBy = CurrentName
                };
                var result = await MechanismRep.AddAsync(mechanism);

                if (result == Model.SaveResult.SUCCESS)
                    return RedirectToAction("Index");
            }

            return View(viewmodel);
        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            FARMechanismDto mechanism = await MechanismRep.SingleAsync(id);
            if (mechanism == null)
                return HttpNotFound();
            MSTViewModel bind = new MSTViewModel
            {
                Name = mechanism.Name,
                Description = mechanism.Description,
                LastUpdatedBy = mechanism.LastUpdatedBy,
                LastUpdate = mechanism.LastUpdate,
            };

            return View(bind);
        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="viewmodel">The viewmodel.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Edit(int id, MSTViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                FARMechanismDto mechanism = new FARMechanismDto
                {
                    Id = id,
                    Name = viewmodel.Name,
                    Description = viewmodel.Description,
                    LastUpdatedBy = CurrentName,
                };
                var result = await MechanismRep.UpdateAsync(mechanism);
                if (result == Model.SaveResult.SUCCESS)
                    return RedirectToAction("Index");
            }
            return View(viewmodel);
        }

        /// <summary>
        /// Gets or sets the mechanism rep.
        /// </summary>
        /// <value>
        /// The mechanism rep.
        /// </value>
        [Inject]
        public IFARMechanismRepository MechanismRep { get; set; }

        /// <summary>
        /// Gets or sets the device rep.
        /// </summary>
        /// <value>The device rep.</value>
        [Inject]
        public IFARDeviceDetailsRepository DeviceRep { get; set; }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>PartialViewResult.</returns>
        [HttpGet]
        public PartialViewResult GetAll(int id)
        {
            var ms = MechanismRep.GetAll();
            var failureMachanism = DeviceRep.GetFailureMechanism(id);
            
            //Enhancement 19-04-2016
            var device = DeviceRep.Single(id);

            bool isSameOverall = false;

            if (device != null)
            {
                isSameOverall = (device.Master.Analyst == this.CurrentName);
            }
            //End Enhacement 19-04-2016

            FindingViewModel finding = new FindingViewModel
            {
                Mechanism = ms,
                FailureDetail = (failureMachanism != null) ? failureMachanism.FailureDetail : "",
                DeviceId = id,
                MechanismId = (failureMachanism != null) ? failureMachanism.MechanismId.Value : 0,
                IsSameOverall = isSameOverall
            };
            return PartialView("_PartialPageGetAll", finding);
        }

        /// <summary>
        /// Views all.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>PartialViewResult.</returns>
        [HttpGet]
        public PartialViewResult ViewAll(int id)
        {
            var ms = MechanismRep.GetAll();
            var device = DeviceRep.GetFailureMechanism(id);

            FindingViewModel finding = new FindingViewModel
            {
                Mechanism = ms,
                FailureDetail = (device != null) ? device.FailureDetail : "",
                DeviceId = id,
                MechanismId = (device != null) ? device.MechanismId.Value : 0
            };
            return PartialView("_PartialPageViewAll", finding);
        }

        /// <summary>
        /// Finds the save.
        /// </summary>
        /// <param name="DeviceId">The device identifier.</param>
        /// <param name="find">The find.</param>
        /// <returns>JsonResult.</returns>
        public JsonResult FindSave(int DeviceId, FindingViewModel find)
        {
            FARDeviceDetailsDto update = new FARDeviceDetailsDto
            {
                Id = DeviceId,
                MechanismId = find.MechanismId,
                FailureDetail = find.FailureDetail
            };

            var saveResult = DeviceRep.UpdateFailureMechanism(update, this.CurrentName);

            if (saveResult == Model.SaveResult.SUCCESS)
            {
                Response.StatusCode = (int)HttpStatusCode.OK;
                return new JsonResult
                {
                    Data = new { code = "SB01" },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new JsonResult
                {
                    Data = new { code = "SB02" },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }
    }
}

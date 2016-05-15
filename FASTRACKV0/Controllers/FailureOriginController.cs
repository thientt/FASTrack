﻿using FASTrack.Infrastructure;
using FASTrack.Model.Abstracts;
using FASTrack.Model.DTO;
using FASTrack.ViewModel;
using Ninject;
using PagedList;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FASTrack.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize(Roles = AuthRole.Admin)]
    public class FailureOriginController : AppController
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
            var items = FailureOriginRepository.GetAll();
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
            MSTFailureOriginDto failureType = await FailureOriginRepository.SingleAsync(id);
            if (failureType == null)
                return HttpNotFound();

            return View(failureType);
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

        // POST: /BU/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                MSTFailureOriginDto failureType = new MSTFailureOriginDto
                {
                    Name = viewmodel.Name,
                    Description = viewmodel.Description,
                    LastUpdatedBy = CurrentName
                };
                var result = await FailureOriginRepository.AddAsync(failureType);

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

            MSTFailureOriginDto failureType = await FailureOriginRepository.SingleAsync(id);
            if (failureType == null)
                return HttpNotFound();
            MSTViewModel bind = new MSTViewModel
            {
                Name = failureType.Name,
                Description = failureType.Description,
                LastUpdatedBy = failureType.LastUpdatedBy,
                LastUpdate = failureType.LastUpdate,
            };

            return View(bind);
        }

        // POST: /BU/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                MSTFailureOriginDto failureType = new MSTFailureOriginDto
                {
                    Id = id,
                    Name = viewmodel.Name,
                    Description = viewmodel.Description,
                    LastUpdatedBy = CurrentName,
                };
                var result = await FailureOriginRepository.UpdateAsync(failureType);
                if (result == Model.SaveResult.SUCCESS)
                    return RedirectToAction("Index");
            }
            return View(viewmodel);
        }

        ///// <summary>
        ///// Deletes the specified identifier.
        ///// </summary>
        ///// <param name="id">The identifier.</param>
        ///// <returns></returns>
        //[HttpGet]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    if (id == 0)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    MSTFailureOriginDto failureType = await FailureOriginRepository.SingleAsync(id);
        //    if (failureType == null)
        //        return HttpNotFound();

        //    return View(failureType);
        //}

        ///// <summary>
        ///// Deletes the confirmed.
        ///// </summary>
        ///// <param name="id">The identifier.</param>
        ///// <param name="failureOrigin">The failureType.</param>
        ///// <returns></returns>
        //[HttpPost, ActionName("Delete")]
        //public async Task<ActionResult> DeleteConfirmed(int id, MSTFailureOriginDto failureOrigin)
        //{
        //    if (!ModelState.IsValid)
        //        return View(failureOrigin);

        //    if (id == 0)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        //    var result = await FailureOriginRepository.DeleteByAsync(id);
        //    switch (result)
        //    {
        //        case Model.SaveResult.SUCESS:
        //            return RedirectToAction("Index");
        //        default:
        //            return View(failureOrigin);
        //    }
        //}

        /// <summary>
        /// Gets or sets the failureType repository.
        /// </summary>
        /// <value>
        /// The failureType repository.
        /// </value>
        [Inject]
        public IMSTFailureOriginRepository FailureOriginRepository { get; set; }
    }
}
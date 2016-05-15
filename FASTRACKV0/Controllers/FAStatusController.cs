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
/// 
/// </summary>
namespace FASTrack.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize(Roles = AuthRole.Admin)]
    public class FAStatusController : AppController
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
            var items = StatusRespository.GetAll();
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

            MSTStatusDto status = await StatusRespository.SingleAsync(id);

            if (status == null)
                return HttpNotFound();

            return View(status);
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
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create(MSTViewModel model)
        {
            if (ModelState.IsValid)
            {
                MSTStatusDto status = new MSTStatusDto()
                {
                    Name = model.Name,
                    Description = model.Description,
                    LastUpdatedBy = CurrentName
                };
                var result = await StatusRespository.AddAsync(status);

                if (result == Model.SaveResult.SUCCESS)
                    return RedirectToAction("Index");
            }

            return View(model);
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

            MSTStatusDto status = await StatusRespository.SingleAsync(id);

            if (status == null)
                return HttpNotFound();

            MSTViewModel bind = new MSTViewModel
            {
                Id = id,
                Name = status.Name,
                Description = status.Description,
                LastUpdatedBy = status.LastUpdatedBy,
                LastUpdate = status.LastUpdate,
            };
            return View(bind);
        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Edit(int id, MSTViewModel model)
        {
            if (ModelState.IsValid)
            {
                var status = new MSTStatusDto()
                {
                    Id = id,
                    Name = model.Name,
                    Description = model.Description,
                    LastUpdatedBy = CurrentName,
                };
                var result = await StatusRespository.UpdateAsync(status);

                if (result == Model.SaveResult.SUCCESS)
                    return RedirectToAction("Index");
            }

            return View(model);
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

        //    var result = await StatusRespository.SingleAsync(id);

        //    if (result == null)
        //        return HttpNotFound();

        //    return View(result);
        //}

        ///// <summary>
        ///// Deletes the specified identifier.
        ///// </summary>
        ///// <param name="id">The identifier.</param>
        ///// <param name="status">The status.</param>
        ///// <returns></returns>
        //[HttpPost, ActionName("Delete")]
        //public async Task<ActionResult> DeleteConfirmed(int id, MSTStatusDto status)
        //{
        //    if (!ModelState.IsValid)
        //        return View(status);

        //    if (id == 0)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        //    var result = await StatusRespository.DeleteByAsync(id);
        //    switch (result)
        //    {
        //        case Model.SaveResult.SUCESS:
        //            return RedirectToAction("Index");
        //        default:
        //            return View(status);
        //    }
        //}

        /// <summary>
        /// Gets or sets the status respository.
        /// </summary>
        /// <value>
        /// The status respository.
        /// </value>
        [Inject]
        public IMSTStatusRepository StatusRespository { get; set; }
    }
}

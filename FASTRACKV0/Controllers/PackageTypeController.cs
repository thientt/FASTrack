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
    public class PackageTypeController : AppController
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
            var items = PackageTypesRepository.GetAll();
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

            var fs = await PackageTypesRepository.SingleAsync(id);
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
                MSTPackageTypesDto package = new MSTPackageTypesDto
                {
                    Name = viewmodel.Name,
                    Description = viewmodel.Description,
                    LastUpdatedBy = CurrentName
                };
                var result = await PackageTypesRepository.AddAsync(package);

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

            MSTPackageTypesDto package = await PackageTypesRepository.SingleAsync(id);
            if (package == null)
                return HttpNotFound();
            MSTViewModel bind = new MSTViewModel
            {
                Name = package.Name,
                Description = package.Description,
                LastUpdatedBy = package.LastUpdatedBy,
                LastUpdate = package.LastUpdate,
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
                MSTPackageTypesDto package = new MSTPackageTypesDto
                {
                    Id = id,
                    Name = viewmodel.Name,
                    Description = viewmodel.Description,
                    LastUpdatedBy = CurrentName,
                };
                var result = await PackageTypesRepository.UpdateAsync(package);
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
        //    var failureType = await PackageTypesRepository.SingleAsync(id);
        //    if (failureType == null)
        //        return HttpNotFound();

        //    return View(failureType);
        //}

        ///// <summary>
        ///// Deletes the confirmed.
        ///// </summary>
        ///// <param name="id">The identifier.</param>
        ///// <param name="package">The fab site.</param>
        ///// <returns></returns>
        //[HttpPost, ActionName("Delete")]
        //public async Task<ActionResult> DeleteConfirmed(int id, MSTPackageTypesDto package)
        //{
        //    if (!ModelState.IsValid)
        //        return View(package);

        //    if (id == 0)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        //    var result = await PackageTypesRepository.DeleteByAsync(id);
        //    switch (result)
        //    {
        //        case Model.SaveResult.SUCESS:
        //            return RedirectToAction("Index");
        //        default:
        //            return View(package);
        //    }
        //}

        /// <summary>
        /// Gets or sets the package types repository.
        /// </summary>
        /// <value>
        /// The package types repository.
        /// </value>
        [Inject]
        public IMSTPackageTypesRepository PackageTypesRepository { get; set; }
    }
}

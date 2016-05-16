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
    public class AssySitesController : AppController
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
            var items = AssembliesSiteRepository.GetAll();
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

            var assemblysite = await AssembliesSiteRepository.SingleAsync(id);
            if (assemblysite == null)
                return HttpNotFound();

            return View(assemblysite);
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
        /// Creates the specified assemblysite.
        /// </summary>
        /// <param name="assemblysite">The assemblysite.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create(MSTViewModel assemblysite)
        {
            if (ModelState.IsValid)
            {
                MSTAssemblySiteDto data = new MSTAssemblySiteDto()
                {
                    Name = assemblysite.Name,
                    Description = assemblysite.Description,
                    LastUpdatedBy = this.CurrentName,
                };
                var result = await AssembliesSiteRepository.AddAsync(data);
                if (result == Model.SaveResult.SUCCESS)
                    return RedirectToAction("Index");
            }

            return View(assemblysite);
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

            var assemblysite = await AssembliesSiteRepository.SingleAsync(id);

            if (assemblysite == null)
                return HttpNotFound();

            MSTViewModel bind = new MSTViewModel
            {
                Id = assemblysite.Id,
                Name = assemblysite.Name,
                Description = assemblysite.Description,
                LastUpdatedBy = assemblysite.LastUpdatedBy,
                LastUpdate = assemblysite.LastUpdate,
            };
            return View(bind);
        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="assemblysite">The assemblysite.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Edit(int id, MSTViewModel assemblysite)
        {
            if (ModelState.IsValid)
            {
                var item = await AssembliesSiteRepository.SingleAsync(id);
                if (item != null)
                {
                    item.Name = assemblysite.Name;
                    item.Description = assemblysite.Description;
                    item.LastUpdatedBy = this.CurrentName;
                    await AssembliesSiteRepository.UpdateAsync(item);
                    return RedirectToAction("Index");
                }
            }
            return View(assemblysite);
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

        //    var assemblysite = await AssembliesSiteRepository.SingleAsync(id);
        //    if (assemblysite == null)
        //        return HttpNotFound();

        //    return View(assemblysite);
        //}

        ///// <summary>
        ///// Deletes the confirmed.
        ///// </summary>
        ///// <param name="id">The identifier.</param>
        ///// <returns></returns>
        //[HttpPost, ActionName("Delete")]
        //public async Task<ActionResult> DeleteConfirmed(int id, MSTAssemblySiteDto assembly)
        //{
        //    if (!ModelState.IsValid)
        //        return View(assembly);

        //    var result = await AssembliesSiteRepository.DeleteByAsync(id);
        //    switch (result)
        //    {
        //        case Model.SaveResult.SUCESS:
        //            return RedirectToAction("Index");
        //        default:
        //            return View(assembly);
        //    }
        //}

        /// <summary>
        /// Gets or sets the assemblies site repository.
        /// </summary>
        /// <value>
        /// The assemblies site repository.
        /// </value>
        [Inject]
        public IMSTAssembliesSiteRepository AssembliesSiteRepository { get; set; }
    }
}

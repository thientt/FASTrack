using FASTrack.Infrastructure;
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
    public class SitesController : AppController
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
            var items = SiteRepository.GetAll();
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

            SitesDto site = await SiteRepository.SingleAsync(id);
            if (site == null)
                return HttpNotFound();

            return View(site);
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View(new SiteViewModel());
        }

        /// <summary>
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create(SiteViewModel model)
        {
            if (ModelState.IsValid)
            {
                SitesDto site = new SitesDto()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Address1 = model.Address1,
                    Address2 = model.Address2,
                    Phone = model.Phone,
                    LastUpdatedBy = CurrentName,
                };

                var result = await SiteRepository.AddAsync(site);
                switch (result)
                {
                    case Model.SaveResult.SUCCESS:
                        return RedirectToAction("Index");
                    default:
                        return View(site);
                }
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

            SitesDto site = await SiteRepository.SingleAsync(id);
            if (site == null)
                return HttpNotFound();

            SiteViewModel bind = new SiteViewModel
            {
                Id = id,
                Name = site.Name,
                Description = site.Description,
                Address2 = site.Address2,
                Address1 = site.Address1,
                Phone = site.Phone
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
        public async Task<ActionResult> Edit(int id, SiteViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                SitesDto site = new SitesDto
                {
                    Id = id,
                    Name = viewmodel.Name,
                    Description = viewmodel.Description,
                    Address1 = viewmodel.Address1,
                    Address2 = viewmodel.Address2,
                    Phone = viewmodel.Phone,
                    LastUpdatedBy = CurrentName
                };
                var result = await SiteRepository.UpdateAsync(site);
                switch (result)
                {
                    case Model.SaveResult.SUCCESS:
                        return RedirectToAction("Index");
                    default:
                        return View(viewmodel);
                }
            }
            return View(viewmodel);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            SitesDto site = await SiteRepository.SingleAsync(id);
            if (site == null)
                return HttpNotFound();

            return View(site);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="site">The site.</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id, SitesDto site)
        {
            if (!ModelState.IsValid)
                return View(site);

            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            site.LastUpdatedBy = this.CurrentName;
            var result = await SiteRepository.DeleteByAsync(id);
            switch (result)
            {
                case Model.SaveResult.SUCCESS:
                    return RedirectToAction("Index");
                default:
                    return View(site);
            }
        }

        /// <summary>
        /// Gets or sets the site repository.
        /// </summary>
        /// <value>
        /// The site repository.
        /// </value>
        [Inject]
        public IMSTSitesRepository SiteRepository { get; set; }
    }
}

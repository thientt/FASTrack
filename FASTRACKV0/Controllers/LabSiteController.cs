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
    public class LabSiteController : AppController
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
            var items = LabSiteRep.GetAll();
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

            var fs = await LabSiteRep.SingleAsync(id);
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
                MSTLabSiteDto failureType = new MSTLabSiteDto
                {
                    Name = viewmodel.Name,
                    Description = viewmodel.Description,
                    LastUpdatedBy = CurrentName
                };
                var result = await LabSiteRep.AddAsync(failureType);

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

            MSTLabSiteDto labSite = await LabSiteRep.SingleAsync(id);
            if (labSite == null)
                return HttpNotFound();
            MSTViewModel bind = new MSTViewModel
            {
                Name = labSite.Name,
                Description = labSite.Description,
                LastUpdatedBy = labSite.LastUpdatedBy,
                LastUpdate = labSite.LastUpdate,
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
                MSTLabSiteDto labSite = new MSTLabSiteDto
                {
                    Id = id,
                    Name = viewmodel.Name,
                    Description = viewmodel.Description,
                    LastUpdatedBy = CurrentName,
                };
                var result = await LabSiteRep.UpdateAsync(labSite);
                if (result == Model.SaveResult.SUCCESS)
                    return RedirectToAction("Index");
            }
            return View(viewmodel);
        }

        /// <summary>
        /// Gets or sets the lab site rep.
        /// </summary>
        /// <value>
        /// The lab site rep.
        /// </value>
        [Inject]
        public IMSTLabSiteRepository LabSiteRep { get; set; }
    }
}

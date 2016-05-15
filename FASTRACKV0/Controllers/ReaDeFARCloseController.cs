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
    public class ReaDeFARCloseController : AppController
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
            var items = CloseRep.GetAll();
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

            var delayreason = await CloseRep.SingleAsync(id);
            if (delayreason == null)
                return HttpNotFound();

            return View(delayreason);
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates the specified delayreason.
        /// </summary>
        /// <param name="delayreason">The delayreason.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create(DelayReasonViewModel delayreason)
        {
            if (ModelState.IsValid)
            {
                DelayReasonDto data = new DelayReasonDto
                {
                    Description = delayreason.Description,
                    LastUpdatedBy = this.CurrentName,
                };

                var result = await CloseRep.AddAsync(data);
                if (result == Model.SaveResult.SUCCESS)
                    return RedirectToAction("Index");
            }

            return View(delayreason);
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

            var delayreason = await CloseRep.SingleAsync(id);
            if (delayreason == null)
                return HttpNotFound();
            return View(delayreason);
        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="delayreason">The delayreason.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Edit(int id, DelayReasonViewModel delayreason)
        {
            if (ModelState.IsValid)
            {
                DelayReasonDto data = new DelayReasonDto
                {
                    Id = id,
                    Description = delayreason.Description,
                    LastUpdatedBy = this.CurrentName,
                };
                var result = await CloseRep.UpdateAsync(data);
                if (result == Model.SaveResult.SUCCESS)
                    return RedirectToAction("Index");
            }
            return View(delayreason);
        }

        /// <summary>
        /// Gets or sets the close rep.
        /// </summary>
        /// <value>
        /// The close rep.
        /// </value>
        [Inject]
        public IMSTReasonFARCloseRepository CloseRep { get; set; }
    }
}

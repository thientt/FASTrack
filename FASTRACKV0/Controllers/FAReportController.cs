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
    public class FAReportController : AppController
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
            var items = FarReportRepository.GetAll();
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

            var processtype = await FarReportRepository.SingleAsync(id);
            if (processtype == null)
                return HttpNotFound();

            return View(processtype);
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            FAReportViewModel bind = new FAReportViewModel();

            var origins = OriginRepository.GetAll();
            var types = ReportTypeRepository.GetAll();
            bind.Origins = origins;
            bind.ReportTypes = types;
            return View(bind);
        }

        /// <summary>
        /// Creates the specified processtype.
        /// </summary>
        /// <param name="report">The processtype.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create(FAReportViewModel report)
        {
            if (ModelState.IsValid)
            {
                MSTFarReportDto data = new MSTFarReportDto
                {
                    OriginId = report.OriginId,
                    ReportTypeId = report.ReportTypeId,
                    Required = report.Required,
                    Description = report.Description,
                    LastUpdatedBy = this.CurrentName,
                };
                var result = await FarReportRepository.AddAsync(data);
                if (result == Model.SaveResult.SUCCESS)
                    return RedirectToAction("Index");
            }

            return View(report);
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

            var report = await FarReportRepository.SingleAsync(id);
            if (report == null)
                return HttpNotFound();
            FAReportViewModel bind = new FAReportViewModel
            {
                Id = report.Id,
                OriginId = report.OriginId,
                ReportTypeId = report.ReportTypeId,
                Required = report.Required,
                Description = report.Description,
                LastUpdatedBy = report.LastUpdatedBy,
                LastUpdate = report.LastUpdate,
            };
            var origins = await OriginRepository.GetAllAsync();
            var types = await ReportTypeRepository.GetAllAsync();
            bind.Origins = origins;
            bind.ReportTypes = types;

            return View(bind);
        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="report">The processtype.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FAReportViewModel report)
        {
            if (ModelState.IsValid)
            {
                MSTFarReportDto data = new MSTFarReportDto
                {
                    Id = id,
                    OriginId = report.OriginId,
                    ReportTypeId = report.ReportTypeId,
                    Required = report.Required,
                    Description = report.Description,
                    LastUpdatedBy = this.CurrentName
                };
                var result = await FarReportRepository.UpdateAsync(data);
                if (result == Model.SaveResult.SUCCESS)
                    return RedirectToAction("Index");
            }
            return View(report);
        }

        /// <summary>
        /// Gets or sets the far report repository.
        /// </summary>
        /// <value>
        /// The far report repository.
        /// </value>
        [Inject]
        public IMSTFarReportRepository FarReportRepository { get; set; }

        /// <summary>
        /// Gets or sets the report type repository.
        /// </summary>
        /// <value>
        /// The report type repository.
        /// </value>
        [Inject]
        public IMSTReportTypesRepository ReportTypeRepository { get; set; }

        /// <summary>
        /// Gets or sets the origin repository.
        /// </summary>
        /// <value>
        /// The origin repository.
        /// </value>
        [Inject]
        public IMSTOriginRepository OriginRepository { get; set; }
    }
}

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
    public class ReportTypeController : AppController
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
            var items = ReportTypesRepository.GetAll();
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

            var processtype = await ReportTypesRepository.SingleAsync(id);
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
            return View();
        }

        /// <summary>
        /// Creates the specified processtype.
        /// </summary>
        /// <param name="processtype">The processtype.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create(ReportTypeViewModel processtype)
        {
            if (ModelState.IsValid)
            {
                ReportTypesDto data = new ReportTypesDto
                {
                    Name = processtype.Name,
                    Description = processtype.Description,
                    DaysAfter = processtype.DayAfter,
                    LastUpdatedBy = this.CurrentName,
                };
                var result = await ReportTypesRepository.AddAsync(data);
                if (result == Model.SaveResult.SUCCESS)
                    return RedirectToAction("Index");
            }

            return View(processtype);
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

            var processtype = await ReportTypesRepository.SingleAsync(id);
            if (processtype == null)
                return HttpNotFound();
            ReportTypeViewModel bind = new ReportTypeViewModel
            {
                Id = processtype.Id,
                Name = processtype.Name,
                Description = processtype.Description,
                DayAfter = processtype.DaysAfter,
                LastUpdatedBy = processtype.LastUpdatedBy,
                LastUpdate = processtype.LastUpdate,
            };
            return View(bind);
        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="processtype">The processtype.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Edit(int id, ReportTypeViewModel processtype)
        {
            if (ModelState.IsValid)
            {
                ReportTypesDto data = new ReportTypesDto
                {
                    Id = id,
                    Name = processtype.Name,
                    Description = processtype.Description,
                    DaysAfter = processtype.DayAfter,
                    LastUpdatedBy = this.CurrentName
                };
                var result = await ReportTypesRepository.UpdateAsync(data);
                if (result == Model.SaveResult.SUCCESS)
                    return RedirectToAction("Index");
            }
            return View(processtype);
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

        //    var processtype = await ReportTypesRepository.SingleAsync(id);

        //    if (processtype == null)
        //        return HttpNotFound();
        //    return View(processtype);
        //}

        ///// <summary>
        ///// Deletes the confirmed.
        ///// </summary>
        ///// <param name="id">The identifier.</param>
        ///// <param name="process">The viewmodel.</param>
        ///// <returns></returns>
        //[HttpPost, ActionName("Delete")]
        //public async Task<ActionResult> DeleteConfirmed(int id, ReportTypesDto process)
        //{
        //    if (!ModelState.IsValid)
        //        return View(process);

        //    if (id == 0)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        //    var result = await ReportTypesRepository.DeleteByAsync(id);
        //    switch (result)
        //    {
        //        case Model.SaveResult.SUCESS:
        //            return RedirectToAction("Index");
        //        default:
        //            return View(process);
        //    }
        //}

        /// <summary>
        /// Gets or sets the report types repository.
        /// </summary>
        /// <value>
        /// The report types repository.
        /// </value>
        [Inject]
        public IMSTReportTypesRepository ReportTypesRepository { get; set; }
    }
}

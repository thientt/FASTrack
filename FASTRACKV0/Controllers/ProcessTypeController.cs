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
    public class ProcessTypeController : AppController
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
            var items = ProcessTypesRepository.GetAll();
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

            var processtype = await ProcessTypesRepository.SingleAsync(id);
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
        public async Task<ActionResult> Create(ProcessTypeViewModel processtype)
        {
            if (ModelState.IsValid)
            {
                MSTProcessTypesDto data = new MSTProcessTypesDto
                {
                    Name = processtype.Name,
                    Description = processtype.Description,
                    Duration = processtype.Duration,
                    SeqNumber = processtype.SeqNumber,
                    LastUpdatedBy = this.CurrentName,
                };
                var result = await ProcessTypesRepository.AddAsync(data);
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

            var processtype = await ProcessTypesRepository.SingleAsync(id);
            if (processtype == null)
                return HttpNotFound();
            ProcessTypeViewModel bind = new ProcessTypeViewModel
            {
                Id = processtype.Id,
                Name = processtype.Name,
                Description = processtype.Description,
                Duration = processtype.Duration,
                SeqNumber = processtype.SeqNumber,
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
        public async Task<ActionResult> Edit(int id, ProcessTypeViewModel processtype)
        {
            if (ModelState.IsValid)
            {
                MSTProcessTypesDto data = new MSTProcessTypesDto
                {
                    Id = id,
                    Name = processtype.Name,
                    Description = processtype.Description,
                    Duration = processtype.Duration,
                    SeqNumber = processtype.SeqNumber,
                    LastUpdatedBy = this.CurrentName
                };
                var result = await ProcessTypesRepository.UpdateAsync(data);
                if (result == Model.SaveResult.SUCCESS)
                    return RedirectToAction("Index");
            }
            return View(processtype);
        }

        /// <summary>
        /// 
        /// </summary>
        [Inject]
        public IMSTProcessTypesRepository ProcessTypesRepository { get; set; }
    }
}

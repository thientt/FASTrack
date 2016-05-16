using FASTrack.Infrastructure;
using FASTrack.Model.Abstracts;
using FASTrack.Model.DTO;
using FASTrack.ViewModel;
using Ninject;
using PagedList;
using System.Collections;
using System.Collections.Generic;
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
    public class FAResultController : AppController
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
            var items = ProcessResultRespository.GetAll();
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

            MSTProcessResultDto pro = await ProcessResultRespository.SingleAsync(id);

            if (pro == null)
                return HttpNotFound();

            return View(pro);
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            ProcessResultViewModel bind = new ProcessResultViewModel();
            bind.ProcessType = ProcessTypesRepository.GetAll();

            return View(bind);
        }

        /// <summary>
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create(ProcessResultViewModel model)
        {
            if (ModelState.IsValid)
            {
                MSTProcessResultDto pro = new MSTProcessResultDto()
                {
                    ProcessTypeId = model.ProcessTypeId,
                    Value = model.Value,
                    Description = model.Description,
                    LastUpdatedBy = CurrentName
                };
                var result = await ProcessResultRespository.AddAsync(pro);

                if (result == Model.SaveResult.SUCCESS)
                    return RedirectToAction("Index");
            }

            model.ProcessType = ProcessTypesRepository.GetAll();
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

            MSTProcessResultDto pro = await ProcessResultRespository.SingleAsync(id);
            IEnumerable<MSTProcessTypesDto> processType = await ProcessTypesRepository.GetAllAsync();
            if (pro == null)
                return HttpNotFound();

            ProcessResultViewModel bind = new ProcessResultViewModel
            {
                Id = id,
                ProcessTypeId = pro.ProcessTypeId,
                Value = pro.Value,
                Description = pro.Description,
                LastUpdatedBy = pro.LastUpdatedBy,
                LastUpdate = pro.LastUpdate,
                ProcessType = processType,
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
        public async Task<ActionResult> Edit(int id, ProcessResultViewModel model)
        {
            if (ModelState.IsValid)
            {
                var status = new MSTProcessResultDto()
                {
                    Id = id,
                    ProcessTypeId = model.ProcessTypeId,
                    Value = model.Value,
                    Description = model.Description,
                    LastUpdatedBy = CurrentName,
                };
                var result = await ProcessResultRespository.UpdateAsync(status);

                if (result == Model.SaveResult.SUCCESS)
                    return RedirectToAction("Index");
            }

            IEnumerable<MSTProcessTypesDto> processType = await ProcessTypesRepository.GetAllAsync();
            model.ProcessType = processType;
            return View(model);
        }

        /// <summary>
        /// Gets or sets the status respository.
        /// </summary>
        /// <value>
        /// The status respository.
        /// </value>
        [Inject]
        public IMSTProcessResultRepository ProcessResultRespository { get; set; }

        [Inject]
        public IMSTProcessTypesRepository ProcessTypesRepository { get; set; }
    }
}

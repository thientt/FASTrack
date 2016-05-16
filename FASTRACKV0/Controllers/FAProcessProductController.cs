using FASTrack.Infrastructure;
using FASTrack.Model.Abstracts;
using FASTrack.Model.DTO;
using FASTrack.ViewModel;
using Ninject;
using PagedList;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq;
using FASTrack.Model.Types;

/// <summary>
/// 
/// </summary>
namespace FASTrack.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize(Roles = AuthRole.Admin)]
    public class FAProcessProductController : AppController
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
            var items = ProProtRep.GetAll();
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
            MSTProcessProductDto product = await ProProtRep.SingleAsync(id);
            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            var process = ProcessTypeRepository.GetAll();
            var products = ProductRepository.GetAll();
            var user = UserRepository.GetAll().Where(x => x.RoleId == (int)RoleType.ANALYST || x.RoleId == (int)RoleType.MANAGER);
            var bind = new ProcessProductViewModel
            {
                ProcessTypes = process,
                Products = products,
                Users = user,
            };
            return View(bind);
        }

        // POST: /BU/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creates the specified viewmodel.
        /// </summary>
        /// <param name="viewmodel">The viewmodel.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create(ProcessProductViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                MSTProcessProductDto bu = new MSTProcessProductDto
                {
                    ProcessTypeId = viewmodel.ProcessId,
                    ProductId = viewmodel.ProductId,
                    InChargePerson = viewmodel.InChargePerson,
                    Description = viewmodel.Description,
                    LastUpdatedBy = CurrentName
                };
                var result = await ProProtRep.AddAsync(bu);

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

            MSTProcessProductDto product = await ProProtRep.SingleAsync(id);
            if (product == null)
                return HttpNotFound();
            var process = ProcessTypeRepository.GetAll();
            var products = ProductRepository.GetAll();
            var user = UserRepository.GetAll().Where(x => x.RoleId == (int)RoleType.ANALYST || x.RoleId == (int)RoleType.MANAGER);
            ProcessProductViewModel bind = new ProcessProductViewModel
            {
                ProcessId = product.ProcessTypeId,
                ProductId = product.ProductId,
                InChargePerson = product.InChargePerson,
                Description = product.Description,
                Users = user,
                ProcessTypes = process,
                Products = products,
                LastUpdatedBy = CurrentName
            };

            return View(bind);
        }

        // POST: /BU/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="viewmodel">The viewmodel.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Edit(int id, ProcessProductViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                MSTProcessProductDto product = new MSTProcessProductDto
                {
                    Id = id,
                    //ProcessTypeId = viewmodel.ProcessId,
                    //ProductId = viewmodel.ProductId,
                    InChargePerson = viewmodel.InChargePerson,
                    Description = viewmodel.Description,
                    LastUpdatedBy = CurrentName,
                };
                var result = await ProProtRep.UpdateAsync(product);
                if (result == Model.SaveResult.SUCCESS)
                    return RedirectToAction("Index");
            }
            return View(viewmodel);
        }

        [Inject]
        public IMSTProcessProductRepository ProProtRep { get; set; }

        [Inject]
        public IMSTProcessTypesRepository ProcessTypeRepository { get; set; }

        [Inject]
        public IMSTProductRepository ProductRepository { get; set; }

        [Inject]
        public ISYSUsersRepository UserRepository { get; set; }
    }
}

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
    public class FAProductController : AppController
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
            var items = ProductRep.GetAll();
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
            MSTProductDto product = await ProductRep.SingleAsync(id);
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
            //Get a list LabSite
            var labSites = LabSiteRep.GetAll();

            //Create a data binding to view
            var model = new ProductViewModel
            {
                LabSites = labSites
            };
            
            return View(model);
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
        public async Task<ActionResult> Create(ProductViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                MSTProductDto bu = new MSTProductDto
                {
                    Name = viewmodel.Name,
                    Description = viewmodel.Description,
                    MainPerson = viewmodel.MainPerson,
                    SecondaryPerson = viewmodel.SecondaryPerson,
                    TertiaryPerson = viewmodel.TertiaryPerson,
                    LabSiteId = viewmodel.LabSiteId,
                    LastUpdatedBy = CurrentName
                };
                var result = await ProductRep.AddAsync(bu);

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

            //Get single Product by ID
            MSTProductDto product = await ProductRep.SingleAsync(id);

            //If product is null then exist function
            if (product == null)
                return HttpNotFound();

            //Get list Labsite that bind to view
            var labSites = LabSiteRep.GetAll();

            ProductViewModel bind = new ProductViewModel
            {
                Name = product.Name,
                Description = product.Description,
                MainPerson = product.MainPerson,
                TertiaryPerson = product.TertiaryPerson,
                SecondaryPerson = product.SecondaryPerson,
                LabSiteId = product.LabSiteId,
                LabSites = labSites,
                LastUpdatedBy = product.LastUpdatedBy,
                LastUpdate = product.LastUpdate,
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
        public async Task<ActionResult> Edit(int id, ProductViewModel viewmodel)
        {

            if (ModelState.IsValid)
            {
                MSTProductDto product = new MSTProductDto
                {
                    Id = id,
                    Name = viewmodel.Name,
                    Description = viewmodel.Description,
                    MainPerson = viewmodel.MainPerson,
                    TertiaryPerson = viewmodel.TertiaryPerson,
                    SecondaryPerson = viewmodel.SecondaryPerson,
                    LabSiteId = viewmodel.LabSiteId,
                    LastUpdatedBy = CurrentName,
                };

                //update product to server
                var result = await ProductRep.UpdateAsync(product);

                if (result == Model.SaveResult.SUCCESS)
                    return RedirectToAction("Index");
            }

            return View(viewmodel);
        }

        /// <summary>
        /// Gets or sets the Product repository.
        /// </summary>
        /// <value>
        /// The Product repository.
        /// </value>
        [Inject]
        public IMSTProductRepository ProductRep { get; set; }

        /// <summary>
        /// Gets or sets the LabSite repository.
        /// </summary>
        /// <value>
        /// The LabSite repository.
        /// </value>
        [Inject]
        public IMSTLabSiteRepository LabSiteRep { get; set; }
    }
}

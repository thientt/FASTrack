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
    public class FACustomerController : AppController
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
            var items = CustomerRepository.GetAll();
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
            MSTCustomerDto customer = await CustomerRepository.SingleAsync(id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View(new ProductViewModel());
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
        public async Task<ActionResult> Create(CustomerViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                MSTCustomerDto cus = new MSTCustomerDto
                {
                    CustomerName = viewmodel.Name,
                    EndCustomer = viewmodel.EndCustomer,
                    Location = viewmodel.Location,
                    Strategic = viewmodel.Strategic,
                    LastUpdatedBy = CurrentName
                };
                var result = await CustomerRepository.AddAsync(cus);

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

            MSTCustomerDto customer = await CustomerRepository.SingleAsync(id);
            if (customer == null)
                return HttpNotFound();
            CustomerViewModel bind = new CustomerViewModel
            {
                Name = customer.CustomerName,
                EndCustomer = customer.EndCustomer,
                Location = customer.Location,
                Strategic = customer.Strategic,
                LastUpdatedBy = customer.LastUpdatedBy,
                LastUpdate = customer.LastUpdate,
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
        public async Task<ActionResult> Edit(int id, CustomerViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                MSTCustomerDto customer = new MSTCustomerDto
                {
                    Id = id,
                    CustomerName = viewmodel.Name,
                    EndCustomer = viewmodel.EndCustomer,
                    Location = viewmodel.Location,
                    Strategic = viewmodel.Strategic,
                    LastUpdatedBy = CurrentName,
                };
                var result = await CustomerRepository.UpdateAsync(customer);
                if (result == Model.SaveResult.SUCCESS)
                    return RedirectToAction("Index");
            }
            return View(viewmodel);
        }

        /// <summary>
        /// Gets or sets the customer repository.
        /// </summary>
        /// <value>
        /// The customer repository.
        /// </value>
        [Inject]
        public IMSTCustomerRepository CustomerRepository { get; set; }
    }
}

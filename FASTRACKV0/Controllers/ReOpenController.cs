using FASTrack.Infrastructure;
using FASTrack.Model.Abstracts;
using FASTrack.Model.Types;
using Ninject;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

/// <summary>
/// 
/// </summary>
namespace FASTrack.Controllers
{
    [Authorize(Roles = AuthRole.Admin)]
    public class ReOpenController : AppController
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var items = (await MasterRepository.GetAllAsync()).Where(x => x.StatusId == (int)StatusType.CLOSED).OrderBy(x => x.Number);
            return View(items);
        }

        /// <summary>
        /// Gets or sets the master repository.
        /// </summary>
        /// <value>
        /// The master repository.
        /// </value>
        [Inject]
        public IFARMasterRepository MasterRepository { get; set; }
    }
}
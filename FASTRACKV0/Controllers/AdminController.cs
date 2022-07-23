using FASTrack.Infrastructure;
using FASTrack.Model.Abstracts;
using Ninject;
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
    public class AdminController : AppController
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Management()
        {
            return View();

        }
        /// <summary>
        /// Users the type list.
        /// </summary>
        /// <returns></returns>
        public ActionResult UserTypeList()
        {
            return View();
        }

        /// <summary>
        /// Gets or sets the user repository.
        /// </summary>
        /// <value>
        /// The user repository.
        /// </value>
        [Inject]
        public ISYSUsersRepository UserRepository { get; set; }
    }
}
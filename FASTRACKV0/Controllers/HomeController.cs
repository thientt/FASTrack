using System.Web.Mvc;
using FASTrack.Infrastructure;

/// <summary>
/// 
/// </summary>
namespace FASTrack.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [AllowAnonymous]
    public class HomeController : AppController
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.UserName = this.CurrentName;
            switch (Role)
            {
                case AuthRole.Requestor:
                    return RedirectToAction("AsRequestor", "Dashboard");
                case AuthRole.Analyst:
                    return RedirectToAction("AsAnalyst", "Dashboard");
                case AuthRole.Manager:
                    return RedirectToAction("AsManager", "Dashboard");
                case AuthRole.Admin:
                    return RedirectToAction("AsAdministrator", "Dashboard");
                default:
                    return View();
            }
        }

        /// <summary>
        /// Dashboards this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Dashboard()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        /// <summary>
        /// Supports this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Support()
        {
            ViewBag.Message = "For any bugs, inquiries and suggestions, please send an email to the System Admin or IT Contact below:";
            return View();
        }
    }
}
// ***********************************************************************
// Assembly         : FASTrack
// Author           : tranthiencdsp@gmail.com
// Created          : 02-25-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 03-13-2016
// ***********************************************************************
// <copyright file="UserController.cs" company="Atmel">
//     Copyright © Atmel 2016
// </copyright>
// <summary></summary>
// **********************************************************************

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
    [Authorize(Roles = AuthRole.Admin)]
    public class UserController : AppController
    {
        #region Admin
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
        public ActionResult List(int? page)
        {
            var items = UserRepository.GetAll();
            int pageNumber = page ?? 1;
            return PartialView(items.ToPagedList(pageNumber, FastrackConfig.PAGESIZE));
        }

        /// <summary>
        /// Unlockeds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Unlocked(int id)
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var user = await UserRepository.SingleAsync(id);

            if (user == null)
                return HttpNotFound();

            return View(user);
        }

        /// <summary>
        /// Unlockeds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Unlocked(int id, SYSUsersDto user)
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (ModelState.IsValid)
            {
                var result = await UserRepository.UnlockedAsync(user.Id);
                if (result == Model.SaveResult.SUCCESS)
                    return RedirectToAction("List");
            }

            return View(user);
        }

        /// <summary>
        /// Locks the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Lock(int id)
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var user = await UserRepository.SingleAsync(id);

            if (user == null)
                return HttpNotFound();

            return View(user);
        }

        /// <summary>
        /// Locks the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Lock(int id, SYSUsersDto user)
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (ModelState.IsValid)
            {
                var result = await UserRepository.LockedAsync(id);
                if (result == Model.SaveResult.SUCCESS)
                    return RedirectToAction("List");
            }
            return View(user);
        }

        /// <summary>
        /// Currents the users.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> CurrentUsers()
        {
            var userUnlocked = await UserRepository.FindAllUnlockedAsync();
            return View(userUnlocked);
        }

        /// <summary>
        /// Fors the approval.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> ForApproval()
        {
            var userLocked = await UserRepository.FindAllLockedAsync();
            return View(userLocked);
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

        //    var user = await UserRepository.SingleAsync(id);
        //    if (user == null)
        //        return HttpNotFound();

        //    return View(user);
        //}

        ///// <summary>
        ///// Deletes the specified identifier.
        ///// </summary>
        ///// <param name="id">The identifier.</param>
        ///// <param name="user">The user.</param>
        ///// <returns></returns>
        //[HttpPost]
        //public async Task<ActionResult> Delete(int id, SYSUsersDto user)
        //{
        //    if (id == 0)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        //    if (ModelState.IsValid)
        //    {
        //        var result = await UserRepository.DeleteByAsync(id);
        //        if (result == Model.SaveResult.SUCESS)
        //            return RedirectToAction("List");
        //    }

        //    return View(user);
        //}

        /// <summary>
        /// Sets the role.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> SetRole(int id)
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var user = await UserRepository.SingleAsync(id);
            if (user == null)
                return HttpNotFound();

            //Find all role
            var roles = RoleRepository.GetAllAsync();

            UserViewModel bind = new UserViewModel()
            {
                Email = user.Email,
                Salt = user.Salt,
                RegistedDate = user.RegistedDate,
                IsLocked = user.IsLocked,
                Lastname = user.Lastname,
                Firstname = user.Firstname,
                Phone = user.Phone,
                DepartmentId = user.DepartmentId,
                SiteId = user.SiteId,
                RoleId = user.RoleId,
                LastLoginDate = user.LastLoginDate
            };

            bind.Roles = await roles;

            return View(bind);
        }

        /// <summary>
        /// Sets the role.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="form">The form.</param>
        /// <param name="viewmodel">The viewmodel.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> SetRole(int id, FormCollection form, UserViewModel viewmodel)
        {
            var result = await UserRepository.SetRoleAsync(id, (Model.Types.RoleType)viewmodel.RoleId);
            if (result == Model.SaveResult.SUCCESS)
                return RedirectToAction("List");

            return View(viewmodel);
        }

        #endregion end Admin

        #region Inject
        /// <summary>
        /// Gets or sets the user repository.
        /// </summary>
        /// <value>
        /// The user repository.
        /// </value>
        [Inject]
        public ISYSUsersRepository UserRepository { get; set; }

        /// <summary>
        /// Gets or sets the site repository.
        /// </summary>
        /// <value>
        /// The site repository.
        /// </value>
        [Inject]
        public IMSTSitesRepository SiteRepository { get; set; }

        /// <summary>
        /// Gets or sets the department repository.
        /// </summary>
        /// <value>
        /// The department repository.
        /// </value>
        [Inject]
        public IMSTDepartmentRepository DepartmentRepository { get; set; }

        /// <summary>
        /// Gets or sets the role repository.
        /// </summary>
        /// <value>
        /// The role repository.
        /// </value>
        [Inject]
        public ISYSRolesRepository RoleRepository { get; set; }
        #endregion

        /// <summary>
        /// Changes the type of the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangeUserType(int id)
        {
            return RedirectToAction("List");
        }
    }
}
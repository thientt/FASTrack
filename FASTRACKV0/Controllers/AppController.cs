// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 23-07-2022
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 23-07-2022
// ***********************************************************************
// <copyright file="AppController.cs" company="Atmel Corporation">
//     Copyright © Atmel 2015
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

/// <summary>
/// 
/// </summary>
namespace FASTrack.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class AppController : Controller
    {
        /// <summary>
        /// Gets the authentication manager.
        /// </summary>
        /// <value>
        /// The authentication manager.
        /// </value>
        public IAuthenticationManager AuthenticationManager
        {
            get
            {
                var ctx = Request.GetOwinContext();
                return ctx.Authentication;
            }
        }

        /// <summary>
        /// Gets the name of the current.
        /// </summary>
        /// <value>
        /// The name of the current.
        /// </value>
        public string CurrentName
        {
            get
            {
                var claim = User as ClaimsPrincipal;
                if (claim != null)
                    return claim.FindFirst(ClaimTypes.Name).Value;
                else return string.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Role
        {
            get
            {
                var claim = User as ClaimsPrincipal;
                if (claim != null)
                {
                    Claim c = claim.FindFirst(ClaimTypes.Role);
                    if (c != null)
                        return c.Value;
                    else return string.Empty;
                }
                else return string.Empty;
            }
        }

        /// <summary>
        /// Gets the site.
        /// </summary>
        /// <value>
        /// The site.
        /// </value>
        public string Site
        {
            get
            {
                if (User is ClaimsPrincipal claim)
                    return claim.FindFirst(ClaimTypes.Country).Value;
                else
                    return string.Empty;
            }
        }
    }
}
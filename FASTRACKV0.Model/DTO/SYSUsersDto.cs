// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 11-04-2015
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 08-26-2015
// ***********************************************************************
// <copyright file="SYSUsersDto.cs" company="Atmel Corporation">
//     Copyright © Atmel 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace FASTrack.Model.DTO
{
    public class SYSUsersDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the password hash.
        /// </summary>
        /// <value>
        /// The password hash.
        /// </value>
        public string PasswordHash { get; set; }
        /// <summary>
        /// Gets or sets the salt.
        /// </summary>
        /// <value>
        /// The salt.
        /// </value>
        public string Salt { get; set; }
        /// <summary>
        /// Gets or sets the registed date.
        /// </summary>
        /// <value>
        /// The registed date.
        /// </value>
        public DateTime RegistedDate { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is locked.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is locked; otherwise, <c>false</c>.
        /// </value>
        public bool IsLocked { get; set; }
        /// <summary>
        /// Gets or sets the lastname.
        /// </summary>
        /// <value>
        /// The lastname.
        /// </value>
        public string Lastname { get; set; }
        /// <summary>
        /// Gets or sets the firstname.
        /// </summary>
        /// <value>
        /// The firstname.
        /// </value>
        public string Firstname { get; set; }
        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>
        /// The phone.
        /// </value>
        public string Phone { get; set; }
        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        public int DepartmentId { get; set; }
        /// <summary>
        /// Gets or sets the site identifier.
        /// </summary>
        /// <value>
        /// The site identifier.
        /// </value>
        public int SiteId { get; set; }
        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public int RoleId { get; set; }
        /// <summary>
        /// Gets or sets the recover pass.
        /// </summary>
        /// <value>
        /// The recover pass.
        /// </value>
        public string RecoverPass { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is comfired email.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is comfired email; otherwise, <c>false</c>.
        /// </value>
        public bool IsComfiredEmail { get; set; }
        /// <summary>
        /// Gets or sets the last login date.
        /// </summary>
        /// <value>
        /// The last login date.
        /// </value>
        public DateTime? LastLoginDate { get; set; }
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>
        /// The unique identifier.
        /// </value>
        public string Guid { get; set; }

        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        /// <value>
        /// The department.
        /// </value>
        public MSTDepartmentDto Department { get; set; }
        /// <summary>
        /// Gets or sets the sites.
        /// </summary>
        /// <value>
        /// The sites.
        /// </value>
        public SitesDto Sites { get; set; }
        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        public SYSRolesDto Role { get; set; }
        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string FullName
        {
            get
            {
                return Firstname + " " + Lastname;
            }
        }
    }
}

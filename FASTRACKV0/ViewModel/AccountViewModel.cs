// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 23-07-2022
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 23-07-2022
// ***********************************************************************
// <copyright file="AccountViewModel.cs" company="Atmel Corporation">
//     Copyright © Atmel 2015
// </copyright>
// <summary></summary>
// ***********************************************************************

using FASTrack.Model.DTO;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace FASTrack.ViewModel
{
    /// <summary>
    /// Account view model
    /// </summary>
    public class AccountViewModel : BaseDto
    {
        /// <summary>
        /// The first name
        /// </summary>
        [Display(Name = "Firstname")]
        [Required(ErrorMessage = "FirstName is required!")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "The length of Firstname in range 1 to 50 chars!")]
        public string FirstName { get; set; }

        /// <summary>
        /// The last name
        /// </summary>
        [Display(Name = "Lastname")]
        [Required(ErrorMessage = "Lastname is required!")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "The length of LastName in range 1 to 50 chars!")]
        public string LastName { get; set; }

        /// <summary>
        /// The email
        /// </summary>
        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// The site location
        /// </summary>
        [Display(Name = "Site Location")]
        [Required]
        public int SiteId { get; set; }

        /// <summary>
        /// The site object
        /// </summary>
        [Display(Name = "Site")]
        public IEnumerable<SitesDto> Site { get; set; }

        /// <summary>
        /// The role
        /// </summary>
        [Display(Name = "Role")]
        [Required]
        public int RoleId { get; set; }

        /// <summary>
        /// The role name
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// The role object
        /// </summary>
        public IEnumerable<SYSRolesDto> Role { get; set; }

        /// <summary>
        /// The register date
        /// </summary>
        [Display(Name = "Register Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RegisterDate { get; set; }

        /// <summary>
        /// The phone number
        /// </summary>
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}
// ***********************************************************************
// Assembly         : FASTrack
// Author           : tranthiencdsp@gmail.com
// Created          : 11-04-2015
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 08-26-2015
// ***********************************************************************
// <copyright file="ChangePasswordViewModel.cs" company="Atmel Corporation">
//     Copyright © Atmel 2015
// </copyright>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;

namespace FASTrack.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class ChangePasswordViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Current Password")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false)]
        public string PasswordCurrent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "New Password")]
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string NewPassword { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Confirm Password")]
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string NewConfirmPassword { get; set; }
    }
}
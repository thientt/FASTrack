//***********************************************************************
// Assembly         : FASTrack
// Author           : tranthiencdsp@gmail.com
// Created          : 11-04-2015
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 08-26-2015
// ***********************************************************************
// <copyright file="CustomerViewModel.cs" company="Atmel Corporation">
//     Copyright © Atmel 2015
// </copyright>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;
namespace FASTrack.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerViewModel : MSTViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "EndCustomer")]
        public bool EndCustomer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Location"), MaxLength(255)]
        public string Location { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Strategic")]
        public bool Strategic { get; set; }
    }
}
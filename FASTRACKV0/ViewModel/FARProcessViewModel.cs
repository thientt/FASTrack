// ***********************************************************************
// Assembly         : FASTRACKV0
// Author           : tranthiencdsp@gmail.com
// Created          : 11-04-2015
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 03-23-2016
// ***********************************************************************
// <copyright file="FARProcessViewModel.cs" company="">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************

using FASTrack.Model.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace FASTrack.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class FARProcessViewModel : BaseDto
    {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "FAR NUmber")]
        public string Number { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Master Id")]
        public int DeviceId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "ProcessTypeId")]
        public int ProcessTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "SeqNum")]
        public int SeqNum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Iteration")]
        public int? Iteration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Analystor")]
        public string Analystor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "PlannedIn")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PlannedIn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "PlannedOut")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PlannedOut { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "DateIn")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateIn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "DateOut")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOut { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Comment")]
        public string Comment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Included?")]
        public bool IsIncluded { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Duaration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ProcessResultId { get; set; }
    }
}
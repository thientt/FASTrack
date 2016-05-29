using FASTrack.Model.Types;
// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 03-21-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 03-21-2016
// ***********************************************************************
// <copyright file="LOGProcessHistory.cs" company="Atmel Corporation">
//     Copyright © Atmel Corporation 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

/// <summary>
/// The DTO namespace.
/// </summary>
namespace FASTrack.Model.DTO
{
    /// <summary>
    /// Class LOGProcessHistory.
    /// </summary>
    public class LOGProcessHistoryDto
    {
        public int Id { get; set; }
        public int ProcessHisId { get; set; }
        public PlanType PlanType { get; set; }
        public DateTime? PlanFrom { get; set; }
        public DateTime? PlanTo { get; set; }
        public DateTime InsertedDate { get; set; }
        public string InsertedBy { get; set; }
        public string Description { get; set; }

        public FARProcessHistoryDto FARProcessHistory { get; set; }
    }
}

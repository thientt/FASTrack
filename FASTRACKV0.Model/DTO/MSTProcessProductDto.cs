// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 03-23-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 03-23-2016
// ***********************************************************************
// <copyright file="MSTProcessProductDto.cs" company="Atmel Corporation">
//     Copyright © Atmel Corporation 2015
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace FASTrack.Model.DTO
{
    public class MSTProcessProductDto : BaseDto
    {
        /// <summary>
        /// 
        /// </summary>
        public int ProcessTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string InChargePerson { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MSTProcessTypesDto ProcessType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MSTProductDto Product { get; set; }
    }
}

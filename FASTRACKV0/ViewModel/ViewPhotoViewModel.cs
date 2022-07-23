// ***********************************************************************
// Assembly         : FASTrack
// Author           : tranthiencdsp@gmail.com
// Created          : 02-25-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 06-04-2016
// ***********************************************************************
// <copyright file="ViewPhoto.cs" company="Atmel">
//     Copyright © Atmel 2016
// </copyright>
// <summary></summary>
// **********************************************************************

using System.Collections.Generic;

namespace FASTrack.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ViewPhoto
    {
        /// <summary>
        /// 
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        //Enhancement FADB_Enhancemnet_UAT_result_20160601.pptx
        public bool IsSelected { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ViewPhotoViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public List<ViewPhoto> Photos { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Default { get; set; }
    }
}
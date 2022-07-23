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
    public sealed class ViewPhoto
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }

        //Enhancement FADB_Enhancemnet_UAT_result_20160601.pptx
        public bool IsSelected { get; set; }
    }

    public class ViewPhotoViewModel
    {
        public List<ViewPhoto> Photos { get; set; }
        public string Default { get; set; }
    }
}
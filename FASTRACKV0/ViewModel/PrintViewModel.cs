using FASTrack.Model.DTO;
using System.Collections.Generic;

namespace FASTrack.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class PrintViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string Site { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public FARMasterDto Master { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<FARDeviceDetailsDto> Samples { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<FARProcessHistoryDto> Process { get; set; }
    }
}
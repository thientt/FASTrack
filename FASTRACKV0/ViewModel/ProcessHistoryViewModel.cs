using FASTrack.Model.DTO;
using System.Collections.Generic;

namespace FASTrack.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class ProcessHistoryViewModel
    {

        /// <summary>
        /// 
        /// </summary>
        public int DeviceId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int MasterId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public FARDeviceDetailsDto Device { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<FARProcessHistoryDto> Process { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<SYSUsersDto> Users { get; set; }

    }
}
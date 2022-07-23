using FASTrack.Model.DTO;
using System;

namespace FASTrack.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class ProcessFlowViewModel : BaseDto
    {

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> Duration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> SeqNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public string FARNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int MasterId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ServiceId { get; set; }
    }
}
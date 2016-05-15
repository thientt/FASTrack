using FASTrack.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FASTrack.ViewModel
{
    public class ProcessFlowViewModel : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Duration { get; set; }
        public Nullable<int> SeqNumber { get; set; }

        public string FARNumber { get; set; }
        public int MasterId { get; set; }
        public int ServiceId { get; set; }
    }
}
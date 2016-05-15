using FASTrack.Model.DTO;
using System.Collections.Generic;

namespace FASTrack.ViewModel
{
    public class PrintViewModel
    {
        public string Site { get; set; }
        public FARMasterDto Master { get; set; }
        public IEnumerable<FARDeviceDetailsDto> Samples { get; set; }
        public IEnumerable<FARProcessHistoryDto> Process { get; set; }
    }
}
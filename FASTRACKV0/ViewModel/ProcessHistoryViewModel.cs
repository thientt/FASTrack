using FASTrack.Model.DTO;
using System.Collections.Generic;

namespace FASTrack.ViewModel
{
    public class ProcessHistoryViewModel
    {
        public int DeviceId { get; set; }
        public int MasterId { get; set; }
        public string Number { get; set; }

        public FASTrack.Model.DTO.FARDeviceDetailsDto Device { get; set; }
        public List<FASTrack.Model.DTO.FARProcessHistoryDto> Process { get; set; }

        public string Email { get; set; }
        public IEnumerable<SYSUsersDto> Users { get; set; }

    }
}
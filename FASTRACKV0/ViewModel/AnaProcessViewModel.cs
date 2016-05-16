using FASTrack.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FASTrack.ViewModel
{
    public class AnaProcessViewModel
    {
        public int DeviceId { get; set; }
        public int MasterId { get; set; }
        public string Number { get; set; }

        public string Email { get; set; }
        public IEnumerable<SYSUsersDto> Users { get; set; }

        public List<FASTrack.Model.DTO.FARProcessHistoryDto> Process { get; set; }

        public int ProcessResultId { get; set; }
        public IEnumerable<MSTProcessResultDto> ProcessResult { get; set; }
    }
}
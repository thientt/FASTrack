using System;

namespace FASTrack.Model.DTO
{
    public class FARCancelLogDto : BaseDto
    {
        public int MasterId { get; set; }
        public int StatusId { get; set; }
        public int ReasonId { get; set; }
        public DateTime CancelledDate { get; set; }

        public FARMasterDto Master { get; set; }
        public FARStatusDto Status { get; set; }
        public DelayReasonDto Reason { get; set; }
    }
}

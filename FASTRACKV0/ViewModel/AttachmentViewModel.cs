using System.Collections.Generic;
using System;

namespace FASTrack.ViewModel
{
    public class AttachmentViewModel
    {
        public int Id { get; set; }
        public string FANumber { get; set; }
        public string File { get; set; }
        public List<string> InitialReport { get; set; }
        public List<string> FinalReport { get; set; }
        public DateTime? InitialDate { get; set; }
        public DateTime? FinalDate { get; set; }

        public int InitalReasonId { get; set; }
        public IEnumerable<FASTrack.Model.DTO.DelayReasonDto> InitalReasons { get; set; }
        public int FinalReasonId { get; set; }
        public IEnumerable<FASTrack.Model.DTO.DelayReasonDto> FinalReasons { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using FASTrack.Model.DTO;

namespace FASTrack.ViewModel
{
    public class FARProcessViewModel : BaseDto
    {
        [Display(Name = "FAR NUmber")]
        public string Number { get; set; }

        [Display(Name = "Master Id")]
        public int DeviceId { get; set; }

        [Display(Name = "ProcessTypeId")]
        public int ProcessTypeId { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "SeqNum")]
        public int SeqNum { get; set; }

        [Display(Name = "Iteration")]
        public int? Iteration { get; set; }

        [Display(Name = "Analystor")]
        public string Analystor { get; set; }

        [Display(Name = "PlannedIn")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PlannedIn { get; set; }

        [Display(Name = "PlannedOut")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PlannedOut { get; set; }

        [Display(Name = "DateIn")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateIn { get; set; }

        [Display(Name = "DateOut")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOut { get; set; }

        [Display(Name = "Comment")]
        public string Comment { get; set; }

        [Display(Name = "Included?")]
        public bool IsIncluded { get; set; }

        public int Duaration { get; set; }

        public int ProcessResultId { get; set; }
    }
}
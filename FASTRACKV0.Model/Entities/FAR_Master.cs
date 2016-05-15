//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FASTrack.Model.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class FAR_Master
    {
        public FAR_Master()
        {
            this.FAR_DeviceDetails = new HashSet<FAR_DeviceDetails>();
            this.LOG_FARAnalystReassign = new HashSet<LOG_FARAnalystReassign>();
            this.LOG_FARFinalTarget = new HashSet<LOG_FARFinalTarget>();
            this.LOG_FARHistory = new HashSet<LOG_FARHistory>();
            this.LOG_FARInitialTarget = new HashSet<LOG_FARInitialTarget>();
            this.LOG_FARPriority = new HashSet<LOG_FARPriority>();
        }
    
        public int Id { get; set; }
        public string Number { get; set; }
        public int OriginId { get; set; }
        public string Requestor { get; set; }
        public int RefNo { get; set; }
        public int FailureTypeId { get; set; }
        public int FailureOriginId { get; set; }
        public byte FailureRate { get; set; }
        public int StatusId { get; set; }
        public string Analyst { get; set; }
        public System.DateTime RequestDate { get; set; }
        public Nullable<System.DateTime> SamplesArriveDate { get; set; }
        public int PriorityId { get; set; }
        public Nullable<System.DateTime> InitialReportTargetDate { get; set; }
        public int BUId { get; set; }
        public string Product { get; set; }
        public string FailureDesc { get; set; }
        public Nullable<System.DateTime> FinalReportTargetDate { get; set; }
        public string Customer { get; set; }
        public bool Submitted { get; set; }
        public string LastUpdatedBy { get; set; }
        public System.DateTime LastUpdate { get; set; }
        public bool IsDeleted { get; set; }
        public int LabSiteId { get; set; }
        public Nullable<int> RatingId { get; set; }
        public string Comments { get; set; }
    
        public virtual ICollection<FAR_DeviceDetails> FAR_DeviceDetails { get; set; }
        public virtual ICollection<LOG_FARAnalystReassign> LOG_FARAnalystReassign { get; set; }
        public virtual MST_BU MST_BU { get; set; }
        public virtual MST_FailureOrigin MST_FailureOrigin { get; set; }
        public virtual MST_FailureType MST_FailureType { get; set; }
        public virtual MST_LabSite MST_LabSite { get; set; }
        public virtual MST_Origin MST_Origin { get; set; }
        public virtual MST_Priority MST_Priority { get; set; }
        public virtual MST_Status MST_Status { get; set; }
        public virtual ICollection<LOG_FARFinalTarget> LOG_FARFinalTarget { get; set; }
        public virtual ICollection<LOG_FARHistory> LOG_FARHistory { get; set; }
        public virtual ICollection<LOG_FARInitialTarget> LOG_FARInitialTarget { get; set; }
        public virtual ICollection<LOG_FARPriority> LOG_FARPriority { get; set; }
        public virtual MST_Rating MST_Rating { get; set; }
    }
}
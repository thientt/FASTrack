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
    
    public partial class LOG_FARInitialTarget
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public Nullable<System.DateTime> TargetDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public System.DateTime LastUpdate { get; set; }
        public bool IsDeleted { get; set; }
        public int ReasonId { get; set; }
    
        public virtual FAR_Master FAR_Master { get; set; }
    }
}

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
    
    public partial class LOG_ProcessHistory
    {
        public int Id { get; set; }
        public int ProcessHisId { get; set; }
        public byte PlanType { get; set; }
        public Nullable<System.DateTime> PlanFrom { get; set; }
        public Nullable<System.DateTime> PlanTo { get; set; }
        public System.DateTime InsertedDate { get; set; }
        public string InsertedBy { get; set; }
        public string Description { get; set; }
    
        public virtual FAR_ProcessHistory FAR_ProcessHistory { get; set; }
    }
}

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
    
    public partial class MST_ProcessResult
    {
        public MST_ProcessResult()
        {
            this.FAR_ProcessHistory = new HashSet<FAR_ProcessHistory>();
        }
    
        public int Id { get; set; }
        public int ProcessTypeId { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public string LastUpdatedBy { get; set; }
        public System.DateTime LastUpdate { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual MST_ProcessTypes MST_ProcessTypes { get; set; }
        public virtual ICollection<FAR_ProcessHistory> FAR_ProcessHistory { get; set; }
    }
}

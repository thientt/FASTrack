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
    
    public partial class MST_Status
    {
        public MST_Status()
        {
            this.FAR_Master = new HashSet<FAR_Master>();
            this.LOG_FARHistory = new HashSet<LOG_FARHistory>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LastUpdatedBy { get; set; }
        public System.DateTime LastUpdate { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual ICollection<FAR_Master> FAR_Master { get; set; }
        public virtual ICollection<LOG_FARHistory> LOG_FARHistory { get; set; }
    }
}

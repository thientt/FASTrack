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
    
    public partial class MST_FARReport
    {
        public int Id { get; set; }
        public int ReportTypeId { get; set; }
        public int OriginId { get; set; }
        public bool Required { get; set; }
        public string Description { get; set; }
        public string LastUpdatedBy { get; set; }
        public System.DateTime LastUpdate { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual MST_Origin MST_Origin { get; set; }
        public virtual MST_ReportTypes MST_ReportTypes { get; set; }
    }
}

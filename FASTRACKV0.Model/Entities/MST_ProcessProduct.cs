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
    
    public partial class MST_ProcessProduct
    {
        public int Id { get; set; }
        public int ProcessTypeId { get; set; }
        public int ProductId { get; set; }
        public string InChargePerson { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public string LastUpdatedBy { get; set; }
        public System.DateTime LastUpdate { get; set; }
    
        public virtual MST_ProcessTypes MST_ProcessTypes { get; set; }
        public virtual MST_Product MST_Product { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Accounting
{
    using System;
    using System.Collections.Generic;
    
    public partial class Maintenance
    {
        public int IdMaintenance { get; set; }
        public Nullable<int> IdEquipment { get; set; }
        public Nullable<int> TypeMaintenance { get; set; }
        public Nullable<System.DateTime> DateMaintenance { get; set; }
    
        public virtual Equipment Equipment { get; set; }
        public virtual TypeMaintenance TypeMaintenance1 { get; set; }
    }
}
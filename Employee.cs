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
    
    public partial class Employee
    {
        public int IdEmployee { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<int> IdDepartment { get; set; }
        public Nullable<int> IdEquipment { get; set; }
        public Nullable<int> IdJobTitle { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual JobTitle JobTitle { get; set; }
    }
}

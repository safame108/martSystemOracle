//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class LogIn_Details
    {
        public string UserName { get; set; }
        public Nullable<int> Employee_ID { get; set; }
        public string Pasword { get; set; }
        public string Email { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}

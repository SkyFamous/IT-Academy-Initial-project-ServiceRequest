//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceRequest.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Executor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public int OffersId { get; set; }
        public int CompaniesId { get; set; }
    
        public virtual Company Company { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BNKMVC.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class CR_Verification
    {
        public int Id { get; set; }
        public Nullable<int> CR_AccountId { get; set; }
        public string DocumentUrl { get; set; }
        public string Status { get; set; }
        public string VerificationType { get; set; }
    
        public virtual CR_Account CR_Account { get; set; }
    }
}

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
    
    public partial class tblAccount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblAccount()
        {
            this.ForwardTransfers = new HashSet<ForwardTransfer>();
            this.tblRegisters = new HashSet<tblRegister>();
            this.TransactionCodes = new HashSet<TransactionCode>();
        }
    
        public string acctNo { get; set; }
        public Nullable<decimal> ActiveAmount { get; set; }
        public string currency { get; set; }
        public string userId { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ForwardTransfer> ForwardTransfers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblRegister> tblRegisters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransactionCode> TransactionCodes { get; set; }
    }
}

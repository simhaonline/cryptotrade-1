﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class mbankEntities : DbContext
    {
        public mbankEntities()
            : base("name=mbankEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<CR_Account> CR_Account { get; set; }
        public virtual DbSet<CR_AccountType> CR_AccountType { get; set; }
        public virtual DbSet<CR_Activity> CR_Activity { get; set; }
        public virtual DbSet<CR_Currency> CR_Currency { get; set; }
        public virtual DbSet<CR_Transactions> CR_Transactions { get; set; }
        public virtual DbSet<CR_Verification> CR_Verification { get; set; }
        public virtual DbSet<ForwardTransfer> ForwardTransfers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tblAccount> tblAccounts { get; set; }
        public virtual DbSet<tblAdminLogin> tblAdminLogins { get; set; }
        public virtual DbSet<tblfeedback> tblfeedbacks { get; set; }
        public virtual DbSet<tblLogin> tblLogins { get; set; }
        public virtual DbSet<tblRegister> tblRegisters { get; set; }
        public virtual DbSet<tblTransfer> tblTransfers { get; set; }
        public virtual DbSet<TransactionCode> TransactionCodes { get; set; }
        public virtual DbSet<crypto_payments> crypto_payments { get; set; }
    }
}

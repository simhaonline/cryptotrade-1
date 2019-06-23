namespace BNKMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedAddressType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Address", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Address", c => c.Int(nullable: false));
        }
    }
}

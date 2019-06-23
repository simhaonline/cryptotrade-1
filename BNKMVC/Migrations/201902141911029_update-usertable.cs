namespace BNKMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateusertable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Address", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "CountryId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CountryId");
            DropColumn("dbo.AspNetUsers", "Address");
        }
    }
}

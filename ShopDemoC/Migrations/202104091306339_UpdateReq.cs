namespace ShopDemoC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateReq : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "DisplayText", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "DisplayText", c => c.String());
        }
    }
}

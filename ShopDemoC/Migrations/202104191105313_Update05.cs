namespace ShopDemoC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update05 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Hot", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Hot");
        }
    }
}

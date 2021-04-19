namespace ShopDemoC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update04 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "Info", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Info", c => c.String(maxLength: 500));
            AlterColumn("dbo.Products", "Description", c => c.String(maxLength: 500));
        }
    }
}

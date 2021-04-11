namespace ShopDemoC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Brand", c => c.String(maxLength: 150));
            AddColumn("dbo.Products", "Info", c => c.String(maxLength: 500));
            AddColumn("dbo.Products", "ImgLink1", c => c.String(maxLength: 250));
            AddColumn("dbo.Products", "ImgLink2", c => c.String(maxLength: 250));
            AddColumn("dbo.Products", "ImgLink3", c => c.String(maxLength: 250));
            AddColumn("dbo.Products", "ImgLink4", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ImgLink4");
            DropColumn("dbo.Products", "ImgLink3");
            DropColumn("dbo.Products", "ImgLink2");
            DropColumn("dbo.Products", "ImgLink1");
            DropColumn("dbo.Products", "Info");
            DropColumn("dbo.Products", "Brand");
        }
    }
}

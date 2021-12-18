namespace ProductInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class definefinalstructure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyEntities", "Brand", c => c.String());
            AddColumn("dbo.MyEntities", "Weight", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.MyEntities", "SerialNumber", c => c.Int(nullable: false));
            AddColumn("dbo.MyEntities", "PackagingGrade", c => c.String());
            AddColumn("dbo.MyEntities", "Stock", c => c.Int(nullable: false));
            AddColumn("dbo.MyEntities", "ShipDate", c => c.String());
            AddColumn("dbo.MyEntities", "Location", c => c.String());
            AddColumn("dbo.MyEntities", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MyEntities", "Price");
            DropColumn("dbo.MyEntities", "Location");
            DropColumn("dbo.MyEntities", "ShipDate");
            DropColumn("dbo.MyEntities", "Stock");
            DropColumn("dbo.MyEntities", "PackagingGrade");
            DropColumn("dbo.MyEntities", "SerialNumber");
            DropColumn("dbo.MyEntities", "Weight");
            DropColumn("dbo.MyEntities", "Brand");
        }
    }
}

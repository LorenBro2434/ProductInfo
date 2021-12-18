namespace ProductInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddeletedrow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyEntities", "Deleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MyEntities", "Deleted");
        }
    }
}

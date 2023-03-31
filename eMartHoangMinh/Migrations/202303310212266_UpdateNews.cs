namespace eMartHoangMinh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Category", "Alias", c => c.String());
            AddColumn("dbo.tb_News", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.tb_News", "Alias", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_News", "Alias");
            DropColumn("dbo.tb_News", "IsActive");
            DropColumn("dbo.tb_Category", "Alias");
        }
    }
}

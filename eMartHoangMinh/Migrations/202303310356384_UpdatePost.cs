namespace eMartHoangMinh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Post", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.tb_Post", "Alias", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Post", "Alias");
            DropColumn("dbo.tb_Post", "IsActive");
        }
    }
}

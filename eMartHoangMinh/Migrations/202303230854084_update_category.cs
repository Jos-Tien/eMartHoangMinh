namespace eMartHoangMinh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_category : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Phone", c => c.String());
            AlterColumn("dbo.tb_Category", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.tb_Category", "Description", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Category", "Description", c => c.String());
            AlterColumn("dbo.tb_Category", "Name", c => c.String());
            DropColumn("dbo.AspNetUsers", "Phone");
            DropColumn("dbo.AspNetUsers", "FullName");
        }
    }
}

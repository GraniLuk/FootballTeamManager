namespace FootballTeamManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataUsunieciaMusiBycNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rankings", "RemoveDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rankings", "RemoveDate", c => c.DateTime(nullable: false));
        }
    }
}

namespace FootballTeamManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataWycofaniaDoRankingu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rankings", "RemoveDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rankings", "RemoveDate");
        }
    }
}

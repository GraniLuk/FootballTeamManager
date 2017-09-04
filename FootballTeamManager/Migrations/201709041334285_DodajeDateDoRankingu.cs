namespace FootballTeamManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodajeDateDoRankingu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rankings", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rankings", "Date");
        }
    }
}

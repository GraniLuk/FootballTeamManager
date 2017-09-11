namespace FootballTeamManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NowaKolumnaDoPlayers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "ShortName", c => c.String(nullable: false, maxLength: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "ShortName");
        }
    }
}

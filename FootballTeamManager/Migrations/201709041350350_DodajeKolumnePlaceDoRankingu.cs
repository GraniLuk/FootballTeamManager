namespace FootballTeamManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodajeKolumnePlaceDoRankingu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rankings", "Place", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rankings", "Place");
        }
    }
}

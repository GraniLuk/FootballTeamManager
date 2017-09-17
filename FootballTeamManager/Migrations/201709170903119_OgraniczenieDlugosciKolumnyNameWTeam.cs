namespace FootballTeamManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OgraniczenieDlugosciKolumnyNameWTeam : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teams", "Name", c => c.String(nullable: false, maxLength: 12));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teams", "Name", c => c.String(nullable: false));
        }
    }
}

namespace FootballTeamManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAssociationBetweenPlayerAndTeam : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeamPlayerAssociations",
                c => new
                    {
                        Id = c.Int(false, true),
                        Player_Id = c.Int(),
                        Team_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.Player_Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .Index(t => t.Player_Id)
                .Index(t => t.Team_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeamPlayerAssociations", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.TeamPlayerAssociations", "Player_Id", "dbo.Players");
            DropIndex("dbo.TeamPlayerAssociations", new[] { "Team_Id" });
            DropIndex("dbo.TeamPlayerAssociations", new[] { "Player_Id" });
            DropTable("dbo.TeamPlayerAssociations");
        }
    }
}

namespace FootballTeamManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelaRanking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rankings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Matches = c.Int(nullable: false),
                        Wins = c.Int(nullable: false),
                        Draws = c.Int(nullable: false),
                        Loses = c.Int(nullable: false),
                        PlayerId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.PlayerId_Id)
                .Index(t => t.PlayerId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rankings", "PlayerId_Id", "dbo.Players");
            DropIndex("dbo.Rankings", new[] { "PlayerId_Id" });
            DropTable("dbo.Rankings");
        }
    }
}

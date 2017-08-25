namespace FootballTeamManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WpisyDoTabeliPlayers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Players(Name,Rank,Active) Values (\'£ukasz Granica\',11,1)");
        }
        
        public override void Down()
        {
        }
    }
}

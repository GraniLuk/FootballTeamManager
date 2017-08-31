namespace FootballTeamManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NastepniGracze : DbMigration
    {
        public override void Up()
        {
            //Sql("INSERT INTO Players(Name,Rank,Active) Values (\'Mateusz Wantoch\',10,1)");
            //Sql("INSERT INTO Players(Name,Rank,Active) Values (\'Kamil Pakalski\',6,1)");
        }

        public override void Down()
        {
        }
    }
}

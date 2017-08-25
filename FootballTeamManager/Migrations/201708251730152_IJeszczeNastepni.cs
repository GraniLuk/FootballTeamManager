namespace FootballTeamManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IJeszczeNastepni : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Players(Name,Rank,Active) Values (\'Karol Skupski\',11,1)");
            Sql("INSERT INTO Players(Name,Rank,Active) Values (\'Przemek Stolle\',9,0)");
            Sql("INSERT INTO Players(Name,Rank,Active) Values (\'Damian Kisielewski\',12,0)");
            Sql("INSERT INTO Players(Name,Rank,Active) Values (\'Jarek Mazur\',13,1)");
            Sql("INSERT INTO Players(Name,Rank,Active) Values (\'Krzysztof T\',9,1)");
            Sql("INSERT INTO Players(Name,Rank,Active) Values (\'Vitaly Skripay\',14,1)");
            Sql("INSERT INTO Players(Name,Rank,Active) Values (\'£ukasz Stêpieñ\',10,1)");
            Sql("INSERT INTO Players(Name,Rank,Active) Values (\'£ukasz Tarnowski\',11,1)");
            Sql("INSERT INTO Players(Name,Rank,Active) Values (\'Sylwek Plit\',9,1)");
        
        }

        public override void Down()
        {
        }
    }
}

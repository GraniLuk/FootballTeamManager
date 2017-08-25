namespace FootballTeamManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KolejniGracze : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Players(Name,Rank,Active) Values (\'Pawe³ Cejrowski\',6,0)");
            Sql("INSERT INTO Players(Name,Rank,Active) Values (\'Krzysiek Taranowski\',9,0)");
            Sql("INSERT INTO Players(Name,Rank,Active) Values (\'Sasza od Vitaliya\',6,0)");
            Sql("INSERT INTO Players(Name,Rank,Active) Values (\'Przemek Arszulik\',7,0)");
            Sql("INSERT INTO Players(Name,Rank,Active) Values (\'Sadowski Karol\',5,0)");
            Sql("INSERT INTO Players(Name,Rank,Active) Values (\'Wojciech Ziêtek\',3,0)");
            Sql("INSERT INTO Players(Name,Rank,Active) Values (\'Kuba Krzemiñski\',9,1)");
            Sql("INSERT INTO Players(Name,Rank,Active) Values (\'Hubert Koczergo\',12,0)");
            Sql("INSERT INTO Players(Name,Rank,Active) Values (\'Marcin Urbaniak\',10,0)");
            Sql("INSERT INTO Players(Name,Rank,Active) Values (\'Dorian (od Mateusza)\',8,0)");
            Sql("INSERT INTO Players(Name,Rank,Active) Values (\'Tomek(od Mateusza)\',7,0)");
            Sql("INSERT INTO Players(Name,Rank,Active) Values (\'Maciej (od Jarka)\',8,0)");
            Sql("INSERT INTO Players(Name,Rank,Active) Values (\'Dawid (od Jarka)\',7,1)");
            Sql("INSERT INTO Players(Name,Rank,Active) Values (\'Mateusz (od £ukasz)\',8,1)");
            Sql("INSERT INTO Players(Name,Rank,Active) Values (\'Pawe³ Harhaj\',7,1)");
            Sql("INSERT INTO Players(Name,Rank,Active) Values (\'Adrian od Mateusza\',8,0)");
        }

        public override void Down()
        {
        }
    }
}

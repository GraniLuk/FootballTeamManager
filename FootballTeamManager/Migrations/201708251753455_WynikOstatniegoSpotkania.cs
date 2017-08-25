namespace FootballTeamManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WynikOstatniegoSpotkania : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Teams ([Name]) VALUES('Cwaniaki')");
            Sql("Insert into Teams ([Name]) VALUES('Cieniasy')");
            Sql("Insert into Fixtures (Date,[FirstTeamScore],[SecondTeamScore],[FirstTeam_Id],[SecondTeam_Id]) VALUES('2017-08-22',9,8,1,2) ");
           
        }
        
        public override void Down()
        {
        }
    }
}

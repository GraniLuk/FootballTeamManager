namespace FootballTeamManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeasonToFixture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fixtures", "Season", c => c.Int(nullable: false));
            Sql("UPDATE dbo.Fixtures SET Season =1 where Date <= '2018-01-31 00:00:00.000';");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fixtures", "Season");
        }
    }
}

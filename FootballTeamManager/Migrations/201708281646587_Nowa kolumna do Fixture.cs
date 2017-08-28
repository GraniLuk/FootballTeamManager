namespace FootballTeamManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NowakolumnadoFixture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fixtures", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fixtures", "Name");
        }
    }
}

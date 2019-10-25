namespace FootballTeamManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDoodleNameToPlayer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "DoodleName", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "DoodleName");
        }
    }
}

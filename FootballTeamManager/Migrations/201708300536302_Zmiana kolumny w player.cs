namespace FootballTeamManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Zmianakolumnywplayer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Players", "Name", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.Fixtures", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fixtures", "Name", c => c.String());
            AlterColumn("dbo.Players", "Name", c => c.String(nullable: false));
        }
    }
}

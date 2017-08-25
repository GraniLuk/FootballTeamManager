namespace FootballTeamManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeRequiredFieldsInTeamAndPlayer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teams", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Players", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Players", "Name", c => c.String());
            AlterColumn("dbo.Teams", "Name", c => c.String());
        }
    }
}

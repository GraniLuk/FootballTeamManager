namespace FootballTeamManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170923_Dodanie_LP_do_Player : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "Lp", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "Lp");
        }
    }
}

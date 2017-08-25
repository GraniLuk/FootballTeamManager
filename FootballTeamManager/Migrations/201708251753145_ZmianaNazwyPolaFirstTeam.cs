namespace FootballTeamManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZmianaNazwyPolaFirstTeam : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Fixtures", name: "FirsTeam_Id", newName: "FirstTeam_Id");
            RenameIndex(table: "dbo.Fixtures", name: "IX_FirsTeam_Id", newName: "IX_FirstTeam_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Fixtures", name: "IX_FirstTeam_Id", newName: "IX_FirsTeam_Id");
            RenameColumn(table: "dbo.Fixtures", name: "FirstTeam_Id", newName: "FirsTeam_Id");
        }
    }
}

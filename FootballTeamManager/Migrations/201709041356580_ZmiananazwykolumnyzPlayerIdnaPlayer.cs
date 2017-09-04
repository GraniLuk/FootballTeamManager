namespace FootballTeamManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZmiananazwykolumnyzPlayerIdnaPlayer : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Rankings", name: "PlayerId_Id", newName: "Player_Id");
            RenameIndex(table: "dbo.Rankings", name: "IX_PlayerId_Id", newName: "IX_Player_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Rankings", name: "IX_Player_Id", newName: "IX_PlayerId_Id");
            RenameColumn(table: "dbo.Rankings", name: "Player_Id", newName: "PlayerId_Id");
        }
    }
}

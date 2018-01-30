namespace Cargo4You.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVolume : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Packages", "vol", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Packages", "vol");
        }
    }
}

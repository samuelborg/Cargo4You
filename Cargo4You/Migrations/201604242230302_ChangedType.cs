namespace Cargo4You.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Packages", "height", c => c.Double(nullable: false));
            AlterColumn("dbo.Packages", "width", c => c.Double(nullable: false));
            AlterColumn("dbo.Packages", "depth", c => c.Double(nullable: false));
            AlterColumn("dbo.Packages", "weight", c => c.Double(nullable: false));
            AlterColumn("dbo.Packages", "dprice", c => c.Double(nullable: false));
            AlterColumn("dbo.Packages", "wprice", c => c.Double(nullable: false));
            AlterColumn("dbo.Packages", "price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Packages", "price", c => c.Single(nullable: false));
            AlterColumn("dbo.Packages", "wprice", c => c.Single(nullable: false));
            AlterColumn("dbo.Packages", "dprice", c => c.Single(nullable: false));
            AlterColumn("dbo.Packages", "weight", c => c.Single(nullable: false));
            AlterColumn("dbo.Packages", "depth", c => c.Single(nullable: false));
            AlterColumn("dbo.Packages", "width", c => c.Single(nullable: false));
            AlterColumn("dbo.Packages", "height", c => c.Single(nullable: false));
        }
    }
}

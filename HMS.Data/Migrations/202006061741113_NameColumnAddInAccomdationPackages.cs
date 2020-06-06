namespace HMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameColumnAddInAccomdationPackages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccomodationPackages", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AccomodationPackages", "Name");
        }
    }
}

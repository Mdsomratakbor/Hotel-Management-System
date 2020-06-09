namespace HMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "FullName", c => c.String());
            AddColumn("dbo.User", "Country", c => c.String());
            AddColumn("dbo.User", "City", c => c.String());
            AddColumn("dbo.User", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Address");
            DropColumn("dbo.User", "City");
            DropColumn("dbo.User", "Country");
            DropColumn("dbo.User", "FullName");
        }
    }
}

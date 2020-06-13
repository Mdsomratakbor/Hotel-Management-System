﻿namespace HMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPictures : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccomodationPackagePictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AccomodationPackageID = c.Int(nullable: false),
                        PictuerID = c.Int(nullable: false),
                        Picture_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pictures", t => t.Picture_ID)
                .ForeignKey("dbo.AccomodationPackages", t => t.AccomodationPackageID, cascadeDelete: true)
                .Index(t => t.AccomodationPackageID)
                .Index(t => t.Picture_ID);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        URL = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AccomodationPictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AccomodationID = c.Int(nullable: false),
                        PictuerID = c.Int(nullable: false),
                        Picture_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pictures", t => t.Picture_ID)
                .ForeignKey("dbo.Accomodations", t => t.AccomodationID, cascadeDelete: true)
                .Index(t => t.AccomodationID)
                .Index(t => t.Picture_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccomodationPictures", "AccomodationID", "dbo.Accomodations");
            DropForeignKey("dbo.AccomodationPictures", "Picture_ID", "dbo.Pictures");
            DropForeignKey("dbo.AccomodationPackagePictures", "AccomodationPackageID", "dbo.AccomodationPackages");
            DropForeignKey("dbo.AccomodationPackagePictures", "Picture_ID", "dbo.Pictures");
            DropIndex("dbo.AccomodationPictures", new[] { "Picture_ID" });
            DropIndex("dbo.AccomodationPictures", new[] { "AccomodationID" });
            DropIndex("dbo.AccomodationPackagePictures", new[] { "Picture_ID" });
            DropIndex("dbo.AccomodationPackagePictures", new[] { "AccomodationPackageID" });
            DropTable("dbo.AccomodationPictures");
            DropTable("dbo.Pictures");
            DropTable("dbo.AccomodationPackagePictures");
        }
    }
}

namespace FineRestAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vid2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RestaurantModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        RestaurantName = c.String(),
                        RestaurantDetails = c.String(),
                        Image = c.String(),
                        VID = c.Int(nullable: false),
                        Grade_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.GradeSpreads", t => t.Grade_id, cascadeDelete: true)
                .Index(t => t.Grade_id);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Image = c.String(),
                        VID = c.Int(nullable: false),
                        Grade_id = c.Int(nullable: false),
                        RestaurantModel_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GradeSpreads", t => t.Grade_id, cascadeDelete: true)
                .ForeignKey("dbo.RestaurantModels", t => t.RestaurantModel_id)
                .Index(t => t.Grade_id)
                .Index(t => t.RestaurantModel_id);
            
            CreateTable(
                "dbo.GradeSpreads",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        One = c.Int(nullable: false),
                        Two = c.Int(nullable: false),
                        Three = c.Int(nullable: false),
                        Four = c.Int(nullable: false),
                        Five = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Wines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Image = c.String(),
                        VID = c.Int(nullable: false),
                        Grade_id = c.Int(nullable: false),
                        RestaurantModel_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GradeSpreads", t => t.Grade_id, cascadeDelete: true)
                .ForeignKey("dbo.RestaurantModels", t => t.RestaurantModel_id)
                .Index(t => t.Grade_id)
                .Index(t => t.RestaurantModel_id);
            
            CreateTable(
                "dbo.RestaurantOwners",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Pass = c.String(),
                        Restaurant_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.RestaurantModels", t => t.Restaurant_id, cascadeDelete: true)
                .Index(t => t.Restaurant_id);
            
            CreateTable(
                "dbo.WebUsers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Pass = c.String(),
                        Email = c.String(),
                        VIDs = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RestaurantOwners", "Restaurant_id", "dbo.RestaurantModels");
            DropForeignKey("dbo.Wines", "RestaurantModel_id", "dbo.RestaurantModels");
            DropForeignKey("dbo.Wines", "Grade_id", "dbo.GradeSpreads");
            DropForeignKey("dbo.RestaurantModels", "Grade_id", "dbo.GradeSpreads");
            DropForeignKey("dbo.Foods", "RestaurantModel_id", "dbo.RestaurantModels");
            DropForeignKey("dbo.Foods", "Grade_id", "dbo.GradeSpreads");
            DropIndex("dbo.RestaurantOwners", new[] { "Restaurant_id" });
            DropIndex("dbo.Wines", new[] { "RestaurantModel_id" });
            DropIndex("dbo.Wines", new[] { "Grade_id" });
            DropIndex("dbo.Foods", new[] { "RestaurantModel_id" });
            DropIndex("dbo.Foods", new[] { "Grade_id" });
            DropIndex("dbo.RestaurantModels", new[] { "Grade_id" });
            DropTable("dbo.WebUsers");
            DropTable("dbo.RestaurantOwners");
            DropTable("dbo.Wines");
            DropTable("dbo.GradeSpreads");
            DropTable("dbo.Foods");
            DropTable("dbo.RestaurantModels");
        }
    }
}

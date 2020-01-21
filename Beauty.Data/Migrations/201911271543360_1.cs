namespace Beauty.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkerId = c.Int(nullable: false),
                        ClientFirstname = c.String(),
                        ClientLastname = c.String(),
                        ClientPhoneNumber = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Workers", t => t.WorkerId, cascadeDelete: true)
                .Index(t => t.WorkerId);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Lastname = c.String(),
                        Firstname = c.String(),
                        Middlename = c.String(),
                        Password = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkerPositions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkerId = c.Int(nullable: false),
                        PositionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .ForeignKey("dbo.Workers", t => t.WorkerId, cascadeDelete: true)
                .Index(t => t.WorkerId)
                .Index(t => t.PositionId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkerPositions", "WorkerId", "dbo.Workers");
            DropForeignKey("dbo.WorkerPositions", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Enrollments", "WorkerId", "dbo.Workers");
            DropIndex("dbo.WorkerPositions", new[] { "PositionId" });
            DropIndex("dbo.WorkerPositions", new[] { "WorkerId" });
            DropIndex("dbo.Enrollments", new[] { "WorkerId" });
            DropTable("dbo.Positions");
            DropTable("dbo.WorkerPositions");
            DropTable("dbo.Workers");
            DropTable("dbo.Enrollments");
        }
    }
}

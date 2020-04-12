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
                        ClientFirstname = c.String(),
                        ClientPhoneNumber = c.String(),
                        Description = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        CreationDateTime = c.DateTime(nullable: false),
                        EditDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EnrollmentWorkerServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EnrollmentId = c.Int(nullable: false),
                        WorkerId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Enrollments", t => t.EnrollmentId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Workers", t => t.WorkerId, cascadeDelete: true)
                .Index(t => t.EnrollmentId)
                .Index(t => t.WorkerId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Lastname = c.String(),
                        Firstname = c.String(),
                        Middlename = c.String(),
                        PasswordHash = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PositionServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PositionId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.PositionId)
                .Index(t => t.ServiceId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkerPositions", "WorkerId", "dbo.Workers");
            DropForeignKey("dbo.WorkerPositions", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.PositionServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.PositionServices", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.EnrollmentWorkerServices", "WorkerId", "dbo.Workers");
            DropForeignKey("dbo.EnrollmentWorkerServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.EnrollmentWorkerServices", "EnrollmentId", "dbo.Enrollments");
            DropIndex("dbo.WorkerPositions", new[] { "PositionId" });
            DropIndex("dbo.WorkerPositions", new[] { "WorkerId" });
            DropIndex("dbo.PositionServices", new[] { "ServiceId" });
            DropIndex("dbo.PositionServices", new[] { "PositionId" });
            DropIndex("dbo.EnrollmentWorkerServices", new[] { "ServiceId" });
            DropIndex("dbo.EnrollmentWorkerServices", new[] { "WorkerId" });
            DropIndex("dbo.EnrollmentWorkerServices", new[] { "EnrollmentId" });
            DropTable("dbo.WorkerPositions");
            DropTable("dbo.PositionServices");
            DropTable("dbo.Positions");
            DropTable("dbo.Workers");
            DropTable("dbo.Services");
            DropTable("dbo.EnrollmentWorkerServices");
            DropTable("dbo.Enrollments");
        }
    }
}

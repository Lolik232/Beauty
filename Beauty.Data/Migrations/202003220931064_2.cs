namespace Beauty.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EnrollmentServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EnrollmentId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Enrollments", t => t.EnrollmentId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.EnrollmentId)
                .Index(t => t.ServiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnrollmentServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.EnrollmentServices", "EnrollmentId", "dbo.Enrollments");
            DropIndex("dbo.EnrollmentServices", new[] { "ServiceId" });
            DropIndex("dbo.EnrollmentServices", new[] { "EnrollmentId" });
            DropTable("dbo.EnrollmentServices");
        }
    }
}

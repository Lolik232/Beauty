namespace Beauty.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workers", "PasswordHash", c => c.String());
            DropColumn("dbo.Workers", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workers", "Password", c => c.String());
            DropColumn("dbo.Workers", "PasswordHash");
        }
    }
}

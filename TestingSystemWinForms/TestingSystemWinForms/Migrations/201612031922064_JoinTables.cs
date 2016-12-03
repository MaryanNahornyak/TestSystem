namespace TestingSystemWinForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JoinTables : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.TestResults", "userId");
            AddForeignKey("dbo.TestResults", "userId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestResults", "userId", "dbo.Users");
            DropIndex("dbo.TestResults", new[] { "userId" });
        }
    }
}

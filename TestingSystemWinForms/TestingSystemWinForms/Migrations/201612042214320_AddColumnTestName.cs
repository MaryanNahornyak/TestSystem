namespace TestingSystemWinForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnTestName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestResults", "testName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestResults", "testName");
        }
    }
}

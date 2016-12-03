namespace TestingSystemWinForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTestResults : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestResults",
                c => new
                    {
                        testId = c.Int(nullable: false, identity: true),
                        userId = c.Int(nullable: false),
                        result = c.String(),
                    })
                .PrimaryKey(t => t.testId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TestResults");
        }
    }
}

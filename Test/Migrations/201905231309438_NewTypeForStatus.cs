namespace Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTypeForStatus : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pastas", "Status", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pastas", "Status", c => c.Int(nullable: false));
        }
    }
}

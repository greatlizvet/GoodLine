namespace Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableEndTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pastas", "EndTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pastas", "EndTime", c => c.DateTime(nullable: false));
        }
    }
}

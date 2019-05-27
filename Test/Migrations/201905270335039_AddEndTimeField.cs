namespace Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEndTimeField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pastas", "EndTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pastas", "EndTime");
        }
    }
}

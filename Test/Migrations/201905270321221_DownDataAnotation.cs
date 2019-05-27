namespace Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DownDataAnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pastas", "AuthorName", c => c.String());
            AlterColumn("dbo.Pastas", "Text", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pastas", "Text", c => c.String(nullable: false));
            AlterColumn("dbo.Pastas", "AuthorName", c => c.String(nullable: false));
        }
    }
}

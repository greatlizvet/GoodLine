namespace Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnotation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pastas", "CreationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Pastas", "AuthorName", c => c.String(nullable: false));
            AlterColumn("dbo.Pastas", "Text", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pastas", "Text", c => c.String());
            AlterColumn("dbo.Pastas", "AuthorName", c => c.String());
            DropColumn("dbo.Pastas", "CreationDate");
        }
    }
}

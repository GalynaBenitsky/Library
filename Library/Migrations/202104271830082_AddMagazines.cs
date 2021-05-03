namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMagazines : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Magazines", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Magazines", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Magazines", "NumberInStock", c => c.Byte(nullable: false));
            AlterColumn("dbo.Magazines", "Title", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Books", "Img");
            DropColumn("dbo.Magazines", "Img");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Magazines", "Img", c => c.String());
            AddColumn("dbo.Books", "Img", c => c.String());
            AlterColumn("dbo.Magazines", "Title", c => c.String());
            DropColumn("dbo.Magazines", "NumberInStock");
            DropColumn("dbo.Magazines", "ReleaseDate");
            DropColumn("dbo.Magazines", "DateAdded");
        }
    }
}

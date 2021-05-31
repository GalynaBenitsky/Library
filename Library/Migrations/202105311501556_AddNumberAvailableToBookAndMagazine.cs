namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberAvailableToBookAndMagazine : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "NumberAvailable", c => c.Byte(nullable: false));
            Sql("UPDATE Books SET NumberAvailable = NumberInStock");

            AddColumn("dbo.Magazines", "NumberAvailable", c => c.Byte(nullable: false));
            Sql("UPDATE Magazines SET NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Magazines", "NumberAvailable");
            DropColumn("dbo.Books", "NumberAvailable");
        }
    }
}

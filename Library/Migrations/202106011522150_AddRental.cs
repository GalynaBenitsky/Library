namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddRental : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    DateRented = c.DateTime(nullable: false),
                    DateReturned = c.DateTime(),
                    Reader_Id = c.Int(nullable: false),
                    Book_Id = c.Int(nullable: false),
                    Magazine_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Readers", t => t.Reader_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .ForeignKey("dbo.Magazines", t => t.Magazine_Id, cascadeDelete: true)
                .Index(t => t.Reader_Id)
                .Index(t => t.Book_Id)
                .Index(t => t.Magazine_Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.Rentals", "Magazine_Id", "dbo.Magazines");
            DropForeignKey("dbo.Rentals", "Reader_Id", "dbo.Readers");
            DropIndex("dbo.Rentals", new[] { "Book_Id" });
            DropIndex("dbo.Rentals", new[] { "Magazine_Id" });
            DropIndex("dbo.Rentals", new[] { "Reader_Id" });
            DropTable("dbo.Rentals");
        }
    }
}

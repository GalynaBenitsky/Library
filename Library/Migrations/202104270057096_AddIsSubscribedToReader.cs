namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubscribedToReader : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Readers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Readers", new[] { "MembershipTypeId" });
            DropColumn("dbo.Readers", "MembershipTypeId");
            DropTable("dbo.MembershipTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonth = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Readers", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Readers", "MembershipTypeId");
            AddForeignKey("dbo.Readers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
    }
}

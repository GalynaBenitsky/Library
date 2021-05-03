namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToReaderName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Readers", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Readers", "Name", c => c.String());
        }
    }
}

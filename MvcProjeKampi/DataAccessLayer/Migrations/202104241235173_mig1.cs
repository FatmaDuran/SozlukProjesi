namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contents", "HeadingID", "dbo.Headings");
            DropIndex("dbo.Contents", new[] { "HeadingID" });
            RenameColumn(table: "dbo.Contents", name: "Writer_WriterID", newName: "WriterID");
            RenameIndex(table: "dbo.Contents", name: "IX_Writer_WriterID", newName: "IX_WriterID");
            AlterColumn("dbo.Contents", "HeadingID", c => c.Int(nullable: false));
            CreateIndex("dbo.Contents", "HeadingID");
            AddForeignKey("dbo.Contents", "HeadingID", "dbo.Headings", "HeadingID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "HeadingID", "dbo.Headings");
            DropIndex("dbo.Contents", new[] { "HeadingID" });
            AlterColumn("dbo.Contents", "HeadingID", c => c.Int());
            RenameIndex(table: "dbo.Contents", name: "IX_WriterID", newName: "IX_Writer_WriterID");
            RenameColumn(table: "dbo.Contents", name: "WriterID", newName: "Writer_WriterID");
            CreateIndex("dbo.Contents", "HeadingID");
            AddForeignKey("dbo.Contents", "HeadingID", "dbo.Headings", "HeadingID");
        }
    }
}

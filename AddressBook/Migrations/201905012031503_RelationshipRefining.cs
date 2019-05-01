namespace AddressBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationshipRefining : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Telephones", "contact_ContactId", "dbo.Contacts");
            DropIndex("dbo.Telephones", new[] { "contact_ContactId" });
            RenameColumn(table: "dbo.Telephones", name: "contact_ContactId", newName: "ContactId");
            AlterColumn("dbo.Telephones", "ContactId", c => c.Int(nullable: false));
            CreateIndex("dbo.Telephones", "ContactId");
            AddForeignKey("dbo.Telephones", "ContactId", "dbo.Contacts", "ContactId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telephones", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Telephones", new[] { "ContactId" });
            AlterColumn("dbo.Telephones", "ContactId", c => c.Int());
            RenameColumn(table: "dbo.Telephones", name: "ContactId", newName: "contact_ContactId");
            CreateIndex("dbo.Telephones", "contact_ContactId");
            AddForeignKey("dbo.Telephones", "contact_ContactId", "dbo.Contacts", "ContactId");
        }
    }
}

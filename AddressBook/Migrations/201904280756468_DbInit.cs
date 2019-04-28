namespace AddressBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.Telephones",
                c => new
                    {
                        TelephoneId = c.Int(nullable: false, identity: true),
                        Number = c.String(nullable: false),
                        contact_ContactId = c.Int(),
                    })
                .PrimaryKey(t => t.TelephoneId)
                .ForeignKey("dbo.Contacts", t => t.contact_ContactId)
                .Index(t => t.contact_ContactId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telephones", "contact_ContactId", "dbo.Contacts");
            DropIndex("dbo.Telephones", new[] { "contact_ContactId" });
            DropTable("dbo.Telephones");
            DropTable("dbo.Contacts");
        }
    }
}

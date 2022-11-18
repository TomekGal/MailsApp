namespace MailsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveContactsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Mails", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Contacts", new[] { "UserId" });
            DropIndex("dbo.Mails", new[] { "ContactId" });
            AddColumn("dbo.Mails", "SendTo", c => c.String(nullable: false));
            AddColumn("dbo.Mails", "RecivedFrom", c => c.String());
            DropColumn("dbo.Mails", "ContactId");
            DropTable("dbo.Contacts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailAdress = c.String(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Mails", "ContactId", c => c.Int(nullable: false));
            DropColumn("dbo.Mails", "RecivedFrom");
            DropColumn("dbo.Mails", "SendTo");
            CreateIndex("dbo.Mails", "ContactId");
            CreateIndex("dbo.Contacts", "UserId");
            AddForeignKey("dbo.Contacts", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Mails", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
        }
    }
}

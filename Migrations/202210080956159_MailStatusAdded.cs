namespace MailsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MailStatusAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Mails", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Mails", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Mails", new[] { "Contact_Id" });
            RenameColumn(table: "dbo.Mails", name: "Contact_Id", newName: "ContactId");
            CreateTable(
                "dbo.MailStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Mails", "MailStatusId", c => c.Int(nullable: false));
            AlterColumn("dbo.Mails", "ContactId", c => c.Int(nullable: false));
            CreateIndex("dbo.Mails", "MailStatusId");
            CreateIndex("dbo.Mails", "ContactId");
            AddForeignKey("dbo.Mails", "MailStatusId", "dbo.MailStatus", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Mails", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Contacts", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Mails", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mails", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contacts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Mails", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Mails", "MailStatusId", "dbo.MailStatus");
            DropIndex("dbo.Mails", new[] { "ContactId" });
            DropIndex("dbo.Mails", new[] { "MailStatusId" });
            AlterColumn("dbo.Mails", "ContactId", c => c.Int());
            DropColumn("dbo.Mails", "MailStatusId");
            DropTable("dbo.MailStatus");
            RenameColumn(table: "dbo.Mails", name: "ContactId", newName: "Contact_Id");
            CreateIndex("dbo.Mails", "Contact_Id");
            AddForeignKey("dbo.Mails", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Contacts", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Mails", "Contact_Id", "dbo.Contacts", "Id");
        }
    }
}

namespace MailsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkboxRemove : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Mails", "Mail_Id", "dbo.Mails");
            DropIndex("dbo.Mails", new[] { "Mail_Id" });
            DropColumn("dbo.Mails", "IsChecked");
            DropColumn("dbo.Mails", "Discriminator");
            DropColumn("dbo.Mails", "Mail_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mails", "Mail_Id", c => c.Int());
            AddColumn("dbo.Mails", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Mails", "IsChecked", c => c.Boolean());
            CreateIndex("dbo.Mails", "Mail_Id");
            AddForeignKey("dbo.Mails", "Mail_Id", "dbo.Mails", "Id");
        }
    }
}

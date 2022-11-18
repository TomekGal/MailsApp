namespace MailsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkboxtest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mails", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Mails", "Mail_Id", c => c.Int());
            AlterColumn("dbo.Mails", "IsChecked", c => c.Boolean());
            CreateIndex("dbo.Mails", "Mail_Id");
            AddForeignKey("dbo.Mails", "Mail_Id", "dbo.Mails", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mails", "Mail_Id", "dbo.Mails");
            DropIndex("dbo.Mails", new[] { "Mail_Id" });
            AlterColumn("dbo.Mails", "IsChecked", c => c.Boolean(nullable: false));
            DropColumn("dbo.Mails", "Mail_Id");
            DropColumn("dbo.Mails", "Discriminator");
        }
    }
}

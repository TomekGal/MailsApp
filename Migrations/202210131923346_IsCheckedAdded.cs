namespace MailsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsCheckedAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mails", "IsChecked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mails", "IsChecked");
        }
    }
}

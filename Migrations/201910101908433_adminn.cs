namespace ArticleTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "title", c => c.String(nullable: false));
            AlterColumn("dbo.Articles", "body", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "body", c => c.String());
            AlterColumn("dbo.Articles", "title", c => c.String());
        }
    }
}

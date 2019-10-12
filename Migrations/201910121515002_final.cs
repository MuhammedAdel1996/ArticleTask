namespace ArticleTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ArticleCategories", "name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ArticleCategories", "name", c => c.String());
        }
    }
}

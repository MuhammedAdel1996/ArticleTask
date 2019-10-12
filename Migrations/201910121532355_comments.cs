namespace ArticleTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        comment = c.String(nullable: false),
                        articaleid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Articles", t => t.articaleid, cascadeDelete: true)
                .Index(t => t.articaleid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "articaleid", "dbo.Articles");
            DropIndex("dbo.Comments", new[] { "articaleid" });
            DropTable("dbo.Comments");
        }
    }
}

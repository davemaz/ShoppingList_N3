namespace ShoppingList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Files : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.File",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        ShoppingListItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.ShoppingListItem", t => t.ShoppingListItemId, cascadeDelete: true)
                .Index(t => t.ShoppingListItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.File", "ShoppingListItemId", "dbo.ShoppingListItem");
            DropIndex("dbo.File", new[] { "ShoppingListItemId" });
            DropTable("dbo.File");
        }
    }
}

namespace ShoppingList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Priority : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShoppingListItem", "Priority", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShoppingListItem", "Priority");
        }
    }
}

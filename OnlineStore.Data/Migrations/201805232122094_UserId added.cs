namespace OnlineStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIdadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "UserId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "UserId");
        }
    }
}

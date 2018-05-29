namespace OnlineStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIdToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "UserId", c => c.Long(nullable: false));
        }
    }
}

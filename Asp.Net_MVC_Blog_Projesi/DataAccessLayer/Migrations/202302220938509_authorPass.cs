namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class authorPass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "AuthorPassword", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "AuthorPassword");
        }
    }
}

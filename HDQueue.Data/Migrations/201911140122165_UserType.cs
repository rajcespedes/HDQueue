namespace HDQueue.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "TipoDeUsuario", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "TipoDeUsuario");
        }
    }
}

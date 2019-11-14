namespace HDQueue.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ANoviembre13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "UserId", "dbo.AspNetUsers");
            AddColumn("dbo.Tickets", "TecnicoId", c => c.String(maxLength: 128));
            AddColumn("dbo.Tickets", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Tickets", "TecnicoId");
            CreateIndex("dbo.Tickets", "ApplicationUser_Id");
            AddForeignKey("dbo.Tickets", "TecnicoId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Tickets", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Tickets", "Tecnico");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "Tecnico", c => c.String());
            DropForeignKey("dbo.Tickets", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "TecnicoId", "dbo.AspNetUsers");
            DropIndex("dbo.Tickets", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Tickets", new[] { "TecnicoId" });
            DropColumn("dbo.Tickets", "ApplicationUser_Id");
            DropColumn("dbo.Tickets", "TecnicoId");
            AddForeignKey("dbo.Tickets", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}

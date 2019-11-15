namespace HDQueue.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCierre : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cierres",
                c => new
                    {
                        TicketID = c.Int(nullable: false),
                        TecnicoId = c.String(nullable: false, maxLength: 128),
                        ComentarioCierre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TicketID)
                .ForeignKey("dbo.AspNetUsers", t => t.TecnicoId, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.TicketID)
                .Index(t => t.TicketID)
                .Index(t => t.TecnicoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cierres", "TicketID", "dbo.Tickets");
            DropForeignKey("dbo.Cierres", "TecnicoId", "dbo.AspNetUsers");
            DropIndex("dbo.Cierres", new[] { "TecnicoId" });
            DropIndex("dbo.Cierres", new[] { "TicketID" });
            DropTable("dbo.Cierres");
        }
    }
}

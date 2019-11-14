namespace HDQueue.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AFechaInTicket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "Fecha", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "Fecha");
        }
    }
}

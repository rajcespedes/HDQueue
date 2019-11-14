namespace HDQueue.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificacionFecha : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "Estado", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "Estado", c => c.String());
        }
    }
}

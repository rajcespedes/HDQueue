namespace HDQueue.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "Comentario", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "Comentario");
        }
    }
}

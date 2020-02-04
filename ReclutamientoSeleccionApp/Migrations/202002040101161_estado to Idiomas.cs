namespace ReclutamientoSeleccionApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class estadotoIdiomas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Idiomas", "Estado", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Idiomas", "Estado");
        }
    }
}

namespace ReclutamientoSeleccionApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class estadoencompetenca : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Competencias", "Estado", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Competencias", "Estado");
        }
    }
}

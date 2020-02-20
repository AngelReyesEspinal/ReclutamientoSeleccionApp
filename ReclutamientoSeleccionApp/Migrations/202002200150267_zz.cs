namespace ReclutamientoSeleccionApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zz : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Candidatos", "Experiencia");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Candidatos", "Experiencia", c => c.String());
        }
    }
}

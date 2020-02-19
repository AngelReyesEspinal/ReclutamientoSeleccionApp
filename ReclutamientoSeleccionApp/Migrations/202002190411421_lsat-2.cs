namespace ReclutamientoSeleccionApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lsat2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidatos", "Nombres", c => c.String());
            AddColumn("dbo.Candidatos", "Apellidos", c => c.String());
            DropColumn("dbo.Candidatos", "Nombre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Candidatos", "Nombre", c => c.String());
            DropColumn("dbo.Candidatos", "Apellidos");
            DropColumn("dbo.Candidatos", "Nombres");
        }
    }
}

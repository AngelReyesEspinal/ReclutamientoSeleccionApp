namespace ReclutamientoSeleccionApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instituciones", "NombreInstitucion", c => c.String());
            AddColumn("dbo.Niveles", "Titulo", c => c.String());
            DropColumn("dbo.Instituciones", "Nombre");
            DropColumn("dbo.Niveles", "Descripcion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Niveles", "Descripcion", c => c.String());
            AddColumn("dbo.Instituciones", "Nombre", c => c.String());
            DropColumn("dbo.Niveles", "Titulo");
            DropColumn("dbo.Instituciones", "NombreInstitucion");
        }
    }
}

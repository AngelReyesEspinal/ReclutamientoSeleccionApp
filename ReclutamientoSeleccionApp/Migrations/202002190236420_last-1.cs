namespace ReclutamientoSeleccionApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class last1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Candidatos", "DatoPersonalId", "dbo.DatosPersonales");
            DropForeignKey("dbo.Empleados", "DatoPersonalId", "dbo.DatosPersonales");
            DropIndex("dbo.Candidatos", new[] { "DatoPersonalId" });
            DropIndex("dbo.Empleados", new[] { "DatoPersonalId" });
            AddColumn("dbo.Candidatos", "Cedula", c => c.String());
            AddColumn("dbo.Candidatos", "Nombre", c => c.String());
            DropColumn("dbo.Candidatos", "DatoPersonalId");
            DropColumn("dbo.Empleados", "DatoPersonalId");
            DropTable("dbo.DatosPersonales");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DatosPersonales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cedula = c.String(),
                        Nombre = c.String(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Empleados", "DatoPersonalId", c => c.Int(nullable: false));
            AddColumn("dbo.Candidatos", "DatoPersonalId", c => c.Int(nullable: false));
            DropColumn("dbo.Candidatos", "Nombre");
            DropColumn("dbo.Candidatos", "Cedula");
            CreateIndex("dbo.Empleados", "DatoPersonalId");
            CreateIndex("dbo.Candidatos", "DatoPersonalId");
            AddForeignKey("dbo.Empleados", "DatoPersonalId", "dbo.DatosPersonales", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Candidatos", "DatoPersonalId", "dbo.DatosPersonales", "Id", cascadeDelete: true);
        }
    }
}

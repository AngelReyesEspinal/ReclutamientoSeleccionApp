namespace ReclutamientoSeleccionApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingnivelderiesgotoenum : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Puestos", "NivelRiesgoId", "dbo.NivelesDeRiesgo");
            DropIndex("dbo.Puestos", new[] { "NivelRiesgoId" });
            AddColumn("dbo.Puestos", "NivelDeRiesgo", c => c.Int(nullable: false));
            DropColumn("dbo.Puestos", "NivelRiesgoId");
            DropTable("dbo.NivelesDeRiesgo");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.NivelesDeRiesgo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Puestos", "NivelRiesgoId", c => c.Int(nullable: false));
            DropColumn("dbo.Puestos", "NivelDeRiesgo");
            CreateIndex("dbo.Puestos", "NivelRiesgoId");
            AddForeignKey("dbo.Puestos", "NivelRiesgoId", "dbo.NivelesDeRiesgo", "Id", cascadeDelete: true);
        }
    }
}

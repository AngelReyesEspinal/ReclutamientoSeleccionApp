namespace ReclutamientoSeleccionApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class institucion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExperienciasLaborales", "EmpresaId", "dbo.Empresas");
            DropIndex("dbo.ExperienciasLaborales", new[] { "EmpresaId" });
            AddColumn("dbo.ExperienciasLaborales", "InstitucionId", c => c.Int(nullable: false));
            AddColumn("dbo.ExperienciasLaborales", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.ExperienciasLaborales", "InstitucionId");
            CreateIndex("dbo.ExperienciasLaborales", "UserId");
            AddForeignKey("dbo.ExperienciasLaborales", "InstitucionId", "dbo.Instituciones", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ExperienciasLaborales", "UserId", "dbo.Usuarios", "Id", cascadeDelete: true);
            DropColumn("dbo.ExperienciasLaborales", "EmpresaId");
            DropTable("dbo.Empresas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ExperienciasLaborales", "EmpresaId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ExperienciasLaborales", "UserId", "dbo.Usuarios");
            DropForeignKey("dbo.ExperienciasLaborales", "InstitucionId", "dbo.Instituciones");
            DropIndex("dbo.ExperienciasLaborales", new[] { "UserId" });
            DropIndex("dbo.ExperienciasLaborales", new[] { "InstitucionId" });
            DropColumn("dbo.ExperienciasLaborales", "UserId");
            DropColumn("dbo.ExperienciasLaborales", "InstitucionId");
            CreateIndex("dbo.ExperienciasLaborales", "EmpresaId");
            AddForeignKey("dbo.ExperienciasLaborales", "EmpresaId", "dbo.Empresas", "Id", cascadeDelete: true);
        }
    }
}

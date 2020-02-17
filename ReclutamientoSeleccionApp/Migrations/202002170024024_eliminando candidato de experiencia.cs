namespace ReclutamientoSeleccionApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eliminandocandidatodeexperiencia : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExperienciaLaboralCandidatoes", "ExperienciaLaboral_Id", "dbo.ExperienciasLaborales");
            DropForeignKey("dbo.ExperienciaLaboralCandidatoes", "Candidato_Id", "dbo.Candidatos");
            DropIndex("dbo.ExperienciaLaboralCandidatoes", new[] { "ExperienciaLaboral_Id" });
            DropIndex("dbo.ExperienciaLaboralCandidatoes", new[] { "Candidato_Id" });
            AddColumn("dbo.ExperienciasLaborales", "Candidato_Id", c => c.Int());
            CreateIndex("dbo.ExperienciasLaborales", "Candidato_Id");
            AddForeignKey("dbo.ExperienciasLaborales", "Candidato_Id", "dbo.Candidatos", "Id");
            DropTable("dbo.ExperienciaLaboralCandidatoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ExperienciaLaboralCandidatoes",
                c => new
                    {
                        ExperienciaLaboral_Id = c.Int(nullable: false),
                        Candidato_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ExperienciaLaboral_Id, t.Candidato_Id });
            
            DropForeignKey("dbo.ExperienciasLaborales", "Candidato_Id", "dbo.Candidatos");
            DropIndex("dbo.ExperienciasLaborales", new[] { "Candidato_Id" });
            DropColumn("dbo.ExperienciasLaborales", "Candidato_Id");
            CreateIndex("dbo.ExperienciaLaboralCandidatoes", "Candidato_Id");
            CreateIndex("dbo.ExperienciaLaboralCandidatoes", "ExperienciaLaboral_Id");
            AddForeignKey("dbo.ExperienciaLaboralCandidatoes", "Candidato_Id", "dbo.Candidatos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ExperienciaLaboralCandidatoes", "ExperienciaLaboral_Id", "dbo.ExperienciasLaborales", "Id", cascadeDelete: true);
        }
    }
}

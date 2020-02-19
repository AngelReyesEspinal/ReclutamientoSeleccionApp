namespace ReclutamientoSeleccionApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lsat3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExperienciasLaborales", "Candidato_Id", "dbo.Candidatos");
            DropIndex("dbo.ExperienciasLaborales", new[] { "Candidato_Id" });
            CreateTable(
                "dbo.ExperienciaLaboralCandidatoes",
                c => new
                    {
                        ExperienciaLaboral_Id = c.Int(nullable: false),
                        Candidato_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ExperienciaLaboral_Id, t.Candidato_Id })
                .ForeignKey("dbo.ExperienciasLaborales", t => t.ExperienciaLaboral_Id, cascadeDelete: false)
                .ForeignKey("dbo.Candidatos", t => t.Candidato_Id, cascadeDelete: false)
                .Index(t => t.ExperienciaLaboral_Id)
                .Index(t => t.Candidato_Id);
            
            DropColumn("dbo.ExperienciasLaborales", "Candidato_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExperienciasLaborales", "Candidato_Id", c => c.Int());
            DropForeignKey("dbo.ExperienciaLaboralCandidatoes", "Candidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.ExperienciaLaboralCandidatoes", "ExperienciaLaboral_Id", "dbo.ExperienciasLaborales");
            DropIndex("dbo.ExperienciaLaboralCandidatoes", new[] { "Candidato_Id" });
            DropIndex("dbo.ExperienciaLaboralCandidatoes", new[] { "ExperienciaLaboral_Id" });
            DropTable("dbo.ExperienciaLaboralCandidatoes");
            CreateIndex("dbo.ExperienciasLaborales", "Candidato_Id");
            AddForeignKey("dbo.ExperienciasLaborales", "Candidato_Id", "dbo.Candidatos", "Id");
        }
    }
}

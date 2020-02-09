namespace ReclutamientoSeleccionApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingmanytomanyrelationships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Capacitaciones", "Candidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.Competencias", "Candidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.ExperienciasLaborales", "Candidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.Idiomas", "Candidato_Id", "dbo.Candidatos");
            DropIndex("dbo.Capacitaciones", new[] { "Candidato_Id" });
            DropIndex("dbo.Competencias", new[] { "Candidato_Id" });
            DropIndex("dbo.ExperienciasLaborales", new[] { "Candidato_Id" });
            DropIndex("dbo.Idiomas", new[] { "Candidato_Id" });
            CreateTable(
                "dbo.CapacitacionCandidatoes",
                c => new
                    {
                        Capacitacion_Id = c.Int(nullable: false),
                        Candidato_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Capacitacion_Id, t.Candidato_Id })
                .ForeignKey("dbo.Capacitaciones", t => t.Capacitacion_Id, cascadeDelete: false)
                .ForeignKey("dbo.Candidatos", t => t.Candidato_Id, cascadeDelete: false)
                .Index(t => t.Capacitacion_Id)
                .Index(t => t.Candidato_Id);
            
            CreateTable(
                "dbo.CompetenciaCandidatoes",
                c => new
                    {
                        Competencia_Id = c.Int(nullable: false),
                        Candidato_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Competencia_Id, t.Candidato_Id })
                .ForeignKey("dbo.Competencias", t => t.Competencia_Id, cascadeDelete: false)
                .ForeignKey("dbo.Candidatos", t => t.Candidato_Id, cascadeDelete: false)
                .Index(t => t.Competencia_Id)
                .Index(t => t.Candidato_Id);
            
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
            
            CreateTable(
                "dbo.IdiomaCandidatoes",
                c => new
                    {
                        Idioma_Id = c.Int(nullable: false),
                        Candidato_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Idioma_Id, t.Candidato_Id })
                .ForeignKey("dbo.Idiomas", t => t.Idioma_Id, cascadeDelete: false)
                .ForeignKey("dbo.Candidatos", t => t.Candidato_Id, cascadeDelete: false)
                .Index(t => t.Idioma_Id)
                .Index(t => t.Candidato_Id);
            
            DropColumn("dbo.Capacitaciones", "Candidato_Id");
            DropColumn("dbo.Competencias", "Candidato_Id");
            DropColumn("dbo.ExperienciasLaborales", "Candidato_Id");
            DropColumn("dbo.Idiomas", "Candidato_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Idiomas", "Candidato_Id", c => c.Int());
            AddColumn("dbo.ExperienciasLaborales", "Candidato_Id", c => c.Int());
            AddColumn("dbo.Competencias", "Candidato_Id", c => c.Int());
            AddColumn("dbo.Capacitaciones", "Candidato_Id", c => c.Int());
            DropForeignKey("dbo.IdiomaCandidatoes", "Candidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.IdiomaCandidatoes", "Idioma_Id", "dbo.Idiomas");
            DropForeignKey("dbo.ExperienciaLaboralCandidatoes", "Candidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.ExperienciaLaboralCandidatoes", "ExperienciaLaboral_Id", "dbo.ExperienciasLaborales");
            DropForeignKey("dbo.CompetenciaCandidatoes", "Candidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.CompetenciaCandidatoes", "Competencia_Id", "dbo.Competencias");
            DropForeignKey("dbo.CapacitacionCandidatoes", "Candidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.CapacitacionCandidatoes", "Capacitacion_Id", "dbo.Capacitaciones");
            DropIndex("dbo.IdiomaCandidatoes", new[] { "Candidato_Id" });
            DropIndex("dbo.IdiomaCandidatoes", new[] { "Idioma_Id" });
            DropIndex("dbo.ExperienciaLaboralCandidatoes", new[] { "Candidato_Id" });
            DropIndex("dbo.ExperienciaLaboralCandidatoes", new[] { "ExperienciaLaboral_Id" });
            DropIndex("dbo.CompetenciaCandidatoes", new[] { "Candidato_Id" });
            DropIndex("dbo.CompetenciaCandidatoes", new[] { "Competencia_Id" });
            DropIndex("dbo.CapacitacionCandidatoes", new[] { "Candidato_Id" });
            DropIndex("dbo.CapacitacionCandidatoes", new[] { "Capacitacion_Id" });
            DropTable("dbo.IdiomaCandidatoes");
            DropTable("dbo.ExperienciaLaboralCandidatoes");
            DropTable("dbo.CompetenciaCandidatoes");
            DropTable("dbo.CapacitacionCandidatoes");
            CreateIndex("dbo.Idiomas", "Candidato_Id");
            CreateIndex("dbo.ExperienciasLaborales", "Candidato_Id");
            CreateIndex("dbo.Competencias", "Candidato_Id");
            CreateIndex("dbo.Capacitaciones", "Candidato_Id");
            AddForeignKey("dbo.Idiomas", "Candidato_Id", "dbo.Candidatos", "Id");
            AddForeignKey("dbo.ExperienciasLaborales", "Candidato_Id", "dbo.Candidatos", "Id");
            AddForeignKey("dbo.Competencias", "Candidato_Id", "dbo.Candidatos", "Id");
            AddForeignKey("dbo.Capacitaciones", "Candidato_Id", "dbo.Candidatos", "Id");
        }
    }
}

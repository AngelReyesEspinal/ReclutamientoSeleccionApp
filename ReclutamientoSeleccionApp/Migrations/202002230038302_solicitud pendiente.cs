namespace ReclutamientoSeleccionApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class solicitudpendiente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SolicitudPendientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CandidatoId = c.Int(nullable: false),
                        FueAceptado = c.Boolean(nullable: false),
                        EstaPendiente = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidatos", t => t.CandidatoId, cascadeDelete: true)
                .Index(t => t.CandidatoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SolicitudPendientes", "CandidatoId", "dbo.Candidatos");
            DropIndex("dbo.SolicitudPendientes", new[] { "CandidatoId" });
            DropTable("dbo.SolicitudPendientes");
        }
    }
}

namespace ReclutamientoSeleccionApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creandodependenciaenempleadodecandidato : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empleados", "CandidatoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Empleados", "CandidatoId");
            AddForeignKey("dbo.Empleados", "CandidatoId", "dbo.Candidatos", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empleados", "CandidatoId", "dbo.Candidatos");
            DropIndex("dbo.Empleados", new[] { "CandidatoId" });
            DropColumn("dbo.Empleados", "CandidatoId");
        }
    }
}

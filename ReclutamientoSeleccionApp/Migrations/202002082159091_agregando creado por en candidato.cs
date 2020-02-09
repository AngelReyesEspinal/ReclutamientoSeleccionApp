namespace ReclutamientoSeleccionApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregandocreadoporencandidato : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidatos", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Candidatos", "UserId");
            AddForeignKey("dbo.Candidatos", "UserId", "dbo.Usuarios", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidatos", "UserId", "dbo.Usuarios");
            DropIndex("dbo.Candidatos", new[] { "UserId" });
            DropColumn("dbo.Candidatos", "UserId");
        }
    }
}

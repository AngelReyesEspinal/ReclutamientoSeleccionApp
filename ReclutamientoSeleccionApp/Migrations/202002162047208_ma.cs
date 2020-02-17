namespace ReclutamientoSeleccionApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ma : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Capacitaciones", "PuestoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Capacitaciones", "PuestoId");
            AddForeignKey("dbo.Capacitaciones", "PuestoId", "dbo.Puestos", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Capacitaciones", "PuestoId", "dbo.Puestos");
            DropIndex("dbo.Capacitaciones", new[] { "PuestoId" });
            DropColumn("dbo.Capacitaciones", "PuestoId");
        }
    }
}

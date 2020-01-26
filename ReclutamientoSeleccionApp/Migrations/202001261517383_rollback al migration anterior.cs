﻿namespace ReclutamientoSeleccionApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rollbackalmigrationanterior : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidatos", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Capacitaciones", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Instituciones", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Niveles", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Competencias", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Puestos", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.DatosPersonales", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Departamentos", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.ExperienciasLaborales", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Empresas", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Idiomas", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Empleados", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "Deleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Candidatos", "Estado");
            DropColumn("dbo.Capacitaciones", "Estado");
            DropColumn("dbo.Instituciones", "Estado");
            DropColumn("dbo.Niveles", "Estado");
            DropColumn("dbo.Competencias", "Estado");
            DropColumn("dbo.DatosPersonales", "Estado");
            DropColumn("dbo.Departamentos", "Estado");
            DropColumn("dbo.ExperienciasLaborales", "Estado");
            DropColumn("dbo.Empresas", "Estado");
            DropColumn("dbo.Idiomas", "Estado");
            DropColumn("dbo.Empleados", "Estado");
            DropColumn("dbo.Usuarios", "Estado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "Estado", c => c.Int(nullable: false));
            AddColumn("dbo.Empleados", "Estado", c => c.Int(nullable: false));
            AddColumn("dbo.Idiomas", "Estado", c => c.Int(nullable: false));
            AddColumn("dbo.Empresas", "Estado", c => c.Int(nullable: false));
            AddColumn("dbo.ExperienciasLaborales", "Estado", c => c.Int(nullable: false));
            AddColumn("dbo.Departamentos", "Estado", c => c.Int(nullable: false));
            AddColumn("dbo.DatosPersonales", "Estado", c => c.Int(nullable: false));
            AddColumn("dbo.Competencias", "Estado", c => c.Int(nullable: false));
            AddColumn("dbo.Niveles", "Estado", c => c.Int(nullable: false));
            AddColumn("dbo.Instituciones", "Estado", c => c.Int(nullable: false));
            AddColumn("dbo.Capacitaciones", "Estado", c => c.Int(nullable: false));
            AddColumn("dbo.Candidatos", "Estado", c => c.Int(nullable: false));
            DropColumn("dbo.Usuarios", "Deleted");
            DropColumn("dbo.Empleados", "Deleted");
            DropColumn("dbo.Idiomas", "Deleted");
            DropColumn("dbo.Empresas", "Deleted");
            DropColumn("dbo.ExperienciasLaborales", "Deleted");
            DropColumn("dbo.Departamentos", "Deleted");
            DropColumn("dbo.DatosPersonales", "Deleted");
            DropColumn("dbo.Puestos", "Deleted");
            DropColumn("dbo.Competencias", "Deleted");
            DropColumn("dbo.Niveles", "Deleted");
            DropColumn("dbo.Instituciones", "Deleted");
            DropColumn("dbo.Capacitaciones", "Deleted");
            DropColumn("dbo.Candidatos", "Deleted");
        }
    }
}

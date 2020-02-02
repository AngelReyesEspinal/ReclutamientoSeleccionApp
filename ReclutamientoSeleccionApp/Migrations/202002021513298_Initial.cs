namespace ReclutamientoSeleccionApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidatos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecomendadoPor = c.String(),
                        Experiencia = c.String(),
                        Salario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PuestoId = c.Int(nullable: false),
                        DepartamentoId = c.Int(nullable: false),
                        DatoPersonalId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DatosPersonales", t => t.DatoPersonalId, cascadeDelete: true)
                .ForeignKey("dbo.Departamentos", t => t.DepartamentoId, cascadeDelete: true)
                .ForeignKey("dbo.Puestos", t => t.PuestoId, cascadeDelete: true)
                .Index(t => t.PuestoId)
                .Index(t => t.DepartamentoId)
                .Index(t => t.DatoPersonalId);
            
            CreateTable(
                "dbo.Capacitaciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        FechaDesde = c.DateTime(nullable: false),
                        FechaHasta = c.DateTime(nullable: false),
                        NivelId = c.Int(nullable: false),
                        InstitucionId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Candidato_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Instituciones", t => t.InstitucionId, cascadeDelete: true)
                .ForeignKey("dbo.Niveles", t => t.NivelId, cascadeDelete: true)
                .ForeignKey("dbo.Candidatos", t => t.Candidato_Id)
                .Index(t => t.NivelId)
                .Index(t => t.InstitucionId)
                .Index(t => t.Candidato_Id);
            
            CreateTable(
                "dbo.Instituciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Niveles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Competencias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        PuestoId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Candidato_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Puestos", t => t.PuestoId, cascadeDelete: true)
                .ForeignKey("dbo.Candidatos", t => t.Candidato_Id)
                .Index(t => t.PuestoId)
                .Index(t => t.Candidato_Id);
            
            CreateTable(
                "dbo.Puestos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        SalarioMinimo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalarioMaximo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.Int(nullable: false),
                        NivelDeRiesgo = c.Int(nullable: false),
                        DepartamentoId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departamentos", t => t.DepartamentoId, cascadeDelete: false)
                .Index(t => t.DepartamentoId);
            
            CreateTable(
                "dbo.Departamentos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DatosPersonales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cedula = c.String(),
                        Nombre = c.String(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExperienciasLaborales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PuestoOcupado = c.String(),
                        Salario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaDesde = c.DateTime(nullable: false),
                        FechaHasta = c.DateTime(nullable: false),
                        EmpresaId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Candidato_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresas", t => t.EmpresaId, cascadeDelete: true)
                .ForeignKey("dbo.Candidatos", t => t.Candidato_Id)
                .Index(t => t.EmpresaId)
                .Index(t => t.Candidato_Id);
            
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Idiomas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        Candidato_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidatos", t => t.Candidato_Id)
                .Index(t => t.Candidato_Id);
            
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Salario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PuestoId = c.Int(nullable: false),
                        DepartamentoId = c.Int(nullable: false),
                        FechaIngreso = c.DateTime(nullable: false),
                        DatoPersonalId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DatosPersonales", t => t.DatoPersonalId, cascadeDelete: true)
                .ForeignKey("dbo.Departamentos", t => t.DepartamentoId, cascadeDelete: true)
                .ForeignKey("dbo.Puestos", t => t.PuestoId, cascadeDelete: true)
                .Index(t => t.PuestoId)
                .Index(t => t.DepartamentoId)
                .Index(t => t.DatoPersonalId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Rol = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empleados", "PuestoId", "dbo.Puestos");
            DropForeignKey("dbo.Empleados", "DepartamentoId", "dbo.Departamentos");
            DropForeignKey("dbo.Empleados", "DatoPersonalId", "dbo.DatosPersonales");
            DropForeignKey("dbo.Candidatos", "PuestoId", "dbo.Puestos");
            DropForeignKey("dbo.Idiomas", "Candidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.ExperienciasLaborales", "Candidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.ExperienciasLaborales", "EmpresaId", "dbo.Empresas");
            DropForeignKey("dbo.Candidatos", "DepartamentoId", "dbo.Departamentos");
            DropForeignKey("dbo.Candidatos", "DatoPersonalId", "dbo.DatosPersonales");
            DropForeignKey("dbo.Competencias", "Candidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.Competencias", "PuestoId", "dbo.Puestos");
            DropForeignKey("dbo.Puestos", "DepartamentoId", "dbo.Departamentos");
            DropForeignKey("dbo.Capacitaciones", "Candidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.Capacitaciones", "NivelId", "dbo.Niveles");
            DropForeignKey("dbo.Capacitaciones", "InstitucionId", "dbo.Instituciones");
            DropIndex("dbo.Empleados", new[] { "DatoPersonalId" });
            DropIndex("dbo.Empleados", new[] { "DepartamentoId" });
            DropIndex("dbo.Empleados", new[] { "PuestoId" });
            DropIndex("dbo.Idiomas", new[] { "Candidato_Id" });
            DropIndex("dbo.ExperienciasLaborales", new[] { "Candidato_Id" });
            DropIndex("dbo.ExperienciasLaborales", new[] { "EmpresaId" });
            DropIndex("dbo.Puestos", new[] { "DepartamentoId" });
            DropIndex("dbo.Competencias", new[] { "Candidato_Id" });
            DropIndex("dbo.Competencias", new[] { "PuestoId" });
            DropIndex("dbo.Capacitaciones", new[] { "Candidato_Id" });
            DropIndex("dbo.Capacitaciones", new[] { "InstitucionId" });
            DropIndex("dbo.Capacitaciones", new[] { "NivelId" });
            DropIndex("dbo.Candidatos", new[] { "DatoPersonalId" });
            DropIndex("dbo.Candidatos", new[] { "DepartamentoId" });
            DropIndex("dbo.Candidatos", new[] { "PuestoId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Empleados");
            DropTable("dbo.Idiomas");
            DropTable("dbo.Empresas");
            DropTable("dbo.ExperienciasLaborales");
            DropTable("dbo.DatosPersonales");
            DropTable("dbo.Departamentos");
            DropTable("dbo.Puestos");
            DropTable("dbo.Competencias");
            DropTable("dbo.Niveles");
            DropTable("dbo.Instituciones");
            DropTable("dbo.Capacitaciones");
            DropTable("dbo.Candidatos");
        }
    }
}

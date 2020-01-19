using ReclutamientoSeleccionApp.Core.DataModel.Base;
using ReclutamientoSeleccionApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.DataModel.Models
{
    public class Contexto : DbContext
    {
        public Contexto() : base("name=ReclutamientoSeleccionAppConnectionString")
        {
        }
      
        public DbSet<User> Usuarios { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<ExperienciaLaboral> ExperienciasLaborales { get; set; }
        public DbSet<DatoPersonal> DatosPersonales { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Nivel> Niveles { get; set; }
        public DbSet<Institucion> Instituciones { get; set; }
        public DbSet<Capacitacion> Capacitaciones { get; set; }
        public DbSet<NivelRiesgo> NivelesDeRiesgo { get; set; }
        public DbSet<Puesto> Puestos { get; set; }
        public DbSet<Competencia> Competencias { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }

        private int BeforeSave(Func<int> action)
        {
            foreach (var entry in ChangeTracker.Entries<IBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Deleted = false;
                        break;
                    case EntityState.Modified:
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.Deleted = true;
                        goto case EntityState.Modified;
                    default:
                        break;
                }
            }
            return action.Invoke();
        }
        public override int SaveChanges()
        {
            return BeforeSave(() => base.SaveChanges());
        }
    }
}

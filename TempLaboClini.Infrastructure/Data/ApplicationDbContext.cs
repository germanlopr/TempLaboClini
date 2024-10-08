using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using TempLaboClini.Domain.Entities;

namespace TempLaboClini.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entity relationships and constraints

            modelBuilder.Entity<Examen>()
                .HasOne(e => e.Area)
                .WithMany(a => a.Examenes)
                .HasForeignKey(e => e.AreaId);

            modelBuilder.Entity<ExamenMuestra>()
                .HasKey(em => new { em.ExamenId, em.MuestraId });

            modelBuilder.Entity<ExamenMuestra>()
                .HasOne(em => em.Examen)
                .WithMany(e => e.ExamenesMuestras)
                .HasForeignKey(em => em.ExamenId);

            modelBuilder.Entity<ExamenMuestra>()
                .HasOne(em => em.Muestra)
                .WithMany(m => m.ExamenesMuestras)
                .HasForeignKey(em => em.MuestraId);

            modelBuilder.Entity<Paciente>()
                .HasOne(p => p.Direccion)
                .WithMany()
                .HasForeignKey(p => p.DireccionId);

            modelBuilder.Entity<Prueba>()
                .HasOne(p => p.Examen)
                .WithMany(e => e.Pruebas)
                .HasForeignKey(p => p.ExamenId);

            modelBuilder.Entity<SolicitudExamen>()
                .HasOne(se => se.Paciente)
                .WithMany(p => p.SolicitudesExamenes)
                .HasForeignKey(se => se.PacienteId);

            modelBuilder.Entity<SolicitudExamen>()
                .HasOne(se => se.Aseguradora)
                .WithMany(a => a.SolicitudesExamenes)
                .HasForeignKey(se => se.AseguradoraId);

            modelBuilder.Entity<SolicitudExamen>()
                .HasOne(se => se.Medico)
                .WithMany(m => m.SolicitudesExamenes)
                .HasForeignKey(se => se.MedicoId);

            modelBuilder.Entity<ExamenSolicitado>()
                .HasOne(es => es.SolicitudExamen)
                .WithMany(se => se.ExamenesSolicitados)
                .HasForeignKey(es => es.SolicitudExamenId);

            modelBuilder.Entity<ExamenSolicitado>()
                .HasOne(es => es.Examen)
                .WithMany(e => e.ExamenesSolicitados)
                .HasForeignKey(es => es.ExamenId);

            modelBuilder.Entity<ValorReferencia>()
                .HasOne(vr => vr.Prueba)
                .WithMany(p => p.ValoresReferencia)
                .HasForeignKey(vr => vr.PruebaId);

            modelBuilder.Entity<Resultado>()
                .HasOne(r => r.ExamenSolicitado)
                .WithMany(es => es.Resultados)
                .HasForeignKey(r => r.ExamenSolicitadoId);

            modelBuilder.Entity<Resultado>()
                .HasOne(r => r.PersonalLaboratorio)
                .WithMany(pl => pl.Resultados)
                .HasForeignKey(r => r.PersonalLaboratorioId);

            modelBuilder.Entity<Resultado>()
                .HasOne(r => r.ValorReferencia)
                .WithMany()
                .HasForeignKey(r => r.ValorReferenciaId);

            modelBuilder.Entity<Factura>()
                .HasOne(f => f.SolicitudExamen)
                .WithMany(se => se.Facturas)
                .HasForeignKey(f => f.SolicitudExamenId);

        }


         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("labConex");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        // Agregar DbSet<Entidad> aquí
        public DbSet<Area> Areas { get; set; }
        public DbSet<Aseguradora> Aseguradoras { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Examen> Examenes { get; set; }
        public DbSet<ExamenMuestra> ExamenesMuestras { get; set; }
        public DbSet<ExamenSolicitado> ExamenesSolicitados { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Muestra> Muestras { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<PersonalLaboratorio> PersonalLaboratorio { get; set; }
        public DbSet<Prueba> Pruebas { get; set; }
        public DbSet<Resultado> Resultados { get; set; }
        public DbSet<SolicitudExamen> SolicitudesExamenes { get; set; }
        public DbSet<ValorReferencia> ValoresReferencia { get; set; }

    }
}

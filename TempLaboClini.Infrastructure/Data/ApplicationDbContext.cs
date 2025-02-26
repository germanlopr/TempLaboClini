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
        public DbSet<Persona> Personas { get; set; }
        public DbSet<PersonalLaboratorio> PersonalLaboratorios { get; set; }
        public DbSet<Prueba> Pruebas { get; set; }
        public DbSet<Resultado> Resultados { get; set; }
        public DbSet<SolicitudExamen> SolicitudesExamen { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ValorReferencia> ValoresReferencia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar herencia TPT
            modelBuilder.Entity<Persona>().ToTable("Persona");
            modelBuilder.Entity<Medico>().ToTable("Medico");
            modelBuilder.Entity<Paciente>().ToTable("Paciente");
            modelBuilder.Entity<PersonalLaboratorio>().ToTable("PersonalLaboratorio");

            modelBuilder.Entity<Usuario>().ToTable("Usuario");


            // Configurar relaciones
            modelBuilder.Entity<Persona>().HasOne(p => p.Direccion)
                .WithMany(d => d.Personas)
                .HasForeignKey(p => p.DireccionId);


            modelBuilder.Entity<SolicitudExamen>() 
                .HasOne(se => se.Paciente)
                .WithMany()
                .HasForeignKey(se => se.PacienteId)
                .OnDelete(DeleteBehavior.NoAction); // Cambia a NoAction

            modelBuilder.Entity<SolicitudExamen>()
                .HasOne(se => se.Aseguradora)
                .WithMany()
                .HasForeignKey(se => se.AseguradoraId)
                .OnDelete(DeleteBehavior.NoAction); // Cambia a NoAction

            modelBuilder.Entity<SolicitudExamen>()
                .HasOne(se => se.Medico)
                .WithMany()
                .HasForeignKey(se => se.MedicoId)
                .OnDelete(DeleteBehavior.NoAction); // Cambia a NoAction

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
                .HasForeignKey(r => r.ExamenSolicitadoId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Resultado>()
                .HasOne(r => r.PersonalLaboratorio)
                .WithMany(pl => pl.Resultados)
                .HasForeignKey(r => r.PersonalLaboratorioId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Resultado>()
                .HasOne(r => r.ValorReferencia)
                .WithMany()
                .HasForeignKey(r => r.ValorReferenciaId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Persona>().HasOne(p => p.Direccion)
                .WithMany(d => d.Personas)
                .HasForeignKey(p => p.DireccionId);


            // Configurar la precisión y el tipo de columna para PrecioExamen
            modelBuilder.Entity<Examen>()
                .Property(e => e.Precio)
                .HasColumnType("decimal(18,2)");

            // Configurar la precisión y el tipo de columna para Monto
            modelBuilder.Entity<Factura>()
                .Property(f => f.Monto)
                .HasColumnType("decimal(18,2)");

            // Configurar la precisión y el tipo de columna para EdadMaximaAnios
            modelBuilder.Entity<ValorReferencia>()
                .Property(vr => vr.EdadMaximaAnios)
                .HasColumnType("decimal(18,2)");

            // Configurar la precisión y el tipo de columna para otras propiedades decimal en ValorReferencia
            modelBuilder.Entity<ValorReferencia>()
                .Property(vr => vr.EdadMinimaAnios)
                .HasColumnType("decimal(18,2)");


            modelBuilder.Entity<ValorReferencia>()
                .Property(vr => vr.ValorMinimo)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ValorReferencia>()
                .Property(vr => vr.ValorMaximo)
            .HasColumnType("decimal(18,2)");

            // Configurar auditoría automática (opcional)
            modelBuilder.Entity<BaseEntity>()
                .Property(e => e.FechaCreacion)
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<BaseEntity>()
                .Property(e => e.FechaModificacion)
                .HasDefaultValueSql("GETUTCDATE()");

            //***
            //
            //modelBuilder.Entity<Paciente>().ToTable("Pacientes");
            //modelBuilder.Entity<PersonalLaboratorio>().ToTable("PersonalLaboratorio");

            //modelBuilder.Entity<Muestra>()
            //    .HasMany(m => m.ExamenesMuestra)
            //    .WithOne(em => em.Muestra)
            //    .HasForeignKey(em => em.MuestraId);

            //modelBuilder.Entity<Prueba>()
            //    .HasOne(p => p.Examen)
            //    .WithMany(e => e.Pruebas)
            //    .HasForeignKey(p => p.ExamenId);

            //modelBuilder.Entity<Resultado>()
            //    .HasOne(r => r.ExamenSolicitado)
            //    .WithMany(es => es.Resultados)
            //    .HasForeignKey(r => r.ExamenSolicitadoId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Resultado>()
            //    .HasOne(r => r.PersonalLaboratorio)
            //    .WithMany(pl => pl.Resultados)
            //    .HasForeignKey(r => r.PersonalLaboratorioId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Resultado>()
            //    .HasOne(r => r.ValorReferencia)
            //    .WithMany()
            //    .HasForeignKey(r => r.ValorReferenciaId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<SolicitudExamen>()
            //    .HasOne(se => se.Paciente)
            //    .WithMany(p => p.SolicitudesExamen)
            //    .HasForeignKey(se => se.PacienteId);

            //modelBuilder.Entity<SolicitudExamen>()
            //    .HasOne(se => se.Aseguradora)
            //    .WithMany()
            //    .HasForeignKey(se => se.AseguradoraId);

            //modelBuilder.Entity<SolicitudExamen>()
            //    .HasOne(se => se.Medico)
            //    .WithMany(m => m.SolicitudesExamen)
            //    .HasForeignKey(se => se.MedicoId);

            //modelBuilder.Entity<SolicitudExamen>()
            //    .HasMany(se => se.ExamenesSolicitados)
            //    .WithOne(es => es.SolicitudExamen)
            //    .HasForeignKey(es => es.SolicitudExamenId);

            //modelBuilder.Entity<ValorReferencia>()
            //    .HasOne(vr => vr.Prueba)
            //    .WithMany(p => p.ValoresReferencia)
            //    .HasForeignKey(vr => vr.PruebaId);

            //modelBuilder.Entity<ExamenSolicitado>()
            //    .HasOne(es => es.Examen)
            //    .WithMany(e => e.ExamenesSolicitados)
            //    .HasForeignKey(es => es.ExamenId);

            //modelBuilder.Entity<Factura>()
            //    .Property(f => f.Monto)
            //    .HasColumnType("decimal(18,2)");

            //modelBuilder.Entity<ValorReferencia>()
            //    .Property(vr => vr.EdadMaximaAnios)
            //    .HasColumnType("decimal(18,2)");

            //modelBuilder.Entity<ValorReferencia>()
            //    .Property(vr => vr.EdadMinimaAnios)
            //    .HasColumnType("decimal(18,2)");

            //modelBuilder.Entity<ValorReferencia>()
            //    .Property(vr => vr.ValorMinimo)
            //    .HasColumnType("decimal(18,2)");

            //modelBuilder.Entity<ValorReferencia>()
            //    .Property(vr => vr.ValorMaximo)
            //    .HasColumnType("decimal(18,2)");

            //modelBuilder.Entity<BaseEntity>()
            //    .Property(e => e.FechaCreacion)
            //    .HasDefaultValueSql("GETUTCDATE()");

            //modelBuilder.Entity<BaseEntity>()
            //    .Property(e => e.FechaModificacion)
            //    .HasDefaultValueSql("GETUTCDATE()");
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

    }
}

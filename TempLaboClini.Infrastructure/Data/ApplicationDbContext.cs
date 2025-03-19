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

            // Excluir BaseEntity del modelo
            modelBuilder.Ignore<BaseEntity>();

            // Configurar herencia TPT
            modelBuilder.Entity<Persona>().ToTable("Persona");
            modelBuilder.Entity<Medico>().ToTable("Medico");
            modelBuilder.Entity<Paciente>().ToTable("Paciente");
            modelBuilder.Entity<PersonalLaboratorio>().ToTable("PersonalLaboratorio");

            // Configurar herencia TPT (si aplica)
            modelBuilder.Entity<ExamenMuestra>().ToTable("ExamenMuestra");

            modelBuilder.Entity<Usuario>().ToTable("Usuario");


            modelBuilder.Entity<Persona>()   
                .HasOne(p => p.Direccion)  
                .WithMany(d => d.Personas)           
                .HasForeignKey(p => p.DireccionId)   
                .OnDelete(DeleteBehavior.Restrict); // Evita la eliminación en cascada

            // Configuración para Facturas
            modelBuilder.Entity<Factura>()
                .HasOne(f => f.SolicitudExamen)
                .WithMany()
                .HasForeignKey(f => f.SolicitudExamenId)
                .OnDelete(DeleteBehavior.NoAction); // Cambia CASCADE por NO ACTION

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
                .HasForeignKey(vr => vr.PruebaId)
                .OnDelete(DeleteBehavior.NoAction); // Cambia CASCADE por NO ACTION

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
                .HasPrecision(18, 2);

            modelBuilder.Entity<Examen>()
                .HasMany(e => e.Pruebas)
                .WithOne(p => p.Examen)
                .HasForeignKey(p => p.ExamenId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configurar la precisión y el tipo de columna para Monto
            modelBuilder.Entity<Factura>()
                .Property(f => f.Monto)
                .HasPrecision(18, 2);

            // Configurar la precisión y el tipo de columna para EdadMaximaAnios
            modelBuilder.Entity<ValorReferencia>()
                .Property(vr => vr.EdadMaximaAnios)
                .HasPrecision(18, 2);

            // Configurar la precisión y el tipo de columna para otras propiedades decimal en ValorReferencia
            modelBuilder.Entity<ValorReferencia>()
                .Property(vr => vr.EdadMinimaAnios)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ValorReferencia>()
                .Property(vr => vr.ValorMinimo)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ValorReferencia>()
                .Property(vr => vr.ValorMaximo)
                .HasPrecision(18, 2);

            // Configuración para Pruebas.Examen
            modelBuilder.Entity<Prueba>()
                .HasOne(p => p.Examen)
                .WithMany(e => e.Pruebas)
                .HasForeignKey(p => p.ExamenId)
                .OnDelete(DeleteBehavior.NoAction); // Cambia CASCADE por NO ACTION

            // Configurar relaciones
            modelBuilder.Entity<ExamenMuestra>()
                .HasOne(em => em.Examen) // Relación con Examen
                .WithMany(e => e.ExamenesMuestras) // Propiedad de navegación en Examen
                .HasForeignKey(em => em.ExamenId) // Clave foránea
                .OnDelete(DeleteBehavior.Restrict); // Cambiar a Restrict o NoAction

            modelBuilder.Entity<ExamenMuestra>()
                .HasOne(em => em.Muestra) // Relación con Muestra
                .WithMany(m => m.ExamenesMuestras) // Propiedad de navegación en Muestra
                .HasForeignKey(em => em.MuestraId) // Clave foránea
                .OnDelete(DeleteBehavior.Restrict); // Cambiar a Restrict o NoAction

            // Configuración para ExamenesSolicitados
            modelBuilder.Entity<ExamenSolicitado>()
                .HasOne(es => es.Examen)
                .WithMany(e => e.ExamenesSolicitados)
                .HasForeignKey(es => es.ExamenId)
                .OnDelete(DeleteBehavior.NoAction); // Cambia CASCADE por NO ACTION

            modelBuilder.Entity<ExamenSolicitado>()
                .HasOne(es => es.SolicitudExamen)
                .WithMany(se => se.ExamenesSolicitados)
                .HasForeignKey(es => es.SolicitudExamenId)
                .OnDelete(DeleteBehavior.NoAction); // Cambia CASCADE por NO ACTION


            // Si Pruebas hereda de BaseEntity, asegúrate de que la herencia esté bien configurada
            modelBuilder.Entity<Prueba>()
                .ToTable("Pruebas");


            modelBuilder.Entity<SolicitudExamen>()   
                .HasOne(se => se.Paciente)    
                .WithMany(p => p.SolicitudesExamen)  
                .HasForeignKey(se => se.PacienteId)    
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SolicitudExamen>()
                .HasOne(se => se.Medico)
                .WithMany(m => m.SolicitudesExamen)
                .HasForeignKey(se => se.MedicoId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SolicitudExamen>()
                .HasOne(se => se.Aseguradora)
                .WithMany()
                .HasForeignKey(se => se.AseguradoraId)
                .OnDelete(DeleteBehavior.NoAction);

            // **NUEVAS RELACIONES PROPUESTAS**

            // Relación entre ExamenSolicitado y ExamenMuestra (cada examen solicitado puede tener varias muestras asociadas)
            modelBuilder.Entity<ExamenMuestra>()
                .HasOne(em => em.ExamenSolicitado)
                .WithMany(es => es.ExamenesMuestras)
                .HasForeignKey(em => em.ExamenSolicitadoId)
                .OnDelete(DeleteBehavior.Restrict); 

            // Relación entre ExamenMuestra y PersonalLaboratorio (quién tomó la muestra)
            modelBuilder.Entity<ExamenMuestra>()
                .HasOne(em => em.PersonalLaboratorio)
                .WithMany(pl => pl.MuestrasTomadas)
                .HasForeignKey(em => em.PersonalLaboratorioId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación entre Resultado y ExamenMuestra (cada resultado corresponde a una muestra tomada específica)
            modelBuilder.Entity<Resultado>()
                .HasOne(r => r.ExamenMuestra)
                .WithMany(em => em.Resultados)
                .HasForeignKey(r => r.ExamenMuestraId)
                .OnDelete(DeleteBehavior.Restrict);


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

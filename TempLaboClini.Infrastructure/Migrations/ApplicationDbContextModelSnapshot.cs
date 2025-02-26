﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TempLaboClini.Infrastructure.Data;

#nullable disable

namespace TempLaboClini.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TempLaboClini.Domain.Entities.BaseEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<DateTime>("FechaModificacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.ToTable("BaseEntity");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Area", b =>
                {
                    b.HasBaseType("TempLaboClini.Domain.Entities.BaseEntity");

                    b.Property<string>("CodigoArea")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreArea")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Aseguradora", b =>
                {
                    b.HasBaseType("TempLaboClini.Domain.Entities.BaseEntity");

                    b.Property<string>("CodigoAseguradora")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("DireccionId")
                        .HasColumnType("bigint");

                    b.Property<string>("NombreAseguradora")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("DireccionId");

                    b.ToTable("Aseguradoras");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Direccion", b =>
                {
                    b.HasBaseType("TempLaboClini.Domain.Entities.BaseEntity");

                    b.Property<string>("Apartamento")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Bloque")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Casa")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Ciudad")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("CodigoPostal")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Departamento")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Edificio")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Manzana")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("NombreVia")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NumeroPuerta")
                        .HasColumnType("int");

                    b.Property<string>("Pais")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Piso")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("TipoVia")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.ToTable("Direccion");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Examen", b =>
                {
                    b.HasBaseType("TempLaboClini.Domain.Entities.BaseEntity");

                    b.Property<long>("AreaId")
                        .HasColumnType("bigint");

                    b.Property<string>("CodigoCUPS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoSOAT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(12, 2)");

                    b.Property<string>("SignificanciaClinica")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("AreaId");

                    b.ToTable("Examenes");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.ExamenMuestra", b =>
                {
                    b.HasBaseType("TempLaboClini.Domain.Entities.BaseEntity");

                    b.Property<long>("ExamenId")
                        .HasColumnType("bigint");

                    b.Property<long>("MuestraId")
                        .HasColumnType("bigint");

                    b.HasIndex("ExamenId");

                    b.HasIndex("MuestraId");

                    b.ToTable("ExamenesMuestras");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.ExamenSolicitado", b =>
                {
                    b.HasBaseType("TempLaboClini.Domain.Entities.BaseEntity");

                    b.Property<string>("EstadoMuestra")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ExamenId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("FechaResultado")
                        .HasColumnType("datetime2");

                    b.Property<long?>("PersonalLaboratorioId")
                        .HasColumnType("bigint");

                    b.Property<string>("ResultadoExamen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SolicitudExamenId")
                        .HasColumnType("bigint");

                    b.HasIndex("ExamenId");

                    b.HasIndex("PersonalLaboratorioId");

                    b.HasIndex("SolicitudExamenId");

                    b.ToTable("ExamenesSolicitados");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Factura", b =>
                {
                    b.HasBaseType("TempLaboClini.Domain.Entities.BaseEntity");

                    b.Property<decimal>("Monto")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NroFactura")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SolicitudExamenId")
                        .HasColumnType("bigint");

                    b.HasIndex("SolicitudExamenId");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Muestra", b =>
                {
                    b.HasBaseType("TempLaboClini.Domain.Entities.BaseEntity");

                    b.Property<string>("NombreMuestra")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.ToTable("Muestras");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Persona", b =>
                {
                    b.HasBaseType("TempLaboClini.Domain.Entities.BaseEntity");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("DireccionId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NroIdentificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SegundoApellido")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasIndex("DireccionId");

                    b.ToTable("Persona", (string)null);
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Prueba", b =>
                {
                    b.HasBaseType("TempLaboClini.Domain.Entities.BaseEntity");

                    b.Property<bool>("Agrupado")
                        .HasColumnType("bit");

                    b.Property<long>("ExamenId")
                        .HasColumnType("bigint");

                    b.Property<string>("NombrePrueba")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasIndex("ExamenId");

                    b.ToTable("Pruebas");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Resultado", b =>
                {
                    b.HasBaseType("TempLaboClini.Domain.Entities.BaseEntity");

                    b.Property<long>("ExamenSolicitadoId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("FechaResultado")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observaciones")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<long>("PersonalLaboratorioId")
                        .HasColumnType("bigint");

                    b.Property<string>("ResultadoTexto")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ResultadoValor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("ValorReferenciaId")
                        .HasColumnType("bigint");

                    b.HasIndex("ExamenSolicitadoId");

                    b.HasIndex("PersonalLaboratorioId");

                    b.HasIndex("ValorReferenciaId");

                    b.ToTable("Resultados");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.SolicitudExamen", b =>
                {
                    b.HasBaseType("TempLaboClini.Domain.Entities.BaseEntity");

                    b.Property<long>("AseguradoraId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("FechaRecepcion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaSolicitud")
                        .HasColumnType("datetime2");

                    b.Property<string>("IngresoPor")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<long>("MedicoId")
                        .HasColumnType("bigint");

                    b.Property<int>("NroRegistro")
                        .HasColumnType("int");

                    b.Property<long>("PacienteId")
                        .HasColumnType("bigint");

                    b.HasIndex("AseguradoraId");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("SolicitudesExamen");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.ValorReferencia", b =>
                {
                    b.HasBaseType("TempLaboClini.Domain.Entities.BaseEntity");

                    b.Property<decimal>("EdadMaximaAnios")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("EdadMinimaAnios")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Interpretacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PruebaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("TipoReferencia")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Unidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValorMaximo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasPrecision(18, 2)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ValorMinimo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasPrecision(18, 2)
                        .HasColumnType("nvarchar(50)");

                    b.HasIndex("PruebaId");

                    b.ToTable("ValoresReferencia");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Medico", b =>
                {
                    b.HasBaseType("TempLaboClini.Domain.Entities.Persona");

                    b.Property<string>("CodigoMedico")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.ToTable("Medico", (string)null);
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Paciente", b =>
                {
                    b.HasBaseType("TempLaboClini.Domain.Entities.Persona");

                    b.Property<string>("HistoriaClinica")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.ToTable("Paciente", (string)null);
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.PersonalLaboratorio", b =>
                {
                    b.HasBaseType("TempLaboClini.Domain.Entities.Persona");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NroRegistro")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.ToTable("PersonalLaboratorio", (string)null);
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Usuario", b =>
                {
                    b.HasBaseType("TempLaboClini.Domain.Entities.Persona");

                    b.Property<string>("Clave")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Aseguradora", b =>
                {
                    b.HasOne("TempLaboClini.Domain.Entities.Direccion", "Direccion")
                        .WithMany("Aseguradoras")
                        .HasForeignKey("DireccionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Direccion");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Direccion", b =>
                {
                    b.HasOne("TempLaboClini.Domain.Entities.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("TempLaboClini.Domain.Entities.Direccion", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Examen", b =>
                {
                    b.HasOne("TempLaboClini.Domain.Entities.Area", "Area")
                        .WithMany("Examenes")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TempLaboClini.Domain.Entities.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("TempLaboClini.Domain.Entities.Examen", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.ExamenMuestra", b =>
                {
                    b.HasOne("TempLaboClini.Domain.Entities.Examen", "Examen")
                        .WithMany("ExamenesMuestras")
                        .HasForeignKey("ExamenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TempLaboClini.Domain.Entities.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("TempLaboClini.Domain.Entities.ExamenMuestra", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TempLaboClini.Domain.Entities.Muestra", "Muestra")
                        .WithMany("ExamenesMuestra")
                        .HasForeignKey("MuestraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Examen");

                    b.Navigation("Muestra");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.ExamenSolicitado", b =>
                {
                    b.HasOne("TempLaboClini.Domain.Entities.Examen", "Examen")
                        .WithMany("ExamenesSolicitados")
                        .HasForeignKey("ExamenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TempLaboClini.Domain.Entities.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("TempLaboClini.Domain.Entities.ExamenSolicitado", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TempLaboClini.Domain.Entities.PersonalLaboratorio", "PersonalLaboratorio")
                        .WithMany()
                        .HasForeignKey("PersonalLaboratorioId");

                    b.HasOne("TempLaboClini.Domain.Entities.SolicitudExamen", "SolicitudExamen")
                        .WithMany("ExamenesSolicitados")
                        .HasForeignKey("SolicitudExamenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Examen");

                    b.Navigation("PersonalLaboratorio");

                    b.Navigation("SolicitudExamen");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Factura", b =>
                {
                    b.HasOne("TempLaboClini.Domain.Entities.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("TempLaboClini.Domain.Entities.Factura", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TempLaboClini.Domain.Entities.SolicitudExamen", "SolicitudExamen")
                        .WithMany()
                        .HasForeignKey("SolicitudExamenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SolicitudExamen");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Muestra", b =>
                {
                    b.HasOne("TempLaboClini.Domain.Entities.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("TempLaboClini.Domain.Entities.Muestra", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Persona", b =>
                {
                    b.HasOne("TempLaboClini.Domain.Entities.Direccion", "Direccion")
                        .WithMany("Personas")
                        .HasForeignKey("DireccionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TempLaboClini.Domain.Entities.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("TempLaboClini.Domain.Entities.Persona", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Direccion");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Prueba", b =>
                {
                    b.HasOne("TempLaboClini.Domain.Entities.Examen", "Examen")
                        .WithMany("Pruebas")
                        .HasForeignKey("ExamenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TempLaboClini.Domain.Entities.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("TempLaboClini.Domain.Entities.Prueba", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Examen");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Resultado", b =>
                {
                    b.HasOne("TempLaboClini.Domain.Entities.ExamenSolicitado", "ExamenSolicitado")
                        .WithMany("Resultados")
                        .HasForeignKey("ExamenSolicitadoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TempLaboClini.Domain.Entities.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("TempLaboClini.Domain.Entities.Resultado", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TempLaboClini.Domain.Entities.PersonalLaboratorio", "PersonalLaboratorio")
                        .WithMany("Resultados")
                        .HasForeignKey("PersonalLaboratorioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TempLaboClini.Domain.Entities.ValorReferencia", "ValorReferencia")
                        .WithMany()
                        .HasForeignKey("ValorReferenciaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ExamenSolicitado");

                    b.Navigation("PersonalLaboratorio");

                    b.Navigation("ValorReferencia");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.SolicitudExamen", b =>
                {
                    b.HasOne("TempLaboClini.Domain.Entities.Aseguradora", "Aseguradora")
                        .WithMany()
                        .HasForeignKey("AseguradoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TempLaboClini.Domain.Entities.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("TempLaboClini.Domain.Entities.SolicitudExamen", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TempLaboClini.Domain.Entities.Medico", "Medico")
                        .WithMany("SolicitudesExamen")
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TempLaboClini.Domain.Entities.Paciente", "Paciente")
                        .WithMany("SolicitudesExamen")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aseguradora");

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.ValorReferencia", b =>
                {
                    b.HasOne("TempLaboClini.Domain.Entities.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("TempLaboClini.Domain.Entities.ValorReferencia", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TempLaboClini.Domain.Entities.Prueba", "Prueba")
                        .WithMany("ValoresReferencia")
                        .HasForeignKey("PruebaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prueba");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Medico", b =>
                {
                    b.HasOne("TempLaboClini.Domain.Entities.Persona", null)
                        .WithOne()
                        .HasForeignKey("TempLaboClini.Domain.Entities.Medico", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Paciente", b =>
                {
                    b.HasOne("TempLaboClini.Domain.Entities.Persona", null)
                        .WithOne()
                        .HasForeignKey("TempLaboClini.Domain.Entities.Paciente", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.PersonalLaboratorio", b =>
                {
                    b.HasOne("TempLaboClini.Domain.Entities.Persona", null)
                        .WithOne()
                        .HasForeignKey("TempLaboClini.Domain.Entities.PersonalLaboratorio", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Usuario", b =>
                {
                    b.HasOne("TempLaboClini.Domain.Entities.Persona", null)
                        .WithOne()
                        .HasForeignKey("TempLaboClini.Domain.Entities.Usuario", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Area", b =>
                {
                    b.Navigation("Examenes");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Direccion", b =>
                {
                    b.Navigation("Aseguradoras");

                    b.Navigation("Personas");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Examen", b =>
                {
                    b.Navigation("ExamenesMuestras");

                    b.Navigation("ExamenesSolicitados");

                    b.Navigation("Pruebas");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.ExamenSolicitado", b =>
                {
                    b.Navigation("Resultados");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Muestra", b =>
                {
                    b.Navigation("ExamenesMuestra");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Prueba", b =>
                {
                    b.Navigation("ValoresReferencia");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.SolicitudExamen", b =>
                {
                    b.Navigation("ExamenesSolicitados");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Medico", b =>
                {
                    b.Navigation("SolicitudesExamen");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.Paciente", b =>
                {
                    b.Navigation("SolicitudesExamen");
                });

            modelBuilder.Entity("TempLaboClini.Domain.Entities.PersonalLaboratorio", b =>
                {
                    b.Navigation("Resultados");
                });
#pragma warning restore 612, 618
        }
    }
}

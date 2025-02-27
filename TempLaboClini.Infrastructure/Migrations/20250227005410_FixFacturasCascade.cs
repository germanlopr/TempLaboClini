using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TempLaboClini.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixFacturasCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreArea = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TipoVia = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NombreVia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NumeroPuerta = table.Column<int>(type: "int", nullable: false),
                    Bloque = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Manzana = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Casa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Apartamento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Edificio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Piso = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Departamento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CodigoPostal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Direccion_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Examenes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    AreaId = table.Column<long>(type: "bigint", nullable: false),
                    CodigoSOAT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignificanciaClinica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(12,2)", precision: 18, scale: 2, nullable: false),
                    CodigoCUPS = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Examenes_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Examenes_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Muestras",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    NombreMuestra = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muestras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Muestras_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aseguradoras",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoAseguradora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreAseguradora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aseguradoras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aseguradoras_Direccion_DireccionId",
                        column: x => x.DireccionId,
                        principalTable: "Direccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    NroIdentificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SegundoApellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DireccionId = table.Column<long>(type: "bigint", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persona_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persona_Direccion_DireccionId",
                        column: x => x.DireccionId,
                        principalTable: "Direccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pruebas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ExamenId = table.Column<long>(type: "bigint", nullable: false),
                    NombrePrueba = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Agrupado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pruebas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pruebas_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pruebas_Examenes_ExamenId",
                        column: x => x.ExamenId,
                        principalTable: "Examenes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExamenMuestra",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ExamenId = table.Column<long>(type: "bigint", nullable: false),
                    MuestraId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamenMuestra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamenMuestra_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamenMuestra_Examenes_ExamenId",
                        column: x => x.ExamenId,
                        principalTable: "Examenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamenMuestra_Muestras_MuestraId",
                        column: x => x.MuestraId,
                        principalTable: "Muestras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CodigoMedico = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Especialidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medico_Persona_Id",
                        column: x => x.Id,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    HistoriaClinica = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paciente_Persona_Id",
                        column: x => x.Id,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalLaboratorio",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    NroRegistro = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalLaboratorio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalLaboratorio_Persona_Id",
                        column: x => x.Id,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Persona_Id",
                        column: x => x.Id,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ValoresReferencia",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    PruebaId = table.Column<long>(type: "bigint", nullable: false),
                    TipoReferencia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ValorMinimo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, precision: 18, scale: 2, nullable: false),
                    ValorMaximo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, precision: 18, scale: 2, nullable: false),
                    EdadMinimaAnios = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    EdadMaximaAnios = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Unidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interpretacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValoresReferencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValoresReferencia_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ValoresReferencia_Pruebas_PruebaId",
                        column: x => x.PruebaId,
                        principalTable: "Pruebas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SolicitudesExamen",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    NroRegistro = table.Column<int>(type: "int", nullable: false),
                    MedicoId = table.Column<long>(type: "bigint", nullable: false),
                    PacienteId = table.Column<long>(type: "bigint", nullable: false),
                    AseguradoraId = table.Column<long>(type: "bigint", nullable: false),
                    IngresoPor = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    FechaSolicitud = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaRecepcion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudesExamen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitudesExamen_Aseguradoras_AseguradoraId",
                        column: x => x.AseguradoraId,
                        principalTable: "Aseguradoras",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SolicitudesExamen_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitudesExamen_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SolicitudesExamen_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExamenesSolicitados",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    SolicitudExamenId = table.Column<long>(type: "bigint", nullable: false),
                    ExamenId = table.Column<long>(type: "bigint", nullable: false),
                    PersonalLaboratorioId = table.Column<long>(type: "bigint", nullable: true),
                    EstadoMuestra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResultadoExamen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaResultado = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamenesSolicitados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamenesSolicitados_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamenesSolicitados_Examenes_ExamenId",
                        column: x => x.ExamenId,
                        principalTable: "Examenes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExamenesSolicitados_PersonalLaboratorio_PersonalLaboratorioId",
                        column: x => x.PersonalLaboratorioId,
                        principalTable: "PersonalLaboratorio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExamenesSolicitados_SolicitudesExamen_SolicitudExamenId",
                        column: x => x.SolicitudExamenId,
                        principalTable: "SolicitudesExamen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    NroFactura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SolicitudExamenId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facturas_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Facturas_SolicitudesExamen_SolicitudExamenId",
                        column: x => x.SolicitudExamenId,
                        principalTable: "SolicitudesExamen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Resultados",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ExamenSolicitadoId = table.Column<long>(type: "bigint", nullable: false),
                    PersonalLaboratorioId = table.Column<long>(type: "bigint", nullable: false),
                    ResultadoValor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ResultadoTexto = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ValorReferenciaId = table.Column<long>(type: "bigint", nullable: false),
                    FechaResultado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resultados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resultados_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resultados_ExamenesSolicitados_ExamenSolicitadoId",
                        column: x => x.ExamenSolicitadoId,
                        principalTable: "ExamenesSolicitados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Resultados_PersonalLaboratorio_PersonalLaboratorioId",
                        column: x => x.PersonalLaboratorioId,
                        principalTable: "PersonalLaboratorio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Resultados_ValoresReferencia_ValorReferenciaId",
                        column: x => x.ValorReferenciaId,
                        principalTable: "ValoresReferencia",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aseguradoras_DireccionId",
                table: "Aseguradoras",
                column: "DireccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Examenes_AreaId",
                table: "Examenes",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamenesSolicitados_ExamenId",
                table: "ExamenesSolicitados",
                column: "ExamenId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamenesSolicitados_PersonalLaboratorioId",
                table: "ExamenesSolicitados",
                column: "PersonalLaboratorioId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamenesSolicitados_SolicitudExamenId",
                table: "ExamenesSolicitados",
                column: "SolicitudExamenId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamenMuestra_ExamenId",
                table: "ExamenMuestra",
                column: "ExamenId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamenMuestra_MuestraId",
                table: "ExamenMuestra",
                column: "MuestraId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_SolicitudExamenId",
                table: "Facturas",
                column: "SolicitudExamenId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_DireccionId",
                table: "Persona",
                column: "DireccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Pruebas_ExamenId",
                table: "Pruebas",
                column: "ExamenId");

            migrationBuilder.CreateIndex(
                name: "IX_Resultados_ExamenSolicitadoId",
                table: "Resultados",
                column: "ExamenSolicitadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Resultados_PersonalLaboratorioId",
                table: "Resultados",
                column: "PersonalLaboratorioId");

            migrationBuilder.CreateIndex(
                name: "IX_Resultados_ValorReferenciaId",
                table: "Resultados",
                column: "ValorReferenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesExamen_AseguradoraId",
                table: "SolicitudesExamen",
                column: "AseguradoraId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesExamen_MedicoId",
                table: "SolicitudesExamen",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesExamen_PacienteId",
                table: "SolicitudesExamen",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ValoresReferencia_PruebaId",
                table: "ValoresReferencia",
                column: "PruebaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamenMuestra");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Resultados");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Muestras");

            migrationBuilder.DropTable(
                name: "ExamenesSolicitados");

            migrationBuilder.DropTable(
                name: "ValoresReferencia");

            migrationBuilder.DropTable(
                name: "PersonalLaboratorio");

            migrationBuilder.DropTable(
                name: "SolicitudesExamen");

            migrationBuilder.DropTable(
                name: "Pruebas");

            migrationBuilder.DropTable(
                name: "Aseguradoras");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Examenes");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Direccion");

            migrationBuilder.DropTable(
                name: "BaseEntity");
        }
    }
}

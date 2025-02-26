using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TempLaboClini.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NuevaBD : Migration
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
                    NombreArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Muestras",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreMuestra = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muestras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Examenes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaId = table.Column<long>(type: "bigint", nullable: false),
                    CodigoSOAT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignificanciaClinica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    CodigoCUPS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Aseguradoras",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoAseguradora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreAseguradora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionId = table.Column<long>(type: "bigint", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
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
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroIdentificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SegundoApellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DireccionId = table.Column<long>(type: "bigint", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personas_Direccion_DireccionId",
                        column: x => x.DireccionId,
                        principalTable: "Direccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamenesMuestras",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamenId = table.Column<long>(type: "bigint", nullable: false),
                    MuestraId = table.Column<long>(type: "bigint", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamenesMuestras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamenesMuestras_Examenes_ExamenId",
                        column: x => x.ExamenId,
                        principalTable: "Examenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamenesMuestras_Muestras_MuestraId",
                        column: x => x.MuestraId,
                        principalTable: "Muestras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pruebas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamenId = table.Column<long>(type: "bigint", nullable: false),
                    NombrePrueba = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Agrupado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pruebas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pruebas_Examenes_ExamenId",
                        column: x => x.ExamenId,
                        principalTable: "Examenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_Medico_Personas_Id",
                        column: x => x.Id,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    HistoriaClinica = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Personas_Id",
                        column: x => x.Id,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalLaboratorios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    NroRegistro = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalLaboratorios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalLaboratorios_Personas_Id",
                        column: x => x.Id,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
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
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Personas_Id",
                        column: x => x.Id,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ValoresReferencia",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PruebaId = table.Column<long>(type: "bigint", nullable: false),
                    TipoReferencia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ValorMinimo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ValorMaximo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EdadMinimaAnios = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EdadMaximaAnios = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Unidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interpretacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValoresReferencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValoresReferencia_Pruebas_PruebaId",
                        column: x => x.PruebaId,
                        principalTable: "Pruebas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolicitudesExamen",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroRegistro = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<long>(type: "bigint", nullable: false),
                    AseguradoraId = table.Column<long>(type: "bigint", nullable: false),
                    MedicoId = table.Column<long>(type: "bigint", nullable: false),
                    IngresoPor = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    FechaSolicitud = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaRecepcion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudesExamen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitudesExamen_Aseguradoras_AseguradoraId",
                        column: x => x.AseguradoraId,
                        principalTable: "Aseguradoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitudesExamen_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitudesExamen_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamenesSolicitados",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitudExamenId = table.Column<long>(type: "bigint", nullable: false),
                    ExamenId = table.Column<long>(type: "bigint", nullable: false),
                    PersonalLaboratorioId = table.Column<long>(type: "bigint", nullable: true),
                    EstadoMuestra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResultadoExamen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaResultado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamenesSolicitados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamenesSolicitados_Examenes_ExamenId",
                        column: x => x.ExamenId,
                        principalTable: "Examenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamenesSolicitados_PersonalLaboratorios_PersonalLaboratorioId",
                        column: x => x.PersonalLaboratorioId,
                        principalTable: "PersonalLaboratorios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExamenesSolicitados_SolicitudesExamen_SolicitudExamenId",
                        column: x => x.SolicitudExamenId,
                        principalTable: "SolicitudesExamen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroFactura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SolicitudExamenId = table.Column<long>(type: "bigint", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facturas_SolicitudesExamen_SolicitudExamenId",
                        column: x => x.SolicitudExamenId,
                        principalTable: "SolicitudesExamen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resultados",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamenSolicitadoId = table.Column<long>(type: "bigint", nullable: false),
                    PersonalLaboratorioId = table.Column<long>(type: "bigint", nullable: false),
                    ResultadoValor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ResultadoTexto = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ValorReferenciaId = table.Column<long>(type: "bigint", nullable: false),
                    FechaResultado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resultados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resultados_ExamenesSolicitados_ExamenSolicitadoId",
                        column: x => x.ExamenSolicitadoId,
                        principalTable: "ExamenesSolicitados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resultados_PersonalLaboratorios_PersonalLaboratorioId",
                        column: x => x.PersonalLaboratorioId,
                        principalTable: "PersonalLaboratorios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resultados_ValoresReferencia_ValorReferenciaId",
                        column: x => x.ValorReferenciaId,
                        principalTable: "ValoresReferencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_ExamenesMuestras_ExamenId",
                table: "ExamenesMuestras",
                column: "ExamenId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamenesMuestras_MuestraId",
                table: "ExamenesMuestras",
                column: "MuestraId");

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
                name: "IX_Facturas_SolicitudExamenId",
                table: "Facturas",
                column: "SolicitudExamenId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_DireccionId",
                table: "Personas",
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
                name: "ExamenesMuestras");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Resultados");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Muestras");

            migrationBuilder.DropTable(
                name: "ExamenesSolicitados");

            migrationBuilder.DropTable(
                name: "ValoresReferencia");

            migrationBuilder.DropTable(
                name: "PersonalLaboratorios");

            migrationBuilder.DropTable(
                name: "SolicitudesExamen");

            migrationBuilder.DropTable(
                name: "Pruebas");

            migrationBuilder.DropTable(
                name: "Aseguradoras");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Examenes");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Direccion");
        }
    }
}

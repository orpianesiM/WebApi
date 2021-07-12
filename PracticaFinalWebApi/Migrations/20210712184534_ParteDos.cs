using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PracticaFinalWebApi.Migrations
{
    public partial class ParteDos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Oficina",
                columns: table => new
                {
                    CodOficina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Localidad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Provincia = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oficina", x => x.CodOficina);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    CodEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salario = table.Column<decimal>(type: "money", nullable: false),
                    Oficina = table.Column<int>(type: "int", nullable: false),
                    Empleados = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.CodEmpleado);
                    table.ForeignKey(
                        name: "FK_Empleado_Oficina_Empleados",
                        column: x => x.Empleados,
                        principalTable: "Oficina",
                        principalColumn: "CodOficina",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empleado_Oficina_Oficina",
                        column: x => x.Oficina,
                        principalTable: "Oficina",
                        principalColumn: "CodOficina",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    CodReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vehiculo = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Destino = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Kilometros = table.Column<double>(type: "float", nullable: false),
                    Empleado = table.Column<int>(type: "int", nullable: false),
                    Reservas = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.CodReserva);
                    table.ForeignKey(
                        name: "FK_Reserva_Empleado_Empleado",
                        column: x => x.Empleado,
                        principalTable: "Empleado",
                        principalColumn: "CodEmpleado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_Empleado_Reservas",
                        column: x => x.Reservas,
                        principalTable: "Empleado",
                        principalColumn: "CodEmpleado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserva_Vehiculo_Reservas",
                        column: x => x.Reservas,
                        principalTable: "Vehiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserva_Vehiculo_Vehiculo",
                        column: x => x.Vehiculo,
                        principalTable: "Vehiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_Empleados",
                table: "Empleado",
                column: "Empleados");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_Oficina",
                table: "Empleado",
                column: "Oficina");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_Empleado",
                table: "Reserva",
                column: "Empleado");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_Reservas",
                table: "Reserva",
                column: "Reservas");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_Vehiculo",
                table: "Reserva",
                column: "Vehiculo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Oficina");
        }
    }
}

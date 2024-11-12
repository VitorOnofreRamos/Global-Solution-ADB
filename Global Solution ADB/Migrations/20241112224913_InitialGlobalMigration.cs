using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Global_Solution_ADB.Migrations
{
    /// <inheritdoc />
    public partial class InitialGlobalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GlobalEnergy_NuclearPlant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Localization = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    FullCapacity = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    NumberOfReactors = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalEnergy_NuclearPlant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GlobalEnergy_Sensor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Location = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalEnergy_Sensor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GlobalEnergy_User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Role = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PasswordHash = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LastLoginAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalEnergy_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GlobalEnergy_Metric",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NuclearPlantId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NuclearPlantDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ElectricityProvided = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    NuclearParticipation = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    OperationalEfficiency = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalEnergy_Metric", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GlobalEnergy_Metric_GlobalEnergy_NuclearPlant_NuclearPlantId",
                        column: x => x.NuclearPlantId,
                        principalTable: "GlobalEnergy_NuclearPlant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GlobalEnergy_Alert",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Level = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    TriggeredAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ResolvedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    IsResolved = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    SensorId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalEnergy_Alert", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GlobalEnergy_Alert_GlobalEnergy_Sensor_SensorId",
                        column: x => x.SensorId,
                        principalTable: "GlobalEnergy_Sensor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GlobalEnergy_Analysis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Value = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Unit = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    SensorId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalEnergy_Analysis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GlobalEnergy_Analysis_GlobalEnergy_Sensor_SensorId",
                        column: x => x.SensorId,
                        principalTable: "GlobalEnergy_Sensor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GlobalEnergy_Alert_SensorId",
                table: "GlobalEnergy_Alert",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalEnergy_Analysis_SensorId",
                table: "GlobalEnergy_Analysis",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalEnergy_Metric_NuclearPlantId",
                table: "GlobalEnergy_Metric",
                column: "NuclearPlantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GlobalEnergy_Alert");

            migrationBuilder.DropTable(
                name: "GlobalEnergy_Analysis");

            migrationBuilder.DropTable(
                name: "GlobalEnergy_Metric");

            migrationBuilder.DropTable(
                name: "GlobalEnergy_User");

            migrationBuilder.DropTable(
                name: "GlobalEnergy_Sensor");

            migrationBuilder.DropTable(
                name: "GlobalEnergy_NuclearPlant");
        }
    }
}

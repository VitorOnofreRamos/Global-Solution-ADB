﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Global_Solution_ADB.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NUCLEARPLANT",
                columns: table => new
                {
                    ID_NUCLEARPLANT = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValueSql: "NEXTVAL FOR SEQ_NUCLEARPLANT"),
                    PLANTNAME = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    FULLCAPACITY = table.Column<decimal>(type: "NUMBER", nullable: false),
                    NUMBEROFREACTORS = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NUCLEARPLANT", x => x.ID_NUCLEARPLANT);
                });

            migrationBuilder.CreateTable(
                name: "METRIC",
                columns: table => new
                {
                    ID_METRIC = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValueSql: "NEXTVAL FOR SEQ_METRIC"),
                    METRICDATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ELECTRICITYPROVIDED = table.Column<decimal>(type: "NUMBER", nullable: false),
                    NUCLEARPARTICIPATION = table.Column<decimal>(type: "NUMBER", nullable: false),
                    OPERATIONALEFFICIENCY = table.Column<decimal>(type: "NUMBER", nullable: false),
                    ID_NUCLEARPLANT = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_METRIC", x => x.ID_METRIC);
                    table.ForeignKey(
                        name: "FK_METRIC_NUCLEARPLANT_ID_NUCLEARPLANT",
                        column: x => x.ID_NUCLEARPLANT,
                        principalTable: "NUCLEARPLANT",
                        principalColumn: "ID_NUCLEARPLANT",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SENSOR",
                columns: table => new
                {
                    ID_SENSOR = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValueSql: "NEXTVAL FOR SEQ_SENSOR"),
                    SENSORNAME = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    MACHINARYLOCATION = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    STATUS = table.Column<string>(type: "CHAR(1)", nullable: false),
                    ID_NUCLEARPLANT = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SENSOR", x => x.ID_SENSOR);
                    table.ForeignKey(
                        name: "FK_SENSOR_NUCLEARPLANT_ID_NUCLEARPLANT",
                        column: x => x.ID_NUCLEARPLANT,
                        principalTable: "NUCLEARPLANT",
                        principalColumn: "ID_NUCLEARPLANT",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ANALYSIS",
                columns: table => new
                {
                    ID_ANALYSIS = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValueSql: "NEXTVAL FOR SEQ_ANALYSIS"),
                    ANALYSISVALUE = table.Column<decimal>(type: "NUMBER", nullable: false),
                    ANALYSISTIMESTAMP = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ID_SENSOR = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ANALYSIS", x => x.ID_ANALYSIS);
                    table.ForeignKey(
                        name: "FK_ANALYSIS_SENSOR_ID_SENSOR",
                        column: x => x.ID_SENSOR,
                        principalTable: "SENSOR",
                        principalColumn: "ID_SENSOR",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ALERT",
                columns: table => new
                {
                    ID_ALERT = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValueSql: "NEXTVAL FOR SEQ_ALERT"),
                    ALERTDESCRIPTION = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    TRIGGEREDAT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    RESOLVEDAT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ISRESOLVED = table.Column<string>(type: "CHAR(1)", nullable: false),
                    ID_ANALYSIS = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALERT", x => x.ID_ALERT);
                    table.ForeignKey(
                        name: "FK_ALERT_ANALYSIS_ID_ANALYSIS",
                        column: x => x.ID_ANALYSIS,
                        principalTable: "ANALYSIS",
                        principalColumn: "ID_ANALYSIS",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ALERT_ID_ANALYSIS",
                table: "ALERT",
                column: "ID_ANALYSIS");

            migrationBuilder.CreateIndex(
                name: "IX_ANALYSIS_ID_SENSOR",
                table: "ANALYSIS",
                column: "ID_SENSOR");

            migrationBuilder.CreateIndex(
                name: "IX_METRIC_ID_NUCLEARPLANT",
                table: "METRIC",
                column: "ID_NUCLEARPLANT");

            migrationBuilder.CreateIndex(
                name: "IX_SENSOR_ID_NUCLEARPLANT",
                table: "SENSOR",
                column: "ID_NUCLEARPLANT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ALERT");

            migrationBuilder.DropTable(
                name: "METRIC");

            migrationBuilder.DropTable(
                name: "ANALYSIS");

            migrationBuilder.DropTable(
                name: "SENSOR");

            migrationBuilder.DropTable(
                name: "NUCLEARPLANT");
        }
    }
}
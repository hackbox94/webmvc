using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WEBAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mst_company",
                columns: table => new
                {
                    CompanyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    CreditLimit = table.Column<decimal>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    EstCardExpiry = table.Column<DateTime>(nullable: true),
                    LicenseExpiry = table.Column<DateTime>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mst_company", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "mst_job_Service_hdr",
                columns: table => new
                {
                    JobServiceHeadID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mst_job_Service_hdr", x => x.JobServiceHeadID);
                });

            migrationBuilder.CreateTable(
                name: "mst_employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyID = table.Column<int>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    VisaExpiry = table.Column<DateTime>(nullable: true),
                    WorkPermitExpiry = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mst_employee", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_mst_employee_mst_company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "mst_company",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mst_job_service",
                columns: table => new
                {
                    JobServiceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GovtFees = table.Column<decimal>(nullable: false),
                    JobServiceHeadID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mst_job_service", x => x.JobServiceID);
                    table.ForeignKey(
                        name: "FK_mst_job_service_mst_job_Service_hdr_JobServiceHeadID",
                        column: x => x.JobServiceHeadID,
                        principalTable: "mst_job_Service_hdr",
                        principalColumn: "JobServiceHeadID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mst_pricematrix",
                columns: table => new
                {
                    PriceMatrixID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyID = table.Column<int>(nullable: true),
                    JobServicesID = table.Column<int>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mst_pricematrix", x => x.PriceMatrixID);
                    table.ForeignKey(
                        name: "FK_mst_pricematrix_mst_company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "mst_company",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mst_pricematrix_mst_job_service_JobServicesID",
                        column: x => x.JobServicesID,
                        principalTable: "mst_job_service",
                        principalColumn: "JobServiceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mst_employee_CompanyID",
                table: "mst_employee",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_mst_job_service_JobServiceHeadID",
                table: "mst_job_service",
                column: "JobServiceHeadID");

            migrationBuilder.CreateIndex(
                name: "IX_mst_pricematrix_CompanyID",
                table: "mst_pricematrix",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_mst_pricematrix_JobServicesID",
                table: "mst_pricematrix",
                column: "JobServicesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mst_employee");

            migrationBuilder.DropTable(
                name: "mst_pricematrix");

            migrationBuilder.DropTable(
                name: "mst_company");

            migrationBuilder.DropTable(
                name: "mst_job_service");

            migrationBuilder.DropTable(
                name: "mst_job_Service_hdr");
        }
    }
}

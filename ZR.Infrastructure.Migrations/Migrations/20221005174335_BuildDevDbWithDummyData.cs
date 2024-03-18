using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZR.Infrastructure.Migrations.Migrations
{
    public partial class BuildDevDbWithDummyData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerTitles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsSoftDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsHardDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTitles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerTitleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Customer First Name"),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Customer Middle Name"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Customer Last Name"),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Customer Email Address"),
                    Telpehone = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Customer Telpehone Number"),
                    Age = table.Column<int>(type: "int", nullable: false, comment: "Customer Age"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsSoftDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsHardDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_CustomerTitles_CustomerTitleId",
                        column: x => x.CustomerTitleId,
                        principalTable: "CustomerTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsSoftDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsHardDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerAddress_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CustomerTitles",
                columns: new[] { "Id", "IsActive", "IsHardDeleted", "IsSoftDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("270285a4-a176-4cd7-aeb7-d1004a18e7e7"), true, false, false, "Lord" },
                    { new Guid("2fb65fb4-77b2-4db6-b838-ba366865aa44"), true, false, false, "Miss" },
                    { new Guid("3c9608a9-92d0-4e79-99fd-3ebed82a950f"), true, false, false, "Master" },
                    { new Guid("58e08f27-e651-431a-b474-151e12b7d4c3"), true, false, false, "Mrs" },
                    { new Guid("88ed2dca-1bdc-485c-a571-d22dbb42abd7"), true, false, false, "Sir" },
                    { new Guid("958cda47-5346-455d-b3a0-91151802887a"), true, false, false, "Mr" },
                    { new Guid("daf16987-9661-486f-88b3-c2a1ed095ab2"), true, false, false, "Ms" },
                    { new Guid("e3a2005d-0121-4d0c-8a9c-ed8a82a2fe3e"), true, false, false, "Dr" },
                    { new Guid("fb1136d0-5c32-4c97-b0c3-f2ff78f1e7fb"), true, false, false, "Prof" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Age", "CustomerTitleId", "EmailAddress", "FirstName", "IsActive", "IsHardDeleted", "IsSoftDeleted", "LastName", "MiddleName", "Telpehone" },
                values: new object[] { new Guid("1f498795-4092-4490-919c-1a26d29df1c4"), 28, new Guid("daf16987-9661-486f-88b3-c2a1ed095ab2"), "Cheryl.Nixon@NixonNursingSupplies.co.uk", "Cheryl", true, false, false, "Nixon", "", "0121-496-0602" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Age", "CustomerTitleId", "EmailAddress", "FirstName", "IsActive", "IsHardDeleted", "IsSoftDeleted", "LastName", "MiddleName", "Telpehone" },
                values: new object[] { new Guid("35a146db-fdf6-4c1e-89ae-04716fad097b"), 67, new Guid("958cda47-5346-455d-b3a0-91151802887a"), "Clifford.Dickinson@DickinsonOfficeSupplies.co.uk", "Clifford", true, false, false, "Dickinson", "", "0121-496-0643" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Age", "CustomerTitleId", "EmailAddress", "FirstName", "IsActive", "IsHardDeleted", "IsSoftDeleted", "LastName", "MiddleName", "Telpehone" },
                values: new object[] { new Guid("b5c7ab75-c2f6-4e7a-bfa2-2888f0e29b66"), 40, new Guid("958cda47-5346-455d-b3a0-91151802887a"), "Kenneth.Beckley@BackleyScaffoldingLtd.com", "Kenneth", true, false, false, "Beckley", "Xena", "0121-123-4567" });

            migrationBuilder.InsertData(
                table: "CustomerAddress",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "AddressLine3", "AddressLine4", "CustomerId", "IsActive", "IsHardDeleted", "IsSoftDeleted", "PostCode" },
                values: new object[] { new Guid("1fa88489-b68f-4d48-8ad2-9c99686e3a6a"), "20 Stone Street", "Oldbury", "Birmingham", "United Kingdom", new Guid("1f498795-4092-4490-919c-1a26d29df1c4"), true, false, false, "B69 4JL" });

            migrationBuilder.InsertData(
                table: "CustomerAddress",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "AddressLine3", "AddressLine4", "CustomerId", "IsActive", "IsHardDeleted", "IsSoftDeleted", "PostCode" },
                values: new object[] { new Guid("718020a0-076c-49c3-aeef-5455df2cf468"), "N End Way", "Golders Green", "London", "United Kingdom", new Guid("b5c7ab75-c2f6-4e7a-bfa2-2888f0e29b66"), true, false, false, "NW3 7HE" });

            migrationBuilder.InsertData(
                table: "CustomerAddress",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "AddressLine3", "AddressLine4", "CustomerId", "IsActive", "IsHardDeleted", "IsSoftDeleted", "PostCode" },
                values: new object[] { new Guid("898fcbd3-9dba-4602-b19f-8efdca8f7ffb"), "115 Fallows Road", "Hall Green", "Birmingham", "United Kingdom", new Guid("35a146db-fdf6-4c1e-89ae-04716fad097b"), true, false, false, "B11 1PH" });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddress_CustomerId",
                table: "CustomerAddress",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerTitleId",
                table: "Customers",
                column: "CustomerTitleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAddress");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "CustomerTitles");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fastfood.Migrations
{
    /// <inheritdoc />
    public partial class CreateOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DatHangs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    iDTaiKhoan = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tongSo = table.Column<int>(type: "int", nullable: false),
                    tongGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatHangs", x => x.id);
                    table.ForeignKey(
                        name: "FK_DatHangs_AspNetUsers_iDTaiKhoan",
                        column: x => x.iDTaiKhoan,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDatHangs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idDonHang = table.Column<int>(type: "int", nullable: false),
                    ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    soLuong = table.Column<int>(type: "int", nullable: false),
                    gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    hinh = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDatHangs", x => x.id);
                    table.ForeignKey(
                        name: "FK_ChiTietDatHangs_DatHangs_idDonHang",
                        column: x => x.idDonHang,
                        principalTable: "DatHangs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDatHangs_idDonHang",
                table: "ChiTietDatHangs",
                column: "idDonHang");

            migrationBuilder.CreateIndex(
                name: "IX_DatHangs_iDTaiKhoan",
                table: "DatHangs",
                column: "iDTaiKhoan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietDatHangs");

            migrationBuilder.DropTable(
                name: "DatHangs");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}

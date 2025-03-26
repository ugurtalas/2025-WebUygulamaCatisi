using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class tablolartamam2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    No = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.No);
                });

            migrationBuilder.CreateTable(
                name: "SiparisDurum",
                columns: table => new
                {
                    No = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparisDurum", x => x.No);
                });

            migrationBuilder.CreateTable(
                name: "Kullanici",
                columns: table => new
                {
                    No = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parola = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eposta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RolNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanici", x => x.No);
                    table.ForeignKey(
                        name: "FK_Kullanici_Rol_RolNo",
                        column: x => x.RolNo,
                        principalTable: "Rol",
                        principalColumn: "No",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sepet",
                columns: table => new
                {
                    No = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciNo = table.Column<int>(type: "int", nullable: false),
                    UrunNo = table.Column<int>(type: "int", nullable: false),
                    EklemeTarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sepet", x => x.No);
                    table.ForeignKey(
                        name: "FK_Sepet_Kullanici_KullaniciNo",
                        column: x => x.KullaniciNo,
                        principalTable: "Kullanici",
                        principalColumn: "No",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sepet_Urun_UrunNo",
                        column: x => x.UrunNo,
                        principalTable: "Urun",
                        principalColumn: "No",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Siparis",
                columns: table => new
                {
                    No = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunNo = table.Column<int>(type: "int", nullable: false),
                    KullaniciNo = table.Column<int>(type: "int", nullable: false),
                    SiparisDurumNo = table.Column<int>(type: "int", nullable: false),
                    EklemeTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fiyat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparis", x => x.No);
                    table.ForeignKey(
                        name: "FK_Siparis_Kullanici_KullaniciNo",
                        column: x => x.KullaniciNo,
                        principalTable: "Kullanici",
                        principalColumn: "No",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Siparis_SiparisDurum_SiparisDurumNo",
                        column: x => x.SiparisDurumNo,
                        principalTable: "SiparisDurum",
                        principalColumn: "No",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Siparis_Urun_UrunNo",
                        column: x => x.UrunNo,
                        principalTable: "Urun",
                        principalColumn: "No",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Yorum_UrunNo",
                table: "Yorum",
                column: "UrunNo");

            migrationBuilder.CreateIndex(
                name: "IX_Urun_KategoriNo",
                table: "Urun",
                column: "KategoriNo");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanici_RolNo",
                table: "Kullanici",
                column: "RolNo");

            migrationBuilder.CreateIndex(
                name: "IX_Sepet_KullaniciNo",
                table: "Sepet",
                column: "KullaniciNo");

            migrationBuilder.CreateIndex(
                name: "IX_Sepet_UrunNo",
                table: "Sepet",
                column: "UrunNo");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_KullaniciNo",
                table: "Siparis",
                column: "KullaniciNo");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_SiparisDurumNo",
                table: "Siparis",
                column: "SiparisDurumNo");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_UrunNo",
                table: "Siparis",
                column: "UrunNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Urun_Kategori_KategoriNo",
                table: "Urun",
                column: "KategoriNo",
                principalTable: "Kategori",
                principalColumn: "No",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Yorum_Urun_UrunNo",
                table: "Yorum",
                column: "UrunNo",
                principalTable: "Urun",
                principalColumn: "No",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Urun_Kategori_KategoriNo",
                table: "Urun");

            migrationBuilder.DropForeignKey(
                name: "FK_Yorum_Urun_UrunNo",
                table: "Yorum");

            migrationBuilder.DropTable(
                name: "Sepet");

            migrationBuilder.DropTable(
                name: "Siparis");

            migrationBuilder.DropTable(
                name: "Kullanici");

            migrationBuilder.DropTable(
                name: "SiparisDurum");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropIndex(
                name: "IX_Yorum_UrunNo",
                table: "Yorum");

            migrationBuilder.DropIndex(
                name: "IX_Urun_KategoriNo",
                table: "Urun");
        }
    }
}

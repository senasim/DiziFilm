using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiziFilm.Model.Migrations
{
    /// <inheritdoc />
    public partial class FirstMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DilAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Soyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    Cinsiyet = table.Column<bool>(type: "bit", nullable: false),
                    UniqueId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Resim = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Menuİcon = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UstMenuId = table.Column<int>(type: "int", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Sira = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Oyuncu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Soyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Biyografi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Cinsiyet = table.Column<bool>(type: "bit", nullable: true),
                    DogumYeri = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oyuncular", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Platform",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlatformAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platform", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolAdi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YonetmenTuru",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tur = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YonetmenTuru", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Sure = table.Column<int>(type: "int", nullable: true),
                    Imdb = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    DilId = table.Column<int>(type: "int", nullable: true),
                    CikisTarihi = table.Column<DateTime>(type: "date", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Film_Diller",
                        column: x => x.DilId,
                        principalTable: "Diller",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "İzlemeListesi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    ListeAdi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İzlemeListesi_1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_izlemelistesi_Kullanicilar",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Dizi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aciklama = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BaslamaTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    BitisTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    DilId = table.Column<int>(type: "int", nullable: true),
                    PlatformId = table.Column<int>(type: "int", nullable: true),
                    DillerId = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dizi_1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dizi_Diller",
                        column: x => x.DilId,
                        principalTable: "Diller",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dizi_Diller_DillerId",
                        column: x => x.DillerId,
                        principalTable: "Diller",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dizi_Platform",
                        column: x => x.PlatformId,
                        principalTable: "Platform",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KullaniciRol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: true),
                    RolId = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciRol", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KullaniciRol_Kullanicilar",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KullaniciRol_Roller",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "YetkiRol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(type: "int", nullable: true),
                    RolId = table.Column<int>(type: "int", nullable: true),
                    SelectYetki = table.Column<bool>(type: "bit", nullable: true),
                    InsertYetki = table.Column<bool>(type: "bit", nullable: true),
                    UpdateYetki = table.Column<bool>(type: "bit", nullable: true),
                    DeleteYetki = table.Column<bool>(type: "bit", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YetkiRol", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YetkiRol_Menu",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_YetkiRol_Roller",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Yonetmen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Soyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    MiniBio = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    YonetmenTurId = table.Column<int>(type: "int", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yonetmen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_yonetmen_YonetmenTuru",
                        column: x => x.YonetmenTurId,
                        principalTable: "YonetmenTuru",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FilmAfis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DosyaYolu = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    FilmId = table.Column<int>(type: "int", nullable: true),
                    DosyaTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmAfis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmAfis_Film",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FilmOyuncu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OyuncuId = table.Column<int>(type: "int", nullable: true),
                    FilmId = table.Column<int>(type: "int", nullable: true),
                    Rol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmOyuncu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmOyuncu_Film",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FilmOyuncu_oyuncular",
                        column: x => x.OyuncuId,
                        principalTable: "Oyuncu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FilmPlatform",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmId = table.Column<int>(type: "int", nullable: true),
                    PlatformId = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmPlatform", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmPlatform_Film",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FilmPlatform_Platform",
                        column: x => x.PlatformId,
                        principalTable: "Platform",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FilmTur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    TurId = table.Column<int>(type: "int", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmTur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmTur_Film",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FilmTur_Turler",
                        column: x => x.TurId,
                        principalTable: "Turler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "YorumFilm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    Puan = table.Column<int>(type: "int", nullable: true),
                    Yorum = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    YorumTarih = table.Column<DateTime>(type: "datetime", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YorumFilm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YorumFilm_Film",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_YorumFilm_Kullanicilar",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "İzlemeListesiFilm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    İzlemeListesiId = table.Column<int>(type: "int", nullable: true),
                    FilmId = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İzlemeListesiFilm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_İzlemeListesiFilm_Film",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_İzlemeListesiFilm_İzlemeListesi_İzlemeListesiId",
                        column: x => x.İzlemeListesiId,
                        principalTable: "İzlemeListesi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DiziAfis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DosyaYolu = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DiziId = table.Column<int>(type: "int", nullable: true),
                    DosyaTipi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiziAfis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiziAfis_Dizi",
                        column: x => x.DiziId,
                        principalTable: "Dizi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DiziOyuncu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiziId = table.Column<int>(type: "int", nullable: false),
                    OyuncuId = table.Column<int>(type: "int", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiziOyuncu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiziOyuncu_Dizi",
                        column: x => x.DiziId,
                        principalTable: "Dizi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DiziOyuncu_oyuncular",
                        column: x => x.OyuncuId,
                        principalTable: "Oyuncu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DiziTur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiziId = table.Column<int>(type: "int", nullable: false),
                    TurId = table.Column<int>(type: "int", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiziTur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiziTur_Dizi",
                        column: x => x.DiziId,
                        principalTable: "Dizi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DiziTur_Turler",
                        column: x => x.TurId,
                        principalTable: "Turler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "İzlemeListesiDizi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListeId = table.Column<int>(type: "int", nullable: true),
                    DiziId = table.Column<int>(type: "int", nullable: true),
                    İzlemeListesiId = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İzlemeListesiDizi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_İzlemeListesiDizi_Dizi",
                        column: x => x.DiziId,
                        principalTable: "Dizi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_İzlemeListesiDizi_İzlemeListesi_İzlemeListesiId",
                        column: x => x.İzlemeListesiId,
                        principalTable: "İzlemeListesi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sezon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiziId = table.Column<int>(type: "int", nullable: false),
                    KacinciSezon = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sezon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sezon_Dizi",
                        column: x => x.DiziId,
                        principalTable: "Dizi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "YorumDizi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    DiziId = table.Column<int>(type: "int", nullable: true),
                    Puan = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Yorum = table.Column<string>(type: "text", nullable: false),
                    YorumTarih = table.Column<DateTime>(type: "datetime", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YorumDizi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YorumDizi_Dizi",
                        column: x => x.DiziId,
                        principalTable: "Dizi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_YorumDizi_Kullanicilar",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "YonetmenDizi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    YonetmenId = table.Column<int>(type: "int", nullable: false),
                    DiziId = table.Column<int>(type: "int", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YonetmenDizi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YonetmenDizi_Dizi",
                        column: x => x.DiziId,
                        principalTable: "Dizi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_YonetmenDizi_yonetmen",
                        column: x => x.YonetmenId,
                        principalTable: "Yonetmen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "YonetmenFilm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YonetmenId = table.Column<int>(type: "int", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YonetmenFilm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YonetmenFilm_Film",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_YonetmenFilm_yonetmen",
                        column: x => x.YonetmenId,
                        principalTable: "Yonetmen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bolum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BolumAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BolumSayisi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sure = table.Column<int>(type: "int", nullable: true),
                    YayinTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    SezonId = table.Column<int>(type: "int", nullable: true),
                    DiziId = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bolum_Dizi_DiziId",
                        column: x => x.DiziId,
                        principalTable: "Dizi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bolum_Sezon",
                        column: x => x.SezonId,
                        principalTable: "Sezon",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Favori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: true),
                    DiziId = table.Column<int>(type: "int", nullable: true),
                    FilmId = table.Column<int>(type: "int", nullable: true),
                    BolumId = table.Column<int>(type: "int", nullable: true),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_favoriler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favori_Bolum",
                        column: x => x.BolumId,
                        principalTable: "Bolum",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Favori_Dizi",
                        column: x => x.DiziId,
                        principalTable: "Dizi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Favori_Film",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Favori_Kullanicilar",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bolum_DiziId",
                table: "Bolum",
                column: "DiziId");

            migrationBuilder.CreateIndex(
                name: "IX_Bolum_SezonId",
                table: "Bolum",
                column: "SezonId");

            migrationBuilder.CreateIndex(
                name: "IX_Dizi_DilId",
                table: "Dizi",
                column: "DilId");

            migrationBuilder.CreateIndex(
                name: "IX_Dizi_DillerId",
                table: "Dizi",
                column: "DillerId");

            migrationBuilder.CreateIndex(
                name: "IX_Dizi_PlatformId",
                table: "Dizi",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_DiziAfis_DiziId",
                table: "DiziAfis",
                column: "DiziId");

            migrationBuilder.CreateIndex(
                name: "IX_DiziOyuncu_DiziId",
                table: "DiziOyuncu",
                column: "DiziId");

            migrationBuilder.CreateIndex(
                name: "IX_DiziOyuncu_OyuncuId",
                table: "DiziOyuncu",
                column: "OyuncuId");

            migrationBuilder.CreateIndex(
                name: "IX_DiziTur_DiziId",
                table: "DiziTur",
                column: "DiziId");

            migrationBuilder.CreateIndex(
                name: "IX_DiziTur_TurId",
                table: "DiziTur",
                column: "TurId");

            migrationBuilder.CreateIndex(
                name: "IX_Favori_BolumId",
                table: "Favori",
                column: "BolumId");

            migrationBuilder.CreateIndex(
                name: "IX_Favori_DiziId",
                table: "Favori",
                column: "DiziId");

            migrationBuilder.CreateIndex(
                name: "IX_Favori_FilmId",
                table: "Favori",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Favori_KullaniciId",
                table: "Favori",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Film_DilId",
                table: "Film",
                column: "DilId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmAfis_FilmId",
                table: "FilmAfis",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmOyuncu_FilmId",
                table: "FilmOyuncu",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmOyuncu_OyuncuId",
                table: "FilmOyuncu",
                column: "OyuncuId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmPlatform_FilmId",
                table: "FilmPlatform",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmPlatform_PlatformId",
                table: "FilmPlatform",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmTur_FilmId",
                table: "FilmTur",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmTur_TurId",
                table: "FilmTur",
                column: "TurId");

            migrationBuilder.CreateIndex(
                name: "IX_İzlemeListesi_KullaniciId",
                table: "İzlemeListesi",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_İzlemeListesiDizi_DiziId",
                table: "İzlemeListesiDizi",
                column: "DiziId");

            migrationBuilder.CreateIndex(
                name: "IX_İzlemeListesiDizi_İzlemeListesiId",
                table: "İzlemeListesiDizi",
                column: "İzlemeListesiId");

            migrationBuilder.CreateIndex(
                name: "IX_İzlemeListesiFilm_FilmId",
                table: "İzlemeListesiFilm",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_İzlemeListesiFilm_İzlemeListesiId",
                table: "İzlemeListesiFilm",
                column: "İzlemeListesiId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciRol_KullaniciId",
                table: "KullaniciRol",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciRol_RolId",
                table: "KullaniciRol",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Sezon_DiziId",
                table: "Sezon",
                column: "DiziId");

            migrationBuilder.CreateIndex(
                name: "IX_YetkiRol_MenuId",
                table: "YetkiRol",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_YetkiRol_RolId",
                table: "YetkiRol",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Yonetmen_YonetmenTurId",
                table: "Yonetmen",
                column: "YonetmenTurId");

            migrationBuilder.CreateIndex(
                name: "IX_YonetmenDizi_DiziId",
                table: "YonetmenDizi",
                column: "DiziId");

            migrationBuilder.CreateIndex(
                name: "IX_YonetmenDizi_YonetmenId",
                table: "YonetmenDizi",
                column: "YonetmenId");

            migrationBuilder.CreateIndex(
                name: "IX_YonetmenFilm_FilmId",
                table: "YonetmenFilm",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_YonetmenFilm_YonetmenId",
                table: "YonetmenFilm",
                column: "YonetmenId");

            migrationBuilder.CreateIndex(
                name: "IX_YorumDizi_DiziId",
                table: "YorumDizi",
                column: "DiziId");

            migrationBuilder.CreateIndex(
                name: "IX_YorumDizi_KullaniciId",
                table: "YorumDizi",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_YorumFilm_FilmId",
                table: "YorumFilm",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_YorumFilm_KullaniciId",
                table: "YorumFilm",
                column: "KullaniciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiziAfis");

            migrationBuilder.DropTable(
                name: "DiziOyuncu");

            migrationBuilder.DropTable(
                name: "DiziTur");

            migrationBuilder.DropTable(
                name: "Favori");

            migrationBuilder.DropTable(
                name: "FilmAfis");

            migrationBuilder.DropTable(
                name: "FilmOyuncu");

            migrationBuilder.DropTable(
                name: "FilmPlatform");

            migrationBuilder.DropTable(
                name: "FilmTur");

            migrationBuilder.DropTable(
                name: "İzlemeListesiDizi");

            migrationBuilder.DropTable(
                name: "İzlemeListesiFilm");

            migrationBuilder.DropTable(
                name: "KullaniciRol");

            migrationBuilder.DropTable(
                name: "YetkiRol");

            migrationBuilder.DropTable(
                name: "YonetmenDizi");

            migrationBuilder.DropTable(
                name: "YonetmenFilm");

            migrationBuilder.DropTable(
                name: "YorumDizi");

            migrationBuilder.DropTable(
                name: "YorumFilm");

            migrationBuilder.DropTable(
                name: "Bolum");

            migrationBuilder.DropTable(
                name: "Oyuncu");

            migrationBuilder.DropTable(
                name: "Turler");

            migrationBuilder.DropTable(
                name: "İzlemeListesi");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Yonetmen");

            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "Sezon");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "YonetmenTuru");

            migrationBuilder.DropTable(
                name: "Dizi");

            migrationBuilder.DropTable(
                name: "Diller");

            migrationBuilder.DropTable(
                name: "Platform");
        }
    }
}

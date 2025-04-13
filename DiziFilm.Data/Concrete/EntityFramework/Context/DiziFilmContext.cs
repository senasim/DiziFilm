using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DiziFilm.Model.Entity;

public partial class DiziFilmContext : DbContext
{
    public DiziFilmContext()
    {
    }

    public DiziFilmContext(DbContextOptions<DiziFilmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bolum> Bolums { get; set; }

    public virtual DbSet<Diller> Dillers { get; set; }

    public virtual DbSet<Dizi> Dizis { get; set; }

    public virtual DbSet<DiziAfi> DiziAfis { get; set; }

    public virtual DbSet<DiziOyuncu> DiziOyuncus { get; set; }

    public virtual DbSet<DiziTur> DiziTurs { get; set; }

    public virtual DbSet<Favori> Favoris { get; set; }

    public virtual DbSet<Film> Films { get; set; }

    public virtual DbSet<FilmAfi> FilmAfis { get; set; }

    public virtual DbSet<FilmOyuncu> FilmOyuncus { get; set; }

    public virtual DbSet<FilmPlatform> FilmPlatforms { get; set; }

    public virtual DbSet<FilmTur> FilmTurs { get; set; }

    public virtual DbSet<KullaniciRol> KullaniciRols { get; set; }

    public virtual DbSet<Kullanicilar> Kullanicilars { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Oyuncu> Oyuncus { get; set; }

    public virtual DbSet<Platform> Platforms { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Sezon> Sezons { get; set; }

    public virtual DbSet<Turler> Turlers { get; set; }

    public virtual DbSet<YetkiRol> YetkiRols { get; set; }

    public virtual DbSet<Yonetmen> Yonetmen { get; set; }

    public virtual DbSet<YonetmenDizi> YonetmenDizis { get; set; }

    public virtual DbSet<YonetmenFilm> YonetmenFilms { get; set; }

    public virtual DbSet<YonetmenTuru> YonetmenTurus { get; set; }

    public virtual DbSet<YorumDizi> YorumDizis { get; set; }

    public virtual DbSet<YorumFilm> YorumFilms { get; set; }

    public virtual DbSet<İzlemeListesi> İzlemeListesis { get; set; }

    public virtual DbSet<İzlemeListesiDizi> İzlemeListesiDizis { get; set; }

    public virtual DbSet<İzlemeListesiFilm> İzlemeListesiFilms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=SENASIMSEK\\SQLEXPRESS;database=DiziFilm;trusted_connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bolum>(entity =>
        {
            entity.ToTable("Bolum");

            entity.HasIndex(e => e.SezonId, "IX_Bolum_SezonId");

            entity.Property(e => e.BolumAdi).HasMaxLength(50);
            entity.Property(e => e.BolumSayisi).HasMaxLength(50);
            entity.Property(e => e.YayinTarihi).HasColumnType("datetime");

            entity.HasOne(d => d.Sezon).WithMany(p => p.Bolums)
                .HasForeignKey(d => d.SezonId)
                .HasConstraintName("FK_Bolum_Sezon");
        });

        modelBuilder.Entity<Diller>(entity =>
        {
            entity.ToTable("Diller");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.DilAdi).HasMaxLength(50);

        });

        modelBuilder.Entity<Dizi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Dizi_1");

            entity.ToTable("Dizi");

            entity.Property(e => e.Aciklama).HasMaxLength(200);
            entity.Property(e => e.Adi).HasMaxLength(50);
            entity.Property(e => e.BaslamaTarihi).HasColumnType("datetime");
            entity.Property(e => e.BitisTarihi).HasColumnType("datetime");

            entity.HasOne(d => d.Platform).WithMany(p => p.Dizis)
                .HasForeignKey(d => d.PlatformId)
                .HasConstraintName("FK_Dizi_Platform");
            entity.HasOne(d => d.Diller).WithMany()
       .HasForeignKey(d => d.DilId)
       .HasConstraintName("FK_Dizi_Diller");
        });

        modelBuilder.Entity<DiziAfi>(entity =>
        {
            entity.HasIndex(e => e.DiziId, "IX_DiziAfis_DiziId");

            entity.Property(e => e.DosyaYolu).HasMaxLength(150);

            entity.HasOne(d => d.Dizi).WithMany(p => p.DiziAfis)
                .HasForeignKey(d => d.DiziId)
                .HasConstraintName("FK_DiziAfis_Dizi");
        });

        modelBuilder.Entity<DiziOyuncu>(entity =>
        {
            entity.ToTable("DiziOyuncu");

            entity.HasIndex(e => e.DiziId, "IX_DiziOyuncu_DiziId");

            entity.HasIndex(e => e.OyuncuId, "IX_DiziOyuncu_OyuncuId");

            entity.Property(e => e.Rol).HasMaxLength(50);

            entity.HasOne(d => d.Dizi).WithMany(p => p.DiziOyuncus)
                .HasForeignKey(d => d.DiziId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiziOyuncu_Dizi");

            entity.HasOne(d => d.Oyuncu).WithMany(p => p.DiziOyuncus)
                .HasForeignKey(d => d.OyuncuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiziOyuncu_oyuncular");
        });

        modelBuilder.Entity<DiziTur>(entity =>
        {
            entity.ToTable("DiziTur");

            entity.HasIndex(e => e.DiziId, "IX_DiziTur_DiziId");

            entity.HasIndex(e => e.TurId, "IX_DiziTur_TurId");

            entity.HasOne(d => d.Dizi).WithMany(p => p.DiziTurs)
                .HasForeignKey(d => d.DiziId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiziTur_Dizi");

            entity.HasOne(d => d.Tur).WithMany(p => p.DiziTurs)
                .HasForeignKey(d => d.TurId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiziTur_Turler");
        });

        modelBuilder.Entity<Favori>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_favoriler");

            entity.ToTable("Favori");

            entity.HasIndex(e => e.BolumId, "IX_Favori_BolumId");

            entity.HasIndex(e => e.DiziId, "IX_Favori_DiziId");

            entity.HasIndex(e => e.KullaniciId, "IX_Favori_KullaniciId");

            entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

            entity.HasOne(d => d.Bolum).WithMany(p => p.Favoris)
                .HasForeignKey(d => d.BolumId)
                .HasConstraintName("FK_Favori_Bolum");

           

            entity.HasOne(d => d.Dizi).WithMany(p => p.Favoris)
         .HasForeignKey(d => d.DiziId)
         .HasConstraintName("FK_Favori_Dizi"); 

            entity.HasOne(d => d.Film).WithMany(p => p.Favoris) 
                .HasForeignKey(d => d.FilmId)
                .HasConstraintName("FK_Favori_Film");

            entity.HasOne(d => d.KullaniciNavigation).WithMany(p => p.Favoris)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK_Favori_Kullanicilar");
        });

        modelBuilder.Entity<Film>(entity =>
        {
            entity.ToTable("Film");

            entity.Property(e => e.Aciklama).HasMaxLength(200);
            entity.Property(e => e.Adi).HasMaxLength(50);
            entity.Property(e => e.CikisTarihi).HasColumnType("date");
            entity.Property(e => e.Imdb).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Dil).WithMany(p => p.Films)
                .HasForeignKey(d => d.DilId)
                .HasConstraintName("FK_Film_Diller");
        });

        modelBuilder.Entity<FilmAfi>(entity =>
        {
            entity.HasIndex(e => e.FilmId, "IX_FilmAfis_FilmId");

            entity.Property(e => e.DosyaYolu).HasMaxLength(150);

            entity.HasOne(d => d.Film).WithMany(p => p.FilmAfis)
                .HasForeignKey(d => d.FilmId)
                .HasConstraintName("FK_FilmAfis_Film");
        });

        modelBuilder.Entity<FilmOyuncu>(entity =>
        {
            entity.ToTable("FilmOyuncu");

            entity.HasIndex(e => e.FilmId, "IX_FilmOyuncu_FilmId");

            entity.HasIndex(e => e.OyuncuId, "IX_FilmOyuncu_OyuncuId");

            entity.Property(e => e.Rol).HasMaxLength(50);

            entity.HasOne(d => d.Film).WithMany(p => p.FilmOyuncus)
                .HasForeignKey(d => d.FilmId)
                .HasConstraintName("FK_FilmOyuncu_Film");

            entity.HasOne(d => d.Oyuncu).WithMany(p => p.FilmOyuncus)
                .HasForeignKey(d => d.OyuncuId)
                .HasConstraintName("FK_FilmOyuncu_oyuncular");
        });

        modelBuilder.Entity<FilmPlatform>(entity =>
        {
            entity.ToTable("FilmPlatform");

            entity.HasOne(d => d.Film).WithMany(p => p.FilmPlatforms)
                .HasForeignKey(d => d.FilmId)
                .HasConstraintName("FK_FilmPlatform_Film");

            entity.HasOne(d => d.Platform).WithMany(p => p.FilmPlatforms)
                .HasForeignKey(d => d.PlatformId)
                .HasConstraintName("FK_FilmPlatform_Platform");
        });

        modelBuilder.Entity<FilmTur>(entity =>
        {
            entity.ToTable("FilmTur");

            entity.HasIndex(e => e.FilmId, "IX_FilmTur_FilmId");

            entity.HasIndex(e => e.TurId, "IX_FilmTur_TurId");

            entity.HasOne(d => d.Film).WithMany(p => p.FilmTurs)
                .HasForeignKey(d => d.FilmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FilmTur_Film");

            entity.HasOne(d => d.Tur).WithMany(p => p.FilmTurs)
                .HasForeignKey(d => d.TurId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FilmTur_Turler");
        });

        modelBuilder.Entity<KullaniciRol>(entity =>
        {
            entity.ToTable("KullaniciRol");

            entity.HasIndex(e => e.KullaniciId, "IX_KullaniciRol_KullaniciId");

            entity.HasIndex(e => e.RolId, "IX_KullaniciRol_RolId");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.KullaniciRols)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK_KullaniciRol_Kullanicilar");

            entity.HasOne(d => d.Rol).WithMany(p => p.KullaniciRols)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK_KullaniciRol_Roller");
        });

        modelBuilder.Entity<Kullanicilar>(entity =>
        {
            entity.ToTable("Kullanicilar");

            entity.Property(e => e.Adi).HasMaxLength(50);
            entity.Property(e => e.DogumTarihi).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.KullaniciAdi).HasMaxLength(50);
            entity.Property(e => e.Resim).HasMaxLength(100);
            entity.Property(e => e.Sifre).HasMaxLength(500);
            entity.Property(e => e.Soyadi).HasMaxLength(50);
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.ToTable("Menu");

            entity.Property(e => e.Aciklama).HasMaxLength(200);
            entity.Property(e => e.Baslik).HasMaxLength(50);
            entity.Property(e => e.Menuİcon).HasMaxLength(200);
            entity.Property(e => e.Url).HasMaxLength(200);
        });

        modelBuilder.Entity<Oyuncu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_oyuncular");

            entity.ToTable("Oyuncu");

            entity.Property(e => e.Adi).HasMaxLength(50);
            entity.Property(e => e.Biyografi).HasMaxLength(500);
            entity.Property(e => e.DogumYeri).HasMaxLength(50);
            entity.Property(e => e.Soyadi).HasMaxLength(50);
        });

        modelBuilder.Entity<Platform>(entity =>
        {
            entity.ToTable("Platform");

            entity.Property(e => e.Logo).HasMaxLength(200);
            entity.Property(e => e.PlatformAdi).HasMaxLength(50);
            entity.Property(e => e.Url).HasMaxLength(100);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Roller");

            entity.ToTable("Rol");

            entity.Property(e => e.RolAdi).HasMaxLength(150);
        });

        modelBuilder.Entity<Sezon>(entity =>
        {
            entity.ToTable("Sezon");

            entity.HasIndex(e => e.DiziId, "IX_Sezon_DiziId");

            entity.HasOne(d => d.Dizi).WithMany(p => p.Sezons)
                .HasForeignKey(d => d.DiziId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sezon_Dizi");
        });

        modelBuilder.Entity<Turler>(entity =>
        {
            entity.ToTable("Turler");

            entity.Property(e => e.TurAdi).HasMaxLength(50);
        });

        modelBuilder.Entity<YetkiRol>(entity =>
        {
            entity.ToTable("YetkiRol");

            entity.HasIndex(e => e.RolId, "IX_YetkiRol_RolId");

            entity.HasOne(d => d.Menu).WithMany(p => p.YetkiRols)
                .HasForeignKey(d => d.MenuId)
                .HasConstraintName("FK_YetkiRol_Menu");

            entity.HasOne(d => d.Rol).WithMany(p => p.YetkiRols)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK_YetkiRol_Roller");
        });

        modelBuilder.Entity<Yonetmen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_yonetmen");

            entity.HasIndex(e => e.YonetmenTurId, "IX_Yonetmen_YonetmenTurId");

            entity.Property(e => e.Adi).HasMaxLength(50);
            entity.Property(e => e.DogumTarihi).HasColumnType("datetime");
            entity.Property(e => e.MiniBio).HasMaxLength(300);
            entity.Property(e => e.Soyadi).HasMaxLength(50);

            entity.HasOne(d => d.YonetmenTur).WithMany(p => p.Yonetmen)
                .HasForeignKey(d => d.YonetmenTurId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_yonetmen_YonetmenTuru");
        });

        modelBuilder.Entity<YonetmenDizi>(entity =>
        {
            entity.ToTable("YonetmenDizi");

            entity.HasIndex(e => e.DiziId, "IX_YonetmenDizi_DiziId");

            entity.HasIndex(e => e.YonetmenId, "IX_YonetmenDizi_YonetmenId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Dizi).WithMany(p => p.YonetmenDizis)
                .HasForeignKey(d => d.DiziId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_YonetmenDizi_Dizi");

            entity.HasOne(d => d.Yonetmen).WithMany(p => p.YonetmenDizis)
                .HasForeignKey(d => d.YonetmenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_YonetmenDizi_yonetmen");
        });

        modelBuilder.Entity<YonetmenFilm>(entity =>
        {
            entity.ToTable("YonetmenFilm");

            entity.HasIndex(e => e.FilmId, "IX_YonetmenFilm_FilmId");

            entity.HasIndex(e => e.YonetmenId, "IX_YonetmenFilm_YonetmenId");

            entity.HasOne(d => d.Film).WithMany(p => p.YonetmenFilms)
                .HasForeignKey(d => d.FilmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_YonetmenFilm_Film");

            entity.HasOne(d => d.Yonetmen).WithMany(p => p.YonetmenFilms)
                .HasForeignKey(d => d.YonetmenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_YonetmenFilm_yonetmen");
        });

        modelBuilder.Entity<YonetmenTuru>(entity =>
        {
            entity.ToTable("YonetmenTuru");

            entity.Property(e => e.Tur).HasMaxLength(50);
        });

        modelBuilder.Entity<YorumDizi>(entity =>
        {
            entity.ToTable("YorumDizi");

            entity.HasIndex(e => e.DiziId, "IX_YorumDizi_DiziId");

            entity.HasIndex(e => e.KullaniciId, "IX_YorumDizi_KullaniciId");

            entity.Property(e => e.Puan).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Yorum).HasColumnType("text");
            entity.Property(e => e.YorumTarih).HasColumnType("datetime");

            entity.HasOne(d => d.Dizi).WithMany(p => p.YorumDizis)
                .HasForeignKey(d => d.DiziId)
                .HasConstraintName("FK_YorumDizi_Dizi");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.YorumDizis)
                .HasForeignKey(d => d.KullaniciId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_YorumDizi_Kullanicilar");
        });

        modelBuilder.Entity<YorumFilm>(entity =>
        {
            entity.ToTable("YorumFilm");

            entity.HasIndex(e => e.FilmId, "IX_YorumFilm_FilmId");

            entity.HasIndex(e => e.KullaniciId, "IX_YorumFilm_KullaniciId");

            entity.Property(e => e.Yorum).HasMaxLength(250);
            entity.Property(e => e.YorumTarih).HasColumnType("datetime");

            entity.HasOne(d => d.Film).WithMany(p => p.YorumFilms)
                .HasForeignKey(d => d.FilmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_YorumFilm_Film");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.YorumFilms)
                .HasForeignKey(d => d.KullaniciId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_YorumFilm_Kullanicilar");
        });

        modelBuilder.Entity<İzlemeListesi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_İzlemeListesi_1");

            entity.ToTable("İzlemeListesi");

            entity.HasIndex(e => e.KullaniciId, "IX_İzlemeListesi_KullaniciId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");
            entity.Property(e => e.ListeAdi).HasMaxLength(150);

            entity.HasOne(d => d.Kullanici).WithMany(p => p.İzlemeListesis)
     .HasForeignKey(d => d.KullaniciId)
     .OnDelete(DeleteBehavior.ClientSetNull)
     .HasConstraintName("FK_izlemelistesi_Kullanicilar");
                

            entity.HasOne(d => d.Kullanici).WithMany(p => p.İzlemeListesis)
                .HasForeignKey(d => d.KullaniciId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_izlemelistesi_Kullanicilar");
        });

        modelBuilder.Entity<İzlemeListesiDizi>(entity =>
        {
            entity.ToTable("İzlemeListesiDizi");

            entity.HasIndex(e => e.DiziId, "IX_İzlemeListesiDizi_DiziId");

            entity.HasOne(d => d.Dizi).WithMany(p => p.İzlemeListesiDizis)
                .HasForeignKey(d => d.DiziId)
                .HasConstraintName("FK_İzlemeListesiDizi_Dizi");
        });

        modelBuilder.Entity<İzlemeListesiFilm>(entity =>
        {
            entity.ToTable("İzlemeListesiFilm");

            entity.HasIndex(e => e.FilmId, "IX_İzlemeListesiFilm_FilmId");

            entity.HasOne(d => d.Film).WithMany(p => p.İzlemeListesiFilms)
                .HasForeignKey(d => d.FilmId)
                .HasConstraintName("FK_İzlemeListesiFilm_Film");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

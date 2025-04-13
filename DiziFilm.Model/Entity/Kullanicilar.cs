using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace DiziFilm.Model.Entity;

public partial class Kullanicilar : BaseEntity
{

    public string? KullaniciAdi { get; set; }

    public string? Adi { get; set; }

    public string? Soyadi { get; set; }

    public string Email { get; set; } = null!;

    public string Sifre { get; set; } = null!;

    public DateTime? DogumTarihi { get; set; }

    public bool Cinsiyet { get; set; }

    public Guid? UniqueId { get; set; }

    public string? Resim { get; set; }

    public virtual ICollection<Favori> Favoris { get; set; } = new List<Favori>();

    public virtual ICollection<KullaniciRol> KullaniciRols { get; set; } = new List<KullaniciRol>();

    public virtual ICollection<YorumDizi> YorumDizis { get; set; } = new List<YorumDizi>();

    public virtual ICollection<YorumFilm> YorumFilms { get; set; } = new List<YorumFilm>();

    public virtual ICollection<İzlemeListesi> İzlemeListesis { get; set; } = new List<İzlemeListesi>();
}

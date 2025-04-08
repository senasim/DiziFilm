using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace DiziFilm.Model.Entity;

public partial class Yonetmen : BaseEntity
{

    public string? Adi { get; set; }

    public string Soyadi { get; set; } = null!;

    public bool? Cinsiyet { get; set; }

    public DateTime? DogumTarihi { get; set; }

    public string MiniBio { get; set; } = null!;

    public int YonetmenTurId { get; set; }

    public virtual ICollection<YonetmenDizi> YonetmenDizis { get; set; } = new List<YonetmenDizi>();

    public virtual ICollection<YonetmenFilm> YonetmenFilms { get; set; } = new List<YonetmenFilm>();

    public virtual YonetmenTuru YonetmenTur { get; set; } = null!;
}

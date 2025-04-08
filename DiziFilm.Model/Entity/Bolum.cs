using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace DiziFilm.Model.Entity;

public partial class Bolum:BaseEntity
{
    public string? BolumAdi { get; set; }
    public string? BolumSayisi { get; set; }
    public int? Sure { get; set; }
    public DateTime? YayinTarihi { get; set; }
    public int? SezonId { get; set; }

    public virtual ICollection<Favori> Favoris { get; set; } = new List<Favori>();
    public virtual Sezon? Sezon { get; set; }
}

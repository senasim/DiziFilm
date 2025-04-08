using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace DiziFilm.Model.Entity;

public partial class YorumDizi : BaseEntity
{

    public int KullaniciId { get; set; }

    public int? DiziId { get; set; }

    public decimal? Puan { get; set; }

    public string Yorum { get; set; } = null!;

    public DateTime? YorumTarih { get; set; }

    public virtual Dizi? Dizi { get; set; }

    public virtual Kullanicilar Kullanici { get; set; } = null!;
}

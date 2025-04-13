using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace DiziFilm.Model.Entity;

public partial class İzlemeListesi : BaseEntity
{

    public int KullaniciId { get; set; }

    public string? ListeAdi { get; set; }

    public DateTime? EklemeTarihi { get; set; }

    public virtual ICollection<İzlemeListesiFilm> IzlemeListesiFilmler { get; set; } = new List<İzlemeListesiFilm>();
    public virtual ICollection<İzlemeListesiDizi> IzlemeListesiDiziler { get; set; } = new List<İzlemeListesiDizi>();

    public virtual Kullanicilar Kullanici { get; set; } = null!;
}

using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace DiziFilm.Model.Entity;

public partial class Favori : BaseEntity
{

    public int? KullaniciId { get; set; }

    public int? DiziId { get; set; }

    public int? FilmId { get; set; }

    public int? BolumId { get; set; }

    public DateTime? EklemeTarihi { get; set; }

    public virtual Bolum? Bolum { get; set; }

    public virtual Film? Film { get; set; }

    public virtual Dizi? Dizi { get; set; }

    public virtual Kullanicilar? KullaniciNavigation { get; set; }
}

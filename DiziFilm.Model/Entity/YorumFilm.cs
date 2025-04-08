using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace DiziFilm.Model.Entity;

public partial class YorumFilm : BaseEntity
{

    public int KullaniciId { get; set; }

    public int FilmId { get; set; }

    public int? Puan { get; set; }

    public string Yorum { get; set; } = null!;

    public DateTime? YorumTarih { get; set; }

    public virtual Film Film { get; set; } = null!;

    public virtual Kullanicilar Kullanici { get; set; } = null!;
}

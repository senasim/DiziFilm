using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace DiziFilm.Model.Entity;

public partial class FilmOyuncu : BaseEntity
{

    public int? OyuncuId { get; set; }

    public int? FilmId { get; set; }

    public string? Rol { get; set; }

    public virtual Film? Film { get; set; }

    public virtual Oyuncu? Oyuncu { get; set; }
}

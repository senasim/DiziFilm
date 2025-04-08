using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace DiziFilm.Model.Entity;

public partial class FilmAfi : BaseEntity
{

    public string? DosyaYolu { get; set; }

    public int? FilmId { get; set; }

    public virtual Film? Film { get; set; }
    public string? DosyaTipi { get; set; }
}

using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace DiziFilm.Model.Entity;

public partial class Turler : BaseEntity
{

    public string? TurAdi { get; set; }

    public virtual ICollection<DiziTur> DiziTurs { get; set; } = new List<DiziTur>();

    public virtual ICollection<FilmTur> FilmTurs { get; set; } = new List<FilmTur>();
}

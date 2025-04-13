using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace DiziFilm.Model.Entity;

public partial class Platform : BaseEntity
{

    public string? PlatformAdi { get; set; }

    public string? Logo { get; set; }

    public string? Url { get; set; }

    public virtual ICollection<Dizi> Dizis { get; set; } = new List<Dizi>();

    public virtual ICollection<FilmPlatform> FilmPlatforms { get; set; } = new List<FilmPlatform>();
}

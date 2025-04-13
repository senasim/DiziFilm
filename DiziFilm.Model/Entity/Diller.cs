using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace DiziFilm.Model.Entity;

public partial class Diller : BaseEntity
{

    public string? DilAdi { get; set; }

    public virtual ICollection<Film> Films { get; set; } = new List<Film>();

    public virtual ICollection<Dizi> Diziler { get; set; } = new List<Dizi>();
}

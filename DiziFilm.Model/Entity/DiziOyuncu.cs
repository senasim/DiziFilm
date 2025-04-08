using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace DiziFilm.Model.Entity;

public partial class DiziOyuncu:BaseEntity
{

    public int DiziId { get; set; }

    public int OyuncuId { get; set; }

    public string? Rol { get; set; }

    public virtual Dizi Dizi { get; set; } = null!;

    public virtual Oyuncu Oyuncu { get; set; } = null!;
}

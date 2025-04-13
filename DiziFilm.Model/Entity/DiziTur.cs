using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace DiziFilm.Model.Entity;

public partial class DiziTur : BaseEntity
{

    public int DiziId { get; set; }

    public int TurId { get; set; }

    public virtual Dizi Dizi { get; set; } = null!;

    public virtual Turler Tur { get; set; } = null!;
}

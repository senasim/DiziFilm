using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace DiziFilm.Model.Entity;

public partial class FilmTur : BaseEntity
{

    public int FilmId { get; set; }

    public int TurId { get; set; }

    public virtual Film Film { get; set; } = null!;

    public virtual Turler Tur { get; set; } = null!;
}

using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace DiziFilm.Model.Entity;

public partial class FilmPlatform : BaseEntity
{

    public int? FilmId { get; set; }

    public int? PlatformId { get; set; }

    public virtual Film? Film { get; set; }

    public virtual Platform? Platform { get; set; }
}

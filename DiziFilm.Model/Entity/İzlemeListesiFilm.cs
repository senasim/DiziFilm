using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace DiziFilm.Model.Entity;

public partial class İzlemeListesiFilm : BaseEntity
{
    public int? İzlemeListesiId { get; set; }

    public int? FilmId { get; set; }

    public virtual Film? Film { get; set; }

    public virtual İzlemeListesi? İzlemeListesi { get; set; }
}

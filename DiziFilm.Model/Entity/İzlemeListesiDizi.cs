using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace DiziFilm.Model.Entity;

public partial class İzlemeListesiDizi : BaseEntity
{

    public int? ListeId { get; set; }

    public int? DiziId { get; set; }

    public virtual Dizi? Dizi { get; set; }

    public virtual İzlemeListesi? İzlemeListesi { get; set; }
}

using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace DiziFilm.Model.Entity;

public partial class Sezon : BaseEntity
{
    public int DiziId { get; set; }
    public int? KacinciSezon { get; set; }

    public virtual ICollection<Bolum> Bolums { get; set; } = new List<Bolum>();

    public virtual Dizi Dizi { get; set; } = null!;
}

using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace DiziFilm.Model.Entity;

public partial class DiziAfi : BaseEntity
{
    public string? DosyaYolu { get; set; }

    public int? DiziId { get; set; }

    public virtual Dizi? Dizi { get; set; }

    public string DosyaTipi { get; set; }
}

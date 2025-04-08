using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace DiziFilm.Model.Entity;

public partial class YonetmenTuru : BaseEntity
{

    public string? Tur { get; set; }

    public virtual ICollection<Yonetmen> Yonetmen { get; set; } = new List<Yonetmen>();
}

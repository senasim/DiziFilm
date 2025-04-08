using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace DiziFilm.Model.Entity;

public partial class YonetmenFilm : BaseEntity
{

    public int YonetmenId { get; set; }

    public int FilmId { get; set; }

    public virtual Film Film { get; set; } = null!;

    public virtual Yonetmen Yonetmen { get; set; } = null!;
}

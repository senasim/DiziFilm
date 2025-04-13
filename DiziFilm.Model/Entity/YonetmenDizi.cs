using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace DiziFilm.Model.Entity;

public partial class YonetmenDizi : BaseEntity
{

    public int YonetmenId { get; set; }

    public int DiziId { get; set; }


    public virtual Dizi Dizi { get; set; } = null!;

    public virtual Yonetmen Yonetmen { get; set; } = null!;
}

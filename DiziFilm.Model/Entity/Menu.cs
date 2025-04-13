using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace DiziFilm.Model.Entity;

public partial class Menu : BaseEntity
{

    public string? Baslik { get; set; }

    public string? Aciklama { get; set; }

    public string? Menuİcon { get; set; }

    public int? UstMenuId { get; set; }

    public string? Url { get; set; }

    public int? Sira { get; set; }

    public virtual ICollection<YetkiRol> YetkiRols { get; set; } = new List<YetkiRol>();
}

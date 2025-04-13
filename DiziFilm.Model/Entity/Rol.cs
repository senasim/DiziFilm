using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace DiziFilm.Model.Entity;

public partial class Rol : BaseEntity
{

    public string? RolAdi { get; set; }

    public virtual ICollection<KullaniciRol> KullaniciRols { get; set; } = new List<KullaniciRol>();

    public virtual ICollection<YetkiRol> YetkiRols { get; set; } = new List<YetkiRol>();
}

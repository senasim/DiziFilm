using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace DiziFilm.Model.Entity;

public partial class KullaniciRol : BaseEntity
{
    public int? KullaniciId { get; set; }

    public int? RolId { get; set; }

    public virtual Kullanicilar? Kullanici { get; set; }

    public virtual Rol? Rol { get; set; }
}

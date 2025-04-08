using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace DiziFilm.Model.Entity;

public partial class Dizi : BaseEntity
{
    
    public string? Aciklama { get; set; }

    public string? Adi { get; set; }

    public DateTime? BaslamaTarihi { get; set; }

    public DateTime? BitisTarihi { get; set; }

    public int? DilId { get; set; }

    public int? PlatformId { get; set; }

    public virtual Diller? Diller { get; set; }

    public virtual ICollection<DiziAfi> DiziAfis { get; set; } = new List<DiziAfi>();

    public virtual ICollection<DiziOyuncu> DiziOyuncus { get; set; } = new List<DiziOyuncu>();

    public virtual ICollection<DiziTur> DiziTurs { get; set; } = new List<DiziTur>();

    public virtual ICollection<Favori> Favoris { get; set; } = new List<Favori>();

    public virtual Platform? Platform { get; set; }

    public virtual ICollection<Sezon> Sezons { get; set; } = new List<Sezon>();

    public virtual ICollection<YonetmenDizi> YonetmenDizis { get; set; } = new List<YonetmenDizi>();

    public virtual ICollection<YorumDizi> YorumDizis { get; set; } = new List<YorumDizi>();

    public virtual ICollection<İzlemeListesiDizi> İzlemeListesiDizis { get; set; } = new List<İzlemeListesiDizi>();

    public virtual ICollection<Bolum> Bolumler { get; set; } = new List<Bolum>();
}

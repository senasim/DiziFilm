using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace DiziFilm.Model.Entity;

public partial class Film : BaseEntity
{

    public string? Adi { get; set; }

    public string? Aciklama { get; set; }

    public int? Sure { get; set; }

    public decimal? Imdb { get; set; }

    public int? DilId { get; set; }

    public DateTime? CikisTarihi { get; set; }
    public virtual Diller? Dil { get; set; }

    public virtual ICollection<Favori> Favoris { get; set; } = new List<Favori>();

    public virtual ICollection<FilmAfi> FilmAfis { get; set; } = new List<FilmAfi>();

    public virtual ICollection<FilmOyuncu> FilmOyuncus { get; set; } = new List<FilmOyuncu>();

    public virtual ICollection<FilmPlatform> FilmPlatforms { get; set; } = new List<FilmPlatform>();

    public virtual ICollection<FilmTur> FilmTurs { get; set; } = new List<FilmTur>();

    public virtual ICollection<YonetmenFilm> YonetmenFilms { get; set; } = new List<YonetmenFilm>();

    public virtual ICollection<YorumFilm> YorumFilms { get; set; } = new List<YorumFilm>();

    public virtual ICollection<İzlemeListesiFilm> İzlemeListesiFilms { get; set; } = new List<İzlemeListesiFilm>();
}

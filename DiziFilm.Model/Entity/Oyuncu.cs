using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DiziFilm.Model.Entity;

public partial class Oyuncu : BaseEntity
{

    public string? Adi { get; set; }

    public string? Soyadi { get; set; }

    public DateTime? DogumTarihi { get; set; }

    public string? Biyografi { get; set; }

    public bool? Cinsiyet { get; set; }

    public string? DogumYeri { get; set; }

    public virtual ICollection<DiziOyuncu> DiziOyuncus { get; set; } = new List<DiziOyuncu>();

    public virtual ICollection<FilmOyuncu> FilmOyuncus { get; set; } = new List<FilmOyuncu>();
}

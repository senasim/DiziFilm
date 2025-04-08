using DiziFilm.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziFilm.Model.ViewModel.Areas.AdminPanel
{
    public class TurIndexViewModel
    {
        public string? TurAdi { get; set; }

        public List<Turler> TurListesi { get; set; }

        public virtual ICollection<DiziTur> DiziTurs { get; set; } = new List<DiziTur>();

        public virtual ICollection<FilmTur> FilmTurs { get; set; } = new List<FilmTur>();
    }
}

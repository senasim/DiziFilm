using DiziFilm.Model.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DiziFilm.Model.ViewModel.Areas.AdminPanel
{
    public class FilmEditViewModel
    {
        public int Id { get; set; }
        public string? Adi { get; set; }
        public string? Aciklama { get; set; }
        public int? Sure { get; set; }
        public int? DilId { get; set; }
        public DateTime? CikisTarihi { get; set; }

        public List<int>? SelectedTurIds { get; set; } = new List<int>();
        public List<int>? SelectedPlatformIds { get; set; } = new List<int>();

        public List<FilmOyuncu> FilmOyuncus { get; set; } = new List<FilmOyuncu>();
        public List<FilmPlatform> FilmPlatforms { get; set; } = new List<FilmPlatform>();
        public List<YonetmenFilm> YonetmenFilms { get; set; } = new List<YonetmenFilm>();
        public List<FilmAfi> FilmAfis { get; set; } = new List<FilmAfi>();
        public List<int> FilmTurs { get; set; } = new List<int>();

        public List<SelectListItem> Oyuncular { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Platformlar { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Turler { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Yonetmenler { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Diller { get; set; } = new List<SelectListItem>();
    }
}

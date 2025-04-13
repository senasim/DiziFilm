using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DiziFilm.Model.ViewModel.Areas.AdminPanel
{
    public class FilmOyuncuViewModel
    {
        public int Id { get; set; }
        public int OyuncuId { get; set; }
        public string OyuncuAdi { get; set; }
        public string Rol { get; set; }

       public List<SelectListItem> Oyuncular { get; set; }
    }

    public class YonetmenFilmViewModel
    {
        public int Id { get; set; }
        public int YonetmenId { get; set; }
        public int FilmId { get; set; }

       public List<SelectListItem> Yonetmenler { get; set; }
    }

    public class PlatformViewModel
    {
        public int FilmId { get; set; }
        public List<int> PlatformIds { get; set; }
    }
}

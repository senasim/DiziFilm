using DiziFilm.Model.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziFilm.Model.ViewModel.Areas.AdminPanel
{
   public class YonetmenIndexViewModel
    {
        public int Id { get; set; }
        public string? Adi { get; set; }

        public string Soyadi { get; set; } = null!;
        public bool? Cinsiyet { get; set; }

        public DateTime? DogumTarihi { get; set; }

        public string MiniBio { get; set; } = null!;
        public int YonetmenTurId { get; set; }

        public IEnumerable<YonetmenTuru> YonetmenTurleri { get; set; } = new List<YonetmenTuru>();

        public List<SelectListItem> yonetmenTuruList = new List<SelectListItem>();
    }
}

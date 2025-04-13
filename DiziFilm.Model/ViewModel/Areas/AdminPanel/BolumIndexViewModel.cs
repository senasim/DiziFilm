
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DiziFilm.Model.ViewModel.Areas.AdminPanel
{
    public class BolumIndexViewModel
    {
        public int Id { get; set; }
        public string? BolumAdi { get; set; }

        public string? BolumSayisi { get; set; }
        public int? Sure { get; set; }

        public DateTime? YayinTarihi { get; set; }

        public int? SezonId { get; set; }

        public List<SelectListItem> DiziListe { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> SezonListe { get; set; } = new List<SelectListItem>();

    }
}

using DiziFilm.Model.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziFilm.Model.ViewModel.Areas.AdminPanel
{
    public class DiziIndexViewModel
    {
        public int Id { get; set; }
        public string? Adi { get; set; }

        public string? Aciklama { get; set; }
        public DateTime? BaslamaTarihi { get; set; }

        public DateTime? BitisTarihi { get; set; }

        public int SezonSayisi { get; set; }
        public int BolumSayisi { get; set; }

        public int? DilId { get; set; }

        public int? PlatformId { get; set; }

        public virtual Diller? Diller { get; set; }

        

        public virtual ICollection<DiziAfi> DiziAfis { get; set; } = new List<DiziAfi>();

      public  List<SelectListItem> Turler { get; set; }
       public   List<SelectListItem> Oyuncular { get; set; }
       public   List<SelectListItem> Yonetmenler { get; set; }
       public   List<SelectListItem> Platformlar { get; set; }

        public List<SelectListItem> DillerList { get; set; }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DiziFilm.Model.ViewModel.Areas.AdminPanel
{
    public class OyuncuIndexViewModel
    {

        public int Id { get; set; }
        public string? Adi { get; set; }

        public string? Soyadi { get; set; }

        public DateTime? DogumTarihi { get; set; }

        public string? Biyografi { get; set; }

        public bool? Cinsiyet { get; set; }

        public string? DogumYeri { get; set; }
    }
}

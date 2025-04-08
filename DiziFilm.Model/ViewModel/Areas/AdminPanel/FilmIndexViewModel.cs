using DiziFilm.Model.Entity;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace DiziFilm.Model.ViewModel.Areas.AdminPanel
{
    public class FilmIndexViewModel
    {
        public int Id { get; set; }
        public string? Adi { get; set; }

        public string? Aciklama { get; set; }

        public int? Sure { get; set; }

        public DateTime? CikisTarihi { get; set; }
        public int? DilId { get; set; }

        public int PlatformId { get; set; }

        List<SelectListItem> Turler { get; set; }
        public List<FilmTur> Diller { get; set; }

        public List<FilmOyuncu> Platformlar { get; set; }


        //public string AnaAfisUrl
        //{
        //    get
        //    {
        //        var aktifAfis = FilmAfis.FirstOrDefault(x => x.Aktif == true);
        //        if (aktifAfis != null)
        //        {
        //            return $"/uploads/afisler/{aktifAfis.DosyaYolu}";
        //        }


        //        var herhangiAfis = FilmAfis?.FirstOrDefault();
        //        if (herhangiAfis != null)
        //        {
        //            return $"/uploads/afisler/{herhangiAfis.DosyaYolu}";
        //        }
        //        return "/images/noimage.png";
        //    }



        //}
        //public string TurlerString
        //{
        //    get
        //    {
        //        if (FilmTurs != null && FilmTurs.Any())
        //        {
        //            return string.Join(", ", FilmTurs.Select(t => t.TurId));
        //        }
        //        return string.Empty;
        //    }
        //}
    }
}

     


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziFilm.Model.Statics
{
    public static class SessionKeys
    {
        public static string AktifKullanici {  get; } = "AKTIFKULLANICI";
        public static string AktifYonetici { get; } = "AKTİFYONETİCİ";
        public static string GuvenlikKodu { get; set; } = "GUVENLIKKODU";

    }
}

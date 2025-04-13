using DiziFilm.Model.Entity;

namespace DiziFilm.MVCCoreUI.Filters
{
    public interface ISessionManager
    {
        public Kullanicilar AktifKullanici { get; set; }
        public Kullanicilar AktifYonetici { get; set; }
        public string GuvenlikKodu { get; set; }
    public bool YetkisiVarMi (int MenuId,int KullaniciId);

    }
}

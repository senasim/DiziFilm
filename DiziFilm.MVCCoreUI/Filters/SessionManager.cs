using DiziFilm.Business.Abstract;
using DiziFilm.Business.Concrete.Base;
using DiziFilm.Model.Entity;
using DiziFilm.Model.Statics;
using DiziFilm.MVCCoreUI.Extensions;

namespace DiziFilm.MVCCoreUI.Filters
{
    public class SessionManager : ISessionManager
    {
        IHttpContextAccessor _httpContextAccessor;
        private readonly IKullanicilarBs _kullaniciBS;
       private readonly IMenuBs _menuBs;
        public SessionManager(IHttpContextAccessor httpContextAccessor, IKullanicilarBs kullaniciBS,IMenuBs menuBs)
        {
            _httpContextAccessor = httpContextAccessor;
            _kullaniciBS = kullaniciBS;
           _menuBs = menuBs;

        }
        public Kullanicilar AktifKullanici
        {
            get
            {

                return _httpContextAccessor.HttpContext.Session.GetObject<Kullanicilar>(SessionKeys.AktifKullanici);



            }
            set
            {
                _httpContextAccessor.HttpContext.Session.SetObject(SessionKeys.AktifKullanici, value);

            }
        }
        public Kullanicilar AktifYonetici
        {


            get
            {

                return _httpContextAccessor.HttpContext.Session.GetObject<Kullanicilar>(SessionKeys.AktifYonetici);



            }
            set
            {
                _httpContextAccessor.HttpContext.Session.SetObject(SessionKeys.AktifYonetici, value);

            }



        }

        public string GuvenlikKodu
        {
            get
            {
                return _httpContextAccessor.HttpContext.Session.GetObject<string>(SessionKeys.GuvenlikKodu);



            }
            set
            {
                _httpContextAccessor.HttpContext.Session.SetObject(SessionKeys.GuvenlikKodu, value);

            }
        }

        public bool YetkisiVarMi(int MenuId, int KullaniciId)
        {
            Menu menu = _menuBs.Get(x => x.Id == MenuId, false, "YetkiRols", "YetkiRols.Rol", "YetkiRols.Rol.KullaniciRols", "YetkiRols.Rol.KullaniciRols.Kullanici");

            Kullanicilar k=_kullaniciBS.Get(x => x.Id == KullaniciId, false, "KullaniciRols");

            bool Yetki = false;

            foreach (YetkiRol yetki in menu.YetkiRols)
            {
                foreach (KullaniciRol rol in k.KullaniciRols)
                {
                    if (yetki.SelectYetki==true && yetki.RolId==rol.RolId)
                    {
                        Yetki = true;
                        break;
                    }
                }
            }
            return Yetki;
        }
    }
}

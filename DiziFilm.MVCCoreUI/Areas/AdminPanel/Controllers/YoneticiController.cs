using DiziFilm.Business.Abstract;
using DiziFilm.Model.Entity;
using DiziFilm.Model.ViewModel.Areas.AdminPanel;
using DiziFilm.MVCCoreUI.Filters;
using Infrastructure.CrossCuttingConcern.Crypto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace DiziFilm.MVCCoreUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]

    public class YoneticiController : Controller
    {
        private readonly IKullanicilarBs _kullanicilarBs;
        private readonly ISessionManager _session;
        IMemoryCache _memoryCache;
        public YoneticiController(IKullanicilarBs kullanicilarBs,ISessionManager session,IMemoryCache memoryCache)
        {
            _kullanicilarBs = kullanicilarBs;
            _session = session;
            _memoryCache = memoryCache;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Login()
        {


           string Id= HttpContext.Request.Cookies["AktifYoneticiCookie"];
            if (!string.IsNullOrEmpty(Id))
            {
                int kid= Convert.ToInt32(Id);
              Kullanicilar k= _kullanicilarBs.Get(x => x.Id == kid);

                if (k != null) {
                    _session.AktifYonetici = k;
                    return RedirectToAction("Index","Panel");

                }
            }


          
            LoginVm vm = new LoginVm();


            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginVm kullanici)
        {
            if (!ModelState.IsValid)
            {
                return View(kullanici);
            }

            string CryptoPassword = CryptoManager.SHA256Encrypt(kullanici.Sifre);

            Kullanicilar kullanicilar=_kullanicilarBs.Get(x=>x.Email == kullanici.Email && x.Sifre == CryptoPassword,false, "KullaniciRols", "KullaniciRols.Rol");

            if (kullanicilar !=null)
            {
                _session.AktifYonetici = kullanicilar;


                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(1);


                HttpContext.Response.Cookies.Append("AktifYoneticiCookie", kullanicilar.Id.ToString(),options);

                

                return RedirectToAction("Index", "Panel");
            }
            else
            {
                TempData["Mesaj"] = "Giriş Hatalı.";

            }
            return View();
        }

        public IActionResult Logout()
        {
            _session.AktifYonetici = null;
            HttpContext.Response.Cookies.Delete("AktifYoneticiCookie");
            return RedirectToAction("Login");
        }
    }
}

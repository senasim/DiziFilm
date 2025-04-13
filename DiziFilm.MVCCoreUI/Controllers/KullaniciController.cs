using AutoMapper;
using DiziFilm.Business.Abstract;
using DiziFilm.Model.Entity;
using DiziFilm.Model.ViewModel.Areas.AdminPanel;
using DiziFilm.Model.ViewModel.Front;
using DiziFilm.MVCCoreUI.Filters;
using Infrastructure.CrossCuttingConcern.Crypto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DiziFilm.MVCCoreUI.Controllers
{
    
    public class KullaniciController : Controller
    {
        private readonly IKullanicilarBs _kullanicilarBs;
        private readonly IMapper _mapper;
        private readonly ISessionManager _session;

        public KullaniciController(IKullanicilarBs kullanicilarBs, IMapper mapper,ISessionManager session)
        {
            _kullanicilarBs = kullanicilarBs;
            _mapper = mapper;
            _session = session;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Login()
        {
            LoginVm vm = new LoginVm();
            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginVm user)
        {

            if (!ModelState.IsValid)
            {
                return View(user);
            }
            string CryptoSifre = CryptoManager.SHA256Encrypt(user.Sifre);

            Kullanicilar kullanici = _kullanicilarBs.Get(x => x.Email == user.Email && x.Sifre == CryptoSifre);

            if (kullanici != null)
            {

                _session.AktifKullanici = kullanici;


                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Mesaj"] = "Giriş Hatalı.";
            }

            return View();
        }

        public IActionResult Register()
        {
            KullaniciSignUpVm vm = new KullaniciSignUpVm();
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(KullaniciSignUpVm model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(y => y.ErrorMessage).ToList();
                return Json(new { success = false, errors = errors, message = "Eksik Bilgi" });
            }

            Kullanicilar kullanici = _mapper.Map<Kullanicilar>(model);
            kullanici.Sifre = CryptoManager.SHA256Encrypt(model.Sifre);
            kullanici.UniqueId = Guid.NewGuid();
            kullanici.Aktif = true; 

            _kullanicilarBs.Insert(kullanici);

            return Json(new { result = true, mesaj = "Kayıt Başarılı" });
        }


        [HttpPost]
        public IActionResult Logout()
        {
            _session.AktifKullanici = null;
            return RedirectToAction("Login");
        }
        public IActionResult Reset()
        {
            return View();
        }


       
        
    }
}

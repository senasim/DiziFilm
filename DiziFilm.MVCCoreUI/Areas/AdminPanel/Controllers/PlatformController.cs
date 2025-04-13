using DiziFilm.Business.Abstract;
using DiziFilm.Business.Concrete.Base;
using DiziFilm.Model.Entity;
using DiziFilm.Model.ViewModel.Areas.AdminPanel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace DiziFilm.MVCCoreUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class PlatformController : Controller
    {
        private readonly IPlatformBs _platformBs;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PlatformController(IPlatformBs platformBs, IWebHostEnvironment webHostEnvironment)
        {
            _platformBs = platformBs;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            PlatformIndexViewModel model = new PlatformIndexViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult List()
        {
            try
            {
                List<Platform> p = _platformBs.GetAll();

                var result = p.Select(x => new
                {
                    id = x.Id,
                    platformAdi = x.PlatformAdi,
                    logo = x.Logo,
                    logoAdi = x.Url != null ? Path.GetFileName(x.Url) : null,
                    aktif = x.Aktif
                });
                return Json(new { data = result });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PlatformIndexViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var logoFile = Request.Form.Files["Logo"];
                    string logoPath = null;

                    if (logoFile != null && logoFile.Length > 0)
                    {
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "platform-logos");
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + logoFile.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            logoFile.CopyTo(fileStream);
                        }

                        logoPath = "/uploads/platform-logos/" + uniqueFileName;
                    }

                    Platform p = new Platform
                    {
                        PlatformAdi = model.PlatformAdi,
                        Logo = logoPath,
                        Aktif = true,
                        OlusturulmaTarihi = DateTime.Now
                    };

                    _platformBs.Insert(p);
                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = ex.Message });
                }
            }

            return Json(new { success = false, message = "Geçersiz model durumu" });
        }

        [HttpPost]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                
                if (file == null || file.Length == 0)
                {
                    return Json(new { success = false, message = "Dosya yüklenemedi!" });
                }

                // Dosya uzantısını kontrol et
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".svg" };
                var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
                
                if (!allowedExtensions.Contains(fileExtension))
                {
                    return Json(new { success = false, message = "Desteklenmeyen dosya formatı!" });
                }

                // Dosya adını benzersiz yap
                var fileName = $"{Guid.NewGuid()}{fileExtension}";
                
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "platform-logos");
                // Dizin yoksa oluştur
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var filePath = Path.Combine(uploadsFolder, fileName);

                // Dosyayı kaydet
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Dosya URL'sini döndür
                var fileUrl = $"/uploads/platform-logos/{fileName}";

                return Json(new { success = true, filePath = fileUrl });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
      public IActionResult AktifPasif(int id,bool aktif)
        {
          Platform p =  _platformBs.GetById(id);
            p.Aktif = aktif;
            p.DegistirilmeTarihi = DateTime.Now;
            _platformBs.Update(p);

            return Json(new { result = true, mesaj = "Aktiflik durumu başarıyla güncellendi" });
        }

    }

}

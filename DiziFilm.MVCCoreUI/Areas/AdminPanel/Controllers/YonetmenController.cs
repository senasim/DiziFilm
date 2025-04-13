using DiziFilm.Business.Abstract;
using DiziFilm.Business.Concrete.Base;
using DiziFilm.Model.Entity;
using DiziFilm.Model.ViewModel.Areas.AdminPanel;
using DiziFilm.MVCCoreUI.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DiziFilm.MVCCoreUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class YonetmenController : Controller
    {
        private readonly IYonetmenBs _yonetmenBs;
        private readonly ISessionManager _session;
        private readonly IYonetmenTuruBs _yonetmenTuruBs;
        public YonetmenController(IYonetmenBs yonetmenBs,ISessionManager session,IYonetmenTuruBs yonetmenTuruBs)
        {
            _yonetmenBs = yonetmenBs;
            _session= session;
            _yonetmenTuruBs = yonetmenTuruBs;

        }
        public IActionResult Index()
        {
            YonetmenIndexViewModel model = new YonetmenIndexViewModel();
            model.YonetmenTurleri = _yonetmenTuruBs.GetAll();
            return View(model);
        }

        [HttpPost]
        public IActionResult List()
        {
            var yonetmenler = _yonetmenBs.GetAll(null, null, Infrastructure.Enumarations.Sorted.ASC, false, "YonetmenTur");
            var yonetmenList = yonetmenler.Select(x => new
            {
                id = x.Id,
                adi = x.Adi,
                soyadi = x.Soyadi,
                cinsiyet = x.Cinsiyet,
                dogumTarihi = x.DogumTarihi,
                miniBio = x.MiniBio,
                yonetmenTurAdi = x.YonetmenTur?.Tur ?? ""
            }).ToList();

            return Json(new { data = yonetmenList });
        }
        
        public IActionResult Add(IFormCollection data)
        {
            Yonetmen directory = new Yonetmen();
            directory.Adi = data["Adi"];
            directory.Soyadi = data["Soyadi"];
            directory.Cinsiyet = data["Cinsiyet"] == "1";

            string dogumTarihiStr = data["DogumTarihi"].ToString();
            if (!string.IsNullOrEmpty(dogumTarihiStr) && dogumTarihiStr != "undefined")
            {
                DateTime dt;
                if (DateTime.TryParse(dogumTarihiStr, out dt))
                {
                    directory.DogumTarihi = dt;
                }
            }
            directory.MiniBio = data["MiniBio"];
            directory.DegistirenId = _session.AktifYonetici.Id;
            directory.YonetmenTurId = Convert.ToInt32(data["YonetmenTurId"]);
            _yonetmenBs.Insert(directory);
            return Json(new
            {
                result = true,
                mesaj = "Yönetmen Başarıyla Eklendi"
            });
        }
        
        [HttpPost]
        public IActionResult Edit(IFormCollection data) { 
         
            Yonetmen yonetmen = new Yonetmen();
            yonetmen.Id = Convert.ToInt32(data["Id"]);
            yonetmen.Adi = data["Adi"];
            yonetmen.Soyadi = data["Soyadi"];
            yonetmen.Cinsiyet = data["Cinsiyet"] == "1";
            yonetmen.MiniBio = data["MiniBio"];
            yonetmen.DegistirenId = _session.AktifYonetici.Id;

            if (!string.IsNullOrEmpty(data["DogumTarihi"]) && data["DogumTarihi"] != "undefined")
            {
                if (DateTime.TryParse(data["DogumTarihi"], out DateTime dt))
                {
                    yonetmen.DogumTarihi = dt;
                }
            }

            yonetmen.DegistirenId = _session.AktifYonetici.Id;
            yonetmen.YonetmenTurId = Convert.ToInt32(data["YonetmenTurId"]);

            _yonetmenBs.Update(yonetmen);

            return Json(new
            {
                result = true,
                mesaj = "Yönetmen Başarıyla Güncellendi"
            });
        }

        [HttpPost]
        public IActionResult Delete(int id) {
            _yonetmenBs.DeleteById(id);
            return Json(new { result = true, mesaj = "Yönetmen Başarıyla Silindi" });

        }
        public IActionResult GetYonetmen(int id)
        {
            Yonetmen y = _yonetmenBs.Get(x => x.Id == id, false, "YonetmenTur");
            return Json(new { result = true, model = y });
        }
    }
}

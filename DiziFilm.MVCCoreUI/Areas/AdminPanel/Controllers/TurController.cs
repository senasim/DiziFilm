using DiziFilm.Business.Abstract;
using DiziFilm.Business.Concrete.Base;
using DiziFilm.Model.Entity;
using DiziFilm.Model.ViewModel.Areas.AdminPanel;
using Microsoft.AspNetCore.Mvc;

namespace DiziFilm.MVCCoreUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class TurController : Controller
    {

        ITurlerBs _turlerBs;
        public TurController(ITurlerBs turlerBs)
        {
            _turlerBs = turlerBs;
        }
        public IActionResult Index()
        {
            TurIndexViewModel model = new TurIndexViewModel();
            model.TurListesi=_turlerBs.GetAll().ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult List()
        {
            List<Turler> turler=_turlerBs.GetAll();
            return Json(new { data=turler });
        }
        [HttpPost]
        public IActionResult Add(IFormCollection data)
        {
            Turler turler = new Turler();
            turler.TurAdi = data["TurAdi"];
            _turlerBs.Insert(turler);

            List<Turler> tur = _turlerBs.GetAll();

            TurIndexViewModel model= new TurIndexViewModel();
            return Json(new { result = true, mesaj = "Tür Başarıyla Eklendi", model = model });
        }
        [HttpPost]
        public IActionResult Update(IFormCollection data) { 


            int Id = Convert.ToInt32(data["Id"]);
            Turler tur = _turlerBs.GetById(Id);
            tur.TurAdi = data["TurAdi"];
            _turlerBs.Update(tur);

            List<Turler> turler = _turlerBs.GetAll();
            TurIndexViewModel model = new TurIndexViewModel();
            model.TurListesi = turler;
            return Json(new { result = true, mesaj = "Tür Başarıyla Güncellendi", model = model });

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _turlerBs.DeleteById(id);
            return Json(new { result = true, mesaj = "Tür Başarıyla Silindi" });

        }

        public IActionResult AktifPasif(int id, bool aktif)
        {

            Turler tur = _turlerBs.Get(x => x.Id == id);
            tur.Aktif = aktif;
            _turlerBs.Update(tur);


            return Json(new { result = true, mesaj = "Aktiflik Başarıyla Güncellendi" });

        }
        public IActionResult GetTur(int id)
        {
            Turler turler = _turlerBs.GetById(id);
            return Json(new { result = true, model = turler });
          
        }
    }
}

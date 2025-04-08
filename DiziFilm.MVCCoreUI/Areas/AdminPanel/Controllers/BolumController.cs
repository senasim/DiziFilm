using DiziFilm.Business.Abstract;
using DiziFilm.Business.Concrete.Base;
using DiziFilm.Model.Entity;
using DiziFilm.Model.ViewModel.Areas.AdminPanel;
using Infrastructure.Entity;
using Infrastructure.Enumarations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace DiziFilm.MVCCoreUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class BolumController : Controller
    {
        private readonly IBolumBs _bolumBs;
        private readonly IDiziBs _diziBs;
        private readonly ISezonBs _sezonBs;

        public BolumController(IBolumBs bolumBs, IDiziBs diziBs, ISezonBs sezonBs)
        {
            _bolumBs = bolumBs;
            _diziBs = diziBs;
            _sezonBs = sezonBs;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult List()
        {
            try
            {
                int draw = Convert.ToInt32(Request.Form["draw"]);
                int start = Convert.ToInt32(Request.Form["start"]);
                int length = Convert.ToInt32(Request.Form["length"]);

                string searchValue = Request.Form["search[value]"].FirstOrDefault()?.Trim() ?? string.Empty;
                string sortColumn = "Id";
                string sortColumnDirection = "asc";

                if (Request.Form.ContainsKey("order[0][column]"))
                {
                    int sortColumnIdx = Convert.ToInt32(Request.Form["order[0][column]"]);
                    sortColumn = Request.Form[$"columns[{sortColumnIdx}][data]"].FirstOrDefault() ?? "Id";
                    sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault() ?? "asc";
                }

                // Filtre oluştur
                Expression<Func<Bolum, bool>> filter = x => x.Aktif != null;
                if (!string.IsNullOrEmpty(searchValue))
                {
                    filter = x => x.BolumAdi.Contains(searchValue) ||
                                  (x.Sezon != null && x.Sezon.Dizi != null && x.Sezon.Dizi.Adi.Contains(searchValue));
                }

                // Verileri al
                PagingResult<Bolum> bolumData = _bolumBs.GetAllPaging(
                    start, length, filter, x => x.Id,
                    sortColumnDirection.Equals("asc", StringComparison.OrdinalIgnoreCase) ? Sorted.ASC : Sorted.DESC,
                    "Sezon", "Sezon.Dizi"
                );

                // DataTable için istenen formatta veri hazırla
                var formattedData = bolumData.Data.Select(b => new
                {
                    id = b.Id,
                    adi = b.Sezon?.Dizi?.Adi ?? "-",
                    bolumAdi = b.BolumAdi ?? "-",
                    sezonNo = b.Sezon?.KacinciSezon.ToString() ?? "-",
                    bolumNo = b.BolumSayisi ?? "-",
                    sure = b.Sure.ToString(),
                    bolumTarihi = b.YayinTarihi.HasValue ? b.YayinTarihi.Value.ToString("dd.MM.yyyy") : "-",
                    aktif = b.Aktif ?? false
                }).ToList();

                return Json(new
                {
                    draw = draw,
                    recordsFiltered = bolumData.TotalCount,
                    recordsTotal = bolumData.TotalItemCount,
                    data = formattedData
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    draw = 1,
                    recordsFiltered = 0,
                    recordsTotal = 0,
                    data = new List<object>(),
                    error = ex.Message
                });
            }
        }

        [HttpPost]
        public IActionResult GetDizi()
        {
            try
            {
                var diziler = _diziBs.GetAll(x => x.Aktif == true);
                var formattedDiziler = diziler.Select(d => new
                {
                    id = d.Id,
                    text = d.Adi
                }).ToList();

                return Json(new { data = formattedDiziler });
            }
            catch (Exception ex)
            {
                return Json(new { data = new List<object>(), error = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetBolum(int id)
        {
            try
            {
                Bolum bolum = _bolumBs.Get(x => x.Id == id, false, "Sezon", "Sezon.Dizi");
                if (bolum == null)
                {
                    return Json(new { result = false, message = "Bölüm bulunamadı." });
                }

                return Json(new
                {
                    result = true,
                    model = new
                    {
                        bolum = new
                        {
                            id = bolum.Id,
                            bolumAdi = bolum.BolumAdi,
                            bolumSayisi = bolum.BolumSayisi,
                            sure = bolum.Sure,
                            yayinTarihi = bolum.YayinTarihi.HasValue ? bolum.YayinTarihi.Value.ToString("yyyy-MM-dd") : "",
                            sezonId = bolum.SezonId
                        },
                        sezon = new
                        {
                            id = bolum.Sezon?.Id ?? 0,
                            kacinciSezon = bolum.Sezon?.KacinciSezon ?? 0
                        },
                        dizi = new
                        {
                            id = bolum.Sezon?.Dizi?.Id ?? 0,
                            adi = bolum.Sezon?.Dizi?.Adi ?? "-"
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message });
            }
        }

        public IActionResult Add()
        {
            BolumIndexViewModel model = new BolumIndexViewModel();

            model.SezonListe = _sezonBs.GetAll(x => x.Aktif == true, null, Sorted.ASC, false, "Dizi")
                .Select(x => new SelectListItem
                {
                    Text = $"{x.Dizi?.Adi ?? "-"} - {x.KacinciSezon}. Sezon",
                    Value = x.Id.ToString()
                }).ToList();

            model.SezonListe.Insert(0, new SelectListItem { Text = "Sezon Seçiniz", Value = "0", Selected = true });

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(BolumIndexViewModel model)
        {
            try
            {
                Bolum bolum;
                bool isUpdate = model.Id > 0;

                if (isUpdate)
                {
                    // Güncelleme
                    bolum = _bolumBs.GetById(model.Id);
                    if (bolum == null)
                    {
                        return Json(new { result = false, message = "Güncellenecek bölüm bulunamadı." });
                    }

                    bolum.BolumAdi = model.BolumAdi;
                    bolum.BolumSayisi = model.BolumSayisi;
                    bolum.Sure = model.Sure;
                    bolum.YayinTarihi = model.YayinTarihi;
                    bolum.SezonId = model.SezonId;
                    bolum.DegistirilmeTarihi = DateTime.Now;

                    _bolumBs.Update(bolum);
                    return Json(new { result = true, message = "Bölüm başarıyla güncellendi." });
                }
                else
                {
                    // Yeni ekleme
                    bolum = new Bolum
                    {
                        BolumAdi = model.BolumAdi,
                        BolumSayisi = model.BolumSayisi,
                        Sure = model.Sure,
                        YayinTarihi = model.YayinTarihi,
                        SezonId = model.SezonId,
                        Aktif = true,
                        OlusturulmaTarihi = DateTime.Now
                    };

                    _bolumBs.Insert(bolum);
                    return Json(new { result = true, message = "Bölüm başarıyla eklendi." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = "İşlem sırasında bir hata oluştu: " + ex.Message });
            }
        }

        [HttpPost]
        public IActionResult AktifPasif(int id, bool aktif)
        {
            try
            {
                Bolum bolum = _bolumBs.GetById(id);
                if (bolum == null)
                {
                    return Json(new { result = false, mesaj = "Bölüm bulunamadı." });
                }

                bolum.Aktif = aktif;
                bolum.DegistirilmeTarihi = DateTime.Now;
                _bolumBs.Update(bolum);

                return Json(new { result = true, mesaj = "Aktiflik durumu başarıyla güncellendi" });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, mesaj = "İşlem sırasında bir hata oluştu: " + ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetDiziler()
        {
            try
            {
                List<Dizi> dizi = _diziBs.GetAll(x => x.Aktif == true);
                var diziler = dizi.Select(x => new { id = x.Id, text = x.Adi }).ToList();
                return Json(diziler);
            }
            catch (Exception ex)
            {
                return Json(new List<object>());
            }
        }

        [HttpGet]
        public IActionResult GetSezonlar(int id)
        {
            try
            {
                List<Sezon> sezon = _sezonBs.GetAll(x => x.Aktif == true && x.DiziId == id, null, Sorted.ASC, false);
                var sezonlar = sezon.Select(x => new { 
                    id = x.Id, 
                    text = $"{x.KacinciSezon}. Sezon",
                    diziId = x.DiziId
                }).ToList();
                return Json(sezonlar);
            }
            catch (Exception ex)
            {
                return Json(new List<object>());
            }
        }
    }
}
using DiziFilm.Business.Abstract;
using DiziFilm.Model.Entity;
using DiziFilm.Model.ViewModel.Areas.AdminPanel;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace DiziFilm.MVCCoreUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class OyuncuController : Controller
    {
       private readonly IOyuncuBs _oyuncuBs;
        public OyuncuController(IOyuncuBs oyuncuBs)
        {
            _oyuncuBs = oyuncuBs;   
        }
        public IActionResult Index()
        {

            OyuncuIndexViewModel model = new OyuncuIndexViewModel();
            List<Oyuncu> oyuncular = _oyuncuBs.GetAll();
            return View(model);
        }
        [HttpPost]
        public IActionResult List()
        {
            try
            {
                List<Oyuncu> oyuncular = _oyuncuBs.GetAll();
                var formattedData = oyuncular.Select(o => new
                {
                    id = o.Id,
                    adi = o.Adi ?? "-",
                    soyadi = o.Soyadi ?? "-",
                    cinsiyet = o.Cinsiyet,
                    dogumTarihi = o.DogumTarihi?.ToString("yyyy-MM-dd"),
                    dogumYeri = o.DogumYeri ?? "-",
                    biyografi = o.Biyografi ?? "-",
                    aktif = o.Aktif ?? false
                });

                return Json(new { data = formattedData });
            }
            catch (Exception ex)
            {
                return Json(new { error = true, message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Add(IFormCollection data)
        {
            try
            {
                Oyuncu cast = new Oyuncu();

                // Safely handle required fields with validation
                if (!data.ContainsKey("Adi") || string.IsNullOrEmpty(data["Adi"].ToString()))
                    return Json(new { result = false, mesaj = "Oyuncu adı gereklidir." });

                if (!data.ContainsKey("Soyadi") || string.IsNullOrEmpty(data["Soyadi"].ToString()))
                    return Json(new { result = false, mesaj = "Oyuncu soyadı gereklidir." });

                if (!data.ContainsKey("Cinsiyet") || string.IsNullOrEmpty(data["Cinsiyet"].ToString()))
                    return Json(new { result = false, mesaj = "Cinsiyet seçimi gereklidir." });

                // Assign basic values
                cast.Adi = data["Adi"].ToString();
                cast.Soyadi = data["Soyadi"].ToString();
                cast.Cinsiyet = data["Cinsiyet"].ToString() == "1"; // "1" for Kadın, "0" for Erkek

                // Handle optional date value safely
                if (data.ContainsKey("DogumTarihi") && !string.IsNullOrEmpty(data["DogumTarihi"].ToString()))
                {
                    DateTime parsedDate;
                    if (DateTime.TryParse(data["DogumTarihi"].ToString(), out parsedDate))
                        cast.DogumTarihi = parsedDate;
                }

                // Handle other optional fields
                if (data.ContainsKey("Biyografi") && !string.IsNullOrEmpty(data["Biyografi"].ToString()))
                    cast.Biyografi = data["Biyografi"].ToString();

                if (data.ContainsKey("DogumYeri") && !string.IsNullOrEmpty(data["DogumYeri"].ToString()))
                    cast.DogumYeri = data["DogumYeri"].ToString();

                // Set active by default
                cast.Aktif = true;

                // Insert to database
                _oyuncuBs.Insert(cast);

                return Json(new { result = true, mesaj = "Oyuncu Başarıyla Eklendi" });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, mesaj = "Hata oluştu: " + ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Update(IFormCollection data)
        {
            try
            {
                int Id = Convert.ToInt32(data["id"]);
                Oyuncu oyuncu = _oyuncuBs.GetById(Id);

                if (oyuncu != null)
                {
                    // Use null-conditional operator and safe string handling
                    if (data.ContainsKey("adi") && !string.IsNullOrEmpty(data["adi"].ToString()))
                        oyuncu.Adi = data["adi"].ToString();

                    if (data.ContainsKey("soyadi") && !string.IsNullOrEmpty(data["soyadi"].ToString()))
                        oyuncu.Soyadi = data["soyadi"].ToString();

                    // Fixed Cinsiyet logic - "1" is true (Kadın), "0" is false (Erkek)
                    if (data.ContainsKey("cinsiyet") && !string.IsNullOrEmpty(data["cinsiyet"].ToString()))
                        oyuncu.Cinsiyet = data["cinsiyet"].ToString() == "1";

                    // Safe date parsing
                    if (data.ContainsKey("dogumTarihi") && !string.IsNullOrEmpty(data["dogumTarihi"].ToString()))
                    {
                        DateTime parsedDate;
                        if (DateTime.TryParse(data["dogumTarihi"].ToString(), out parsedDate))
                            oyuncu.DogumTarihi = parsedDate;
                    }

                    if (data.ContainsKey("dogumYeri") && !string.IsNullOrEmpty(data["dogumYeri"].ToString()))
                        oyuncu.DogumYeri = data["dogumYeri"].ToString();

                    if (data.ContainsKey("biyografi") && !string.IsNullOrEmpty(data["biyografi"].ToString()))
                        oyuncu.Biyografi = data["biyografi"].ToString();

                    _oyuncuBs.Update(oyuncu);
                    return Json(new { result = true, mesaj = "Oyuncu Başarıyla Güncellendi" });
                }
                return Json(new { result = false, mesaj = "Oyuncu bulunamadı" });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, mesaj = "Hata oluştu: " + ex.Message });
            }
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
           Oyuncu oyuncu = _oyuncuBs.GetById(id);
            _oyuncuBs.Delete(oyuncu);
            return Json(new { result = true, mesaj = "Oyuncu Başarıyla Silindi" });
        }
        [HttpPost]
        public IActionResult AktifPasif(int id,bool aktif)
        {
          Oyuncu oyuncu=  _oyuncuBs.GetById(id);
            oyuncu.Aktif = aktif;
            _oyuncuBs.Update(oyuncu);
            return Json(new { result = true, mesaj = "Oyuncu Başarıyla Güncellendi" });

        }

        public IActionResult Getir(int id)
        {
            try
            {
                Oyuncu oyuncu = _oyuncuBs.GetById(id);
                if (oyuncu != null)
                {
                    return Json(new { 
                        result = true, 
                        model = new { 
                            adi = oyuncu.Adi,
                            soyadi = oyuncu.Soyadi,
                            cinsiyet = oyuncu.Cinsiyet,
                            dogumTarihi = oyuncu.DogumTarihi?.ToString("yyyy-MM-dd"),
                            dogumYeri = oyuncu.DogumYeri,
                            biyografi = oyuncu.Biyografi
                        }
                    });
                }
                return Json(new { result = false, mesaj = "Oyuncu bulunamadı" });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, mesaj = "Hata oluştu: " + ex.Message });
            }
        }


        }
}

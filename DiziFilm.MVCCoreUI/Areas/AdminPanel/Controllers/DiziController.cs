using DiziFilm.Business.Abstract;
using DiziFilm.Model.Entity;
using DiziFilm.Model.ViewModel.Areas.AdminPanel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using DiziFilm.Business.Concrete.Base;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Linq;

namespace DiziFilm.MVCCoreUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class DiziController : Controller
    {
        private readonly IDiziBs _diziBs;
        private readonly IPlatformBs _platformBs;
        private readonly IDillerBs _dilBs;
        private readonly ITurlerBs _turBs;
        private readonly IOyuncuBs _oyuncuBs;
        private readonly IYonetmenBs _yonetmenBs;
        private readonly IDiziOyuncuBs _diziOyuncuBs;
        private readonly IYonetmenDiziBs _yonetmenDiziBs;
        private readonly IDiziAfiBs _diziAfiBs;
        private readonly IConfiguration _configuration;

        public DiziController(IDiziBs diziBs, IPlatformBs platformBs, IDillerBs dilBs, ITurlerBs turBs, IOyuncuBs oyuncuBs, IYonetmenBs yonetmenBs, IDiziOyuncuBs diziOyuncuBs, IYonetmenDiziBs yonetmenDiziBs, IDiziAfiBs diziAfiBs, IConfiguration configuration)
        {
            _diziBs = diziBs;
            _platformBs = platformBs;
            _dilBs = dilBs;
            _turBs = turBs;
            _oyuncuBs = oyuncuBs;
            _yonetmenBs = yonetmenBs;
            _diziOyuncuBs = diziOyuncuBs;
            _yonetmenDiziBs = yonetmenDiziBs;
            _diziAfiBs = diziAfiBs;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            DiziIndexViewModel model = new DiziIndexViewModel();

            List<Dizi> diziler = _diziBs.GetAll().ToList();
            
            //YÖNETMEN
            model.Yonetmenler = diziler
                .Where(x => x.YonetmenDizis != null && x.YonetmenDizis.Any() && x.YonetmenDizis.First().Yonetmen != null)
                .Select(x => new SelectListItem
                {
                    Text = x.YonetmenDizis.First().Yonetmen.Adi,
                    Value = x.YonetmenDizis.First().YonetmenId.ToString()
                })
                .ToList();

            model.Yonetmenler.Insert(0, new SelectListItem()
            {
                Text = "Yönetmen Seçiniz",
                Value = "0",
                Selected = true
            });

            //OYUNCU
            model.Oyuncular = diziler
                .Where(x => x.DiziOyuncus != null && x.DiziOyuncus.Any() && x.DiziOyuncus.First().Oyuncu != null)
                .Select(x => new SelectListItem
                {
                    Text = x.DiziOyuncus.First().Oyuncu.Adi,
                    Value = x.DiziOyuncus.First().OyuncuId.ToString()
                })
                .ToList();

            model.Oyuncular.Insert(0, new SelectListItem()
            {
                Text = "Oyuncu Seçiniz",
                Value = "0",
                Selected = true
            });

            //PLATFORM
            model.Platformlar = diziler
                .Where(x => x.Platform != null)
                .Select(x => new SelectListItem
                {
                    Text = x.Platform.PlatformAdi,
                    Value = x.PlatformId.ToString()
                })
                .ToList();

            model.Platformlar.Insert(0, new SelectListItem()
            {
                Text = "Platform Seçiniz",
                Value = "0",
                Selected = true
            });

            //TÜRLER
            model.Turler = diziler
                .Where(x => x.DiziTurs != null && x.DiziTurs.Any() && x.DiziTurs.First().Tur != null)
                .Select(x => new SelectListItem
                {
                    Text = x.DiziTurs.First().Tur.TurAdi,
                    Value = x.DiziTurs.First().TurId.ToString()
                })
                .ToList();

            model.Turler.Insert(0, new SelectListItem()
            {
                Text = "Tür Seçiniz",
                Value = "0",
                Selected = true
            });

            //DİLLER
            model.DillerList = diziler
                .Where(x => x.Diller != null)
                .Select(x => new SelectListItem
                {
                    Text = x.Diller.DilAdi,
                    Value = x.DilId.ToString()
                })
                .ToList();

            model.DillerList.Insert(0, new SelectListItem()
            {
                Text = "Dil Seçiniz",
                Value = "0",
                Selected = true
            });

            return View(model);
        }

        [HttpPost]
        public IActionResult List()
        {
            try
            {
                List<Dizi> diziler = _diziBs.GetAll(
                    x => x.Aktif == true,
                    x => x.Adi,
                    Infrastructure.Enumarations.Sorted.ASC,
                    false,
                    "DiziTurs", "DiziTurs.Tur", "Platform", "Diller", "DiziAfis", "Sezons", "Sezons.Bolums"
                );

                var result = diziler.Select(dizi => new {
                    id = dizi.Id,
                    adi = dizi.Adi,
                    aciklama = dizi.Aciklama,
                    baslamaTarihi = dizi.BaslamaTarihi.HasValue ? dizi.BaslamaTarihi.Value.ToString("dd.MM.yyyy") : "-",
                    bitisTarihi = dizi.BitisTarihi.HasValue ? dizi.BitisTarihi.Value.ToString("dd.MM.yyyy") : "-",
                    dilAdi = dizi.Diller?.DilAdi ?? "-",
                    turler = dizi.DiziTurs?.Where(x => x.Aktif == true).Select(x => x.Tur?.TurAdi).Where(x => x != null).ToList() ?? new List<string>(),
                    platformAdi = dizi.Platform?.PlatformAdi ?? "-",
                    thumbnail = dizi.DiziAfis?
                        .Where(x => x.Aktif == true && x.DosyaTipi?.ToLower() == "thumbnail")
                        .Select(x => x.DosyaYolu)
                        .FirstOrDefault() ?? "/adminassets/images/avatars/01.png",
                    poster = dizi.DiziAfis?
                        .Where(x => x.Aktif == true && x.DosyaTipi?.ToLower() == "poster")
                        .Select(x => x.DosyaYolu)
                        .FirstOrDefault() ?? "/adminassets/images/avatars/01.png",
                    sezonSayisi = dizi.Sezons?.Count(x => x.Aktif == true) ?? 0,
                    bolumSayisi = dizi.Sezons?
                        .Where(x => x.Aktif == true)
                        .SelectMany(x => x.Bolums)
                        .Count(x => x.Aktif == true) ?? 0,
                    aktif = dizi.Aktif
                }).ToList();

                return Json(new { data = result });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult DiziEkle(IFormCollection data)
        {
            try
            {
                Dizi dizi = new Dizi();
                dizi.Adi = data["adi"];
                dizi.Aciklama = data["aciklama"];

                // Başlama tarihi kontrolü
                if (!string.IsNullOrEmpty(data["baslamatarihi"]) && data["baslamatarihi"] != "undefined")
                {
                    dizi.BaslamaTarihi = Convert.ToDateTime(data["baslamatarihi"]);
                }

                // Bitiş tarihi kontrolü
                if (!string.IsNullOrEmpty(data["bitistarihi"]) && data["bitistarihi"] != "undefined")
                {
                    dizi.BitisTarihi = Convert.ToDateTime(data["bitistarihi"]);
                }

                // Dil ID kontrolü
                if (!string.IsNullOrEmpty(data["dil"]) && data["dil"] != "undefined" && data["dil"] != "0")
                {
                    dizi.DilId = Convert.ToInt32(data["dil"]);
                }

                // Platform ID kontrolü
                if (!string.IsNullOrEmpty(data["platform"]) && data["platform"] != "undefined" && data["platform"] != "0")
                {
                    dizi.PlatformId = Convert.ToInt32(data["platform"]);
                }
                
                // Önce diziyi veritabanına ekle
                dizi = _diziBs.Insert(dizi);
                
                // İlişkili nesneleri ekle
                if (!string.IsNullOrEmpty(data["yonetmen"]) && data["yonetmen"] != "undefined" && data["yonetmen"] != "0")
                {
                    YonetmenDizi yonetmenDizi = new YonetmenDizi
                    {
                        YonetmenId = Convert.ToInt32(data["yonetmen"]),
                        DiziId = dizi.Id
                    };
                    _yonetmenDiziBs.Insert(yonetmenDizi);
                }
                
                if (!string.IsNullOrEmpty(data["tur"]) && data["tur"] != "undefined" && data["tur"] != "0")
                {
                    DiziTur diziTur = new DiziTur
                    {
                        TurId = Convert.ToInt32(data["tur"]),
                        DiziId = dizi.Id
                    };
                    _diziBs.Update(dizi);
                }
                
                if (!string.IsNullOrEmpty(data["oyuncu"]) && data["oyuncu"] != "undefined" && data["oyuncu"] != "0")
                {
                    DiziOyuncu diziOyuncu = new DiziOyuncu
                    {
                        OyuncuId = Convert.ToInt32(data["oyuncu"]),
                        DiziId = dizi.Id
                    };
                    _diziOyuncuBs.Insert(diziOyuncu);
                }

                if (data.Files != null && data.Files.Count > 0)
                {
                    IFormFile file = data.Files[0];
                    if (file != null && file.Length > 0)
                    {
                        if (!file.ContentType.Contains("image/"))
                        {
                            return Json(new { result = false, mesaj = "Lütfen Resim Seçiniz" });
                        }
                        if (file.Length > 10485760) // 10MB dan büyük ise   Byte cinsinden 
                        {
                            return Json(new { result = false, mesaj = "10MB dan büyük olamaz" });
                        }
                        string extension = Path.GetExtension(file.FileName);
                        string newFileName = DateTime.Now.Ticks.ToString() + extension;

                        string uploadpath = Directory.GetCurrentDirectory() + "/wwwroot/images/dizi/" + newFileName;
                        using (FileStream fs = new FileStream(uploadpath, FileMode.Create))
                        {
                            file.CopyTo(fs);
                            
                            DiziAfi diziAfi = new DiziAfi
                            {
                                DiziId = dizi.Id,
                                DosyaYolu = "/images/dizi/" + newFileName,
                                DosyaTipi = "image"
                            };
                            
                            _diziAfiBs.Insert(diziAfi);
                        }
                    }
                }
                
                return Json(new { result = true, mesaj = "Dizi başarıyla eklendi" });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, mesaj = "İşlem sırasında bir hata oluştu: " + ex.Message });
            }
        }

        [HttpPost]
        public IActionResult DiziDuzenle()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult AktifPasif(int id, bool aktif)
        {
            try
            {
                // Tüm dizileri çek, sonra id'ye göre filtrele
                Dizi dizi = _diziBs.GetAll().FirstOrDefault(x => x.Id == id);

                if (dizi == null)
                    return Json(new { result = false, mesaj = "Dizi bulunamadı" });

                dizi.Aktif = aktif;
                _diziBs.Update(dizi);

                return Json(new { result = true, mesaj = "Aktiflik durumu başarıyla güncellendi" });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, mesaj = "İşlem sırasında bir hata oluştu: " + ex.Message });
            }
        }

        [HttpPost]
        public IActionResult GetDiller()
        {
           List <Diller> diller = _dilBs.GetAll();
            return Json(new { data = diller });
        }
        public IActionResult Getplatformlar()
        {
            List<Platform> platformlar = _platformBs.GetAll();
            return Json(new { data = platformlar });
        }
        public IActionResult GetTurler()
        {
            List<Turler> turler = _turBs.GetAll();
            return Json(new { data = turler });
        }
        public IActionResult GetYonetmenler()
        {
            List<Yonetmen> yonetmenler = _yonetmenBs.GetAll();
            return Json(new { data = yonetmenler });
        }
        public IActionResult GetOyuncular()
        {
            List<Oyuncu> oyuncu=_oyuncuBs.GetAll();
            return Json(new { data = oyuncu });
        }

        public IActionResult GetDizi()
        {
            List<Dizi> diziler = _diziBs.GetAll();
            return Json(new { data = diziler });
        }

        [HttpGet]
        public IActionResult GetDiziById(int id)
        {
            try
            {
                var dizi = _diziBs.GetById(id);
                if (dizi == null)
                    return Json(new { result = false, mesaj = "Dizi bulunamadı" });

                var result = new
                {
                    id = dizi.Id,
                    adi = dizi.Adi,
                    aciklama = dizi.Aciklama,
                    baslamaTarihi = dizi.BaslamaTarihi.HasValue ? dizi.BaslamaTarihi.Value.ToString("yyyy-MM-dd") : "",
                    bitisTarihi = dizi.BitisTarihi.HasValue ? dizi.BitisTarihi.Value.ToString("yyyy-MM-dd") : "",
                    sezonSayisi = dizi.Sezons?.Count(x => x.Aktif == true) ?? 0,
                    bolumSayisi = dizi.Sezons?
                        .Where(x => x.Aktif == true)
                        .SelectMany(x => x.Bolums)
                        .Count(x => x.Aktif == true) ?? 0,
                    dilId = dizi.DilId,
                    platformId = dizi.PlatformId,
                    yonetmenler = dizi.YonetmenDizis?.Where(x => x.Aktif == true).Select(x => x.YonetmenId).ToList() ?? new List<int>(),
                    oyuncular = dizi.DiziOyuncus?.Where(x => x.Aktif == true).Select(x => x.OyuncuId).ToList() ?? new List<int>()
                };

                return Json(new { result = true, data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, mesaj = "İşlem sırasında bir hata oluştu: " + ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> SearchTMDB(string query)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var apiKey = _configuration.GetSection("TMDBSettings:ApiKey").Value;
                    var baseUrl = _configuration.GetSection("TMDBSettings:BaseUrl").Value;
                    
                    client.BaseAddress = new Uri(baseUrl);
                    
                    var response = await client.GetAsync($"search/tv?api_key={apiKey}&query={Uri.EscapeDataString(query)}&language=tr-TR");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var jsonContent = JsonSerializer.Deserialize<JsonDocument>(content);
                        var results = jsonContent.RootElement.GetProperty("results").EnumerateArray()
                            .Take(6)
                            .Select(item => new
                            {
                                id = item.GetProperty("id").GetInt32(),
                                name = item.TryGetProperty("name", out var name) ? name.GetString() : "Başlıksız",
                                first_air_date = item.TryGetProperty("first_air_date", out var date) ? date.GetString() : "Tarih belirtilmemiş",
                                overview = item.TryGetProperty("overview", out var overview) ? overview.GetString() : "Açıklama bulunmuyor",
                                poster_path = item.TryGetProperty("poster_path", out var poster) ? 
                                    $"https://image.tmdb.org/t/p/w500{poster.GetString()}" : "/adminassets/images/avatars/01.png"
                            })
                            .ToList();
                        
                        return Json(new { result = true, data = results });
                    }
                    return Json(new { result = false, message = "TMDB API'den veri alınamadı." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = "TMDB araması sırasında bir hata oluştu: " + ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTMDBDetails(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var apiKey = _configuration.GetSection("TMDBSettings:ApiKey").Value;
                    var baseUrl = _configuration.GetSection("TMDBSettings:BaseUrl").Value;
                    
                    client.BaseAddress = new Uri(baseUrl);
                    
                    var response = await client.GetAsync($"tv/{id}?api_key={apiKey}&language=tr-TR");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var jsonContent = JsonSerializer.Deserialize<JsonDocument>(content);
                        var root = jsonContent.RootElement;

                        var result = new
                        {
                            id = root.GetProperty("id").GetInt32(),
                            name = root.TryGetProperty("name", out var name) ? name.GetString() : "Başlıksız",
                            overview = root.TryGetProperty("overview", out var overview) ? overview.GetString() : "Açıklama bulunmuyor",
                            first_air_date = root.TryGetProperty("first_air_date", out var firstAirDate) ? firstAirDate.GetString() : "Tarih belirtilmemiş",
                            last_air_date = root.TryGetProperty("last_air_date", out var lastAirDate) ? lastAirDate.GetString() : "Tarih belirtilmemiş",
                            number_of_seasons = root.TryGetProperty("number_of_seasons", out var seasons) ? seasons.GetInt32() : 0,
                            number_of_episodes = root.TryGetProperty("number_of_episodes", out var episodes) ? episodes.GetInt32() : 0,
                            poster_path = root.TryGetProperty("poster_path", out var poster) ? 
                                $"https://image.tmdb.org/t/p/w500{poster.GetString()}" : "/adminassets/images/avatars/01.png"
                        };

                        return Json(new { result = true, data = result });
                    }
                    return Json(new { result = false, message = "TMDB API'den dizi detayları alınamadı." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = "Dizi detayları alınırken bir hata oluştu: " + ex.Message });
            }
        }
    }
}

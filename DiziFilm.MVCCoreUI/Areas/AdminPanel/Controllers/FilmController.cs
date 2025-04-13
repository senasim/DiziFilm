using DiziFilm.Business.Abstract;
using DiziFilm.Model.Entity;
using DiziFilm.Model.ViewModel.Areas.AdminPanel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace DiziFilm.MVCCoreUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class FilmController : Controller
    {
        private readonly IFilmBs _filmBs;
        private readonly IOyuncuBs _oyuncuBs;
        private readonly IPlatformBs _platformBs;
        private readonly ITurlerBs _turlerBs;
        private readonly IYonetmenBs _yonetmenBs;
        private readonly IDillerBs _dillerBs;
        private readonly IFilmOyuncuBs _filmOyuncuBs;
        private readonly IYonetmenFilmBs _yonetmenFilmBs;
        private readonly IFilmPlatformBs _filmPlatformBs;
        private readonly IFilmTurBs _filmTurBs;
        private readonly IFilmAfiBs _filmAfiBs;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public FilmController(
            IFilmBs filmBs,
            IOyuncuBs oyuncuBs,
            IPlatformBs platformBs,
            ITurlerBs turlerBs,
            IYonetmenBs yonetmenBs,
            IDillerBs dillerBs,
            IFilmOyuncuBs filmOyuncuBs,
            IYonetmenFilmBs yonetmenFilmBs,
            IFilmPlatformBs filmPlatformBs,
            IFilmTurBs filmTurBs,
            IFilmAfiBs filmAfiBs,
            IWebHostEnvironment hostingEnvironment)
        {
            _filmBs = filmBs;
            _oyuncuBs = oyuncuBs;
            _platformBs = platformBs;
            _turlerBs = turlerBs;
            _yonetmenBs = yonetmenBs;
            _dillerBs = dillerBs;
            _filmOyuncuBs = filmOyuncuBs;
            _yonetmenFilmBs = yonetmenFilmBs;
            _filmPlatformBs = filmPlatformBs;
            _filmTurBs = filmTurBs;
            _filmAfiBs = filmAfiBs;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            FilmIndexViewModel model = new FilmIndexViewModel();
            List<Film> filmler = _filmBs.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            FilmAddViewModel model = new FilmAddViewModel();
            
            // Dilleri yükle
            model.Diller = _dillerBs.GetAll()
                .Select(x => new SelectListItem
                {
                    Text = x.DilAdi,
                    Value = x.Id.ToString()
                })
                .ToList();
            
            // Platformları yükle
            model.Platformlar = _platformBs.GetAll()
                .Select(x => new SelectListItem
                {
                    Text = x.PlatformAdi,
                    Value = x.Id.ToString()
                })
                .ToList();
            
            // Türleri yükle
            model.Turler = _turlerBs.GetAll()
                .Select(x => new SelectListItem
                {
                    Text = x.TurAdi,
                    Value = x.Id.ToString()
                })
                .ToList();
            
            // Yönetmenleri yükle
            model.Yonetmenler = _yonetmenBs.GetAll()
                .Select(x => new SelectListItem
                {
                    Text = x.Adi + " " + x.Soyadi,
                    Value = x.Id.ToString()
                })
                .ToList();
            
            // Oyuncuları yükle
            model.Oyuncular = _oyuncuBs.GetAll()
                .Select(x => new SelectListItem
                {
                    Text = x.Adi + " " + x.Soyadi,
                    Value = x.Id.ToString()
                })
                .ToList();
            
            return View(model);
        }

        [HttpPost]
        public IActionResult List()
        {
            try
            {
                List<Film> filmler = _filmBs.GetAll(
                    x => x.Aktif == true,
                    x => x.Adi,
                    Infrastructure.Enumarations.Sorted.ASC,
                    false,
                    "FilmTurs", "FilmTurs.Tur", "FilmPlatforms", "FilmPlatforms.Platform", "Dil", "FilmAfis"
                );

                var result = filmler.Select(film => new {
                    id = film.Id,
                    adi = film.Adi,
                    aciklama = film.Aciklama,
                    sure = film.Sure.HasValue ? $"{film.Sure} dk" : "-",
                    cikisTarihi = film.CikisTarihi.HasValue ? film.CikisTarihi.Value.ToString("dd.MM.yyyy") : "-",
                    dilAdi = film.Dil?.DilAdi ?? "-",
                    turler = film.FilmTurs?.Where(x => x.Aktif == true).Select(x => x.Tur?.TurAdi).Where(x => x != null).ToList() ?? new List<string>(),
                    platformlar = film.FilmPlatforms?
                        .Where(x => x.Aktif == true)
                        .Select(x => x.Platform?.PlatformAdi)
                        .Where(x => x != null)
                        .ToList() ?? new List<string>(),
                    thumbnail = film.FilmAfis?
                        .Where(x => x.Aktif == true && x.DosyaTipi?.ToLower() == "thumbnail")
                        .Select(x => x.DosyaYolu)
                        .FirstOrDefault() ?? "/images/noimage.png",
                    poster = film.FilmAfis?
                        .Where(x => x.Aktif == true && x.DosyaTipi?.ToLower() == "poster")
                        .Select(x => x.DosyaYolu)
                        .FirstOrDefault() ?? "/images/noimage.png",
                    aktif = film.Aktif
                }).ToList();

                return Json(new { data = result });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Add(IFormCollection data)
        {
            try
            {
                Film film = new Film();
                film.Adi = data["Adi"];
                film.Aciklama = data["Aciklama"];
                film.CikisTarihi = Convert.ToDateTime(data["CikisTarihi"]);
                film.Sure = Convert.ToInt32(data["Sure"]);
                film.DilId = Convert.ToInt32(data["DilId"]);
                film.Aktif = true;
                film.OlusturulmaTarihi = DateTime.Now;
                
               
                film = _filmBs.Insert(film);
                
                // Türleri ekle
                if (!string.IsNullOrEmpty(data["FilmTurs"]))
                {
                    var turIds = data["FilmTurs"].ToString().Split(',').Select(int.Parse).ToList();
                    foreach (var turId in turIds)
                    {
                        _filmTurBs.Insert(new FilmTur
                        {
                            FilmId = film.Id,
                            TurId = turId,
                            Aktif = true,
                            OlusturulmaTarihi = DateTime.Now
                        });
                    }
                }
                
                // Oyuncuları ekle
                if (!string.IsNullOrEmpty(data["Oyuncular"]))
                {
                    var oyuncular = JsonSerializer.Deserialize<List<dynamic>>(data["Oyuncular"]);
                    foreach (var oyuncu in oyuncular)
                    {
                        var filmOyuncu = new FilmOyuncu
                        {
                            OyuncuId = Convert.ToInt32(oyuncu.oyuncuId),
                            FilmId = film.Id,
                            Rol = oyuncu.rol.ToString(),
                            Aktif = true,
                            OlusturulmaTarihi = DateTime.Now
                        };
                        _filmOyuncuBs.Insert(filmOyuncu);
                    }
                }
                
                // Yönetmenleri ekle
                if (!string.IsNullOrEmpty(data["Yonetmenler"]))
                {
                    var yonetmenler = JsonSerializer.Deserialize<List<int>>(data["Yonetmenler"]);
                    foreach (var yonetmenId in yonetmenler)
                    {
                        var yonetmenFilm = new YonetmenFilm
                        {
                            YonetmenId = yonetmenId,
                            FilmId = film.Id,
                            Aktif = true,
                            OlusturulmaTarihi = DateTime.Now
                        };
                        _yonetmenFilmBs.Insert(yonetmenFilm);
                    }
                }
                
                // Platformları ekle
                if (!string.IsNullOrEmpty(data["Platformlar"]))
                {
                    var platformlar = JsonSerializer.Deserialize<List<int>>(data["Platformlar"]);
                    foreach (var platformId in platformlar)
                    {
                        var filmPlatform = new FilmPlatform
                        {
                            PlatformId = platformId,
                            FilmId = film.Id,
                            Aktif = true,
                            OlusturulmaTarihi = DateTime.Now
                        };
                        _filmPlatformBs.Insert(filmPlatform);
                    }
                }

                // Afişleri ekle
                if (data.Files.Count > 0)
                {
                    string uploadDir = Path.Combine(_hostingEnvironment.WebRootPath, "images", "film");
                    if (!Directory.Exists(uploadDir))
                    {
                        Directory.CreateDirectory(uploadDir);
                    }

                    foreach (var file in data.Files)
                    {
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
                            string fileType = file.Name.ToLower(); // "Thumbnail" veya "Poster"
                            
                            string uploadpath = Path.Combine(uploadDir, newFileName);
                            using (FileStream fs = new FileStream(uploadpath, FileMode.Create))
                            {
                                file.CopyTo(fs);
                                
                                var filmAfi = new FilmAfi
                                {
                                    FilmId = film.Id,
                                    DosyaYolu = "/images/film/" + newFileName,
                                    DosyaTipi = fileType,
                                    Aktif = true,
                                    OlusturulmaTarihi = DateTime.Now
                                };
                                _filmAfiBs.Insert(filmAfi);
                            }
                        }
                    }
                }
                
                return Json(new { result = true, mesaj = "Film başarıyla eklendi" });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, mesaj = "İşlem sırasında bir hata oluştu: " + ex.Message });
            }
        }

        [HttpPost]
        public IActionResult GetFilm(int id)
        {
            try
            {
                Film film = _filmBs.GetById(id, false, "FilmTurs", "FilmPlatforms", "FilmAfis", "FilmOyuncus", "YonetmenFilms", "Dil");
                return Json(new { result = true, model = film });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                Film film = _filmBs.GetById(id, false, "FilmTurs", "FilmPlatforms", "FilmAfis", "FilmOyuncus", "FilmOyuncus.Oyuncu", "YonetmenFilms", "YonetmenFilms.Yonetmen", "FilmPlatforms.Platform");

                if (film == null)
                {
                    return RedirectToAction("Index");
                }

                FilmEditViewModel model = new FilmEditViewModel
                {
                    Id = film.Id,
                    Adi = film.Adi,
                    Aciklama = film.Aciklama,
                    Sure = film.Sure ?? 0,
                    DilId = film.DilId ?? 0,
                    CikisTarihi = film.CikisTarihi,


                    Diller = _dillerBs.GetAll(x => x.Aktif == true).Select(x => new SelectListItem
                    {
                        Text = x.DilAdi,
                        Value = x.Id.ToString()
                    }).ToList(),

                    Oyuncular = _oyuncuBs.GetAll().Select(x => new SelectListItem
                    {
                        Text = x.Adi + " " + x.Soyadi,
                        Value = x.Id.ToString()
                    }).ToList(),

                    Yonetmenler = _yonetmenBs.GetAll().Select(x => new SelectListItem
                    {
                        Text = x.Adi + " " + x.Soyadi,
                        Value = x.Id.ToString()
                    }).ToList(),

                };
                model.Turler = _turlerBs.GetAll(x => x.Aktif == true).Select(x => new SelectListItem
                {
                    Text = x.TurAdi,
                    Value = x.Id.ToString()
                }).ToList();

                model.FilmTurs=film.FilmTurs
                    .Where(x => x.Aktif == true)
                    .Select(x => x.TurId)
                    .ToList();

                model.Platformlar = _platformBs.GetAll(x => x.Aktif == true).Select(x => new SelectListItem
                {
                    Text = x.PlatformAdi,
                    Value = x.Id.ToString()
                }).ToList();


                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        
        [HttpPost]
        public IActionResult Edit(IFormCollection data)
        {
            try
            {
                int id = Convert.ToInt32(data["FilmId"]);
                Film film = _filmBs.GetById(id, false, "FilmTurs", "FilmPlatforms", "FilmAfis", "FilmOyuncus", "YonetmenFilms");

                if (film == null)
                {
                    return Json(new { result = false, message = "Film bulunamadı!" });
                }

                film.Adi = data["Adi"];
                film.Aciklama = data["Aciklama"];

                if (!string.IsNullOrEmpty(data["Sure"]))
                {
                    film.Sure = Convert.ToInt32(data["Sure"]);
                }

                if (!string.IsNullOrEmpty(data["DilId"]))
                {
                    film.DilId = Convert.ToInt32(data["DilId"]);
                }

                if (!string.IsNullOrEmpty(data["CikisTarihi"]))
                {
                    film.CikisTarihi = DateTime.Parse(data["CikisTarihi"]);
                }

                film.DegistirilmeTarihi = DateTime.Now;

                // Dosya işlemleri
                if (data.Files.Count > 0)
                {
                    foreach (var file in data.Files)
                    {
                        if (file != null && file.Length > 0)
                        {
                            if (!file.ContentType.Contains("image/"))
                            {
                                return Json(new { result = false, message = "Lütfen resim formatında dosya yükleyin." });
                            }

                            if (file.Length > 10485760) // 10MB
                            {
                                return Json(new { result = false, message = "Dosya boyutu 10MB'dan büyük olamaz." });
                            }

                            string extension = Path.GetExtension(file.FileName);
                            string newFileName = DateTime.Now.Ticks.ToString() + extension;
                            string fileType = "";
                            string uploadPath = "";

                            if (file.Name == "Thumbnail")
                            {
                                fileType = "thumbnail";
                                uploadPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", "thumbnails", newFileName);
                            }
                            else if (file.Name == "Poster")
                            {
                                fileType = "poster";
                                uploadPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", "afisler", newFileName);
                            }

                            if (!string.IsNullOrEmpty(fileType))
                            {
                                Directory.CreateDirectory(Path.GetDirectoryName(uploadPath));

                                using (FileStream fs = new FileStream(uploadPath, FileMode.Create))
                                {
                                    file.CopyTo(fs);
                                }

                                // Mevcut afiş varsa güncelle, yoksa yeni ekle
                                var filmAfis = film.FilmAfis.FirstOrDefault(x => x.DosyaTipi == fileType && x.Aktif == true);
                                if (filmAfis != null)
                                {
                                    filmAfis.DosyaYolu = newFileName;
                                    filmAfis.DegistirilmeTarihi = DateTime.Now;
                                    _filmAfiBs.Update(filmAfis);
                                }
                                else
                                {
                                    _filmAfiBs.Insert(new FilmAfi
                                    {
                                        FilmId = film.Id,
                                        DosyaYolu = newFileName,
                                        DosyaTipi = fileType,
                                        Aktif = true,
                                        OlusturulmaTarihi = DateTime.Now
                                    });
                                }
                            }
                        }
                    }
                }

              
                if (data["SelectedTurIds[]"].Count > 0)
                {
                    
                    foreach (var turId in data["SelectedTurIds[]"])
                    {
                        int turIdInt = Convert.ToInt32(turId);

                        // Eğer bu tür zaten varsa aktifleştir
                        var existingTur = film.FilmTurs.FirstOrDefault(x => x.TurId == turIdInt);
                        if (existingTur != null)
                        {
                            existingTur.Aktif = true;
                            existingTur.DegistirilmeTarihi = DateTime.Now;
                            _filmTurBs.Update(existingTur);
                        }
                        else
                        {
                            // Yoksa yeni ekle
                            _filmTurBs.Insert(new FilmTur
                            {
                                FilmId = film.Id,
                                TurId = turIdInt,
                                Aktif = true,
                                OlusturulmaTarihi = DateTime.Now
                            });
                        }
                    }
                }

                _filmBs.Update(film);

                return Json(new { result = true, message = "Film başarıyla güncellendi." });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = "Film güncellenirken bir hata oluştu: " + ex.Message });
            }
        }

        [HttpPost]
        public IActionResult AktifPasif(int id, bool aktif)
        {
            try
            {
                Film film = _filmBs.GetById(id);
                film.Aktif = aktif;
                film.DegistirilmeTarihi = DateTime.Now;
                _filmBs.Update(film);

                return Json(new { result = true, mesaj = "Aktiflik durumu başarıyla güncellendi" });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, mesaj = "İşlem sırasında bir hata oluştu: " + ex.Message });
            }
        }

        // OYUNCU İŞLEMLERİ
        [HttpPost]
        public IActionResult SaveOyuncu(int id, int filmId, int oyuncuId, string rol)
        {
            try
            {
                if (string.IsNullOrEmpty(rol) || oyuncuId <= 0 || filmId <= 0)
                {
                    return Json(new { result = false, message = "Geçersiz veriler!" });
                }

                if (id == 0)
                {
                    // Yeni kayıt
                    FilmOyuncu filmOyuncu = new FilmOyuncu
                    {
                        OyuncuId = oyuncuId,
                        FilmId = filmId,
                        Rol = rol,
                        Aktif = true,
                        OlusturulmaTarihi = DateTime.Now
                    };

                    var newOyuncu = _filmOyuncuBs.Insert(filmOyuncu);
                    var oyuncu = _oyuncuBs.GetById(oyuncuId);

                    return Json(new
                    {
                        result = true,
                        id = newOyuncu.Id,
                        oyuncuAdi = oyuncu != null ? $"{oyuncu.Adi} {oyuncu.Soyadi}" : ""
                    });
                }
                else
                {
                    // Güncelleme
                    var filmOyuncu = _filmOyuncuBs.GetById(id);
                    if (filmOyuncu == null)
                    {
                        return Json(new { result = false, message = "Oyuncu bulunamadı!" });
                    }

                    filmOyuncu.OyuncuId = oyuncuId;
                    filmOyuncu.Rol = rol;
                    filmOyuncu.DegistirilmeTarihi = DateTime.Now;

                    _filmOyuncuBs.Update(filmOyuncu);
                    var oyuncu = _oyuncuBs.GetById(oyuncuId);

                    return Json(new
                    {
                        result = true,
                        id = filmOyuncu.Id,
                        oyuncuAdi = oyuncu != null ? $"{oyuncu.Adi} {oyuncu.Soyadi}" : ""
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult DeleteOyuncu(int id)
        {
            try
            {
                var filmOyuncu = _filmOyuncuBs.GetById(id);
                if (filmOyuncu == null)
                {
                    return Json(new { result = false, message = "Oyuncu bulunamadı!" });
                }

                filmOyuncu.Aktif = false;
                filmOyuncu.DegistirilmeTarihi = DateTime.Now;
                _filmOyuncuBs.Update(filmOyuncu);

                return Json(new { result = true });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message });
            }
        }

        // YÖNETMEN İŞLEMLERİ
        [HttpPost]
        public IActionResult SaveYonetmen(int id, int filmId, int yonetmenId)
        {
            try
            {
                if (yonetmenId <= 0 || filmId <= 0)
                {
                    return Json(new { result = false, message = "Geçersiz veriler!" });
                }

                if (id == 0)
                {
                    // Yeni kayıt
                    YonetmenFilm yonetmenFilm = new YonetmenFilm
                    {
                        YonetmenId = yonetmenId,
                        FilmId = filmId,
                        Aktif = true,
                        OlusturulmaTarihi = DateTime.Now
                    };

                    var newYonetmen = _yonetmenFilmBs.Insert(yonetmenFilm);
                    var yonetmen = _yonetmenBs.GetById(yonetmenId);

                    return Json(new
                    {
                        result = true,
                        id = newYonetmen.Id,
                        yonetmenAdi = yonetmen != null ? $"{yonetmen.Adi} {yonetmen.Soyadi}" : ""
                    });
                }
                else
                {
                    // Güncelleme
                    var yonetmenFilm = _yonetmenFilmBs.GetById(id);
                    if (yonetmenFilm == null)
                    {
                        return Json(new { result = false, message = "Yönetmen bulunamadı!" });
                    }

                    yonetmenFilm.YonetmenId = yonetmenId;
                    yonetmenFilm.DegistirilmeTarihi = DateTime.Now;

                    _yonetmenFilmBs.Update(yonetmenFilm);
                    var yonetmen = _yonetmenBs.GetById(yonetmenId);

                    return Json(new
                    {
                        result = true,
                        id = yonetmenFilm.Id,
                        yonetmenAdi = yonetmen != null ? $"{yonetmen.Adi} {yonetmen.Soyadi}" : ""
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult DeleteYonetmen(int id)
        {
            try
            {
                var yonetmenFilm = _yonetmenFilmBs.GetById(id);
                if (yonetmenFilm == null)
                {
                    return Json(new { result = false, message = "Yönetmen bulunamadı!" });
                }

                yonetmenFilm.Aktif = false;
                yonetmenFilm.DegistirilmeTarihi = DateTime.Now;
                _yonetmenFilmBs.Update(yonetmenFilm);

                return Json(new { result = true });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message });
            }
        }

        // PLATFORM İŞLEMLERİ
        [HttpPost]
        public IActionResult SavePlatforms(int filmId, string platformIds)
        {
            try
            {
                if (filmId <= 0 || string.IsNullOrEmpty(platformIds))
                {
                    return Json(new { result = false, message = "Geçersiz veriler!" });
                }

                // Mevcut platformları pasif yap
                var mevcutPlatformlar = _filmPlatformBs.GetAll(x => x.FilmId == filmId);
                foreach (var platform in mevcutPlatformlar)
                {
                    platform.Aktif = false;
                    platform.DegistirilmeTarihi = DateTime.Now;
                    _filmPlatformBs.Update(platform);
                }

                // Yeni platformları ekle
                var seciliPlatformlar = JsonSerializer.Deserialize<List<int>>(platformIds);
                var eklenenPlatformlar = new List<object>();

                if (seciliPlatformlar != null && seciliPlatformlar.Any())
                {
                    foreach (var platformId in seciliPlatformlar)
                    {
                        // Mevcut platformu kontrol et, varsa aktifleştir
                        var mevcutPlatform = mevcutPlatformlar.FirstOrDefault(x => x.PlatformId == platformId);
                        if (mevcutPlatform != null)
                        {
                            mevcutPlatform.Aktif = true;
                            mevcutPlatform.DegistirilmeTarihi = DateTime.Now;
                            _filmPlatformBs.Update(mevcutPlatform);

                            var platform = _platformBs.GetById(platformId);
                            eklenenPlatformlar.Add(new
                            {
                                id = mevcutPlatform.Id,
                                platformId = platformId,
                                platformAdi = platform?.PlatformAdi
                            });
                        }
                        else
                        {
                            // Yeni platform ekle
                            FilmPlatform filmPlatform = new FilmPlatform
                            {
                                PlatformId = platformId,
                                FilmId = filmId,
                                Aktif = true,
                                OlusturulmaTarihi = DateTime.Now
                            };

                            var yeniPlatform = _filmPlatformBs.Insert(filmPlatform);
                            var platform = _platformBs.GetById(platformId);

                            eklenenPlatformlar.Add(new
                            {
                                id = yeniPlatform.Id,
                                platformId = platformId,
                                platformAdi = platform?.PlatformAdi
                            });
                        }
                    }
                }

                return Json(new { result = true, data = eklenenPlatformlar });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult DeletePlatform(int id)
        {
            try
            {
                var filmPlatform = _filmPlatformBs.GetById(id);
                if (filmPlatform == null)
                {
                    return Json(new { result = false, message = "Platform bulunamadı!" });
                }

                filmPlatform.Aktif = false;
                filmPlatform.DegistirilmeTarihi = DateTime.Now;
                _filmPlatformBs.Update(filmPlatform);

                return Json(new { result = true });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult GetFilmPlatforms(int filmId)
        {
            try
            {
                var platforms = _filmPlatformBs.GetAll(
                    x => x.FilmId == filmId && x.Aktif == true,
                    null,
                    Infrastructure.Enumarations.Sorted.ASC,
                    false,
                    "Platform"
                );

                var result = platforms.Select(p => new
                {
                    id = p.Id,
                    platformId = p.PlatformId,
                    platformAdi = p.Platform?.PlatformAdi
                }).ToList();

                return Json(new { result = true, data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message });
            }
        }
    }
}
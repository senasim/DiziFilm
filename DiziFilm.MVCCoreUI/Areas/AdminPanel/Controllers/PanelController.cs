using DiziFilm.MVCCoreUI.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace DiziFilm.MVCCoreUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [YoneticiFilter]
    public class PanelController : Controller
    {
        IMemoryCache _memoryCache;
        public PanelController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

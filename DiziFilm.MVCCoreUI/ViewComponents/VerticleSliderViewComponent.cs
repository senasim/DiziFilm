using Microsoft.AspNetCore.Mvc;

namespace DiziFilm.MVCCoreUI.ViewComponents
{
    public class VerticleSliderViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

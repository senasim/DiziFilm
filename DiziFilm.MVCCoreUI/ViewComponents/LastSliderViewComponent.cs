using Microsoft.AspNetCore.Mvc;

namespace DiziFilm.MVCCoreUI.ViewComponents
{
    public class LastSliderViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

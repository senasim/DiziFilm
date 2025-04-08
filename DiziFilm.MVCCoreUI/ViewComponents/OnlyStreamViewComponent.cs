using Microsoft.AspNetCore.Mvc;

namespace DiziFilm.MVCCoreUI.ViewComponents
{
    public class OnlyStreamViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

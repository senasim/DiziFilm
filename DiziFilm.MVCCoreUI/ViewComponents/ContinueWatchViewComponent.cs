using Microsoft.AspNetCore.Mvc;

namespace DiziFilm.MVCCoreUI.ViewComponents
{
    public class ContinueWatchViewComponent:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

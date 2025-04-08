using Microsoft.AspNetCore.Mvc;

namespace DiziFilm.MVCCoreUI.ViewComponents
{
    public class footerViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

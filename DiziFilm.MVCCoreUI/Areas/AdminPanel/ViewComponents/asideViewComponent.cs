using Microsoft.AspNetCore.Mvc;

namespace DiziFilm.MVCCoreUI.Areas.AdminPanel.ViewComponents
{
    public class asideViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

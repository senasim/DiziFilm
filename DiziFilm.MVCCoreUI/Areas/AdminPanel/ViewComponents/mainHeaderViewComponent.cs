using Microsoft.AspNetCore.Mvc;

namespace DiziFilm.MVCCoreUI.Areas.AdminPanel.ViewComponents
{
    public class mainHeaderViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

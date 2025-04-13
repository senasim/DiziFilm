using DiziFilm.Business.Abstract;
using DiziFilm.Model.Entity;
using DiziFilm.Model.ViewModel.Areas.AdminPanel;
using DiziFilm.MVCCoreUI.Filters;
using Infrastructure.Enumarations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace DiziFilm.MVCCoreUI.Areas.AdminPanel.ViewComponents
{
    public class sidebarViewComponent:ViewComponent
    {

        IMenuBs _menuBs;
        ISessionManager _session;
        IKullanicilarBs _kullaniciBs;
        IMemoryCache _cache;
        public sidebarViewComponent(IMenuBs menuBs,ISessionManager session,IKullanicilarBs kullaniciBs,IMemoryCache cache)
        {
            _menuBs = menuBs;
            _session = session;
            _kullaniciBs = kullaniciBs;
            _cache = cache;
        }
        public IViewComponentResult Invoke()
        {
            List<Menu> menu = new List<Menu>();
          menu= _menuBs.GetAll(filter: x => x.Aktif == true, orderby: x => x.Sira, sorted:Sorted.ASC, Tracking: false, "YetkiRols", "YetkiRols.Rol", "YetkiRols.Rol.KullaniciRols", "YetkiRols.Rol.KullaniciRols.Kullanici");

            SidebarViewModel model = new SidebarViewModel();
            model.menuler = menu;
            return View(model);
        }
    }
}

using DiziFilm.Model.Entity;
using DiziFilm.Model.Statics;
using DiziFilm.MVCCoreUI.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace DiziFilm.MVCCoreUI.Filters
{
    public class RolFilter: ActionFilterAttribute
    {
        private string[] _allowedRols;

        public RolFilter(params string[] allowedRols)
        {
            _allowedRols = allowedRols;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Kullanicilar kullanici = context.HttpContext.Session.GetObject<Kullanicilar>(SessionKeys.AktifYonetici);

            bool allowed=false;

            foreach (KullaniciRol rol in kullanici.KullaniciRols)
            {
                foreach (string  item in _allowedRols)
                {
                    if (rol.Rol.RolAdi ==item)
                    {
                        allowed = true;
                        break;
                    }
                }

            }

            if (!allowed)
            {
                context.Result = new RedirectResult("/AdminPanel/Yonetici/AccessDenied");
            }

            base.OnActionExecuting(context);
        }
    }
}

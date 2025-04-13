using DiziFilm.Model.Entity;
using DiziFilm.MVCCoreUI.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DiziFilm.MVCCoreUI.Filters
{
    public class KullaniciFilter:ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Kullanicilar kullanici = context.HttpContext.Session.GetObject<Kullanicilar>("AktifKullanici");


            if (kullanici == null)
            {
                context.Result = new RedirectResult("/Kullanici/Login");
            }
            base.OnActionExecuting(context);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}

using DiziFilm.Model.Entity;
using DiziFilm.Model.Statics;
using DiziFilm.MVCCoreUI.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DiziFilm.MVCCoreUI.Filters
{
    public class YoneticiFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Kullanicilar kullanici= context.HttpContext.Session.GetObject<Kullanicilar>(SessionKeys.AktifYonetici);

            if (kullanici==null)
            {
                context.Result = new RedirectResult("/AdminPanel/Yonetici/Login");
            }

            base.OnActionExecuting(context);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}

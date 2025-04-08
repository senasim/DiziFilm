using DiziFilm.Business;
using DiziFilm.Business.MappingRules;
using DiziFilm.Business.ValidationRules.Areas.AdminPanel;
using DiziFilm.Business.ValidationRules.Front;
using DiziFilm.Model.ViewModel.Areas.AdminPanel;
using DiziFilm.Model.ViewModel.Front;
using DiziFilm.MVCCoreUI.Filters;
using FluentValidation;
using FluentValidation.AspNetCore;
using Newtonsoft;
using Newtonsoft.Json;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});



builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddSession();
builder.Services.AddBusinessService();
builder.Services.AddScoped<ISessionManager, SessionManager>();

//VALÝDATÝON
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddTransient<IValidator<LoginVm>, LoginVmValidator>();
builder.Services.AddTransient<IValidator<KullaniciSignUpVm>, KullaniciSignupValidator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}



app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapAreaControllerRoute(
            name: "area",
            areaName: "AdminPanel",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
           );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using DiziFilm.Business.Abstract;
using DiziFilm.Business.Concrete.Base;
using DiziFilm.Data.Abstract;
using DiziFilm.Data.Concrete.EntityFramework.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziFilm.Business
{
    public static class BusinessService
    {

        public static IServiceCollection AddBusinessService(this IServiceCollection services)
        {
            #region Business
            services.AddScoped<IBolumBs, BolumBs>();
            services.AddScoped<IDiziBs,DiziBs>();
            services.AddScoped<IDiziAfiBs,DiziAfiBs>();
            services.AddScoped<IDiziOyuncuBs, DiziOyuncuBs>();
            services.AddScoped<IDiziTurBs, DiziTurBs>();
            services.AddScoped<IFavoriBs, FavoriBs>();
            services.AddScoped<IFilmBs, FilmBs>();
            services.AddScoped<IFilmAfiBs, FilmAfiBs>();
            services.AddScoped<IFilmOyuncuBs, FilmOyuncuBs>();
            services.AddScoped<IFilmTurBs, FilmTurBs>();
            services.AddScoped<IİzlemeListesiBs, İzlemeListesiBs>();
            services.AddScoped<IİzlemeListesiDiziBs, İzlemeListesiDiziBs>();
            services.AddScoped<IİzlemeListesiFilmBs, İzlemeListesiFilmBs>();
            services.AddScoped<IKullanicilarBs, KullanicilarBs>();
            services.AddScoped<IKullaniciRolBs, KullaniciRolBs>();
            services.AddScoped<IOyuncuBs, OyuncuBs>();
            services.AddScoped<ISezonBs, SezonBs>();
            services.AddScoped<IRolBs, RolBs>();
            services.AddScoped<ITurlerBs, TurlerBs>();
            services.AddScoped<IMenuBs, MenuBs>();
            services.AddScoped<IPlatformBs, PlatformBs>();
            services.AddScoped<IFilmPlatformBs, FilmPlatformBs>();
            services.AddScoped<IDillerBs,DillerBs>();
            services.AddScoped<IYetkiRolBs, YetkiRolBs>();
            services.AddScoped<IYonetmenBs, YonetmenBs>();
            services.AddScoped<IYonetmenDiziBs, YonetmenDiziBs>();
            services.AddScoped<IYonetmenFilmBs, YonetmenFilmBs>();
            services.AddScoped<IYonetmenTuruBs, YonetmenTuruBs>();
            services.AddScoped<IYorumDiziBs, YorumDiziBs>();
            services.AddScoped<IYorumFilmBs, YorumFilmBs>();

            #endregion

            #region Data
            services.AddScoped<IBolumRepository, EfBolumRepository>();
            services.AddScoped<IDiziRepository,EfDiziRepository>();
            services.AddScoped<IDiziAfiRepository, EfDiziAfiRepository>();
            services.AddScoped<IDiziOyuncuRepository, EfDiziOyuncuRepository>();
            services.AddScoped<IDiziTurRepository, EfDiziTurRepository>();
            services.AddScoped<IFavoriRepository, EfFavoriRepository>();
            services.AddScoped<IFilmRepository, EfFilmRepository>();
            services.AddScoped<IFilmTurRepository, EfFilmTurRepository>();
            services.AddScoped<IFilmAfiRepository, EfFilmAfiRepository>();
            services.AddScoped<IFilmOyuncuRepository, EfFilmOyuncuRepository>();
            services.AddScoped<IİzlemeListesiRepository, EfİzlemeListesiRepo>();
            services.AddScoped<IİzlemeListesiDiziRepository, EfİzlemeListesiDiziRepo>();
            services.AddScoped<IİzlemeListesiFilmRepository, EfİzlemeListesiFilmRepo>();
            services.AddScoped<IKullanicilarRepository, EfKullanicilarRepo>();
            services.AddScoped<IKullaniciRolRepository, EfKullanicilarRolRepo>();
            services.AddScoped<IOyuncuRepository, EfOyuncuRepo>();
            services.AddScoped<IRolRepository, EfRolRepo>();
            services.AddScoped<ISezonRepository, EfSezonRepo>();
            services.AddScoped<ITurlerRepository, EfTurlerRepo>();
            services.AddScoped<IYetkiRolRepository, EfYetkiRolRepo>();
            services.AddScoped<IYonetmenRepository, EfYonetmenRepo>();
            services.AddScoped<IYonetmenDiziRepository, EfYonetmenDiziRepo>();
            services.AddScoped<IYonetmenFilmRepository, EfYonetmenFilmRepo>();
            services.AddScoped<IYonetmenTuruRepository, EfYonetmenTuruRepo>();
            services.AddScoped<IYorumDiziRepository, EfYorumDiziRepo>();
            services.AddScoped<IYorumFilmRepository, EfYorumFilmRepo>();
            services.AddScoped<IMenuRepository, EfMenuRepository>();
            services.AddScoped<IPlatformRepository, EfPlatformRepository>();
            services.AddScoped<IFilmPlatformRepository,EfFilmPlatformRepo>();
            services.AddScoped<IDillerRepo, EfDillerRepo>();

            #endregion
            return services;

        }
    }
}

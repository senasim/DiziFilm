using AutoMapper;
using DiziFilm.Model.Entity;
using DiziFilm.Model.ViewModel.Front;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziFilm.Business.MappingRules
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<KullaniciSignUpVm,Kullanicilar>().ReverseMap();
        }
    }
}

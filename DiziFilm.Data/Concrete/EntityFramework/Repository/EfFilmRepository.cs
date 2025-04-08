using DiziFilm.Data.Abstract;
using DiziFilm.Model.Entity;
using Infrastructure.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziFilm.Data.Concrete.EntityFramework.Repository
{
    public class EfFilmRepository:EfRepositoryBase<Film,DiziFilmContext>,IFilmRepository
    {
    }
}

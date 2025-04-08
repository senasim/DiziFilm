using DiziFilm.Business.Abstract;
using DiziFilm.Data.Abstract;
using DiziFilm.Data.Concrete.EntityFramework.Repository;
using DiziFilm.Model.Entity;
using Infrastructure.Entity;
using Infrastructure.Enumarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DiziFilm.Business.Concrete.Base
{
    public class FilmBs:IFilmBs
    {
        private readonly IFilmRepository _repo;
        public FilmBs(IFilmRepository repo)
        {
            _repo = repo;
        }
        public Film Delete(Film entity)
        {
            return _repo.Delete(entity);
        }

        public Film DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Film Get(Expression<Func<Film, bool>> filter = null, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Film> GetAll(Expression<Func<Film, bool>> filter = null, Expression<Func<Film, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Film> GetAllByAktif(Expression<Func<Film, bool>> filter = null, Expression<Func<Film, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Film> GetAllPaging(int Page, int PageSize, Expression<Func<Film, bool>> filter = null, Expression<Func<Film, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Film GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Film, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Film Insert(Film entity)
        {
            return _repo.Insert(entity);
        }

        public Film Update(Film entity)
        {
            return _repo.Update(entity);
        }
    }
}
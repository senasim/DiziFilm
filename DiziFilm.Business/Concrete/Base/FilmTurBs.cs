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
    public class FilmTurBs:IFilmTurBs
    {
        private readonly IFilmTurRepository _repo;
        public FilmTurBs(IFilmTurRepository repo)
        {
            _repo = repo;
        }
        public FilmTur Delete(FilmTur entity)
        {
            return _repo.Delete(entity);
        }

        public FilmTur DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public FilmTur Get(Expression<Func<FilmTur, bool>> filter = null, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<FilmTur> GetAll(Expression<Func<FilmTur, bool>> filter = null, Expression<Func<FilmTur, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<FilmTur> GetAllByAktif(Expression<Func<FilmTur, bool>> filter = null, Expression<Func<FilmTur, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<FilmTur> GetAllPaging(int Page, int PageSize, Expression<Func<FilmTur, bool>> filter = null, Expression<Func<FilmTur, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public FilmTur GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<FilmTur, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public FilmTur Insert(FilmTur entity)
        {
            return _repo.Insert(entity);
        }

        public FilmTur Update(FilmTur entity)
        {
            return _repo.Update(entity);
        }
    }
}

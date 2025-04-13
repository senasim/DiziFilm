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
    public class FilmAfiBs:IFilmAfiBs
    {
        private readonly IFilmAfiRepository _repo;
        public FilmAfiBs(IFilmAfiRepository repo)
        {
            _repo = repo;
        }
        public FilmAfi Delete(FilmAfi entity)
        {
            return _repo.Delete(entity);
        }

        public FilmAfi DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public FilmAfi Get(Expression<Func<FilmAfi, bool>> filter = null, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<FilmAfi> GetAll(Expression<Func<FilmAfi, bool>> filter = null, Expression<Func<FilmAfi, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<FilmAfi> GetAllByAktif(Expression<Func<FilmAfi, bool>> filter = null, Expression<Func<FilmAfi, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<FilmAfi> GetAllPaging(int Page, int PageSize, Expression<Func<FilmAfi, bool>> filter = null, Expression<Func<FilmAfi, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public FilmAfi GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<FilmAfi, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public FilmAfi Insert(FilmAfi entity)
        {
            return _repo.Insert(entity);
        }

        public FilmAfi Update(FilmAfi entity)
        {
            return _repo.Update(entity);
        }
    }
}


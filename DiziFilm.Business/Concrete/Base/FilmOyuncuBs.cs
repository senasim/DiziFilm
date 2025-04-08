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
    public class FilmOyuncuBs:IFilmOyuncuBs
    {
        private readonly IFilmOyuncuRepository _repo;
        public FilmOyuncuBs(IFilmOyuncuRepository repo)
        {
            _repo = repo;
        }
        public FilmOyuncu Delete(FilmOyuncu entity)
        {
            return _repo.Delete(entity);
        }

        public FilmOyuncu DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public FilmOyuncu Get(Expression<Func<FilmOyuncu, bool>> filter = null, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<FilmOyuncu> GetAll(Expression<Func<FilmOyuncu, bool>> filter = null, Expression<Func<FilmOyuncu, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<FilmOyuncu> GetAllByAktif(Expression<Func<FilmOyuncu, bool>> filter = null, Expression<Func<FilmOyuncu, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<FilmOyuncu> GetAllPaging(int Page, int PageSize, Expression<Func<FilmOyuncu, bool>> filter = null, Expression<Func<FilmOyuncu, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public FilmOyuncu GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<FilmOyuncu, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public FilmOyuncu Insert(FilmOyuncu entity)
        {
            return _repo.Insert(entity);
        }

        public FilmOyuncu Update(FilmOyuncu entity)
        {
            return _repo.Update(entity);
        }
    }
}

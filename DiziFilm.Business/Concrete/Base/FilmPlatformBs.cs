using DiziFilm.Business.Abstract;
using DiziFilm.Data.Abstract;
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
    public class FilmPlatformBs : IFilmPlatformBs
    {

    
        IFilmPlatformRepository _repo;
        public FilmPlatformBs(IFilmPlatformRepository repo)
        {
          _repo = repo;
        }
        public FilmPlatform Delete(FilmPlatform entity)
        {
            return _repo.Delete(entity);
        }

        public FilmPlatform DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public FilmPlatform Get(Expression<Func<FilmPlatform, bool>> filter = null, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<FilmPlatform> GetAll(Expression<Func<FilmPlatform, bool>> filter = null, Expression<Func<FilmPlatform, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<FilmPlatform> GetAllByAktif(Expression<Func<FilmPlatform, bool>> filter = null, Expression<Func<FilmPlatform, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<FilmPlatform> GetAllPaging(int Page, int PageSize, Expression<Func<FilmPlatform, bool>> filter = null, Expression<Func<FilmPlatform, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public FilmPlatform GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<FilmPlatform, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public FilmPlatform Insert(FilmPlatform entity)
        {
            return _repo.Insert(entity);
        }

        public FilmPlatform Update(FilmPlatform entity)
        {
            return _repo.Update(entity);
        }
    }
}

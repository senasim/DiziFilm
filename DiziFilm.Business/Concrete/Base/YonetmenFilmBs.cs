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
    public class YonetmenFilmBs:IYonetmenFilmBs
    {
        private readonly IYonetmenFilmRepository _repo;
        public YonetmenFilmBs(IYonetmenFilmRepository repo)
        {
            _repo = repo;
        }
        public YonetmenFilm Delete(YonetmenFilm entity)
        {
            return _repo.Delete(entity);
        }

        public YonetmenFilm DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public YonetmenFilm Get(Expression<Func<YonetmenFilm, bool>> filter = null, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<YonetmenFilm> GetAll(Expression<Func<YonetmenFilm, bool>> filter = null, Expression<Func<YonetmenFilm, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<YonetmenFilm> GetAllByAktif(Expression<Func<YonetmenFilm, bool>> filter = null, Expression<Func<YonetmenFilm, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<YonetmenFilm> GetAllPaging(int Page, int PageSize, Expression<Func<YonetmenFilm, bool>> filter = null, Expression<Func<YonetmenFilm, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public YonetmenFilm GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<YonetmenFilm, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public YonetmenFilm Insert(YonetmenFilm entity)
        {
            return _repo.Insert(entity);
        }

        public YonetmenFilm Update(YonetmenFilm entity)
        {
            return _repo.Update(entity);
        }
    }
}

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
    public class YorumFilmBs:IYorumFilmBs
    {
        private readonly IYorumFilmRepository _repo;
        public YorumFilmBs(IYorumFilmRepository repo)
        {
            _repo = repo;
        }
        public YorumFilm Delete(YorumFilm entity)
        {
            return _repo.Delete(entity);
        }

        public YorumFilm DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public YorumFilm Get(Expression<Func<YorumFilm, bool>> filter = null, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<YorumFilm> GetAll(Expression<Func<YorumFilm, bool>> filter = null, Expression<Func<YorumFilm, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<YorumFilm> GetAllByAktif(Expression<Func<YorumFilm, bool>> filter = null, Expression<Func<YorumFilm, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<YorumFilm> GetAllPaging(int Page, int PageSize, Expression<Func<YorumFilm, bool>> filter = null, Expression<Func<YorumFilm, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public YorumFilm GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<YorumFilm, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public YorumFilm Insert(YorumFilm entity)
        {
            return _repo.Insert(entity);
        }

        public YorumFilm Update(YorumFilm entity)
        {
            return _repo.Update(entity);
        }
    }
}

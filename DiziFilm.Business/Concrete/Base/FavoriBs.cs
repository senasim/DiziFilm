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
    public class FavoriBs:IFavoriBs
    {
        private readonly IFavoriRepository _repo;
        public FavoriBs(IFavoriRepository repo)
        {
            _repo = repo;
        }
        public Favori Delete(Favori entity)
        {
            return _repo.Delete(entity);
        }

        public Favori DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Favori Get(Expression<Func<Favori, bool>> filter = null, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Favori> GetAll(Expression<Func<Favori, bool>> filter = null, Expression<Func<Favori, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Favori> GetAllByAktif(Expression<Func<Favori, bool>> filter = null, Expression<Func<Favori, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Favori> GetAllPaging(int Page, int PageSize, Expression<Func<Favori, bool>> filter = null, Expression<Func<Favori, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Favori GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Favori, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Favori Insert(Favori entity)
        {
            return _repo.Insert(entity);
        }

        public Favori Update(Favori entity)
        {
            return _repo.Update(entity);
        }
    }
}


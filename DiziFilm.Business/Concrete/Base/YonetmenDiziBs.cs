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
    public class YonetmenDiziBs:IYonetmenDiziBs
    {
        private readonly IYonetmenDiziRepository _repo;
        public YonetmenDiziBs(IYonetmenDiziRepository repo)
        {
            _repo = repo;
        }
        public YonetmenDizi Delete(YonetmenDizi entity)
        {
            return _repo.Delete(entity);
        }

        public YonetmenDizi DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public YonetmenDizi Get(Expression<Func<YonetmenDizi, bool>> filter = null, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<YonetmenDizi> GetAll(Expression<Func<YonetmenDizi, bool>> filter = null, Expression<Func<YonetmenDizi, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<YonetmenDizi> GetAllByAktif(Expression<Func<YonetmenDizi, bool>> filter = null, Expression<Func<YonetmenDizi, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<YonetmenDizi> GetAllPaging(int Page, int PageSize, Expression<Func<YonetmenDizi, bool>> filter = null, Expression<Func<YonetmenDizi, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public YonetmenDizi GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<YonetmenDizi, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public YonetmenDizi Insert(YonetmenDizi entity)
        {
            return _repo.Insert(entity);
        }

        public YonetmenDizi Update(YonetmenDizi entity)
        {
            return _repo.Update(entity);
        }
    }
}

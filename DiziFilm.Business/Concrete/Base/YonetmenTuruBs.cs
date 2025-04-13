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
    public class YonetmenTuruBs:IYonetmenTuruBs
    {
        private readonly IYonetmenTuruRepository _repo;
        public YonetmenTuruBs(IYonetmenTuruRepository repo)
        {
            _repo = repo;
        }
        public YonetmenTuru Delete(YonetmenTuru entity)
        {
            return _repo.Delete(entity);
        }

        public YonetmenTuru DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public YonetmenTuru Get(Expression<Func<YonetmenTuru, bool>> filter = null, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<YonetmenTuru> GetAll(Expression<Func<YonetmenTuru, bool>> filter = null, Expression<Func<YonetmenTuru, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<YonetmenTuru> GetAllByAktif(Expression<Func<YonetmenTuru, bool>> filter = null, Expression<Func<YonetmenTuru, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<YonetmenTuru> GetAllPaging(int Page, int PageSize, Expression<Func<YonetmenTuru, bool>> filter = null, Expression<Func<YonetmenTuru, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public YonetmenTuru GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<YonetmenTuru, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public YonetmenTuru Insert(YonetmenTuru entity)
        {
            return _repo.Insert(entity);
        }

        public YonetmenTuru Update(YonetmenTuru entity)
        {
            return _repo.Update(entity);
        }
    }
}

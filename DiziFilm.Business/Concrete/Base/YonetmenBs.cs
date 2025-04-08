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
    public class YonetmenBs:IYonetmenBs
    {
        private readonly IYonetmenRepository _repo;
        public YonetmenBs(IYonetmenRepository repo)
        {
            _repo = repo;
        }
        public Yonetmen Delete(Yonetmen entity)
        {
            return _repo.Delete(entity);
        }

        public Yonetmen DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Yonetmen Get(Expression<Func<Yonetmen, bool>> filter = null, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Yonetmen> GetAll(Expression<Func<Yonetmen, bool>> filter = null, Expression<Func<Yonetmen, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Yonetmen> GetAllByAktif(Expression<Func<Yonetmen, bool>> filter = null, Expression<Func<Yonetmen, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Yonetmen> GetAllPaging(int Page, int PageSize, Expression<Func<Yonetmen, bool>> filter = null, Expression<Func<Yonetmen, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Yonetmen GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Yonetmen, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Yonetmen Insert(Yonetmen entity)
        {
            return _repo.Insert(entity);
        }

        public Yonetmen Update(Yonetmen entity)
        {
            return _repo.Update(entity);
        }
    }
}

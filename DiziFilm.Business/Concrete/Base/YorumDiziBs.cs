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
    public class YorumDiziBs:IYorumDiziBs
    {
        private readonly IYorumDiziRepository _repo;
        public YorumDiziBs(IYorumDiziRepository repo)
        {
            _repo = repo;
        }
        public YorumDizi Delete(YorumDizi entity)
        {
            return _repo.Delete(entity);
        }

        public YorumDizi DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public YorumDizi Get(Expression<Func<YorumDizi, bool>> filter = null, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<YorumDizi> GetAll(Expression<Func<YorumDizi, bool>> filter = null, Expression<Func<YorumDizi, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<YorumDizi> GetAllByAktif(Expression<Func<YorumDizi, bool>> filter = null, Expression<Func<YorumDizi, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<YorumDizi> GetAllPaging(int Page, int PageSize, Expression<Func<YorumDizi, bool>> filter = null, Expression<Func<YorumDizi, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public YorumDizi GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<YorumDizi, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public YorumDizi Insert(YorumDizi entity)
        {
            return _repo.Insert(entity);
        }

        public YorumDizi Update(YorumDizi entity)
        {
            return _repo.Update(entity);
        }
    }
}

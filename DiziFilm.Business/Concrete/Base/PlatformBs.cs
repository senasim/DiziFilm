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
    public class PlatformBs : IPlatformBs
    {

        IPlatformRepository _repo;
        public PlatformBs(IPlatformRepository repo)
        {
            _repo = repo;
        }
        public Platform Delete(Platform entity)
        {
            return _repo.Delete(entity);
        }

        public Platform DeleteById(int Id)
        {
           return _repo.DeleteById(Id);
        }

        public Platform Get(Expression<Func<Platform, bool>> filter = null, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Platform> GetAll(Expression<Func<Platform, bool>> filter = null, Expression<Func<Platform, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Platform> GetAllByAktif(Expression<Func<Platform, bool>> filter = null, Expression<Func<Platform, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Platform> GetAllPaging(int Page, int PageSize, Expression<Func<Platform, bool>> filter = null, Expression<Func<Platform, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Platform GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Platform, bool>> filter = null, params string[] includelist)
        {
           return _repo.GetCount(filter, includelist);
        }

        public Platform Insert(Platform entity)
        {
            return _repo.Insert(entity);
        }

        public Platform Update(Platform entity)
        {
            return _repo.Update(entity);
        }
    }
}

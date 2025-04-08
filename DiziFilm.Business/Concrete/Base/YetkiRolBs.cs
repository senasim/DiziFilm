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
    public class YetkiRolBs:IYetkiRolBs
    {
        private readonly IYetkiRolRepository _repo;
        public YetkiRolBs(IYetkiRolRepository repo)
        {
            _repo = repo;
        }
        public YetkiRol Delete(YetkiRol entity)
        {
            return _repo.Delete(entity);
        }

        public YetkiRol DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public YetkiRol Get(Expression<Func<YetkiRol, bool>> filter = null, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<YetkiRol> GetAll(Expression<Func<YetkiRol, bool>> filter = null, Expression<Func<YetkiRol, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<YetkiRol> GetAllByAktif(Expression<Func<YetkiRol, bool>> filter = null, Expression<Func<YetkiRol, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<YetkiRol> GetAllPaging(int Page, int PageSize, Expression<Func<YetkiRol, bool>> filter = null, Expression<Func<YetkiRol, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public YetkiRol GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<YetkiRol, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public YetkiRol Insert(YetkiRol entity)
        {
            return _repo.Insert(entity);
        }

        public YetkiRol Update(YetkiRol entity)
        {
            return _repo.Update(entity);
        }
    }
}

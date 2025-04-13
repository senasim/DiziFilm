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
    public class TurlerBs:ITurlerBs
    {
        private readonly ITurlerRepository _repo;
        public TurlerBs(ITurlerRepository repo)
        {
            _repo = repo;
        }
        public Turler Delete(Turler entity)
        {
            return _repo.Delete(entity);
        }

        public Turler DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Turler Get(Expression<Func<Turler, bool>> filter = null, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Turler> GetAll(Expression<Func<Turler, bool>> filter = null, Expression<Func<Turler, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Turler> GetAllByAktif(Expression<Func<Turler, bool>> filter = null, Expression<Func<Turler, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Turler> GetAllPaging(int Page, int PageSize, Expression<Func<Turler, bool>> filter = null, Expression<Func<Turler, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Turler GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Turler, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Turler Insert(Turler entity)
        {
            return _repo.Insert(entity);
        }

        public Turler Update(Turler entity)
        {
            return _repo.Update(entity);
        }
    }
}

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
    public class DiziTurBs:IDiziTurBs
    {
        private readonly IDiziTurRepository _repo;
        public DiziTurBs(IDiziTurRepository repo)
        {
            _repo = repo;
        }
        public DiziTur Delete(DiziTur entity)
        {
            return _repo.Delete(entity);
        }

        public DiziTur DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public DiziTur Get(Expression<Func<DiziTur, bool>> filter = null, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<DiziTur> GetAll(Expression<Func<DiziTur, bool>> filter = null, Expression<Func<DiziTur, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<DiziTur> GetAllByAktif(Expression<Func<DiziTur, bool>> filter = null, Expression<Func<DiziTur, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<DiziTur> GetAllPaging(int Page, int PageSize, Expression<Func<DiziTur, bool>> filter = null, Expression<Func<DiziTur, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public DiziTur GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<DiziTur, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public DiziTur Insert(DiziTur entity)
        {
            return _repo.Insert(entity);
        }

        public DiziTur Update(DiziTur entity)
        {
            return _repo.Update(entity);
        }
    }
}


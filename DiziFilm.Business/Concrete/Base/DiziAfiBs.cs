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
    public class DiziAfiBs:IDiziAfiBs
    {
        private readonly IDiziAfiRepository _repo;
        public DiziAfiBs(IDiziAfiRepository repo)
        {
            _repo = repo;
        }
        public DiziAfi Delete(DiziAfi entity)
        {
            return _repo.Delete(entity);
        }

        public DiziAfi DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public DiziAfi Get(Expression<Func<DiziAfi, bool>> filter = null, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<DiziAfi> GetAll(Expression<Func<DiziAfi, bool>> filter = null, Expression<Func<DiziAfi, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<DiziAfi> GetAllByAktif(Expression<Func<DiziAfi, bool>> filter = null, Expression<Func<DiziAfi, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<DiziAfi> GetAllPaging(int Page, int PageSize, Expression<Func<DiziAfi, bool>> filter = null, Expression<Func<DiziAfi, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public DiziAfi GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<DiziAfi, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public DiziAfi Insert(DiziAfi entity)
        {
            return _repo.Insert(entity);
        }

        public DiziAfi Update(DiziAfi entity)
        {
            return _repo.Update(entity);
        }
    }
}


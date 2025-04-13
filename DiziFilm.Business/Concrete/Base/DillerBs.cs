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
    
    public class DillerBs :IDillerBs
    {
        private readonly IDillerRepo _repo;
        public DillerBs(IDillerRepo repo)
        {
            _repo = repo;
        }

        public Diller Delete(Diller entity)
        {
           return _repo.Delete(entity);
        }

        public Diller DeleteById(int Id)
        {
           return _repo.DeleteById(Id);
        }

        public Diller Get(Expression<Func<Diller, bool>> filter = null, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Diller> GetAll(Expression<Func<Diller, bool>> filter = null, Expression<Func<Diller, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
          return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Diller> GetAllByAktif(Expression<Func<Diller, bool>> filter = null, Expression<Func<Diller, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
           return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Diller> GetAllPaging(int Page, int PageSize, Expression<Func<Diller, bool>> filter = null, Expression<Func<Diller, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Diller GetById(int Id, bool Tracking = false, params string[] includelist)
        {
           return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Diller, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Diller Insert(Diller entity)
        {
           return _repo.Insert(entity);
        }

        public Diller Update(Diller entity)
        {
           return _repo.Update(entity);
        }
    }
}

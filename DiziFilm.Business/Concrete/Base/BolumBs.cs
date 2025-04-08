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
    public class BolumBs : IBolumBs
    {
        private readonly IBolumRepository _repo;
        public BolumBs(IBolumRepository repo)
        {
            _repo = repo;
        }
        public Bolum Delete(Bolum entity)
        {
            return _repo.Delete(entity);
        }

        public Bolum DeleteById(int Id)
        {
           return _repo.DeleteById(Id);
        }

        public Bolum Get(Expression<Func<Bolum, bool>> filter = null, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter,Tracking,includelist);
        }

        public List<Bolum> GetAll(Expression<Func<Bolum, bool>> filter = null, Expression<Func<Bolum, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter,orderby,sorted,Tracking,includelist);
        }

        public List<Bolum> GetAllByAktif(Expression<Func<Bolum, bool>> filter = null, Expression<Func<Bolum, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter,orderby,sorted,Aktif,Tracking,includelist);
        }

        public PagingResult<Bolum> GetAllPaging(int Page, int PageSize, Expression<Func<Bolum, bool>> filter = null, Expression<Func<Bolum, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page,PageSize,filter,orderby,sorted,includelist);
        }

        public Bolum GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id,Tracking,includelist);
        }

        public int GetCount(Expression<Func<Bolum, bool>> filter = null, params string[] includelist)
        {
           return _repo.GetCount(filter,includelist);
        }

        public Bolum Insert(Bolum entity)
        {
            return _repo.Insert(entity);
        }

        public Bolum Update(Bolum entity)
        {
           return _repo.Update(entity);
        }
    }
}

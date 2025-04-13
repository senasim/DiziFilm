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
    public class OyuncuBs:IOyuncuBs
    {
        private readonly IOyuncuRepository _repo;
        public OyuncuBs(IOyuncuRepository repo)
        {
            _repo = repo;
        }
        public Oyuncu Delete(Oyuncu entity)
        {
            return _repo.Delete(entity);
        }

        public Oyuncu DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Oyuncu Get(Expression<Func<Oyuncu, bool>> filter = null, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Oyuncu> GetAll(Expression<Func<Oyuncu, bool>> filter = null, Expression<Func<Oyuncu, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Oyuncu> GetAllByAktif(Expression<Func<Oyuncu, bool>> filter = null, Expression<Func<Oyuncu, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Oyuncu> GetAllPaging(int Page, int PageSize, Expression<Func<Oyuncu, bool>> filter = null, Expression<Func<Oyuncu, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Oyuncu GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Oyuncu, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Oyuncu Insert(Oyuncu entity)
        {
            return _repo.Insert(entity);
        }

        public Oyuncu Update(Oyuncu entity)
        {
            return _repo.Update(entity);
        }
    }
}

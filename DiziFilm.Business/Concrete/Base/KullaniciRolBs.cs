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
    public class KullaniciRolBs:IKullaniciRolBs
    {
        private readonly IKullaniciRolRepository _repo;
        public KullaniciRolBs(IKullaniciRolRepository repo)
        {
            _repo = repo;
        }
        public KullaniciRol Delete(KullaniciRol entity)
        {
            return _repo.Delete(entity);
        }

        public KullaniciRol DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public KullaniciRol Get(Expression<Func<KullaniciRol, bool>> filter = null, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<KullaniciRol> GetAll(Expression<Func<KullaniciRol, bool>> filter = null, Expression<Func<KullaniciRol, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<KullaniciRol> GetAllByAktif(Expression<Func<KullaniciRol, bool>> filter = null, Expression<Func<KullaniciRol, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<KullaniciRol> GetAllPaging(int Page, int PageSize, Expression<Func<KullaniciRol, bool>> filter = null, Expression<Func<KullaniciRol, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public KullaniciRol GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<KullaniciRol, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public KullaniciRol Insert(KullaniciRol entity)
        {
            return _repo.Insert(entity);
        }

        public KullaniciRol Update(KullaniciRol entity)
        {
            return _repo.Update(entity);
        }
    }
}

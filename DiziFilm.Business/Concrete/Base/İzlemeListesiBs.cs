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
    public class İzlemeListesiBs:IİzlemeListesiBs
    {
        private readonly IİzlemeListesiRepository _repo;
        public İzlemeListesiBs(IİzlemeListesiRepository repo)
        {
            _repo = repo;
        }
        public İzlemeListesi Delete(İzlemeListesi entity)
        {
            return _repo.Delete(entity);
        }

        public İzlemeListesi DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public İzlemeListesi Get(Expression<Func<İzlemeListesi, bool>> filter = null, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<İzlemeListesi> GetAll(Expression<Func<İzlemeListesi, bool>> filter = null, Expression<Func<İzlemeListesi, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<İzlemeListesi> GetAllByAktif(Expression<Func<İzlemeListesi, bool>> filter = null, Expression<Func<İzlemeListesi, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<İzlemeListesi> GetAllPaging(int Page, int PageSize, Expression<Func<İzlemeListesi, bool>> filter = null, Expression<Func<İzlemeListesi, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public İzlemeListesi GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<İzlemeListesi, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public İzlemeListesi Insert(İzlemeListesi entity)
        {
            return _repo.Insert(entity);
        }

        public İzlemeListesi Update(İzlemeListesi entity)
        {
            return _repo.Update(entity);
        }
    }
}

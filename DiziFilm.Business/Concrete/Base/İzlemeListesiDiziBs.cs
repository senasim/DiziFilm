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
    public class İzlemeListesiDiziBs:IİzlemeListesiDiziBs
    {
        private readonly IİzlemeListesiDiziRepository _repo;
        public İzlemeListesiDiziBs(IİzlemeListesiDiziRepository repo)
        {
            _repo = repo;
        }
        public İzlemeListesiDizi Delete(İzlemeListesiDizi entity)
        {
            return _repo.Delete(entity);
        }

        public İzlemeListesiDizi DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public İzlemeListesiDizi Get(Expression<Func<İzlemeListesiDizi, bool>> filter = null, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<İzlemeListesiDizi> GetAll(Expression<Func<İzlemeListesiDizi, bool>> filter = null, Expression<Func<İzlemeListesiDizi, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<İzlemeListesiDizi> GetAllByAktif(Expression<Func<İzlemeListesiDizi, bool>> filter = null, Expression<Func<İzlemeListesiDizi, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<İzlemeListesiDizi> GetAllPaging(int Page, int PageSize, Expression<Func<İzlemeListesiDizi, bool>> filter = null, Expression<Func<İzlemeListesiDizi, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public İzlemeListesiDizi GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<İzlemeListesiDizi, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public İzlemeListesiDizi Insert(İzlemeListesiDizi entity)
        {
            return _repo.Insert(entity);
        }

        public İzlemeListesiDizi Update(İzlemeListesiDizi entity)
        {
            return _repo.Update(entity);
        }
    }
}

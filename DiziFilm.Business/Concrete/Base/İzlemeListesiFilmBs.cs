using DiziFilm.Business.Abstract;
using DiziFilm.Data.Concrete.EntityFramework.Repository;
using DiziFilm.Model.Entity;
using DiziFilm.Data.Abstract;
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
    public class İzlemeListesiFilmBs:IİzlemeListesiFilmBs
    {
        private readonly IİzlemeListesiFilmRepository _repo;
        public İzlemeListesiFilmBs(IİzlemeListesiFilmRepository repo)
        {
            _repo = repo;
        }
        public İzlemeListesiFilm Delete(İzlemeListesiFilm entity)
        {
            return _repo.Delete(entity);
        }

        public İzlemeListesiFilm DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public İzlemeListesiFilm Get(Expression<Func<İzlemeListesiFilm, bool>> filter = null, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<İzlemeListesiFilm> GetAll(Expression<Func<İzlemeListesiFilm, bool>> filter = null, Expression<Func<İzlemeListesiFilm, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<İzlemeListesiFilm> GetAllByAktif(Expression<Func<İzlemeListesiFilm, bool>> filter = null, Expression<Func<İzlemeListesiFilm, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<İzlemeListesiFilm> GetAllPaging(int Page, int PageSize, Expression<Func<İzlemeListesiFilm, bool>> filter = null, Expression<Func<İzlemeListesiFilm, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public İzlemeListesiFilm GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<İzlemeListesiFilm, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public İzlemeListesiFilm Insert(İzlemeListesiFilm entity)
        {
            return _repo.Insert(entity);
        }

        public İzlemeListesiFilm Update(İzlemeListesiFilm entity)
        {
            return _repo.Update(entity);
        }
    }
}

using Infrastructure.Data.Abstract;
using Infrastructure.Entity;
using Infrastructure.Enumarations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Concrete.EntityFramework
{
    public class EfRepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : BaseEntity, new()
        where TContext : DbContext, new()
    {
        public TEntity Delete(TEntity entity)
        {
            try
            {
                using TContext ctx = new TContext();
                ctx.Set<TEntity>().Remove(entity);
                ctx.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {


                return null;
            }

        }

        public TEntity DeleteById(int Id)
        {
            try
            {
                using TContext ctx = new TContext();
                TEntity entity = ctx.Set<TEntity>().SingleOrDefault(x => x.Id == Id);
                if (entity != null)
                {
                    ctx.Set<TEntity>().Remove(entity);
                    ctx.SaveChanges();
                }
                return entity;

            }
            catch (Exception)
            {
                throw;
            }

        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            try
            {
                using TContext ctx = new TContext();
                IQueryable<TEntity> query = ctx.Set<TEntity>();
                if (includelist != null && includelist.Length > 0)
                {
                    for (int i = 0; i < includelist.Length; i++)
                    {
                        query = query.Include(includelist[i]);
                    }
                }
                if (Tracking)
                    return query.SingleOrDefault(filter);
                else
                    return query.AsNoTracking().SingleOrDefault(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {

            using TContext ctx = new TContext();
            IQueryable<TEntity> query = ctx.Set<TEntity>();

            if (Tracking)
            {
                if (filter != null)
                {
                    query = query.Where(filter);
                }
            }
            else
            {
                if (filter != null)
                {
                    query = query.Where(filter).AsNoTracking();
                }
                else
                {
                    query = query.AsNoTracking();
                }
            }

            if (includelist != null && includelist.Length > 0)
            {
                for (int i = 0; i < includelist.Length; i++)
                {
                    query = query.Include(includelist[i]);
                }
            }
            if (orderby != null)
            {
                if (sorted == Sorted.ASC)

                    query = query.OrderBy(orderby);
                else
                    query = query.OrderByDescending(orderby);
            }


            return query.ToList();

        }

        public List<TEntity> GetAllByAktif(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            try
            {
                using TContext ctx = new TContext();
                IQueryable<TEntity> query = ctx.Set<TEntity>();


                if (Tracking)
                {
                    if (filter != null)

                        query = query.Where(x => x.Aktif == Aktif).Where(filter);
                    else

                        query = query.Where(x => x.Aktif == Aktif);

                }
                else
                {
                    if (filter != null)

                        query = query.Where(x => x.Aktif == Aktif).Where(filter).AsNoTracking();
                    else
                        query = query.Where(x => x.Aktif == Aktif).AsNoTracking();


                }

                if (includelist != null && includelist.Length > 0)
                {
                    for (int i = 0; i < includelist.Length; i++)
                    {
                        query = query.Include(includelist[i]);
                    }
                }
                if (orderby != null)
                {
                    if (sorted == Sorted.ASC)

                        query = query.OrderBy(orderby);
                    else
                        query = query.OrderByDescending(orderby);
                }

                return query.ToList();

            }
            catch (Exception)
            {

                throw;
            }




        }

        public PagingResult<TEntity> GetAllPaging(int skip, int take, Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            try
            {




                using (TContext _ctx = new TContext())
                {
                    IQueryable<TEntity> list = _ctx.Set<TEntity>();
                    int totalCount = 0;

                    if (filter != null)
                    {
                        list = _ctx.Set<TEntity>().Where(filter);

                    }


                    if (includelist != null && includelist.Length > 0)
                    {
                        for (int i = 0; i < includelist.Length; i++)
                        {
                            list = list.Include(includelist[i]);
                        }
                    }
                    int totalItemCount = list.Count();

                    if (orderby != null && sorted == Sorted.ASC)
                    {
                        list = list.OrderBy(orderby);
                    }
                    else if (orderby != null && sorted == Sorted.DESC)
                    {

                        list = list.OrderByDescending(orderby);
                    }

                    list = list.Skip(skip).Take(take);


                    return new PagingResult<TEntity>(list.ToList(), totalItemCount, totalCount);
                }














            ;






            }
            catch (Exception)
            {

                throw;
            }



        }

        public TEntity GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            try
            {
                using TContext ctx = new TContext();
                IQueryable<TEntity> query = ctx.Set<TEntity>();
                if (includelist != null && includelist.Length > 0)
                {
                    for (int i = 0; i < includelist.Length; i++)
                    {
                        query = query.Include(includelist[i]);
                    }
                }
                if (Tracking)
                    return query.SingleOrDefault(x => x.Id == Id);
                else
                    return query.AsNoTracking().SingleOrDefault(x => x.Id == Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCount(Expression<Func<TEntity, bool>> filter = null, params string[] includelist)
        {
            try
            {
                using TContext ctx = new TContext();
                IQueryable<TEntity> query = ctx.Set<TEntity>();
                if (includelist != null && includelist.Length > 0)
                {
                    for (int i = 0; i < includelist.Length; i++)
                    {
                        query = query.Include(includelist[i]);
                    }
                }

                return query.Where(filter).Count();
            }
            catch (Exception)
            {

                throw;
            }








        }

        public TEntity Insert(TEntity entity)
        {
            try
            {
                using TContext ctx = new TContext();

                // entity.OlusturulmaTarihi = DateTime.UtcNow;

                ctx.Set<TEntity>().Add(entity);
                ctx.SaveChanges();

                return entity;

            }
            catch (Exception)
            {

                throw;
            }

        }


        public TEntity Update(TEntity entity)
        {
            try
            {
                using TContext ctx = new TContext();
                //  entity.DegistirilmeTarihi = DateTime.UtcNow;
                ctx.Set<TEntity>().Attach(entity);
                ctx.Entry(entity).State = EntityState.Modified;
                ctx.SaveChanges();
                return entity;

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

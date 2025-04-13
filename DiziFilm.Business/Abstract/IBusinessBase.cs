using Infrastructure.Data.Abstract;
using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziFilm.Business.Abstract
{
    public interface IBusinessBase<T>:IRepository<T> where T : BaseEntity,new()
    {
    }
}

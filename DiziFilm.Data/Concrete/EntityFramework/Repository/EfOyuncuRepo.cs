using DiziFilm.Data.Abstract;
using DiziFilm.Model.Entity;
using Infrastructure.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziFilm.Data.Concrete.EntityFramework.Repository
{
    public class EfOyuncuRepo : EfRepositoryBase<Oyuncu, DiziFilmContext>, IOyuncuRepository
    {
        public EfOyuncuRepo()
        {
            
        }
        public void Ekle(Oyuncu oyuncu)
        {
           base.Insert(oyuncu);
        }

        public Oyuncu OyuncuBul(string Ad, string Soyad)
        {
           return base.GetAll().Where(x => x.Adi == Ad && x.Soyadi == Soyad).FirstOrDefault();    
        }

        public IEnumerable<Oyuncu> OyunculariGetir()
        {
           return base.GetAll();
        }
    }
}

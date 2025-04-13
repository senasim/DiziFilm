using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public bool? Aktif { get; set; }
        public DateTime? OlusturulmaTarihi { get; set; }
        public DateTime? DegistirilmeTarihi { get; set; }
        public int? OlusturanId { get; set; }
        public int? DegistirenId { get; set; }

    }
}

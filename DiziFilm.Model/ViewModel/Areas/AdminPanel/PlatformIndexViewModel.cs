using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziFilm.Model.ViewModel.Areas.AdminPanel
{
   public class PlatformIndexViewModel
    {
        public int Id { get; set; }
        public string? PlatformAdi { get; set; }

        public string? Logo { get; set; }




    }
}

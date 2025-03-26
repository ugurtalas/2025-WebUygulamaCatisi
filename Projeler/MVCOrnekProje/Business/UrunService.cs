using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UrunService
    {
        public static List<Entities.Urun> UrunListele()
        {
            DataBaseContext Model = new DataBaseContext();
            var Cevap = Model.Urun.Include("Kategori")
                .Include("Yorum").ToList();
            return Cevap;
        }

        public static List<DTO.Response.Urun.UrunOzetBilgi> TumUrunListele()
        {
            DataBaseContext Model = new DataBaseContext();
            var Cevap = Model.Urun.ToList().Take(20)
                .Select(s=> new DTO.Response.Urun.UrunOzetBilgi { 
                     No = s.No,
                     Fiyat=s.Fiyat,
                     Ad=s.Ad,
                     ResimYol=s.ResimYol,        })           
                
                .ToList();
            return Cevap;
        }
    }
}

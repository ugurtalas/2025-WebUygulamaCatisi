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
    }
}

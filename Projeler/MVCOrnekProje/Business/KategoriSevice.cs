using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class KategoriSevice
    {
        public static List<Entities.Kategori> KategoriListele()
        {
            DataBaseContext Model = new DataBaseContext();
            var Cevap = Model.Kategori.ToList();
            return Cevap;
        }
    }
}

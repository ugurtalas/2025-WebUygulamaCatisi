using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyDataGenerator.Generators
{
    public class Kategori
    {
        public static void Generate()
        {
            DataBaseContext Model = new DataBaseContext();
            Model.Kategori.Add(new  Entities.Kategori { Ad="Telefon" });
            Model.Kategori.Add(new Entities.Kategori { Ad="Tablet" });
            Model.Kategori.Add(new Entities.Kategori { Ad="Bilgisayar" });
            Model.Kategori.Add(new Entities.Kategori { Ad="Televizyon" });
            Model.Kategori.Add(new Entities.Kategori { Ad="Süpürge" });
            Model.SaveChanges();
            
        }
    }
}

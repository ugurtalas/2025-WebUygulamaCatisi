using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyDataGenerator.Generators
{
    public class Yorum
    {
        public static void Generate()
        {
            Random rnd = new Random();
            DataBaseContext Model = new DataBaseContext();

            var UrunList = Model.Urun.ToList();

            foreach (var item in UrunList)
            {
                Entities.Yorum Nesne = new Entities.Yorum();
                Nesne.Baslik = "Urun Harika";
                Nesne.Icerik = "Hızlı kargo. Ürün resimde görüldüğü gibi.";
                Nesne.Mail = "a@a.com";
                Nesne.UrunNo = item.No;
                Model.Yorum.Add(Nesne);
            }



            Model.SaveChanges();

        }
    }
}

using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyDataGenerator.Generators
{
    public class Urun
    {
        public static void Generate()
        {
            Random rnd = new Random();
            DataBaseContext Model = new DataBaseContext();

            var KategoriList = Model.Kategori.ToList();

            foreach (var item in KategoriList) {
                Entities.Urun Nesne = new Entities.Urun();
                Nesne.Ad = "Rastgele Urun " + rnd.Next(0, 1000);
                Nesne.Baslik = "Rastgele Uretilen Urun";
                Nesne.Icerik = "Rastgele içerik";
                Nesne.Fiyat = 1000;
                Nesne.Stok = 10;
                Nesne.ResimYol = "https://dummyimage.com/600x400/000/fff";
                Nesne.KategoriNo = item.No;
                Model.Urun.Add(Nesne);
            }


            
            Model.SaveChanges();

        }
    }
}

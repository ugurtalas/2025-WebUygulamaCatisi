using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyDataGenerator.Generators
{
    public class Kullanici
    {
        public static void Generate()
        {
            DataBaseContext Model = new DataBaseContext();
            
            Entities.Kullanici Nesne= new Entities.Kullanici();
            Nesne.Ad = "İkra";
            Nesne.Soyad = "TALAŞ";
            Nesne.KullaniciAd = "ikratalas";
            Nesne.Parola = "123";
            Nesne.Adres = "Bilecik";
            Nesne.Eposta = "ikra@x.com";
            Nesne.RolNo = 1;
            Model.Kullanici.Add(Nesne);

            Entities.Kullanici Nesne2 = new Entities.Kullanici();
            Nesne2.Ad = "Beyazıd";
            Nesne2.Soyad = "TALAŞ";
            Nesne2.KullaniciAd = "beyazidtalas";
            Nesne2.Parola = "123";
            Nesne2.Adres = "Bilecik";
            Nesne2.Eposta = "beyazid@x.com";
            Nesne2.RolNo = 2;
            Model.Kullanici.Add(Nesne2);


            Entities.Kullanici Nesne3 = new Entities.Kullanici();
            Nesne3.Ad = "Uğur";
            Nesne3.Soyad = "TALAŞ";
            Nesne3.KullaniciAd = "ugurtalas";
            Nesne3.Parola = "123";
            Nesne3.Adres = "Bilecik";
            Nesne3.Eposta = "ugur@x.com";
            Nesne3.RolNo = 3;
            Model.Kullanici.Add(Nesne3);

            Model.SaveChanges();
            
        }
    }
}

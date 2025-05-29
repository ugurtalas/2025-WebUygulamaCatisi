using DataAccessLayer;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class SiparisService
    {
        public static void SiparisTamamla(int Kullanicino)
        {
            DataBaseContext Model = new DataBaseContext();
            
            
            var SepettekiUrunler = Model.Sepet.Include("Urun").Where(q => q.KullaniciNo == Kullanicino).ToList();

            foreach (var item in SepettekiUrunler)
            {
                Siparis Nesne = new Siparis();

                Nesne.KullaniciNo = Kullanicino;
                Nesne.SiparisDurumNo = 1;
                Nesne.EklemeTarih = DateTime.Now;
                Nesne.Fiyat = item.Urun.Fiyat;
                Nesne.UrunNo = item.UrunNo;

                Model.Siparis.Add(Nesne);

                Model.SaveChanges();
            }


            foreach (var item in SepettekiUrunler)
            {
                Model.Sepet.Remove(item);
            }
            Model.SaveChanges();

        

        }


        public static List<DTO.Response.Siparis.Siparis> SiparisListele(int KullaniciNo)
        {
            DataBaseContext Model = new DataBaseContext();

            var Liste = Model.Siparis.Include("Urun").Where(q => q.KullaniciNo == KullaniciNo)
                .Select(s => new DTO.Response.Siparis.Siparis
                {
                     Ad = s.Urun.Ad,
                      Fiyat = s.Urun.Fiyat,
                       EklemeTarih=s.EklemeTarih,
                        SiaprisDurum = s.SiparisDurum.Ad,
                }).ToList();
            
            return Liste;
        }

    }
}

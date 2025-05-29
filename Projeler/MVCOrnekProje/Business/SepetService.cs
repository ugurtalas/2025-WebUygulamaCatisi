using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class SepetService
    {
        public static bool SepeteUrunEkle(int KullaniciNo, int EklencekUrunNo)
        {
            DataBaseContext Model = new DataBaseContext();
            Entities.Sepet Nesne = new Entities.Sepet();
            Nesne.KullaniciNo = KullaniciNo;
            Nesne.UrunNo = EklencekUrunNo;  
            Nesne.EklemeTarih = DateTime.Now;
            try
            {
                Model.Sepet.Add(Nesne);
                Model.SaveChanges();    
                return true;
            }
            catch 
            {

                return false;
            }

  
        }


        public static List<DTO.Response.Sepet.SepetUrunBilgileri> SepetGoruntule(int KullaniciNo)
        {
            DataBaseContext Model = new DataBaseContext();
            List<DTO.Response.Sepet.SepetUrunBilgileri> Liste = new List<DTO.Response.Sepet.SepetUrunBilgileri>();


            Liste = Model.Sepet.Include("Urun").Where(q=> q.KullaniciNo == KullaniciNo)
                .Select(s=> new DTO.Response.Sepet.SepetUrunBilgileri { 
                  SepetNo=s.No,
                  Ad=s.Urun.Ad,
                  UrunNo = s.UrunNo,
                  EklemeTarih=s.EklemeTarih,
                  Fiyat =s.Urun.Fiyat
                }).ToList();

            return Liste;
        }
        public static void SepettenUrunSil(int SepetNo, int KullaniciNo)
        {
            DataBaseContext Model = new DataBaseContext();
            var SepetNesne = Model.Sepet.FirstOrDefault(f => f.No == SepetNo && f.KullaniciNo == KullaniciNo);

            if (SepetNesne != null)
            {
                Model.Sepet.Remove(SepetNesne);
                Model.SaveChanges();
            }



        }

        public static int SepetteKacUrunVar(int KullaniciNo)
        {
            DataBaseContext Model = new DataBaseContext();
            int Say = Model.Sepet.Where(q=> q.KullaniciNo == KullaniciNo).Count();  
            return Say;
        }

    }

    

}

using DataAccessLayer;
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

    }
}

using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class LoginService
    {
        public static DTO.Response.kullanici.KullaniciOturumBilgileri KullaniciDogrula(string KullaniciAd, string Parola)
        {
            DTO.Response.kullanici.KullaniciOturumBilgileri Nesne = new DTO.Response.kullanici.KullaniciOturumBilgileri();
            DataBaseContext Model = new DataBaseContext();
            Nesne = Model.Kullanici.Where(p => p.KullaniciAd == KullaniciAd && p.Parola == Parola).
                 Select(s=> new  DTO.Response.kullanici.KullaniciOturumBilgileri
                 { 
                     No= s.No,
                     Ad=s.Ad,
                     Soyad = s.Soyad,
                     RolNo=s.RolNo
                 }).FirstOrDefault();
            return Nesne;
        }
    }
}

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

        public static List<DTO.Response.Urun.UrunOzetBilgi> TumUrunListele()
        {
            DataBaseContext Model = new DataBaseContext();
            var Cevap = Model.Urun.ToList().Take(20)
                .Select(s=> new DTO.Response.Urun.UrunOzetBilgi { 
                     No = s.No,
                     Fiyat=s.Fiyat,
                     Ad=s.Ad,
                     ResimYol=s.ResimYol})       
                
                .ToList();
            return Cevap;
        }

        public static DTO.Response.Urun.UrunDetayBilgi UruNDetayGetir(DTO.Request.BaseRequest request)
        {
            DataBaseContext Model = new DataBaseContext();

            var Cevap = Model.Urun.Include("Kategori").Where(q => q.No == request.No)
                .Select(s => new DTO.Response.Urun.UrunDetayBilgi
                {
                    No = s.No,
                    Ad = s.Ad,
                    Baslik = s.Baslik,
                    Icerik = s.Icerik,
                    Fiyat = s.Fiyat,
                    Stok = s.Stok,
                    ResimYol = s.ResimYol,
                    KategoriAd = s.Kategori.Ad,
                    KategoriNo=s.KategoriNo
                }).FirstOrDefault();

            return Cevap;
        }

        public static List<DTO.Response.Urun.UrunOzetBilgi> KategoriyeaitUrunListele(DTO.Request.BaseRequest request)
        {
            DataBaseContext Model = new DataBaseContext();
            var Cevap = Model.Urun.Where(q=> q.KategoriNo == request.No)
                .Select(s => new DTO.Response.Urun.UrunOzetBilgi
                {
                    No = s.No,
                    Fiyat = s.Fiyat,
                    Ad = s.Ad,
                    ResimYol = s.ResimYol
                })

                .ToList();
            return Cevap;
        }

    }
}

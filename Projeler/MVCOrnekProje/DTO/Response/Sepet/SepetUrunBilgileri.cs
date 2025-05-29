using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Response.Sepet
{
    public class SepetUrunBilgileri
    {
        public int SepetNo { get; set; }
        public DateTime? EklemeTarih { get; set; }
        public int Fiyat { get; set; }
        public string Ad { get; set; }
        public int UrunNo { get; set; }

    }
}

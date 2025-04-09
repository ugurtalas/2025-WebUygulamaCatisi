﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Response.Urun
{
    public class UrunDetayBilgi
    {
        public int No { get; set; }
        public string Ad { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public int Fiyat { get; set; }
        public int Stok { get; set; }

        public string ResimYol { get; set; }

        public string KategoriAd { get; set; }
        public int KategoriNo { get; set; }
    }
}

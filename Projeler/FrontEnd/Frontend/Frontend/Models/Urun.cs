using System.ComponentModel.DataAnnotations.Schema;

namespace Frontend.Models
{
    public class Urun
    {
        public int no { get; set; }
        public string ad { get; set; }
        public string baslik { get; set; }
        public string icerik { get; set; }
        public string resimYol { get; set; }
        public int fiyat { get; set; }
        public int stok { get; set; }

      
        public int kategoriNo { get; set; }
       

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Urun
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int No { get; set; }
        public string Ad { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string ResimYol { get; set; }
        public int Fiyat { get; set; }
        public int Stok { get; set; }

        [ForeignKey("KategoriNo")]
        public int KategoriNo { get; set; }
        public Kategori Kategori { get; set; }

        public List<Yorum> Yorum { get; set; } = new List<Yorum>();
    }

}

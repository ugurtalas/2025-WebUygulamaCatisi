using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Sepet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int No { get; set; }
        [ForeignKey("KullaniciNo")]
        public int KullaniciNo { get; set; }

        public Kullanici Kullanici { get; set; }

        [ForeignKey("UrunNo")]
        public int UrunNo { get; set; }

        public Urun Urun { get; set; }

        public DateTime EklemeTarih { get; set; }

    
    }
}

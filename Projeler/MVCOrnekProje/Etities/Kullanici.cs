using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Kullanici
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int No { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAd { get; set; }
        public string Parola { get; set; }
        public string Adres { get; set; }
        public string Eposta { get; set; }

        [ForeignKey("RolNo")]
        public int RolNo { get; set; }

        public Rol Rol { get; set; }
    }
}

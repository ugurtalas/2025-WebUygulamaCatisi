using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Response.Siparis
{
    public class Siparis
    {

        public DateTime? EklemeTarih { get; set; }
        public int Fiyat { get; set; }
        public string Ad { get; set; }
        public string SiaprisDurum { get; set; }

    }
}

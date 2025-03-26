using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyDataGenerator.Generators
{
    public class SiparisDurum
    {
        public static void Generate()
        {
            DataBaseContext Model = new DataBaseContext();
            Model.SiparisDurum.Add(new  Entities.SiparisDurum { Ad="Yeni Sipariş" });
            Model.SiparisDurum.Add(new  Entities.SiparisDurum { Ad="Kargolandı" });
            Model.SiparisDurum.Add(new  Entities.SiparisDurum { Ad="Teslim Edildi" });
        
            Model.SaveChanges();
            
        }
    }
}

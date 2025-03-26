using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyDataGenerator.Generators
{
    public class Rol
    {
        public static void Generate()
        {
            DataBaseContext Model = new DataBaseContext();
            Model.Rol.Add(new  Entities.Rol { Ad="Admin" });
            Model.Rol.Add(new  Entities.Rol { Ad="Satıcı" });
            Model.Rol.Add(new  Entities.Rol { Ad="Müşteri" });
   
            Model.SaveChanges();
            
        }
    }
}

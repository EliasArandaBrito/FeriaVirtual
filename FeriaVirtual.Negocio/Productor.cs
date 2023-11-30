using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeriaVirtual.DALC;
namespace FeriaVirtual.Negocio
{
    public class Productor
    {
        public decimal ID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        FeriaVirtualEntities db = new FeriaVirtualEntities();

        public List<Productor> ReadAll()
        {
            return db.PRODUCTOR.Select(c => new Productor()
            { 
                ID = c.PRODUCTORID,
                Nombre = c.NOMBRE
            
            }).ToList();

        }

        
    }
}

using FeriaVirtual.DALC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Negocio
{
    public class Subasta
    {
        public decimal Subastaid { get; set; }
        public decimal Ventaid { get; set; }
        public Nullable<System.DateTime> Fechainicio { get; set; }
        public Nullable<System.DateTime> Fechatermino { get; set; }
        public Nullable<decimal> Ancho_min { get; set; }
        public Nullable<decimal> Largo_min { get; set; }
        public Nullable<decimal> Alto_min { get; set; }
        public Nullable<decimal> Capacidad { get; set; }
        public Nullable<short> Refrigerado { get; set; }
        public Nullable<short> Finished { get; set; }

        public SubastaMedio SubastaMedio { get; set; }
        public Venta Venta { get; set; }

        private readonly FeriaVirtualEntities db = new FeriaVirtualEntities();

        public List<Subasta> ReadAll()
        {
            try
            {
                return db.SUBASTA.Select(c => new Subasta
                {
                    Subastaid = c.SUBASTAID,
                    Ventaid = c.VENTAID,
                    Fechainicio = c.FECHAINICIO,
                    Fechatermino = c.FECHATERMINO,
                    Ancho_min = c.ANCHO_MIN,
                    Largo_min = c.LARGO_MIN,
                    Alto_min = c.ALTO_MIN,
                    Capacidad = c.CAPACIDAD,
                    Refrigerado = c.REFRIGERADO,
                    Finished = c.FINISHED,
                    SubastaMedio = new SubastaMedio(),
                    Venta = new Venta()
                }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener por ID: " + ex.Message);
                return null;
            }

        }

        public List<Subasta> ReadUnfinished()
        {
            try
            {
                return this.db.SUBASTA
                    .Where(c => c.FINISHED == 0)
                    .Select(c => new Subasta()
                    {
                        Subastaid = c.SUBASTAID,
                        Ventaid = c.VENTAID,
                        Fechainicio = c.FECHAINICIO,
                        Fechatermino = c.FECHATERMINO,
                        Ancho_min = c.ANCHO_MIN,
                        Largo_min = c.LARGO_MIN,
                        Alto_min = c.ALTO_MIN,
                        Capacidad = c.CAPACIDAD,
                        Refrigerado = c.REFRIGERADO,
                        Finished = c.FINISHED,
                        SubastaMedio = new SubastaMedio(),
                        Venta = new Venta()
                    }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener por ID: " + ex.Message);
                return null;
            }
        }

        public List<Subasta> ReadById(decimal Id)
        {
            try
            {
                return this.db.SUBASTA
                    .Where(c => c.SUBASTAID == Id)
                    .Select(c => new Subasta()
                    {
                        Subastaid = c.SUBASTAID,
                        Ventaid = c.VENTAID,
                        Fechainicio = c.FECHAINICIO,
                        Fechatermino = c.FECHATERMINO,
                        Ancho_min = c.ANCHO_MIN,
                        Largo_min = c.LARGO_MIN,
                        Alto_min = c.ALTO_MIN,
                        Capacidad = c.CAPACIDAD,
                        Refrigerado = c.REFRIGERADO,
                        Finished = c.FINISHED,
                        SubastaMedio = new SubastaMedio(),
                        Venta = new Venta()
                    }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener por ID: " + ex.Message);
                return null;
            }
        }

        public List<Subasta> ReadByTransportistaId(decimal Id)
        {
            try
            {
                var subastas = db.SUBASTA
                    .Join(db.SUBASTA_MEDIO, s => s.SUBASTAID, sm => sm.SUBASTAID, (s, sm) => new { s, sm })
                    .Join(db.MEDIOTRANSPORTE, joined => joined.sm.MEDIOID, m => m.MEDIOID, (joined, m) => new { joined.s, m })
                    .Join(db.TRANSPORTISTA, joined => joined.m.TRANSPORTISTAID, t => t.TRANSPORTISTAID, (joined, t) => new { joined.s, t })
                    .Where(joined => joined.t.TRANSPORTISTAID == Id)
                    .Select(joined => new Subasta
                    {
                        Subastaid = joined.s.SUBASTAID,
                        Ventaid = joined.s.VENTAID,
                        Fechainicio = joined.s.FECHAINICIO,
                        Fechatermino = joined.s.FECHATERMINO,
                        Ancho_min = joined.s.ANCHO_MIN,
                        Largo_min = joined.s.LARGO_MIN,
                        Alto_min = joined.s.ALTO_MIN,
                        Capacidad = joined.s.CAPACIDAD,
                        Refrigerado = joined.s.REFRIGERADO,
                        Finished = joined.s.FINISHED,
                        SubastaMedio = new SubastaMedio(),
                        Venta = new Venta()
                    })
                    .Distinct()
                    .ToList();

                return subastas;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving subastas: " + ex.Message);
                return null;
            }
        }
    }
}

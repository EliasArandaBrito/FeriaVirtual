using FeriaVirtual.DALC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Negocio
{
   public class Transporte
    {
        public decimal TransporteID { get; set; }
        public string TipoTransporte { get; set; }
        public Nullable<System.DateTime> FechaTransporte { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string EstadoTransporte { get; set; }
        public decimal MedioID { get; set; }

        public MedioTransporte MedioTransporte { get; set; }
        public Venta Venta { get; set; }

        private readonly FeriaVirtualEntities db = new FeriaVirtualEntities();

        public List<Transporte> ReadAll()
        {
            try
            {
                return db.TRANSPORTE.Select(c => new Transporte
                {
                    TransporteID = c.TRANSPORTEID,
                    TipoTransporte = c.TIPOTRANSPORTE,
                    FechaTransporte = c.FECHATRANSPORTE,
                    Origen = c.ORIGEN,
                    Destino = c.DESTINO,
                    EstadoTransporte = c.ESTADOTRANSPORTE,
                    MedioID = c.MEDIOID,
                    MedioTransporte = new MedioTransporte(),
                    Venta = new Venta()
                }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener datos: " + ex.Message);
                return null;
            }
            
        }

        public List<Transporte> ReadById(decimal Id)
        {
            try
            {
                return this.db.TRANSPORTE
                    .Where(c => c.TRANSPORTEID == Id)
                    .Select(c => new Transporte()
                    {
                        TransporteID = c.TRANSPORTEID,
                        TipoTransporte = c.TIPOTRANSPORTE,
                        FechaTransporte = c.FECHATRANSPORTE,
                        Origen = c.ORIGEN,
                        Destino = c.DESTINO,
                        EstadoTransporte = c.ESTADOTRANSPORTE,
                        MedioID = c.MEDIOID,
                        MedioTransporte = new MedioTransporte(),
                        Venta = new Venta()
                    }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener por ID: " + ex.Message);
                return null;
            }
        }

        public List<Transporte> ReadByMedioId(decimal Id)
        {
            try
            {
                return this.db.TRANSPORTE
                    .Where(c => c.MEDIOID == Id)
                    .Select(c => new Transporte()
                    {
                        TransporteID = c.TRANSPORTEID,
                        TipoTransporte = c.TIPOTRANSPORTE,
                        FechaTransporte = c.FECHATRANSPORTE,
                        Origen = c.ORIGEN,
                        Destino = c.DESTINO,
                        EstadoTransporte = c.ESTADOTRANSPORTE,
                        MedioID = c.MEDIOID,
                        MedioTransporte = new MedioTransporte(),
                        Venta = new Venta()
                    }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener por ID: " + ex.Message);
                return null;
            }
        }

        public List<Transporte> ReadByTransportistaId(decimal Id)
        {
            try
            {
                var transportes = db.TRANSPORTE
                    .Join(db.MEDIOTRANSPORTE, t => t.MEDIOID, m => m.MEDIOID, (t, m) => new { t, m })
                    .Where(joined => joined.m.TRANSPORTISTAID == Id)
                    .Select(joined => new Transporte
                    {
                        TransporteID = joined.t.TRANSPORTEID,
                        TipoTransporte = joined.t.TIPOTRANSPORTE,
                        FechaTransporte = joined.t.FECHATRANSPORTE,
                        Origen = joined.t.ORIGEN,
                        Destino = joined.t.DESTINO,
                        EstadoTransporte = joined.t.ESTADOTRANSPORTE,
                        MedioID = joined.t.MEDIOID,
                        MedioTransporte = new MedioTransporte(),
                        Venta = new Venta()
                    })
                    .ToList();

                return transportes;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving transportes: " + ex.Message);
                return null;
            }
        }

        public List<Transporte> ReadByVentaId(decimal Id)
        {
            try
            {
                var transportes = db.TRANSPORTE
                    .Join(db.VENTAS, t => t.TRANSPORTEID, v => v.TRANSPORTEID, (t, v) => new { t, v })
                    .Where(joined => joined.v.VENTAID == Id)
                    .Select(joined => new Transporte
                    {
                        TransporteID = joined.t.TRANSPORTEID,
                        TipoTransporte = joined.t.TIPOTRANSPORTE,
                        FechaTransporte = joined.t.FECHATRANSPORTE,
                        Origen = joined.t.ORIGEN,
                        Destino = joined.t.DESTINO,
                        EstadoTransporte = joined.t.ESTADOTRANSPORTE,
                        MedioID = joined.t.MEDIOID,
                        MedioTransporte = new MedioTransporte(),
                        Venta = new Venta()
                    })
                    .ToList();

                return transportes;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving transportes: " + ex.Message);
                return null;
            }
        }

        public List<Transporte> ReadByClientId(decimal Id)
        {
            try
            {
                var transportes = db.TRANSPORTE
                    .Join(db.VENTAS, t => t.TRANSPORTEID, v => v.TRANSPORTEID, (t, v) => new { t, v })
                    .Where(joined => joined.v.CLIENTEID == Id)
                    .Select(joined => new Transporte
                    {
                        TransporteID = joined.t.TRANSPORTEID,
                        TipoTransporte = joined.t.TIPOTRANSPORTE,
                        FechaTransporte = joined.t.FECHATRANSPORTE,
                        Origen = joined.t.ORIGEN,
                        Destino = joined.t.DESTINO,
                        EstadoTransporte = joined.t.ESTADOTRANSPORTE,
                        MedioID = joined.t.MEDIOID,
                        MedioTransporte = new MedioTransporte(),
                        Venta = new Venta()
                    })
                    .ToList();

                return transportes;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving transportes: " + ex.Message);
                return null;
            }
        }

        public bool UpdateEstado(int transporteId, string nuevoEstado)
        {
            try
            {
                var transporte = db.TRANSPORTE.Find(transporteId);

                if (transporte != null)
                {
                    transporte.ESTADOTRANSPORTE = nuevoEstado;
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating estado: " + ex.Message);
                // Handle the exception as needed
                return false;
            }
        }
    }
}

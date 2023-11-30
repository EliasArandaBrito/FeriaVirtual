using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeriaVirtual.DALC;

namespace FeriaVirtual.Negocio
{
    public class MedioTransporte
    {
        public decimal ID { get; set; }
        public string Patente { get; set; }
        public decimal Ancho { get; set; }
        public decimal Largo { get; set; }
        public decimal Alto { get; set; }
        public decimal Capacidad { get; set; }
        public decimal Refrigerado { get; set; }
        public decimal Precio { get; set; }

        public decimal IDTransportista { get; set; }

        public Transportista Transportista { get; set; }

        FeriaVirtualEntities db = new FeriaVirtualEntities();

        public List<MedioTransporte> ReadByIdAndNotInSubasta(decimal transportistaId, decimal subastaId)
        {
            try
            {
                var medios = this.db.MEDIOTRANSPORTE
                    .Where(m =>
                        m.TRANSPORTISTAID == transportistaId &&
                        !db.SUBASTA_MEDIO.Any(sm => sm.SUBASTAID == subastaId && sm.MEDIOID == m.MEDIOID)
                    )
                    .Select(m => new MedioTransporte()
                    {
                        ID = m.MEDIOID,
                        Patente = m.PATENTE,
                        Ancho = m.ANCHO,
                        Largo = m.LARGO,
                        Alto = m.ALTO,
                        Capacidad = (decimal)m.CAPACIDAD,
                        Refrigerado = (decimal)m.REFRIGERADO,
                        Precio = (decimal)m.PRECIO,
                        IDTransportista = m.TRANSPORTISTAID,
                        Transportista = new Transportista()
                    })
                    .ToList();

                return medios;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving medios: " + ex.Message);
                return null;
            }
        }

        public List<MedioTransporte> ReadById(decimal Id)
        {
            try
            {
                return this.db.MEDIOTRANSPORTE
                    .Where(p => p.TRANSPORTISTAID == Id)
                    .Select(p => new MedioTransporte()
                    {
                        ID = p.MEDIOID,
                        Patente = p.PATENTE,
                        Ancho = p.ANCHO,
                        Largo = p.LARGO,
                        Alto = p.ALTO,
                        Capacidad = (decimal)p.CAPACIDAD,
                        Refrigerado = (decimal)p.REFRIGERADO,
                        Precio = (decimal)p.PRECIO,
                        IDTransportista = p.TRANSPORTISTAID,
                        Transportista = new Transportista()
                    }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener por ID: " + ex.Message);
                return null;
            }
        }

        public List<MedioTransporte> ReadByMedioId(decimal Id)
        {
            try
            {
                return this.db.MEDIOTRANSPORTE
                    .Where(p => p.MEDIOID == Id)
                    .Select(p => new MedioTransporte()
                    {
                        ID = p.MEDIOID,
                        Patente = p.PATENTE,
                        Ancho = p.ANCHO,
                        Largo = p.LARGO,
                        Alto = p.ALTO,
                        Capacidad = (decimal)p.CAPACIDAD,
                        Refrigerado = (decimal)p.REFRIGERADO,
                        Precio = (decimal)p.PRECIO,
                        IDTransportista = p.TRANSPORTISTAID,
                        Transportista = new Transportista()
                    }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener por ID: " + ex.Message);
                return null;
            }
        }

        public List<MedioTransporte> ReadAll()
        {
            return this.db.MEDIOTRANSPORTE.Select(p => new MedioTransporte()
            {
            ID = p.MEDIOID,
            Patente = p.PATENTE,
            Ancho = p.ANCHO,
            Largo = p.LARGO,
            Alto = p.ALTO,
            Capacidad = (decimal)p.CAPACIDAD,
            Refrigerado = (decimal)p.REFRIGERADO,
            Precio = (decimal)p.PRECIO,
            IDTransportista = p.TRANSPORTISTAID,
            Transportista = new Transportista()
            }).ToList();
        }

        public bool Save()
        {
            try
            {


                // Llama al procedimiento almacenado
                db.INSERT_MEDIOTRANSPORTE(this.Patente, this.Ancho, this.Largo, this.Alto, this.Precio, this.Capacidad, this.Refrigerado, this.IDTransportista);



                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al guardar: " + ex.Message);

                return false;
            }
        }

        public bool Delete()
        {
            try
            {
                var medioTransporte = db.MEDIOTRANSPORTE.FirstOrDefault(p => p.MEDIOID == this.ID);

                if (medioTransporte != null)
                {
                    db.MEDIOTRANSPORTE.Remove(medioTransporte);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar: " + ex.Message);
                return false;
            }
        }
    }
}

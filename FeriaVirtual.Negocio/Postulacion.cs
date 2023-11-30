using FeriaVirtual.DALC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Negocio
{
    public class Postulacion
    {

        public decimal Postulacionid { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public Nullable<decimal> Cantidad { get; set; }
        public DateTime? Fechacosecha { get; set; }
        public decimal Contratoid { get; set; }
        public decimal Productorid { get; set; }
        public Nullable<short> Selected { get; set; }

        public Productor Productor { get; set; }
        public Contratos Contratos { get; set; }

       FeriaVirtualEntities db = new FeriaVirtualEntities();


        public List<Postulacion> ReadByContratoId(decimal contratoId)
        {
            try
            {
                return db.POSTULACION
                    .Where(p => p.CONTRATOID == contratoId)
                    .Select(p => new Postulacion()
                    {
                        Postulacionid = p.POSTULACIONID,
                        Precio = p.PRECIO,
                        Cantidad = p.CANTIDAD,
                        Fechacosecha = p.FECHACOSECHA,
                        Contratoid = p.CONTRATOID,
                        Contratos = new Contratos()
                        {
                          Contratoid = p.CONTRATOID,
                        },
                        Productorid = p.PRODUCTORID,
                        Productor = new Productor()
                        {
                            ID = p.PRODUCTORID
                        },
                        Selected = p.SELECTED
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener por ID de contrato: " + ex.Message);
                return null;
            }
        }

        public List<Postulacion> ReadByProductorId(decimal Productorid)
        {
            try
            {
                return db.POSTULACION
                    .Where(p => p.PRODUCTORID == Productorid)
                    .Select(p => new Postulacion()
                    {
                        Postulacionid = p.POSTULACIONID,
                        Precio = p.PRECIO,
                        Cantidad = p.CANTIDAD,
                        Fechacosecha = p.FECHACOSECHA,
                        Contratoid = p.CONTRATOID,
                        Contratos = new Contratos()
                        {
                            Contratoid = p.CONTRATOID,
                        },
                        Productorid = p.PRODUCTORID,
                        Productor = new Productor()
                        {
                            ID = p.PRODUCTORID
                        },
                        Selected = p.SELECTED
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener por ID de productor: " + ex.Message);
                return null;
            }
        }

        public List<Postulacion> ReadAll()
        {
            try
            {
                return db.POSTULACION.Select(p => new Postulacion()
                    {
                        Postulacionid = p.POSTULACIONID,
                        Precio = p.PRECIO,
                        Cantidad = p.CANTIDAD,
                        Fechacosecha = p.FECHACOSECHA,
                        Contratoid = p.CONTRATOID,
                        Contratos = new Contratos()
                        {
                            Contratoid = p.CONTRATOID,
                        },
                        Productorid = p.PRODUCTORID,
                        Productor = new Productor()
                        {
                            ID = p.PRODUCTORID
                        },
                        Selected = p.SELECTED
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los datos de las postulaciones: " + ex.Message);
                return null;
            }
        }

        public bool Save()
        {
            try
            {
                // Llama al procedimiento almacenado
                db.INSERT_POSTULACION(
                    this.Precio,
                    this.Cantidad,
                    this.Fechacosecha,
                    this.Contratoid,
                    this.Productorid           
                );

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
                var postulacionAEliminar = db.POSTULACION.FirstOrDefault(p => p.POSTULACIONID == this.Postulacionid);

                if (postulacionAEliminar != null)
                {
                    db.POSTULACION.Remove(postulacionAEliminar);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar la postulación: " + ex.Message);
                return false;
            }
        }

        public bool Select(decimal id, int selectedValue)
        {
            try
            {
                var postulacionesToUpdate = db.POSTULACION
                    .Where(p => p.POSTULACIONID == id)
                    .ToList();

                foreach (var postulacion in postulacionesToUpdate)
                {
                    postulacion.SELECTED = (short)selectedValue;
                }

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el campo Selected: " + ex.Message);
                return false;
            }
        }

    }
}

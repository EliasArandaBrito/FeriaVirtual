using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeriaVirtual.DALC;

namespace FeriaVirtual.Negocio
{
    public class Productos
    {
        public decimal ID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public decimal Stock { get; set; }
        public decimal IDProductor { get; set; }

        public Productor Productor { get; set; }

        FeriaVirtualEntities db = new FeriaVirtualEntities();

        public List<Productos> ReadByProductorId(decimal productorId)
        {
            try
            {
                return this.db.PRODUCTOS
                    .Where(p => p.PRODUCTORID == productorId)
                    .Select(p => new Productos()
                    {
                        ID = (decimal)p.PRODUCTOID,
                        Nombre = p.NOMBRE,
                        Precio = (decimal)p.PRECIO,
                        Stock = (decimal)p.STOCK,
                        IDProductor = (decimal)p.PRODUCTORID,
                        Productor = new Productor()
                        {
                            ID = (decimal)p.PRODUCTORID,
                            Nombre = p.PRODUCTOR.NOMBRE
                        }
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener por ID de productor: " + ex.Message);
                return null; 
            }
        }

        public List<Productos> ReadAll()
        {
            return this.db.PRODUCTOS.Select(p => new Productos()
            {
                ID = (decimal)p.PRODUCTOID,
                Nombre = p.NOMBRE,
                Precio = (decimal)p.PRECIO,
                Stock = (decimal)p.STOCK,
                IDProductor = (decimal)p.PRODUCTORID,
                Productor = new Productor()
                {
                    ID = (decimal)p.PRODUCTORID,
                    Nombre = p.PRODUCTOR.NOMBRE
                }
            }).ToList();
        }

        

        public bool Save()
        {
            try
            {


                // Llama al procedimiento almacenado
                db.INSERT_PRODUCTO(this.Nombre, this.Precio, this.Stock, this.IDProductor);



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
                var producto = db.PRODUCTOS.FirstOrDefault(p => p.PRODUCTOID == this.ID);

                if (producto != null)
                {
                    db.PRODUCTOS.Remove(producto);
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
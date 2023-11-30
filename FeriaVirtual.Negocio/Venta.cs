using FeriaVirtual.DALC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Negocio
{
    public class Venta
    {
        public decimal Ventaid { get; set; }
        public string Tipoventa { get; set; }
        public System.DateTime Fechaventa { get; set; }
        public decimal Totalventa { get; set; }
        public Nullable<decimal> Estadoventaid { get; set; }
        public Nullable<decimal> Transporteid { get; set; }
        public decimal Productorid { get; set; }
        public Nullable<decimal> Clienteid { get; set; }

        public EstadoVenta EstadoVenta { get; set; }

  

        public Transporte Transporte { get; set; }
        public  Productor Productor { get; set; }
        public Cliente Cliente { get; set; }

        private readonly FeriaVirtualEntities db = new FeriaVirtualEntities();

        public bool UpdateEstadoVentaid(decimal p_ventaid, decimal p_estadoventaid)
        {
            try
            {
                var venta = db.VENTAS.FirstOrDefault(v => v.VENTAID == p_ventaid);

                if (venta != null)
                {
                    venta.ESTADOVENTAID = p_estadoventaid;

                    db.SaveChanges(); // This commits the changes
                    
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating venta: " + ex.Message);
                // Handle the exception as needed
                return true;
            }
        }

        public List<Venta> ReadAll()
        {
            try
            {
                return db.VENTAS.Select(c => new Venta
                {
                    Ventaid = c.VENTAID,
                    Tipoventa = c.TIPOVENTA,
                    Fechaventa = c.FECHAVENTA,
                    Totalventa = c.TOTALVENTA,
                    Estadoventaid = c.ESTADOVENTAID,
                    Transporteid = c.TRANSPORTEID,
                    Productorid = c.PRODUCTORID,
                    Clienteid = c.CLIENTEID,
                    EstadoVenta = new EstadoVenta()
                    {
                        Estadoventaid = c.ESTADOVENTA.ESTADOVENTAID,
                        Nombreestadoventa = c.ESTADOVENTA.NOMBREESTADOVENTA
                    },
                    Transporte = new Transporte(),
                    Productor = new Productor()
                    {
                        ID = c.PRODUCTOR.PRODUCTORID,
                        Nombre = c.PRODUCTOR.NOMBRE,
                        Direccion = c.PRODUCTOR.DIRECCION,
                        Correo = c.PRODUCTOR.CORREO
                    },
                    Cliente = new Cliente()
                    {
                        Id = c.CLIENTE.CLIENTEID,
                        Nombre = c.CLIENTE.NOMBRE
                    }
                }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener por ID: " + ex.Message);
                return null;
            }
            
        }

        public List<Venta> ReadById(decimal Id)
        {
            try
            {
                return this.db.VENTAS
                    .Where(c => c.VENTAID == Id)
                    .Select(c => new Venta()
                    {
                        Ventaid = c.VENTAID,
                        Tipoventa = c.TIPOVENTA,
                        Fechaventa = c.FECHAVENTA,
                        Totalventa = c.TOTALVENTA,
                        Estadoventaid = c.ESTADOVENTAID,
                        Transporteid = c.TRANSPORTEID,
                        Productorid = c.PRODUCTORID,
                        Clienteid = c.CLIENTEID,
                        EstadoVenta = new EstadoVenta()
                        {
                            Estadoventaid = c.ESTADOVENTA.ESTADOVENTAID,
                            Nombreestadoventa = c.ESTADOVENTA.NOMBREESTADOVENTA
                        },
                        Transporte = new Transporte(),
                        Productor = new Productor(),
                        Cliente = new Cliente()
                    }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener por ID: " + ex.Message);
                return null;
            }
        }

        public List<Venta> ReadByProductorId(decimal Id)
        {
            try
            {
                return this.db.VENTAS
                    .Where(c => c.PRODUCTORID == Id)
                    .Select(c => new Venta()
                    {
                        Ventaid = c.VENTAID,
                        Tipoventa = c.TIPOVENTA,
                        Fechaventa = c.FECHAVENTA,
                        Totalventa = c.TOTALVENTA,
                        Estadoventaid = c.ESTADOVENTAID,
                        Transporteid = c.TRANSPORTEID,
                        Productorid = c.PRODUCTORID,
                        Clienteid = c.CLIENTEID,
                        EstadoVenta = new EstadoVenta()
                        {
                            Estadoventaid = c.ESTADOVENTA.ESTADOVENTAID,
                            Nombreestadoventa = c.ESTADOVENTA.NOMBREESTADOVENTA
                        },
                        Transporte = new Transporte(),
                        Productor = new Productor(),
                        Cliente = new Cliente()
                    }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener por ID: " + ex.Message);
                return null;
            }


        }

        public List<Venta> ReadByClienteId(decimal Id)
        {
            

            try
            {
                return this.db.VENTAS
                    .Where(c => c.CLIENTEID == Id)
                    .Select(c => new Venta()
                    {
                        Ventaid = c.VENTAID,
                        Tipoventa = c.TIPOVENTA,
                        Fechaventa = c.FECHAVENTA,
                        Totalventa = c.TOTALVENTA,
                        Estadoventaid = c.ESTADOVENTAID,
                        Transporteid = c.TRANSPORTEID,
                        Productorid = c.PRODUCTORID,
                        Clienteid = c.CLIENTEID,
                        EstadoVenta = new EstadoVenta()
                        {
                            Estadoventaid = c.ESTADOVENTA.ESTADOVENTAID,
                            Nombreestadoventa = c.ESTADOVENTA.NOMBREESTADOVENTA
                        },
                        Transporte = new Transporte(),
                        Productor = new Productor(),
                        Cliente = new Cliente()
                    }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener por ID: " + ex.Message);
                return null;
            }

        }

        public List<Venta> ReadByTransporteId(decimal Id)
        {
            try
            {
                return this.db.VENTAS
                    .Where(c => c.TRANSPORTEID == Id)
                    .Select(c => new Venta()
                    {
                        Ventaid = c.VENTAID,
                        Tipoventa = c.TIPOVENTA,
                        Fechaventa = c.FECHAVENTA,
                        Totalventa = c.TOTALVENTA,
                        Estadoventaid = c.ESTADOVENTAID,
                        Transporteid = c.TRANSPORTEID,
                        Productorid = c.PRODUCTORID,
                        Clienteid = c.CLIENTEID,
                        EstadoVenta = new EstadoVenta()
                        {
                            Estadoventaid = c.ESTADOVENTA.ESTADOVENTAID,
                            Nombreestadoventa = c.ESTADOVENTA.NOMBREESTADOVENTA
                        },
                        Transporte = new Transporte(),
                        Productor = new Productor(),
                        Cliente = new Cliente()
                    }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener por ID: " + ex.Message);
                return null;
            }


        }

        public List<Venta> ReadPublished()
        {
            try
            {
                return this.db.VENTAS
                    .Where(c => c.ESTADOVENTAID == 4 && c.TIPOVENTA == "Venta Interna")
                    .Select(c => new Venta()
                    {
                        Ventaid = c.VENTAID,
                        Tipoventa = c.TIPOVENTA,
                        Fechaventa = c.FECHAVENTA,
                        Totalventa = c.TOTALVENTA,
                        Estadoventaid = c.ESTADOVENTAID,
                        Transporteid = c.TRANSPORTEID,
                        Productorid = c.PRODUCTORID,
                        Clienteid = c.CLIENTEID,
                        EstadoVenta = new EstadoVenta()
                        {
                            Estadoventaid = c.ESTADOVENTA.ESTADOVENTAID,
                            Nombreestadoventa = c.ESTADOVENTA.NOMBREESTADOVENTA
                        },
                        Transporte = new Transporte(),
                        Productor = new Productor(),
                        Cliente = new Cliente()
                    }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener por ID: " + ex.Message);
                return null;
            }


        }

        public List<VentaDetails> ReadDetailVentas()
        {
            try
            {
                var ventasInternas = db.VENTAS
                    .Where(v => v.TIPOVENTA == "Venta Interna" && v.ESTADOVENTAID == 4 && v.CLIENTEID == null)
                    .Join(db.VENTA_PRODUCTO, v => v.VENTAID, vp => vp.VENTAID, (v, vp) => new { v, vp })
                    .Join(db.PRODUCTOS, joined => joined.vp.PRODUCTOID, p => p.PRODUCTOID, (joined, p) => new { joined.v, joined.vp, p })
                    .Select(joined => new VentaDetails
                    {
                        VentaId = joined.v.VENTAID,
                        TipoVenta = joined.v.TIPOVENTA,
                        TotalVenta = joined.v.TOTALVENTA,
                        FechaVenta = joined.v.FECHAVENTA,
                        EstadoVentaId = joined.v.ESTADOVENTAID,
                        TransporteId = joined.v.TRANSPORTEID,
                        ProductorId = joined.v.PRODUCTORID,
                        ClienteId = joined.v.CLIENTEID,
                        Cantidad = joined.vp.CANTIDAD,
                        ProductoNombre = joined.p.NOMBRE,
                        Precio = joined.p.PRECIO
                    })
                    .Distinct()
                    .ToList();

                return ventasInternas;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving distinct Ventas Internas: " + ex.Message);
                return null;
            }
        }

        public bool SolicitarVenta(decimal ventaId, decimal ClienteId)
        {
            try
            {
                var ventaToUpdate = db.VENTAS.FirstOrDefault(v => v.VENTAID == ventaId);

                if (ventaToUpdate != null)
                {
                    ventaToUpdate.CLIENTEID = ClienteId;
                    db.SaveChanges(); // This will commit the changes to the database
                    return true;
                }

                return false; // Return false if the venta with the specified ID is not found
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating Venta ClienteId: " + ex.Message);
                return false;
            }
        }

        public decimal ObtenerPrecioProducto(decimal ventaId)
        {
            decimal precioProducto = 0; // Valor por defecto

            try
            {
                // Aquí realizamos la consulta para obtener el precio del producto
                var venta = db.VENTAS.FirstOrDefault(v => v.VENTAID == ventaId);

                if (venta != null)
                {
                    precioProducto = venta.TOTALVENTA;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el precio del producto: " + ex.Message);
                // Manejo del error, podrías lanzar una excepción o manejarlo según tu lógica
            }

            return precioProducto;
        }

       
    }

}

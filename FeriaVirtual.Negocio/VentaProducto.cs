using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Negocio
{
    public class VentaProducto
    {
        public decimal VentaId { get; set; }
        public decimal ProductoId { get; set; }
        public Nullable<decimal> Cantidad { get; set; }
    
        public Productos Producto { get; set; }
        public Venta Venta { get; set; }
    }
}

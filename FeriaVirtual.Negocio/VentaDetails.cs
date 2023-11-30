using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Negocio
{
    public class VentaDetails
    {
        public decimal VentaId { get; set; }
        public string TipoVenta { get; set; }
        public decimal? TotalVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal? EstadoVentaId { get; set; }
        public decimal? TransporteId { get; set; }
        public decimal ProductorId { get; set; }
        public decimal? ClienteId { get; set; }
        public decimal? Cantidad { get; set; }
        public string ProductoNombre { get; set; }
        public decimal Precio { get; set; }


    }
}

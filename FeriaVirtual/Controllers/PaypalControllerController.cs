using System;
using System.Web.Mvc;
using FeriaVirtual.Negocio;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeriaVirtual.Controllers
{
    public class PayPalController : Controller
    {
        // Acción para iniciar el pago
        public ActionResult StartPayment()
        {

            // Supongamos que tienes el ID de la venta almacenado en algún lugar
            // Método ficticio para obtener el ID de la venta HAY QUE HACER EL SESSION

            


            // Creamos una instancia de la clase Venta para acceder al método ObtenerPrecioProducto
            var venta = new Venta().ReadById((int)Session["VentaID"]).FirstOrDefault();
            Session["Monto"] = venta.Totalventa;
            Session["FinishedVenta"] = 0;
            decimal precioProducto = venta.Totalventa; //No se como aplicar el session xd

            // Configuramos el modelo PayPalPayment con el precio del producto
            var payment = new PayPalPayment
            {
                Monto = precioProducto // Asignamos el precio al modelo PayPalPayment
                                       // ... Otras configuraciones ...
            };

            // Retornamos la vista con el botón de PayPal para iniciar el pago
            return View(payment);
        }


        private decimal ObtenerVentaId()
        {
            //ESTE ES EL MÉTODO PARA DEOLVER EL SESSION ID
            // var ventaId = //Aquí va el session id que arrasta la pagina anterior;
            // return ventaId;

            // En este ejemplo ficticio, simplemente retornamos un valor arbitrario
            // return ventaId;

            return 1;
        }

        // Acción para procesar la confirmación del pago
        public ActionResult ConfirmPayment(string paymentId, string token, string PayerID)
        {
            if(paymentId != null)
            {
                Venta v = new Venta();
                v.UpdateEstadoVentaid((int)Session["VentaID"], 3);
            }
            
            // Procesa la confirmación del pago recibida de PayPal
            // Actualiza el estado del pedido en tu sistema

            return View();
        }
    }
}

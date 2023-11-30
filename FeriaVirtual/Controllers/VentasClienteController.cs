using FeriaVirtual.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeriaVirtual.Controllers
{
    public class VentasClienteController : Controller
    {
        // GET: VentasCliente
        public ActionResult Index()
        {
            
            ViewBag.ventas = new Venta().ReadByClienteId((decimal)Session["UserID"]);
            return View();
        }

        public ActionResult IndexBuy()
        {

            ViewBag.ventasd = new Venta().ReadDetailVentas();
            return View();
        }

        // GET: VentasCliente/Details/5
        public ActionResult Details(int id)
        {
            Venta v = new Venta();
            try
            {
                    if (v.SolicitarVenta(id, (decimal)Session["UserID"]))
                    {
                        TempData["SolicitarVenta"] = "Venta agregada exitosamente";
                        return RedirectToAction("IndexBuy");
                    }
                    else
                    {
                        TempData["SolicitarVenta"] = "Error al agregar la venta.";
                    }


                return RedirectToAction("IndexBuy");
            }
            catch (Exception ex)
            {
                TempData["SolicitarVenta"] = "Error al agregar la venta: " + ex.Message;
                return RedirectToAction("IndexBuy");
            }
        }


        public ActionResult Cancel(int id)
        {
            Venta v = new Venta();
            try
            {
                v.UpdateEstadoVentaid(id, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return RedirectToAction("Index");
        }

        // POST: VentasCliente/Delete/5
        [HttpPost]
        public ActionResult Cancel(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Pay(int id)
        {
            Session["VentaID"] = id;
            return RedirectToAction("StartPayment", "PayPal");
        }

        // POST: VentasCliente/Delete/5
        [HttpPost]
        public ActionResult Pay(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

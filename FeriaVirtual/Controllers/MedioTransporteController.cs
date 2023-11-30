using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FeriaVirtual.Negocio;
namespace FeriaVirtual.Controllers
{
    public class MedioTransporteController : Controller
    {
        // GET: MedioTransporte
        public ActionResult Index()
        {

            ViewBag.MedioTransporte = new MedioTransporte().ReadById((decimal)Session["UserID"]);

            return View();
        }

        // GET: MedioTransporte/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MedioTransporte/Create
        public ActionResult Create()
        {
            //EnviarTransportistas();

            return View();
        }

        /*
        private void EnviarTransportistas()
        {
            ViewBag.transportista = new Transportista().ReadById((decimal)Session["UserID"]);

        }
        */

        // POST: MedioTransporte/Create
        [HttpPost]
        public ActionResult Create(MedioTransporte medioTransporte)
        {
            try
            {
                // TODO: Add insert logic here
                
                medioTransporte.Save();
               
                TempData["MedioTransporteAgregado"] = "Producto agregado exitosamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MedioTransporte/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MedioTransporte/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MedioTransporte/Delete/5
        public ActionResult Delete(int id)
        {
            MedioTransporte medioTransporte = new MedioTransporte { ID = id };

            if (medioTransporte.Delete())
            {
                TempData["MedioTransporteEliminado"] = "Medio de transporte eliminado exitosamente";
            }
            else
            {
                TempData["Mensaje"] = "Error al eliminar el medio de transporte.";
            }

            return RedirectToAction("Index");
        }

        // POST: MedioTransporte/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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

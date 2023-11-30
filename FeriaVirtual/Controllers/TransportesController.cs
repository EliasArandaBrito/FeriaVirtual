using FeriaVirtual.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeriaVirtual.Controllers
{
    public class TransportesController : Controller
    {
        // GET: Transportes
        public ActionResult Index()
        {
            ViewBag.transportes = new Transporte().ReadByTransportistaId((decimal)Session["UserID"]);
            return View();
        }
        public ActionResult IndexClient()
        {
            ViewBag.transportes = new Transporte().ReadByClientId((decimal)Session["UserID"]);
            return View();
        }


        // GET: Transportes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Transportes/Create
        public ActionResult Create(int id)
        {
            Session["TransporteID"] = id;
            return View();
        }

        // POST: Transportes/Create
        [HttpPost]
        public ActionResult Create(string estado)
        {
            Transporte t = new Transporte();
            t.TransporteID = (int)Session["TransporteID"];
            try
            {
                // TODO: Add insert logic here
                t.UpdateEstado((int)t.TransporteID, estado);
                TempData["TransporteStatus"] = "Transporte cambiado exitosamente";


                return RedirectToAction("Index");
            }
            catch
            {
                return View(estado);
            }
        }

        // GET: Transportes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Transportes/Edit/5
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

        // GET: Transportes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Transportes/Delete/5
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

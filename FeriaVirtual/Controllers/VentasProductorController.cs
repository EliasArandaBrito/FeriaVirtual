using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FeriaVirtual.Negocio;

namespace FeriaVirtual.Controllers
{
    public class VentasProductorController : Controller
    {
        // GET: VentasProductor
        public ActionResult Index()
        {

            ViewBag.ventas = new Venta().ReadByProductorId((decimal)Session["UserID"]);
            return View();
        }

        // GET: VentasProductor/Details
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VentasProductor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VentasProductor/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: VentasProductor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VentasProductor/Edit/5
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

        // GET: VentasProductor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VentasProductor/Delete/5
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

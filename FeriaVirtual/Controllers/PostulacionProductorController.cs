using FeriaVirtual.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeriaVirtual.Controllers
{
    public class PostulacionProductorController : Controller
    {
        // GET: PostulacionProductor
        public ActionResult Index()
        {
            Contratos contrato = new Contratos();
            ViewBag.Contratos = contrato.ReadPublished();
            return View();
        }


        // GET: PostulacionProductor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostulacionProductor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostulacionProductor/Create
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

        // GET: PostulacionProductor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PostulacionProductor/Edit/5
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

        // GET: PostulacionProductor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PostulacionProductor/Delete/5
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

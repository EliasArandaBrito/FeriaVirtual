using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FeriaVirtual.Negocio;

namespace FeriaVirtual.Controllers
{

    public class ProductosController : Controller
    {
        [UserTypeAuthorize("productor")]
        // GET: Productos
        public ActionResult Index()
        {
            ViewBag.productos = new Productos().ReadByProductorId((decimal)Session["UserID"]);
            return View();
        }

        // GET: Productos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            //EnviarProductor();
            return View();
        }

        /*
        private void EnviarProductor()
        {
            ViewBag.productor = new Productor().ReadAll();
        }
        */

        // POST: Productos/Create
        [HttpPost]
        public ActionResult Create(Productos productos)
        {
            try
            {
                // TODO: Add insert logic here
                productos.Save();
                TempData["ProductoAgregado"] = "Producto agregado exitosamente";


                return RedirectToAction("Index");
            }
            catch
            {
                return View(productos);
            }
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Productos/Edit/5
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

        // GET: Productos/Delete/5
        public ActionResult Delete(int id)
        {
            Productos producto = new Productos { ID = id };

            if (producto.Delete())
            {
                TempData["ProductoEliminado"] = "Producto eliminado exitosamente";
            }
            else
            {
                TempData["Mensaje"] = "Error al eliminar el producto.";
            }

            return RedirectToAction("Index");
        }

        // POST: Productos/Delete/5
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

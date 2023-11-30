using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FeriaVirtual.Negocio;

namespace FeriaVirtual.Controllers
{
    public class PostulacionController : Controller
    {
        // GET: Postulacion
        public ActionResult Index()
        {
            Postulacion postulacion = new Postulacion();
            ViewBag.Postulaciones = postulacion.ReadByProductorId((decimal)Session["UserID"]);
            return View();
        }

        // GET: Postulacion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Postulacion/Create
        public ActionResult Create(int contratoid)
        {
            Postulacion postulacion = new Postulacion();
            Session["ContratoID"] = (decimal)contratoid;
            return View(postulacion);
        }

        // POST: Postulacion/Create
        [HttpPost]
        public ActionResult Create(Postulacion postulacion)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    if (postulacion.Save())
                    {
                        TempData["PostulacionMessage"] = "Postulación agregada exitosamente";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["PostulacionMessage"] = "Error al agregar la postulación.";
                    }
                }
                else
                {
                    TempData["PostulacionMessage"] = "El modelo de postulación no es válido.";
                }

                return View(postulacion);
            }
            catch (Exception ex)
            {
                TempData["Mensaje"] = "Error al agregar la postulación: " + ex.Message;
                return View(postulacion);
            }
        }

        // GET: Postulacion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Postulacion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // Implementar la lógica de actualización aquí

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Postulacion/Delete/5
        public ActionResult Delete(int id)
        {
            Postulacion postulacion = new Postulacion { Postulacionid = id };

            if (postulacion.Delete())
            {
                TempData["PostulacionEliminada"] = "Postulación eliminada exitosamente";
            }
            else
            {
                TempData["Mensaje"] = "Error al eliminar la postulación.";
            }

            return RedirectToAction("Index");
        }

        // POST: Postulacion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // Implementar la lógica de eliminación aquí

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
      
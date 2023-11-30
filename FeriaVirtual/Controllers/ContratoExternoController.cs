using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FeriaVirtual.Negocio;

namespace FeriaVirtual.Controllers
{
    public class ContratosController : Controller
    {
        // GET: Contratos
        public ActionResult Index()
        {
            Contratos contrato = new Contratos();
            ViewBag.Contratos = contrato.ReadById((decimal)Session["UserID"]);
            return View();
        }

        public ActionResult Status()
        {
            Contratos contrato = new Contratos();
            ViewBag.Contratos = contrato.ReadPublished();
            return View();
        }

        // GET: Contratos/Create
        public ActionResult Create()
        {
            Contratos contrato = new Contratos();
            contrato.Estadocontratoid = 4; // Establecer automáticamente el estado del contrato
            return View(contrato);
        }

        // POST: Contratos/Create
        [HttpPost]
        public ActionResult Create(Contratos contrato)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (contrato.Save())
                    {
                        TempData["ContratoAgregado"] = "Contrato agregado exitosamente";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Mensaje"] = "Error al agregar el contrato.";
                    }
                }
                else
                {
                    TempData["Mensaje"] = "El modelo de contrato no es válido.";
                }

                return View(contrato);
            }
            catch (Exception ex)
            {
                TempData["Mensaje"] = "Error al agregar el contrato: " + ex.Message;
                return View(contrato);
            }
        }

        // GET: Contratos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contratos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Contratos contrato)
        {
            try
            {
                // Implementa la lógica para actualizar el contrato con el id proporcionado

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Mensaje"] = "Error al editar el contrato: " + ex.Message;
                return View(contrato);
            }
        }

        // GET: Contratos/Delete/5
        public ActionResult Delete(int id)
        {
            Contratos contrato = new Contratos { Contratoid = id };

            if (contrato.Delete())
            {
                TempData["ContratoEliminado"] = "Contrato eliminado exitosamente";
            }
            else
            {
                TempData["Mensaje"] = "Error al eliminar el contrato.";
            }

            return RedirectToAction("Index");
        }

        // POST: Contratos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // Implementa la lógica para eliminar el contrato con el id proporcionado

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Mensaje"] = "Error al eliminar el contrato: " + ex.Message;
                return View();
            }
        }

        public ActionResult Postulaciones(int id)
        {
            Postulacion postulacion = new Postulacion();
            Session["ContratoID"] = (decimal)id;
            ViewBag.Postulaciones = postulacion.ReadByContratoId((decimal)Session["ContratoID"]);
            return View(id);
        }

        public ActionResult Select(int id)
        {
            Postulacion postulacion = new Postulacion { Postulacionid = id };

            if (postulacion.Select(id, 1))
            {
                TempData["PostulacionMensaje"] = "Contrato eliminado exitosamente";
            }
            else
            {
                TempData["PostulacionMensaje"] = "Error al eliminar el contrato.";
            }

            return RedirectToAction("Index");
        }

        // POST: Contratos/Delete/5
        [HttpPost]
        public ActionResult Select(int id, FormCollection collection)
        {
            try
            {
                // Implementa la lógica para eliminar el contrato con el id proporcionado

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["PostulacionMensaje"] = "Error al eliminar el contrato: " + ex.Message;
                return View();
            }
        }
    }
}

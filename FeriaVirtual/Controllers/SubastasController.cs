using FeriaVirtual.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeriaVirtual.Controllers
{
    public class SubastasController : Controller
    {
        // GET: Subastas
        public ActionResult Index()
        {
            ViewBag.subastas = new Subasta().ReadUnfinished();
            return View();
        }

        // GET: Subastas/Details/5
        public ActionResult Details(int id)
        {
            Session["SubastaID"] = id;
            ViewBag.subastamedio = new SubastaMedio().ReadBySubastaIdAndTransportistaId((int)Session["SubastaID"], (decimal)Session["UserID"]);
            return View();
        }

        public ActionResult MySub()
        {
            ViewBag.subastas = new Subasta().ReadByTransportistaId((decimal)Session["UserID"]);
            return View();
        }

        // GET: Subastas/Create/
        public ActionResult Create(int id)
        {
            Session["SubastaID"] = id;
            ViewBag.medios = new MedioTransporte().ReadByIdAndNotInSubasta((decimal)Session["UserID"], (int)Session["SubastaID"]);
            return View();
        }

        // POST: Subastas/Postular/
        public ActionResult Postular(int id)
        {
            SubastaMedio submedio = new SubastaMedio();
            submedio.MedioId = Convert.ToDecimal(id);
            submedio.SubastaId = Convert.ToDecimal((int)Session["SubastaID"]);
            submedio.Selected = 0;

            try
            {
                if (ModelState.IsValid)
                {
                    if (submedio.Save())
                    {
                        TempData["SubastaMessage"] = "Submedio agregado exitosamente";
                        System.Diagnostics.Debug.WriteLine((int)Session["SubastaID"]);
                        System.Diagnostics.Debug.WriteLine(id);
                        System.Diagnostics.Debug.WriteLine("entró");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["SubastaMessage"] = "Error al agregar el Submedio.";
                        System.Diagnostics.Debug.WriteLine((int)Session["SubastaID"]);
                        System.Diagnostics.Debug.WriteLine(id);
                        System.Diagnostics.Debug.WriteLine("no entró");
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    TempData["SubastaMessage"] = "El modelo de Submedio no es válido.";
                    return RedirectToAction("Index");
                    System.Diagnostics.Debug.WriteLine((int)Session["SubastaID"]);
                    System.Diagnostics.Debug.WriteLine(id);
                    System.Diagnostics.Debug.WriteLine("menos entró");
                }

            }
            catch (Exception ex)
            {
                TempData["SubastaMessage"] = "Error al agregar el Submedio: " + ex.Message;
                return RedirectToAction("Index");
                System.Diagnostics.Debug.WriteLine((int)Session["SubastaID"]);
                System.Diagnostics.Debug.WriteLine(id);
                System.Diagnostics.Debug.WriteLine("entró a error: "+ex.Message);
            }
        }

        // GET: Subastas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Subastas/Edit/5
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

        // GET: Subastas/Delete/5
        public ActionResult Delete(int id)
        {
           
            return RedirectToAction("Index");
        }

        // POST: Subastas/Delete/5
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

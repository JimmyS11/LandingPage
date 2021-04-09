using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LandingPage.Models;

namespace LandingPage.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ManejoRegistro mr = new ManejoRegistro();
            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            ManejoRegistro mr = new ManejoRegistro();
            Registro registro = new Registro
            {
                Nombre = collection["nombre"].ToString(),
                Correo = collection["correo"],
                Telefono = collection["telefono"],
                Ciudad = collection["ciudad"].ToString()
            };
            mr.Insertar(registro);
            return RedirectToAction("Index");
        }

        public ActionResult Listar()
        {
            ManejoRegistro mr = new ManejoRegistro();
            return View(mr.Seleccionar_Todo());
        }

        /*// GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
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

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
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
        }*/
    }
}

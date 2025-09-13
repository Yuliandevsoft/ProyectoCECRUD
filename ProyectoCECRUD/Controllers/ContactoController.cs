using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ProyectoCECRUD.Models;
using System.Data;


namespace ProyectoCECRUD.Controllers
{
    public class ContactoController : Controller
    {
        // GET: Contacto
        public ActionResult Inicio()
        {
            List<Contacto> contactos = new List<Contacto>();
            contactos = new Datacontact().ShowContact();

            return View(contactos);
        }
        [HttpGet]
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(Contacto ocontacto)
        {
            Datacontact data = new Datacontact();
            data.Registrar(ocontacto); 

            return RedirectToAction("Inicio", "Contacto");
        }
    }
}

using ProyectoCECRUD.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;


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
        [HttpGet]
        public ActionResult Editar(int? idcontacto)
        {
            if (idcontacto == null)
                return RedirectToAction("Inicio", "Contacto");

            //La forma que no funciono porque esta el ShowContact en el Datacontact y el olista esta alla.
            //Contacto ocontacto = olista.(c => c.IdContacto == idcontacto).FirstOrDefault();

            // Forma que funciono Traer lista de contactos desde la capa de datos
            List<Contacto> contactos = new Datacontact().ShowContact();

            // Buscar el contacto que coincide con el id
            Contacto ocontacto = contactos.Where(c => c.IdContacto == idcontacto).FirstOrDefault();

            if (ocontacto == null)
                return RedirectToAction("Inicio", "Contacto");

            return View(ocontacto);

        }
        [HttpGet]
        public ActionResult Eliminar(int? idcontacto)
        {
            if (idcontacto == null)
                return RedirectToAction("Inicio", "Contacto");

            // Forma que funciono Traer lista de contactos desde la capa de datos
            List<Contacto> contactos = new Datacontact().ShowContact();

            // Buscar el contacto que coincide con el id
            Contacto ocontacto = contactos.Where(c => c.IdContacto == idcontacto).FirstOrDefault();

            if (ocontacto == null)
                return RedirectToAction("Inicio", "Contacto");

            return View(ocontacto);

        }
        [HttpPost]
        public ActionResult Eliminar(string IdContacto)
        {
            Datacontact data = new Datacontact();
            data.Eliminar(IdContacto);  // Este método lo implementas en tu capa de datos

            return RedirectToAction("Inicio", "Contacto");
        }


        [HttpPost]
        public ActionResult Editar(Contacto ocontacto)
        {
            Datacontact data = new Datacontact();
            data.Editar(ocontacto);

            return RedirectToAction("Inicio", "Contacto");
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

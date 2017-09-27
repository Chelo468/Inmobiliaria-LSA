using Datos;
using Entidades;
using Inmobiliaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inmobiliaria.Controllers
{
    public class ClienteController : Controller
    {
        ClienteDatos clienteDatos = new ClienteDatos();

        // GET: Cliente
        public ActionResult Index()
        {
            List<Cliente> clientes = clienteDatos.obtenerClienteById(1);
            return View("Index", clientes);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using CapaDatosEmpleados.Models;
using CapaLogicaEmpleados;

/**
 * Controlador de administración
 * de la lista de empleados
 */
namespace CapaWebEmpleados.Controllers
{
    public class buscarPorId
    {
        public int id { get; set; }
    }

    public class EmpleadoController : Controller
    {
        //
        // GET: /Empleado/

        public ActionResult Empleado()
        {
            return View(ObtenerEmpleado());
        }

        [HttpPost]
        public JsonResult Empleado(buscarPorId empleado)
        {
            IEnumerable<Empleado> listaEmpleados;
            listaEmpleados = ObtenerEmpleado();

            if (empleado.id != 0)
            {
                listaEmpleados = listaEmpleados.Where(s => s.id == empleado.id).ToList();
            }
            return Json(listaEmpleados, JsonRequestBehavior.AllowGet);
        }

        /**
         * Método que se conecta al Web API
         * que contiene el listado de empleados
         */
        private IEnumerable<Empleado> ObtenerEmpleado()
        {
            IEnumerable<Empleado> empleados = null;

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("http://masglobaltestapi.azurewebsites.net/api/");

                var respuesta = cliente.GetAsync("Employees");
                respuesta.Wait();

                var resultado = respuesta.Result;

                if (resultado.IsSuccessStatusCode)
                {
                    var lectura = resultado.Content.ReadAsAsync<IList<Empleado>>();
                    lectura.Wait();

                    empleados = lectura.Result;
                }
                else
                {
                    empleados = Enumerable.Empty<Empleado>();
                    ModelState.AddModelError(string.Empty, "Error al intentar conectar con el servidor, por favor intente nuevamente");
                }
            }

            return EmpleadoLogica.ObtenerEmpleados(empleados);
        }

    }
}

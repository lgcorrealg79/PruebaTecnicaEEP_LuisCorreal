using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatosEmpleados.Models;
using CapaDatosEmpleados.Controllers;

/**
 * Clase para retornar la
 * lista de empleados
 */
namespace CapaLogicaEmpleados
{
    public static class EmpleadoLogica
    {
        public static IEnumerable<Empleado> ObtenerEmpleados(IEnumerable<Empleado> listaEmpleados)
        {
            EmpleadoController empleado = new TipoContratoEmpleado();
            List<Empleado> nuevaListaEmpleados = new List<Empleado>();

            foreach (Empleado e in listaEmpleados)
            {
                IEmpleadoController emp = empleado.ObtenerEmpleado(e);
                e.annualSalary = emp.CalcularSalarioAnual(e.contractTypeName);
                nuevaListaEmpleados.Add(e);
            }

            return (IEnumerable<Empleado>)nuevaListaEmpleados;
        }
    }
}

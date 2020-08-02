using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatosEmpleados.Models;

/**
 * Clase utilizada para declarar los métodos
 * de consulta de un empleado o de todos los
 * empleados
 */
namespace CapaDatosEmpleados.Repositorio
{
    public class EmpleadoRepositorio : IRepositorio<Empleado>
    {
        public List<Empleado> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        public Empleado ObtenerEmpleadoPorId(long id)
        {
            throw new NotImplementedException();
        }
    }
}

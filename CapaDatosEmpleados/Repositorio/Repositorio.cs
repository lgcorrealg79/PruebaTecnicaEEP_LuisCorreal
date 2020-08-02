using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatosEmpleados.Models;

/**
 * Clase utilizada para
 * declarar las listas para
 * obtener los empleados
 */
namespace CapaDatosEmpleados.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : Entidad
    {
        public List<T> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        public T ObtenerEmpleadoPorId(long id)
        {
            throw new NotImplementedException();
        }
    }
}

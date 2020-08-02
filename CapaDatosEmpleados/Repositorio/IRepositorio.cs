using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatosEmpleados.Models;

/**
 * Interface utilizada para
 * declarar las listas para
 * obtener los empleados
 */
namespace CapaDatosEmpleados.Repositorio
{
    public interface IRepositorio<T> where T : Entidad
    {
        T ObtenerEmpleadoPorId(Int64 id);
        List<T> ObtenerTodos();
    }
}

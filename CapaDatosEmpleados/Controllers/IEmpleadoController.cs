using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatosEmpleados.Models;

/**
 * Interface utilizada para calcular el salario anual del empleado
 * dependiendo de si recibe pago por horas o pago por mes
 */
namespace CapaDatosEmpleados.Controllers
{
    public interface IEmpleadoController
    {
        decimal CalcularSalarioAnual(String contractTypeName);
    }

    public class EmpleadoPagoPorHoras : Empleado, IEmpleadoController
    {
        public EmpleadoPagoPorHoras(int id, string name, string contractTypeName, int roleId, string roleName, string roleDescription, decimal hourlySalary, decimal monthlySalary)
            : base(id, name, contractTypeName, roleId, roleName, roleDescription, hourlySalary, monthlySalary)
        {
        }

        public decimal CalcularSalarioAnual(String contractTypeName)
        {
            return 120 * hourlySalary * 12;
        }
    }

    public class EmpleadoPagoPorMes : Empleado, IEmpleadoController
    {
        public EmpleadoPagoPorMes(int id, string name, string contractTypeName, int roleId, string roleName, string roleDescription, decimal hourlySalary, decimal monthlySalary)
            : base(id, name, contractTypeName, roleId, roleName, roleDescription, hourlySalary, monthlySalary)
        {
        }

        public decimal CalcularSalarioAnual(String contractTypeName)
        {
            return monthlySalary * 12;
        }
    }

    public abstract class EmpleadoController
    {
        public abstract IEmpleadoController ObtenerEmpleado(Empleado item);
    }

    public class TipoContratoEmpleado : EmpleadoController
    {
        public override IEmpleadoController ObtenerEmpleado(Empleado item)
        {
            switch (item.contractTypeName)
            {
                case "HourlySalaryEmployee":
                    return new EmpleadoPagoPorHoras(item.id, item.name, item.contractTypeName, item.roleId, item.roleName, item.roleDescription, item.hourlySalary, item.monthlySalary);
                case "MonthlySalaryEmployee":
                    return new EmpleadoPagoPorMes(item.id, item.name, item.contractTypeName, item.roleId, item.roleName, item.roleDescription, item.hourlySalary, item.monthlySalary);
                default:
                    throw new ApplicationException(string.Format("Employee '{0}' cannot be created", item.contractTypeName));
            }
        }
    }
}

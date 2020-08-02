using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Clase en donde se establecen todos
 * los datos del empleado
 */
namespace CapaDatosEmpleados.Models
{
    public class Empleado : Entidad
    {
        private Empleado empleado;

        public Empleado()
        {
        }

        public Empleado(int id, string name, string contractTypeName, int roleId, string roleName, string roleDescription, decimal hourlySalary, decimal monthlySalary)
        {
            this.id = id;
            this.name = name;
            this.contractTypeName = contractTypeName;
            this.roleId = roleId;
            this.roleName = roleName;
            this.roleDescription = roleDescription;
            this.hourlySalary = hourlySalary;
            this.monthlySalary = monthlySalary;
        }
        public string name { get; set; }
        public string contractTypeName { get; set; }
        public int roleId { get; set; }
        public string roleName { get; set; }
        public string roleDescription { get; set; }
        public decimal hourlySalary { get; set; }
        public decimal monthlySalary { get; set; }
        public decimal annualSalary { get; set; }
    }
}

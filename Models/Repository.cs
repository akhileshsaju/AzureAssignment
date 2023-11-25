using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCurdApp.Models
{
    public static class Repository
    {
        private static List<Employee> _employees = new List<Employee>();
       
        public static IEnumerable<Employee> getEmployees()
        {
            return(_employees);
        }
        public static void createEmployee(Employee employee)
        {
            _employees.Add(employee);
        }

        public static void Delete(Employee employee)
        {
            _employees.Remove(employee);
        }
        public static Boolean UniqueCheck(int empid)
        {
            var employees = Repository.getEmployees();
            var employee = employees.FirstOrDefault(e => e.Id == empid);
            if(employee == null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

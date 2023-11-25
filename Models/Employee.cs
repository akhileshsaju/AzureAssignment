using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCurdApp.Models
{
    public class Employee
    {
        
        public  int Id { get; set; }
        public bool IsIdUnique()
        {
            var employees = Repository.getEmployees();
            var employee = employees.FirstOrDefault(e => e.Id == Id);

            if (employee == null)
                return true;
            else
                return false;
        }
        public string Name { get; set; }
        public string Drpartment { get; set; }
        public string salary { get; set; }

        public string phone { get; set; }
        public string Email { get; set; }

        

        
    }

   
}

using Microsoft.AspNetCore.Mvc;
using FirstCurdApp.Models;

using System.Linq;

namespace FirstCurdApp.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View(Repository.getEmployees());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {


            if (Repository.UniqueCheck(emp.Id)) {
                Repository.createEmployee(emp);
                return View("Thanks", emp);
            }

            return View("Error", emp);


        }
        
        public IActionResult Update(int empid)
        {
            var employees = Repository.getEmployees();
            var employee = employees.FirstOrDefault(e => e.Id == empid);
            
            
            return View(employee);
        }

        [HttpPost]
        public IActionResult Update(Employee employee)
        {


            Repository.getEmployees().Where(e => e.Id == employee.Id).FirstOrDefault().Name = employee.Name;

            Repository.getEmployees().Where(e => e.Id == employee.Id).FirstOrDefault().Email = employee.Email;

            Repository.getEmployees().Where(e => e.Id ==employee.Id).FirstOrDefault().phone = employee.phone; 
            Repository.getEmployees().Where(e => e.Id == employee.Id).FirstOrDefault().Drpartment = employee.Drpartment; 
            Repository.getEmployees().Where(e => e.Id ==employee.Id).FirstOrDefault().salary = employee.salary;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int empid)
        {
            var employees = Repository.getEmployees();
            var employee = employees.FirstOrDefault(e => e.Id == empid);
            Repository.Delete(employee);

            return RedirectToAction("Index");
        }



        


    }
}

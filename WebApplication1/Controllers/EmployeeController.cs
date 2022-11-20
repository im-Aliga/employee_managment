
using EmployeeManagment.Migrations;
using EmployeeManagment_.Database.Contexts;
using EmployeeManagment_.Database.Models;
using EmployeeManagment_.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employee = EmployeeManagment_.Database.Models.Employee;

namespace EmployeeManagment_.Controllers
{
    [Route("Employee")]
    public class EmployeeController : Controller
    {
        [HttpGet("list", Name = "employee-list")]
        public IActionResult List()
        {
            using DataContext dbContexts = new DataContext();
            var employees = dbContexts.Employees.ToList();
            var model = dbContexts.Employees
               .Select(b => new EmployeesLIstViewModel( b.IsDeleted,b.EmployeeCode, b.EmployeeName, b.EmployeeLastname, b.EmployeeFathername))
               .ToList();
            return View(model);

        }

        [HttpGet("add", Name = "employee-add")]
        public IActionResult AddEmployee()
        {

            return View();

        }
        [HttpPost("add", Name = "employee-add")]
        public IActionResult AddEmployee(EmployeeAddViewModel model)
        {
            using DataContext dbContexts = new DataContext();
            var employees = dbContexts.Employees.ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            dbContexts.Employees.Add(new Employee
            {
               
                EmployeeCode = EmployeeCodeAutoincrement.BlogCode,
                EmployeeName = model.EmployeeName,
                EmployeeLastname = model.EmployeeLastname,
                EmployeeFathername = model.EmployeeFathername,
                FinCode = model.FinCode,
                Email = model.Email,
                IsDeleted = default
            });
            dbContexts.SaveChanges();

            return RedirectToAction(nameof(List));
        }


        [HttpGet("update/{empcode}", Name = "employee-update-id")]
        public ActionResult UpdateEmployee(string empCode)
        {
            using DataContext dbContexts = new DataContext();
            var employees = dbContexts.Employees.ToList();
            var employee = dbContexts.Employees.FirstOrDefault(e => e.EmployeeCode == empCode);
            if (employee is null && employee.IsDeleted==true)
            {
                return NotFound();
            }
            dbContexts.SaveChanges();
            return View(new EmployeeUpdateViewModel { EmployeeName = employee.EmployeeName, EmployeeLastname = employee.EmployeeLastname, EmployeeFathername = employee.EmployeeFathername,FinCode=employee.FinCode,Email=employee.Email });
        }

        [HttpPost("update/{EmployeeCode}", Name = "employee-update")]
        public ActionResult UpdateEmployee(EmployeeUpdateViewModel model)
        {
            using DataContext dbContexts = new DataContext();
            
            var employee = dbContexts.Employees.FirstOrDefault(e => e.EmployeeCode == model.EmployeeCode);

            if (employee is null)
            {
                return NotFound();  
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            employee.EmployeeName = model.EmployeeName;
            employee.EmployeeLastname = model.EmployeeLastname;
            employee.EmployeeFathername = model.EmployeeFathername;
            employee.FinCode = model.FinCode;
            employee.Email = model.Email;

            dbContexts.SaveChanges();
            return RedirectToAction(nameof(List));
        }


        [HttpGet("deleted/{empcode}", Name = "employee-deleted-blogcode")]
        public ActionResult DeletedEmployee(string empCode)
        {
            using DataContext dbContexts = new DataContext();
            var employee = dbContexts.Employees.FirstOrDefault(e => e.EmployeeCode == empCode);
            if (employee is null)
            {
                return NotFound();
            }
            employee.IsDeleted = true;

            dbContexts.SaveChanges();
            return RedirectToAction(nameof(List));
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkExplained.Models;
using EntityFrameworkExplained.ViewModels;

namespace EntityFrameworkExplained.Controllers
{
    [Route("")]
    public class EmployeeController : Controller
    {
        readonly EmployeeDbContext employeeDbContext;
        
        public EmployeeController(EmployeeDbContext employeeDbContext)
        {
            this.employeeDbContext = employeeDbContext;
        }

        //The Index action method corresponding to the GET action 
        //method will be called when you access the URL 
        //(http://localhost/Employee/Index) or when you run the
        //application.

        //GET : /<controller>/
        public IActionResult Index()
        {
            //we are creating the ViewModel object and passing it to the view
            EmployeeAddViewModel employeeAddViewModel = new EmployeeAddViewModel();
            var db = this.employeeDbContext;
            employeeAddViewModel.EmployeesList = db.Employees.ToList();
            //employeeAddViewModel.NewEmployee = new Employee();

            return View(employeeAddViewModel);
        }

        [HttpPost]
        public IActionResult Index(EmployeeAddViewModel employeeAddViewModel)
        {
            //var db = this.employeeDbContext;
            //var newRecord = employeeAddViewModel.NewEmployee;
            //var existingEmployee =
            //    db.Employees.FirstOrDefault(
            //        existingEmp => existingEmp.Name == newRecord.Name);
            //if(existingEmployee != null)
            //{
            //    existingEmployee.Designation = newRecord.Designation;
            //    existingEmployee.Salary = newRecord.Salary;
            //}
            //else
            //{
            //    db.Employees.Add(newRecord);
            //}
            //db.SaveChanges();
            ////Redirect to get index Get method 
            //return RedirectToAction("Index");

            if (ModelState.IsValid)
            {
                Employee employee = new Employee
                {
                    Name = employeeAddViewModel.Name,
                    Designation = employeeAddViewModel.Designation,
                    Salary = employeeAddViewModel.Salary,
                    
                };

                employeeDbContext.Employees.Add(employee);
                employeeDbContext.SaveChanges();

                //Redirect to get index Get method 
                return RedirectToAction("Index");
            }
            employeeAddViewModel.EmployeesList = employeeDbContext.Employees.ToList();
            return View(employeeAddViewModel);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkExplained.Models;
using System.ComponentModel.DataAnnotations;
using EntityFrameworkExplained.Models;

namespace EntityFrameworkExplained.ViewModels
{
    //As we are going to show a list of employees and the form
    //to add employees in the same screen, we are going to
    //build a model specific to this view.This model will 
    //contain information about the list of employees 
    //and the employee to be added.
    public class EmployeeAddViewModel
    {
        //This list will be fetched from the database
        public List<Employee> EmployeesList { get; set; }
        [Required(ErrorMessage = "Employee name is required!")] //We are adding validation to our forms
        public String Name { get; set; }

        [Required(ErrorMessage = "Employee Designation is required!")]
        [MinLength(5, ErrorMessage = "Minimum length of designation should be at least 5 characters!")]
        [RegularExpression(@"^[A-Za-z]+(?:\s[A-Za-z]+)+$", ErrorMessage = "Designation should be at least two words!")]
        public string Designation { get; set; }

        [Required]
        [Range(1000, 9999.99, ErrorMessage = "Salary should range from 1000 to 9999.99!")]
        public decimal Salary { get; set; }

        //NewEmployee will hold the employee information entered by the user
        //public Employee NewEmployee { get; set; }

    }
}

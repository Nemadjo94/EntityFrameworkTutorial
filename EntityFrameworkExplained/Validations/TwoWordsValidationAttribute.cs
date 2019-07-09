using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using EntityFrameworkExplained.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkExplained.ViewModels;

namespace EntityFrameworkExplained.Validations
{
    public class TwoWordsValidationAttribute : ValidationAttribute, IClientModelValidator
    {
        public void AddValidation(ClientModelValidationContext context)
        {
            if(context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            context.Attributes.TryAdd("data-val-twowords", "There should be minimum two words!");
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var employee = (EmployeeAddViewModel)validationContext.ObjectInstance;
            if (employee.Designation.Trim().Contains(" "))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Designation should be at least two words!");
            }
        }
    }
}

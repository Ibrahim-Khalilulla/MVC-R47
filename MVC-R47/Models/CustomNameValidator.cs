using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MVC_R47.Models
{
    public class CustomNameValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (Regex.IsMatch(value.ToString(), @"^([A-Za-z0-9\s\-])+$", RegexOptions.IgnoreCase))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Please Enter a Valid Value, any alphanumeric ");
                }
            }
            else
            {
                return new ValidationResult(validationContext.DisplayName + " is required");
            }
        }
    }
}
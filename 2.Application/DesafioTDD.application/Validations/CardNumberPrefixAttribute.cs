using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesafioTDD.application.Validations
{
    public class CardNumberPrefixAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is null || string.IsNullOrEmpty(value.ToString()))
                return ValidationResult.Success;

            var valueString = value.ToString().Replace("-", "");
            var length = valueString.Length;
            var errorMessage = new ValidationResult("Prefixos inválidos, Ex. 0000-0000-0000-0000");

            if (!IsNumber(valueString))
                return errorMessage;

            if (!(length % 4 == 0))
                return errorMessage;

            return ValidationResult.Success;
        }

        private bool IsNumber(string value)
        {
            if (Regex.IsMatch(value, @"[^\d]"))
                return true;
            return false;
        }
    }
}
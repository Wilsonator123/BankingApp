using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

public class UniqueAccountNumberAttribute : ValidationAttribute
{
    private static HashSet<string> existingAccountNumbers = new HashSet<string>();

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is string accountNumber)
        {
            if (existingAccountNumbers.Contains(accountNumber))
            {
                return new ValidationResult("Account number must be unique.");
            }

            existingAccountNumbers.Add(accountNumber);
            return ValidationResult.Success;
        }

        return new ValidationResult("Invalid account number.");
    }
}

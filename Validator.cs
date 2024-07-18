using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Text.RegularExpressions;

namespace BankingApp;

public static class Validator
{
    public static bool ValidateDriversLicense(Customer customer, string driversLicense)
    {
        StringBuilder licenseBuilder = new StringBuilder();
        if(driversLicense.Length != 18)
        {
            Console.WriteLine("Invalid drivers license");
            return false;
        }
        string lastName; 
        if (customer.LastName.Length > 5)
        { 
            lastName = customer.LastName.Substring(0, 5);
        }
        else
        {
            lastName = customer.LastName.Substring(0, customer.LastName.Length).PadRight(5, '9');
        }

        lastName = lastName.ToUpper();
        licenseBuilder.Append(lastName);
        
        char[] licenseNumbers = new char[6];
        string dateOfBirth = customer.DateOfBirth.ToString("ddMMyy");
        licenseNumbers[0] = dateOfBirth[4];
        licenseNumbers[5] = dateOfBirth[5];
        licenseNumbers[1] = dateOfBirth[2];
        licenseNumbers[2] = dateOfBirth[3];
        licenseNumbers[3] = dateOfBirth[0];
        licenseNumbers[4] = dateOfBirth[1];

        licenseBuilder.Append(licenseNumbers);
        licenseBuilder.Append(customer.FirstName[0]);
        licenseBuilder.Append("[A-Z|9][A-Z0-9]{3}[0-9]{2}");
        
        if (Regex.IsMatch(driversLicense, licenseBuilder.ToString()))
        {
            Console.WriteLine("Valid drivers license");
        }
        else
        {
            Console.WriteLine("Invalid drivers license");
            return false;
        }
        
        Console.WriteLine(licenseBuilder);

        return true;
    }
}
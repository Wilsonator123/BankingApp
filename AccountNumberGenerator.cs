using System;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using BankingApp;

public class AccountNumberGenerator
{
    private static Random _random = new Random();

    public static string GenerateAccountNumber()
    {
        StringBuilder accountNumber = new StringBuilder(10);

        for (int i = 0; i < 10; i++)
        {
            accountNumber.Append(_random.Next(0, 10));
        }

        return accountNumber.ToString();
    }

    public static Account CreateAccount(string accountName, decimal initialBalance, string creationDate)
    {
        Account newAccount;
        List<ValidationResult> results = new List<ValidationResult>();
        ValidationContext context;

        do
        {
            string accountNumber = GenerateAccountNumber();
            
            newAccount = new PersonalAccount(accountName, accountNumber, initialBalance, creationDate, initialBalance) ;

            context = new ValidationContext(newAccount, serviceProvider: null, items: null);
        } while (!Validator.TryValidateObject(newAccount, context, results, true));

        return newAccount;
    }

}

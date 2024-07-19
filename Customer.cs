using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public class Customer
    {
        private readonly Guid _id;
        private readonly string _firstName;
        private readonly string _lastName;
        private int _photoId;
        private int _addressId;
        private readonly DateTime _dateOfBirth;

        // Can have multiple personal accounts but one business / isa
        //TODO : Create Personal Account Class
        private List<PersonalAccount> _personalAccounts = new();

        // TODO : Create Business Account Class (This type will be Business)
        private int? _businessAccounts = null;

        //TODO : Create ISA Account Class (This type will be ISA)
        private int? _isaAccount = null;

        // TODO : Create list of transactions could be a file instead!
        // Transactions/<id>(.txt / .csv)
        private string transactionPath;


        public Customer(string firstName, string lastName, int photoId, int addressId, string dateOfBirth)
        {
            try
            {
                // Probably want a way to verify its unique (it's very unlikely tho)
                _id = new Guid();
                _firstName = firstName;
                _lastName = lastName;
                // TODO : We should validate the IDs presented (basic regex will do)
                _photoId = photoId;
                _addressId = addressId;
                _dateOfBirth = DateTime.ParseExact(dateOfBirth, "dd/MM/yyyy", new CultureInfo("en-GB"));
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid Date Format");
            }
        }


        public int PhotoId { get => _photoId; set => _photoId = value; }
        public int AddressId { get => _addressId; set => _addressId = value; }

        // DoB shouldn't change
        public DateTime DateOfBirth { get => _dateOfBirth; }

        public string FirstName => _firstName;

        public string LastName => _lastName;

        public Guid Id => _id;


        private static Random _random = new Random();

        // Generate a ten digit account Number for a new account
        public static string GenerateAccountNumber()
        {
            // create a string of ten numbers
            StringBuilder accountNumber = new(10);

            for (int i = 0; i < 10; i++)
            {
                accountNumber.Append(_random.Next(0, 10));
            }
            
            // convert accountNumber back to string
            
            return accountNumber.ToString();
        }

        public bool AddPersonalAccount( decimal initialBalance)
        {
            // Create new personal account
            string name = $"{_firstName} {_lastName}";
            string accountNumber = GenerateAccountNumber();
            PersonalAccount personal = new PersonalAccount(name, accountNumber, initialBalance, DateTime.Now.ToString(), initialBalance);
            _personalAccounts.Add(personal);
            return true;
        }
        private bool ValidateDateOfBirth(string date)
        {
            // TODO : Take in a dd/mm/yyyy string and validate it
            return true;
        }

        public override string ToString()
        {
            // TODO : Display all customer information
            return $"""
                    
                                Name : {FirstName} {LastName}
                                Date of Birth : {DateHelper.DateToString(_dateOfBirth)}
                                Accounts: {_personalAccounts.Count}
                                
                    """;
        }

        public void OpenBusinessAccount()
        {
            if (_businessAccounts == null)
            {
                // TODO : Create BusinessAccount object
                // _businessAccount = new BusinessAccount();
            }
            else
            {
                Console.WriteLine("You already have a business account");
            }
        }

        public void CloseBusinessAccount()
        {
            // If account has a balance or debt can it close?
            if (_businessAccounts != null) _businessAccounts = null;
            Console.WriteLine("Business Account Closed");
        }

        public void OpenIsaAccount()
        {
            if (_isaAccount == null)
            {
                // TODO : Create ISA Account
                // _isaAccount = new IsaAccount();
            }
        }

        public void CloseIsaAccount()
        {
            // What to do with money inside
            if (_isaAccount != null) _isaAccount = null;
            Console.WriteLine("ISA Account Closed");
        }
    }
}

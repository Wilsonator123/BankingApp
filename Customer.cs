using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    internal class Customer
    {
        private string _name;
        private int _photoId;
        private int _addressId;
        private DateTime _dateOfBirth;

        // Can have multiple personal accounts but one business / isa
        //TODO : Create Personal Account Class
        private List<int> _personalAccounts = [];

        // TODO : Create Business Account Class (This type will be Business)
        private int? _businessAccounts = null;

        //TODO : Create ISA Account Class (This type will be ISA)
        private int? _isaAccount = null;


        public Customer(string name, int photoId, int addressId, string dateOfBirth)
        {
            try
            {
                _name = name;
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

        // Should a name be able to change?
        public string Name { get => _name; set => _name = value; }
        public int PhotoId { get => _photoId; set => _photoId = value; }
        public int AddressId { get => _addressId; set => _addressId = value; }
        
        // DoB shouldn't change
        public DateTime DateOfBirth { get => _dateOfBirth; }

        public bool AddPersonalAccount(int accountNumber)
        {
            // TODO : Create new personal account 
            _personalAccounts.Add(accountNumber);
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
                    
                                Name : {_name}
                                Date of Birth : {DateHelper.DateToString(_dateOfBirth)}
                                Accounts: {_personalAccounts.Count}
                                
                    """;
        }

        public void OpenBusinessAccount()
        {
            if (_businessAccounts == null)
            {
                // TODO : Create BusniessAccount object
                // _businessAccount = new BusinessAccount();
            }
            else
            {
                Console.WriteLine("You already have a business account");
            }
        }

        public void OpenIsaAccount()
        {
            if (_isaAccount == null)
            {
                // TODO : Create ISA Account
                // _isaAccount = new IsaAccount();
            }
        }

        public static void Main()
        {
            Customer cus = new Customer("George Wilson", 100, 100, "24/01/2003");
            Console.WriteLine(cus.ToString());
        }
    }
}

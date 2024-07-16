using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    internal class Customer
    {
        private string _name;
        private int _photoId;
        private int _addressId;
        private string _dateOfBirth;

        //TODO : Create Personal Account Class
        private List<int> _personalAccounts = [];

        // TODO : Create Business Account Class
        private int _businessAccounts;

        //TODO : Create ISA Account Class
        private int _isaAccount;


        public Customer(string name, int photoID, int addressID, string dateOfBirth)
        {
            _name = name;
            _photoId = photoID;
            _addressId = addressID;
            _dateOfBirth = dateOfBirth;
        }

        public string Name { get => _name; set => _name = value; }
        public int PhotoID { get => _photoId; set => _photoId = value; }
        public int AddressID { get => _addressId; set => _addressId = value; }
        public string DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }

        public bool AddPersonalAccount(int accountNumber)
        {
            // TODO : Create new personal account 
            _personalAccounts.Add(accountNumber);
            return true;
        }



        public void DisplayCustomerInformation()
        {
            // TODO : Display all customer information
            Console.WriteLine($@"
            Name : {_name}
            Date of Birth : {_dateOfBirth}
            Accounts: {_personalAccounts.Count}
            ");
        }


        private bool ValidateDateOfBirth(string date)
        {
            // TODO : Take in a dd/mm/yyyy string and validate it
            return true;
        }



    }
}

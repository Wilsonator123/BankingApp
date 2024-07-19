using System.Linq.Expressions;

namespace BankingApp
{
    internal class Bank
    {

        public List<PersonalAccount> PersonalAccounts
        {
            get => Data.ReadAccountFromCSV(Data.GetAccountInfoLocation("Personal"), "Personal").Cast<PersonalAccount>().ToList();
            set => Data.StoreDataAsCSV(value.Cast<Account>().ToList(), "Personal");
        }
        public List<BusinessAccount> BusinessAccounts
        {
            get => Data.ReadAccountFromCSV(Data.GetAccountInfoLocation("Business"), "Business").Cast<BusinessAccount>().ToList();
            set => Data.StoreDataAsCSV(value.Cast<Account>().ToList(), "Business");
        }
        public List<ISAAccount> ISAAccounts
        {
            get => Data.ReadAccountFromCSV(Data.GetAccountInfoLocation("ISA"), "ISA").Cast<ISAAccount>().ToList();
            set => Data.StoreDataAsCSV(value.Cast<Account>().ToList(), "ISA");
        }


        // This will init from scratch, do not use if you want to update data
        // Use setters in that case
        public Bank()
        {
            var tempBusinessAccounts = Data.InitAccountsFromTemp("Business");
            var tempPersonalAccounts = Data.InitAccountsFromTemp("Personal");
            var tempISAAccounts = Data.InitAccountsFromTemp("ISA");

            Data.StoreDataAsCSV(tempPersonalAccounts, "Personal");
            Data.StoreDataAsCSV(tempBusinessAccounts, "Business");
            Data.StoreDataAsCSV(tempISAAccounts, "ISA");

            PersonalAccounts = tempPersonalAccounts.Cast<PersonalAccount>().ToList();
            BusinessAccounts = tempBusinessAccounts.Cast<BusinessAccount>().ToList();
            ISAAccounts = tempISAAccounts.Cast<ISAAccount>().ToList();
        }
    }
}

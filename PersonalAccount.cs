namespace BankingApp
{
    public class PersonalAccount : Account
    {
        private decimal _initialDeposit = 0m;

        public PersonalAccount(string accountName, string accountNumber, decimal accountBalance, string creationDate, decimal initialDeposit) :
        base(accountName, accountNumber, accountBalance, creationDate)
        {
            _initialDeposit = initialDeposit;
        }

        public decimal InitialDeposit { get => _initialDeposit; set => _initialDeposit = value; }

        public void ChargesIncurred()
        {
            if (AccountBalance < 0)
            {
                AccountBalance += -1;
                Console.WriteLine($"You have incurred a charge on your account of {AccountBalance}");
            }

            else
            {
                Console.WriteLine("No charges incurred as your account balance is non-negative.");
            }
        }


        public bool InitiateInitialDeposit(decimal amount)
        {
            if (amount < 1)
            {
                Console.WriteLine("""
                Sorry, we cannot initiate this transaction.
                The minimum amount to open an account is 1:C2
                """);
                return false;
            }
            _initialDeposit = amount;
            AccountBalance += amount;
            Console.WriteLine($"Deposited: {amount:C2}");
            return true;
        }

    }


}
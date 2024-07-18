using BankingApp;

public class ISAAccount : Account
{
    private const decimal InterestRate = 0.0275m;
    private const decimal MaxAllottedBalance = 20000.00m;
    private decimal _allottedBalance = MaxAllottedBalance;


    public ISAAccount(string accountName, string accountNumber, decimal accountBalance, string creationDate)
        : base(accountName, accountNumber, accountBalance, creationDate)
    { }




    public override bool Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Invalid input: Cannot deposit this amount");
            return false;
        }

        if (!CanDeposit(amount))
        {
            return false;
        }


        if (amount > _allottedBalance)
        {
            Console.WriteLine($"Cannot deposit more than allotted balance: {_allottedBalance:C2}");
            return false;
        }

        AccountBalance += amount;
        _allottedBalance -= amount;
        Transactions.Add(new Transaction("deposit", amount));
        Console.WriteLine($"Deposited: {amount:C2}");

        return true;
    }


    // looks through each deposit and determines if there
    // is enough of an allotted balance to allow a deposit 
    private bool CanDeposit(decimal amount)
    {
        // look through transaction list
        // look at every deposit within tax year 
        // retrieve each amount deposited and deduct from allottedBalance
        // retrieve the date 

        DateTime currentTaxYear = GetTaxYear(DateTime.Now);

        List<Transaction?> depositsThisTaxYear =
            Transactions.Where(t => t != null 
                                    && t?.TransactionType.ToUpper() == "DEPOSIT" 
                                    && GetTaxYear(t.TransactionDate) == currentTaxYear).ToList();

        decimal totalDepositThisTaxYear = depositsThisTaxYear.Sum(d => d.TransactionAmount);

        if (amount > (MaxAllottedBalance - totalDepositThisTaxYear))
        {
            Console.WriteLine($"Cannot deposit more than allotted balance: { _allottedBalance: C2}");
            return false;
        }


        return true;
    }



    // tax year = 1st April - 31st March
    // IF transaction's month is after april
    //      THEN we know it's tax year
    // ELSE (transaction's month is before april)
    //      THEN it's tax year is the year before
    private DateTime GetTaxYear(DateTime date)
    {
        int year = 0;

        if (date.Month >= 4)
        {
            year = date.Year;
        }
        else
        {
            year = date.Year - 1;
        }
        // should probably convert to ternary
        return new DateTime(year, 4, 1);
    }

}


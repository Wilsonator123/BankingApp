using BankingApp;

public class ISAAccount : Account
{
    private const decimal InterestRate = 0.0275m;
    private decimal _allottedBalance = 20000;


    public ISAAccount(string accountName, string accountNumber, decimal accountBalance, string creationDate)
        : base(accountName, accountNumber, accountBalance, creationDate)
    { }



    /* check tax year for specific deposit transaction using its associated date
     if current deposit transaction's tax year is the same,  
        if (allotted balance - amount) > 0,
          allotted balance -= amount
          current balance += current balance + amount
     otherwise, 
     allotted balance = 20000
    */
    public override bool Deposit(decimal amount)
    {

        if (!IsDepositLessThanAllotted())
        {
            return false;
        }

        if (amount <= 0)
        {
            Console.WriteLine("Invalid input: Cannot deposit this amount");
            return false;
        }

        if (amount > _allottedBalance)
        {
            Console.WriteLine($"Cannot deposit more than allotted balance: {_allottedBalance:C2}");
            return false;
        }

        AccountBalance += amount;
        _allottedBalance -= amount;
        Console.WriteLine($"Deposited: {amount:C2}");

        return true;
    }

    private bool IsDepositLessThanAllotted()
    {
        // look through transaction list
        // check the latest one with deposit
        // look at every deposit within tax year -- IGNORE
        // retrieve each amount deposited and deduct from allottedBalance -- IGNORE
        // retrieve the date 

        Transaction? latestDeposit =
            Transactions.FindLast(transaction => transaction?.TransactionType.ToUpper() == "DEPOSIT");

        if (latestDeposit == null)
        {

            // no previous deposit therefore allotted balance stays 20000
            return true;
        } 

        // check if tax year of latest deposit is the same as current tax year
        // IF NOT THEN _allottedBalance = 20000; RETURN TRUE;
        // ELSE THEN...

        return false;
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


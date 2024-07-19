using BankingApp;

public abstract class Account
{

    private string _accountName = "";
    private string _accountNumber = "";
    private decimal _accountBalance = 0;
    private string _accountType = "";
    private string _creationDate = "";
    // transaction list could be initialised from a file
    private List<Transaction?> _transactions = [];

    public Account(string accountName, string accountNumber, decimal accountBalance, string accountType, string creationDate)
    {
        _accountName = accountName;
        _accountNumber = accountNumber;
        _accountBalance = accountBalance;
        _accountType = accountType;
        _creationDate = creationDate;
    }

    public string AccountName { get => _accountName; set => _accountName = value; }
    public string AccountNumber { get => _accountNumber; }
    public decimal AccountBalance { get => _accountBalance; set => _accountBalance = value; }
    public string AccountType { get => _accountType; set => _accountType = value; }

    public string CreationDate { get => _creationDate; set => _creationDate = value; }
    public List<Transaction?> Transactions { get => _transactions; }

    public virtual bool Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Cannot deposit less than 0");
            return false;
        }

        AccountBalance += amount;
        Transactions.Add(new Transaction("deposit", amount));
        Console.WriteLine($"Deposited: {amount:C2}");

        return true;
    }

    public bool Withdraw(decimal amount)
    {
        if (AccountBalance < 0)
        {
            return false;
        }

        if (amount <= 0)
        {
            Console.WriteLine("Invalid input: Amount must be greater than 0");
            return false;
        }

        if (amount > AccountBalance)
        {
            Console.WriteLine("Invalid input: Cannot withdraw more than the balance in the account");
            return false;
        }

        AccountBalance -= amount;
        Transactions.Add(new Transaction("withdrawal", amount));

        return true;
    }

    public StandingOrder CreateStandingOrder(string payee, string reference, decimal amount, string interval, DateTime date = default)
    {
        if (date == default)
        {
            date = DateTime.Now;
        }

        switch (interval.ToUpper())
        {

            case "DAILY":
                break;

            case "WEEKLY":
                break;

            case "MONTHLY":
                break;

            case "QUARTERLY":
                break;

            case "YEARLY":
                break;

            default:
                throw new ArgumentException("Not a valid interval type");


        }

        StandingOrder so = new StandingOrder(payee, reference, amount, interval, date);
        Transactions.Add(so);
        return so;
    }

    public bool RemoveStandingOrder(string reference)
    {
        var standingOrders = Transactions.OfType<StandingOrder>().ToList();
        StandingOrder? so = standingOrders.Find(s => s.Reference == reference);
        if (so != null)
        {
            Transactions.Remove(so);
            return true;
        }

        Console.WriteLine("There is no standing order with the reference: " + reference);
        return false;
    }



    public bool DisplayStandingOrders()
    {
        var standingOrders = Transactions.OfType<StandingOrder>().ToList();

        if (standingOrders.Count > 0)
        {
            foreach (var standingOrder in standingOrders)
            {
                standingOrder.ShowDetails();
                Console.WriteLine("");
                standingOrder.DisplayDetails();
                Console.WriteLine("");
            }

            return true;
        }

        Console.WriteLine("There are no standing orders");
        return false;
    }

    public StandingOrder FindStandingOrderByReference(string reference)
    {
        var standingOrders = Transactions.OfType<StandingOrder>().ToList();
        StandingOrder? so = standingOrders.Find(s => s.Reference == reference);
        if (so != null)
        {
            so.ShowDetails();
            Console.WriteLine();
            so.DisplayDetails();
            return so;
        }
        Console.WriteLine("There is no standing order with the reference: " + reference);
        return null;
    }

    


    public void DisplayAccountTransactions()
    {
        foreach (var transaction in Transactions)
        {
            transaction.ShowDetails();
        }
    }

    public void DisplayBalance()
    {
        Console.WriteLine($"{AccountBalance:C2}");
    }

    public virtual void DisplayAccountInformation()
    {
        Console.WriteLine($"""
        Account Name : {_accountName}
        Account Number: {_accountNumber}
        Account Balance: {_accountBalance}
        Date of Creation : {_creationDate}
        """);
    }

}
public abstract class Account
{

    private string _accountName = "";
    private int _accountNumber = 0;
    private decimal _accountBalance = 0;
    private string _creationDate = "";

    public Account(string accountName, int accountNumber, decimal accountBalance, string creationDate)
    {
        _accountName = accountName;
        _accountNumber = accountNumber;
        _accountBalance = accountBalance;
        _creationDate = creationDate;
    }

    public string AccountName { get => _accountName; set => _accountName = value; }
    public int AccountNumber { get => _accountNumber; }
    public decimal AccountBalance { get => _accountBalance; set => _accountBalance = value; }

    public string CreationDate { get => _creationDate; set => _creationDate = value; }

    public virtual bool Deposit (decimal amount){
        AccountBalance += amount;
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
        return true;
    }

    public void DisplayBalance (){
        Console.WriteLine($"{AccountBalance:C2}");
    }

    public virtual void DisplayAccountInformation(){
        Console.WriteLine($"""
        Account Name : {_accountName}
        Account Number: {_accountNumber}
        Account Balance: {_accountBalance}
        Date of Creation : {_creationDate}
        """);
    }
    
}
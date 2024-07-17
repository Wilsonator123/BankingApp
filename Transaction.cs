namespace BankingApp;

public class Transaction
{
    // could throw exceptions on null arguments
    public Guid TransactionId { get; }
    public string TransactionType { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal TransactionAmount { get; set; }

    public Transaction(string transactionType, DateTime transactionDate)
    {
        // could throw exceptions on null arguments
        TransactionId = Guid.NewGuid();
        TransactionType = transactionType;
        TransactionDate = transactionDate;
    }

    // for withdrawals and deposits
    public Transaction(string transactionType, decimal transactionAmount)
    {
        TransactionId = Guid.NewGuid();
        TransactionType = transactionType;
        TransactionDate = DateTime.Now;
        TransactionAmount = transactionAmount;

    }

 

    public virtual void ShowDetails()
    {
        Console.WriteLine($"""
                          Transaction ID: {TransactionId}
                          Type: {TransactionType}
                          Creation Date: {DateHelper.DateToString(TransactionDate)}
                          """);

        // could make a switch statement for each transaction type
        switch (TransactionType.ToLower())
        {
            case "withdrawal":
                Console.WriteLine($"Amount Withdrawn: {TransactionAmount}");
                break;
            case "deposit":
                Console.WriteLine($"Amount Deposited: {TransactionAmount}");
                break;
        }
    }

}


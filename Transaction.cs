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
        TransactionType = transactionType.ToUpper();
        TransactionDate = transactionDate;
    }

    // for withdrawals and deposits
    public Transaction(string transactionType, decimal transactionAmount)
    {
        TransactionId = Guid.NewGuid();
        TransactionType = transactionType.ToUpper();
        TransactionDate = DateTime.Now;
        TransactionAmount = transactionAmount;

    }
    public Transaction(string transactionType)
    {
        TransactionId = Guid.NewGuid();
        TransactionType = transactionType.ToUpper();
        TransactionDate = DateTime.Now;

    }

 

    public virtual void ShowDetails()
    {
        Console.WriteLine($"""
                          Transaction ID: {TransactionId}
                          Type: {TransactionType}
                          Creation Date: {DateHelper.DateToString(TransactionDate)}
                          """);
        // creation date for standing order and direct debit
        // transaction date for withdrawals and deposits

        // could make a switch statement for each transaction type
        switch (TransactionType)
        {
            case "WITHDRAWAL":
                Console.WriteLine($"Amount Withdrawn: {TransactionAmount:C2}");
                break;
            case "DEPOSIT":
                Console.WriteLine($"Amount Deposited: {TransactionAmount:C2}");
                break;
        }
    }

}


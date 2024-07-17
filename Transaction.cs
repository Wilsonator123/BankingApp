namespace BankingApp;

public class Transaction
{
    // could throw exceptions on null arguments
    public Guid TransactionId { get; }
    public string TransactionType { get; set; }
    public DateTime TransactionDate { get; set; }

    public Transaction(string transactionType, DateTime transactionDate)
    {
        // could throw exceptions on null arguments
        TransactionId = Guid.NewGuid();
        TransactionType = transactionType;
        TransactionDate = transactionDate;
    }

    public Transaction(string transactionType)
    {
        TransactionId = Guid.NewGuid();
        TransactionType = transactionType;
        TransactionDate = DateTime.Now;
    }

 

    public virtual void ShowTransactionDetails()
    {
        Console.WriteLine($"""
                          TransactionID: {TransactionId}
                          TransactionType: {TransactionType}
                          TransactionDate: {DateHelper.DateToString(TransactionDate)}
                          """);
    }

}


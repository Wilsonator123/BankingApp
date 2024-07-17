namespace BankingApp;

public class Transaction
{
    public Transaction(Guid transactionId, string transactionType, DateTime transactionDate)
    {
        // could throw exceptions on null arguments
        TransactionID = transactionId;
        TransactionType = transactionType;
        TransactionDate = transactionDate;
    }

    // could throw exceptions on null arguments
    public Guid TransactionID { get; set; }

    public string TransactionType { get; set; } = "";
    public DateTime TransactionDate { get; set; }

    public virtual void ShowTransactionDetails()
    {
        Console.WriteLine($"""
                          TransactionID: {TransactionID}
                          TransactionType: {TransactionType}
                          TransactionDate: {TransactionDate}
                          """);
    }

}


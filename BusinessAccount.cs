namespace BankingApp;

public enum BusinessType
{
    // These types need to be handled by our application
    SoleTrader,
    Partnership,
    LimitedCompany,

    // These types should not be handled, but still could be kept in our application
    Enterprise,
    PLC,
    Charity,
    PublicSector
}

public class BusinessAccount : Account
{
    public string BusinessName => _businessName;

    public int AnnualCharge => _annualCharge;

    public BusinessType BusinessType => _businessType;

    public string? DebitCardNumber => _debitCardNumber;

    public string? CreditCardNumber => _creditCardNumber;

    public decimal OverdraftAmount => _overdraftAmount;

    public string ChequeBookId => _chequeBookId;

    public decimal LoanRate => _loanRate;

    private string _businessName;

    // A business can only apply for one account and will
    // be subject to an annual charge of £120 (GBP)
    private int _annualCharge = 120;

    // Any company coming forward that is an enterprise, plc, charity, public sector based will need to be
    // handled by another department. These business types are excluded from this account.
    private BusinessType _businessType;

    // The account holders will be issued debit/credit cards
    // and may also receive an overdraft facility.
    private string? _debitCardNumber;
    private string? _creditCardNumber;

    private decimal _overdraftAmount;

    // A business account comes with a business cheque book, which is by request. 
    private string _chequeBookId;

    // Other benefits include international trading and access to loans.
    private decimal _loanRate;

    public BusinessAccount(string accountName, string accountNumber, decimal accountBalance,string creationDate,
        string businessName, BusinessType businessType, string? debitCardNumber, string? creditCardNumber,
        decimal overdraftAmount, string chequeBookId, decimal loanRate) : base(accountName, accountNumber,
        accountBalance, accountType: "business", creationDate)
    {
        _businessName = businessName;
        _businessType = businessType;
        _debitCardNumber = debitCardNumber;
        _creditCardNumber = creditCardNumber;
        _overdraftAmount = overdraftAmount;
        _chequeBookId = chequeBookId;
        _loanRate = loanRate;
    }


    public override void DisplayAccountInformation()
    {
        base.DisplayAccountInformation();

        string businessRelatedInfo = $"""
                                      Business Name: {_businessName}
                                      Business Type: {_businessType}
                                      Annual Charge: {_annualCharge:C2}
                                      Debit Card Number: {_debitCardNumber}
                                      Credit Card Number: {_creditCardNumber}
                                      Overdraft Amount: {_overdraftAmount:C2}
                                      ChequeBook Id: {_chequeBookId}
                                      Loan Rate: {_loanRate}
                                      """;
        Console.WriteLine(businessRelatedInfo);
    }
}
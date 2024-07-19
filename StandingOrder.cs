namespace BankingApp
{
    public class StandingOrder : Transaction
    {

        private string _payee;

        private string _reference;

        private decimal _amount;
        // weekly, monthly, etc.
        private string _interval;

        public StandingOrder(string payee, string reference, decimal amount, string interval) 
            : base("Standing Order") 
  
        {
            // could throw exceptions on null arguments
            Payee = payee;
            Reference = reference;
            Amount = amount;
            Interval = interval;

        }

        // could throw exceptions on null arguments
        public string Payee { get => _payee; set => _payee = value; }

        public string Reference { get => _reference; set => _reference = value; }

        public decimal Amount { get => _amount; set => _amount = value; }
        // weekly, monthly, etc.
        public string Interval { get => _interval; set => _interval = value; }


        public void DisplayDetails()
        {
            Console.WriteLine($"""
                              Transaction ID: {TransactionId}
                              Payee: {Payee}
                              Reference: {Reference}
                              Amount: {Amount}
                              Interval: {Interval}
                              """);
        }

        private DateTime NextPaymentDate()
        {
            // TODO: Calculate next payment date
            // assuming payment first started on transaction's creation date...
            // Get transaction's creation date
            // get standing order's interval
            // get current date
            // calculate the difference between current date and creation date...
            //  ... in terms of the interval - call it 'timeDifference'

            // e.g. how many weeks/months has it been since creation date
            //          can get amount of payments and total paid from this
            // creationDate + timeDifference + intervalTimeSpan = nextPaymentDate (turn it into a date)

            throw new NotImplementedException();
        }

    }
}

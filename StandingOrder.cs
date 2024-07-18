namespace BankingApp
{
    public class StandingOrder : Transaction
    {
        // could throw exceptions on null arguments
        public string Payee { get; set; }

        public string Reference { get; set; }

        public decimal Amount { get; set; }
        // weekly, monthly, etc.
        public string Interval { get; set; }

        public StandingOrder(string payee, string reference, decimal amount, string interval) 
            : base("Standing Order") 
  
        {
            // could throw exceptions on null arguments
            Payee = payee;
            Reference = reference;
            Amount = amount;
            Interval = interval;

        }


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

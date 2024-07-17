namespace BankingApp
{
    public class StandingOrder
    {
        

        public StandingOrder(string payee, string reference, decimal amount, string interval)
        {
            // could throw exceptions on null arguments
            Payee = payee;
            Reference = reference;
            Amount = amount;
            Interval = interval;

        }

        // could throw exceptions on null arguments
        public string Payee { get; set; }

        public string Reference { get; set; }

        public decimal Amount { get; set; }
        // weekly, monthly, etc.
        public string Interval { get; set; }


        public void DisplayDetails()
        {
            Console.WriteLine($"""
                              Payee: {Payee}
                              Reference: {Reference}
                              Amount: {Amount}
                              Interval: {Interval}
                              """);
        }



    }
}

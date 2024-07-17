namespace BankingApp
{
    public class StandingOrder
    {
        private string _payee = "";
        private string _reference = "";
        private decimal _amount = 0.00m;
        // weekly, monthly, etc.
        private string _interval = "";

        public StandingOrder(string payee, string reference, decimal amount, string interval)
        {
            // could throw exceptions on null arguments
            Payee = payee;
            Reference = reference;
            Amount = amount;
            Interval = interval;

        }

        // could throw exceptions on null arguments
        public string Payee { get => _payee; set => _payee = value; }
        public string Reference { get => _reference; set => _reference = value;
        }
        public decimal Amount { get => _amount; set => _amount = value; }

        public string Interval { get => _interval; set => _interval = value; }

        

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

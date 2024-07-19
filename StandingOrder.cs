using System.Runtime.InteropServices.JavaScript;

namespace BankingApp
{
    public class StandingOrder : Transaction
    {

        private string _payee;

        private string _reference;

        private decimal _amount;
        // weekly, monthly, etc.
        private string _interval;

        private DateTime _nextPaymentDate;

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
        public DateTime NextPaymentDate { get => _nextPaymentDate; set => _nextPaymentDate = GetNextPaymentDate(); }


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

        private DateTime GetNextPaymentDate()
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


            DateTime creationDate = TransactionDate.Date;
            DateTime currentDate = DateTime.Now.Date;
            DateTime nextPaymentDate = creationDate;
            
            TimeSpan timeDifference = currentDate - creationDate;

            int numberOfIntervals = timeDifference.Days;
            decimal totalAmountPaid = 0; ;// should split this into a different method


            switch (Interval.ToUpper())

            {

                case "DAILY":
                    nextPaymentDate = creationDate.AddDays(timeDifference.Days + 1);
                    totalAmountPaid = numberOfIntervals * _amount;


                    break;
                case "WEEKLY":
                    // can't do add weeks so... convert to weeks + 1... then convert back to days to fit AddDays()
                    nextPaymentDate = creationDate.AddDays((timeDifference.Days / 7 + 1) * 7);
                    numberOfIntervals = timeDifference.Days / 7;
                    totalAmountPaid = numberOfIntervals * _amount;

                    break;
                case "MONTHLY":
                    nextPaymentDate = creationDate.AddMonths(1);
                    numberOfIntervals = timeDifference.Days / 12;
                    totalAmountPaid = numberOfIntervals * _amount;

                    break;
                case "QUARTERLY":
                    nextPaymentDate = creationDate.AddMonths(3);
                    numberOfIntervals = timeDifference.Days / 4;
                    totalAmountPaid = numberOfIntervals * _amount;

                    break;
                case "YEARLY":
                    nextPaymentDate = creationDate.AddYears(1);
                    numberOfIntervals = timeDifference.Days / 365;
                    totalAmountPaid = numberOfIntervals * _amount;

                    break;
            }



            return nextPaymentDate;
        }

    }
}

// Should probably make a StandingOrder interface as personal and business accounts can have 
// standing orders but ISA accounts can't

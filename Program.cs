using BankingApp;
public class Program
{
    public static void Main()
    {
        // var businessAccount = new BusinessAccount("MyBusinessAccount", 12123, 1000m, "17-07-2024", "Warner Bros", 
        //     BusinessType.Partnership, null, 1234512, 1000, "#1234", 4.5m);
        // businessAccount.DisplayAccountInformation();
        // Customer cus = new Customer("George", "Wilson", 100, 100, "24/01/2003");
        // Console.WriteLine(cus.ToString());


        // // Uncomment this to test the data parser
        // string workingDirectory = Environment.CurrentDirectory;
        // string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        // Console.WriteLine(projectDirectory);
        // var businessAccountData = DataParser.ReadDataFromCSV(projectDirectory + "/Data/BusinessSampleData.csv");
        // foreach (var account in businessAccountData)
        // {
        //     Console.WriteLine(account["AccountName"]);
        //     Console.WriteLine(account["AccountBalance"]);
        //     
        // }

        // An example of how to do local data storage
        //Console.WriteLine(Globals.LOCAL_DATA_PATH);
        //if (!Directory.Exists(Globals.LOCAL_DATA_PATH))
        //{
        //    Directory.CreateDirectory(Globals.LOCAL_DATA_PATH);
        //}
        //string businessAccountDataLocation = Globals.LOCAL_DATA_PATH + "BusinessAccount.csv";

        //using (StreamWriter sr = new StreamWriter(businessAccountDataLocation))
        //{
        //    sr.WriteLine("AccountName, AccountNumber, AccountBalance, CreationDate, BusinessName, BusinessType, DebitCardNumber, CreditCardNumber, OverdraftAmount, ChequeBookId, LoanRate\r\nMyBusinessAccount1, 12123,    1000m, 17-07-2024, Warner Bros, BusinessType.Partnership, null, 1234512, 1000, #1234, 4.5m\r\nMyBusinessAccount2,12121311, 2421m, 17-01-2024, Barner Bros, BusinessType.Partnership, 2323213, 1234512, 1000, #1231, 2.5m\r\nMyBusinessAccount2,12121311, 1231m, 17-01-2024, Barner Bros, BusinessType.Partnership, 2323213, 1234512, 1000, #1231, 2.5m\r\n");
        //}

        //Console.WriteLine(businessAccountDataLocation);
    }
}

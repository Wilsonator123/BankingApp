using System.Security.Principal;

namespace BankingApp;

public class Data
{
    /// <summary>
    /// (Should be able to) Read and convert files in csv format storing
    /// bank account information into a a list of dictionaries
    /// 
    /// An ideal csv file should be the following format 
    ///  accountName,   acocuntNumber1, accountBalance1 ... 
    ///  john,          1234,           2000                          
    ///  luise,         2345,           4200                          
    /// </summary>
    /// 
    /// <param name="filePath">absolute or relative path to the csv file</param>
    /// <returns>
    /// A list of dictionaries, each dictionary contains a
    /// list of key-value pairs where each key is a account attribute name,
    /// and the value is the attribute value 
    /// </returns>
    public static List<Account> ReadAccountFromCSV(string filePath, string accountType)
    {
        List<Account> accountList = new();
        string[] attributes = [];

        try
        {
            StreamReader sr = new StreamReader(filePath);
            // A line (except the first one) should be a list of comma
            // seperated values of attributes for a single account
            // e.g. accountName1, acocuntNumber1, accountBalance1 ... 
            string line;
            int lineCount = 0;
            while ((line = sr.ReadLine()) != null)
            {
                string[] fields = line.Trim().Split(',');

                if (lineCount == 0)
                {
                    attributes = fields;
                }
                else
                {
                    Dictionary<string, string> accountInfo = new();
                    for (int i = 0; i < fields.Length; i++)
                    {
                        accountInfo.Add(attributes[i].Trim(), fields[i].Trim());
                    }
                    Account newAccount = null;
                    switch (accountType)
                    {
                        case "Personal":
                            throw new NotImplementedException();
                            break;

                        case "Business":
                            newAccount = GenerateBusinessAccountObj(accountInfo);
                            break;

                        case "ISA":
                            throw new NotImplementedException();
                            break;

                        default:
                            throw new Exception("The account type is not recognised");


                    }
                    accountList.Add(newAccount);
                }

                lineCount++;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
        return accountList;
    }

    private static BusinessAccount GenerateBusinessAccountObj(Dictionary<string, string> accountInfo)
    {
        string accountName = accountInfo["AccountName"];
        string accountNumber = accountInfo["AccountNumber"];
        decimal accountBalance;

        if (!decimal.TryParse(accountInfo["AccountBalance"], out accountBalance))
        {
            throw new Exception("Account balance entered is not valid");
        };

        string creationDate = accountInfo["CreationDate"];
        string businessName = accountInfo["BusinessName"];

        BusinessType businessType;
        if (!BusinessType.TryParse(accountInfo["BusinessType"], out businessType))
        {
            throw new Exception("Business type entered does not match");
        };
        string? debitCardNumber = accountInfo["DebitCardNumber"];
        string? creditCardNumber = accountInfo["CreditCardNumber"];
        decimal overdraftAmount;
        if (!decimal.TryParse(accountInfo["OverdraftAmount"], out overdraftAmount))
        {
            throw new Exception("Overdraft amount entered is not valid");

        }
        string chequeBookId = accountInfo["ChequeBookId"];
        decimal loanRate;
        if (!decimal.TryParse(accountInfo["LoanRate"], out loanRate))
        {
            throw new Exception("Loan rate entered in not valid");

        }

        BusinessAccount newAccount = new(accountName, accountNumber, accountBalance, creationDate, businessName, businessType, debitCardNumber, creditCardNumber, overdraftAmount, chequeBookId, loanRate);

        return newAccount;
    }


    //// An example of how to do local data storage
    //public static void StoreDataAsJson()
    //{

    //    Console.WriteLine(Globals.LOCAL_DATA_PATH);
    //    if (!Directory.Exists(Globals.LOCAL_DATA_PATH))
    //    {
    //        Directory.CreateDirectory(Globals.LOCAL_DATA_PATH);
    //    }
    //    string businessAccountDataLocation = Globals.LOCAL_DATA_PATH + "BusinessAccount.csv";

    //    using (StreamWriter sr = new StreamWriter(businessAccountDataLocation))
    //    {
    //        sr.WriteLine("AccountName, AccountNumber, AccountBalance, CreationDate, BusinessName, BusinessType, DebitCardNumber, CreditCardNumber, OverdraftAmount, ChequeBookId, LoanRate\r\nMyBusinessAccount1, 12123,    1000m, 17-07-2024, Warner Bros, BusinessType.Partnership, null, 1234512, 1000, #1234, 4.5m\r\nMyBusinessAccount2,12121311, 2421m, 17-01-2024, Barner Bros, BusinessType.Partnership, 2323213, 1234512, 1000, #1231, 2.5m\r\nMyBusinessAccount2,12121311, 1231m, 17-01-2024, Barner Bros, BusinessType.Partnership, 2323213, 1234512, 1000, #1231, 2.5m\r\n");
    //    }

    //    Console.WriteLine(businessAccountDataLocation);
    //}

}
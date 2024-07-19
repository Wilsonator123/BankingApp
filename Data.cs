using System.Reflection;

namespace BankingApp;

public class Data
{
    // The first time we intialise the account object,
    // we will read from the template data provided inside the temp folder

    public static List<Account> InitAccountsFromTemp(string fileType)
    {
        string workingDirectory = Environment.CurrentDirectory;
        string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

        var initialAccounts = Data.ReadAccountFromCSV(projectDirectory + $"/Temp/{fileType}SampleData.csv", fileType);

        return initialAccounts;
    }

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
    /// 
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
                            newAccount = GeneratePersonalAccountObj(accountInfo);
                            break;

                        case "Business":
                            newAccount = GenerateBusinessAccountObj(accountInfo);
                            break;

                        case "ISA":
                            newAccount = GenerateISAAccountObj(accountInfo);

                            break;

                        default:
                            throw new Exception(@"The account type is not recognised, it must either 'Personal', 'Business', 'ISA'");
                    }
                    accountList.Add(newAccount);
                }

                lineCount++;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The file does not exist or could not be read:");
            Console.WriteLine(e.Message);
        }
        return accountList;
    }

    private static ISAAccount GenerateISAAccountObj(Dictionary<string, string> accountInfo)
    {
        string accountName = accountInfo["AccountName"];
        string accountNumber = accountInfo["AccountNumber"];
        decimal accountBalance;
        if (!decimal.TryParse(accountInfo["AccountBalance"], out accountBalance))
        {
            throw new Exception("Some acccount balances field in the csv are not valid");
        }
        string creationDate = accountInfo["CreationDate"];

        ISAAccount newAccount = new(accountName, accountNumber, accountBalance, creationDate);
        return newAccount;
    }

    private static PersonalAccount GeneratePersonalAccountObj(Dictionary<string, string> accountInfo)
    {

        string accountName = accountInfo["AccountName"];
        string accountNumber = accountInfo["AccountNumber"];
        decimal accountBalance;
        if (!decimal.TryParse(accountInfo["AccountBalance"], out accountBalance))
        {
            throw new Exception("Some acccount balances field in the csv are not valid");
        }
        string creationDate = accountInfo["CreationDate"];
        decimal initialDeposit;
        if (!decimal.TryParse(accountInfo["InitialDeposit"], out initialDeposit))
        {
            throw new Exception("Some Initial Deposit field in the csv are not valid");
        }
        PersonalAccount newAccount = new(accountName, accountNumber, accountBalance, creationDate, initialDeposit);
        return newAccount;
    }

    private static BusinessAccount GenerateBusinessAccountObj(Dictionary<string, string> accountInfo)
    {
        string accountName = accountInfo["AccountName"];
        string accountNumber = accountInfo["AccountNumber"];
        decimal accountBalance;

        if (!decimal.TryParse(accountInfo["AccountBalance"], out accountBalance))
        {
            throw new Exception("Some Account Balance field in the csv are not valid");
        };

        string creationDate = accountInfo["CreationDate"];
        string businessName = accountInfo["BusinessName"];

        BusinessType businessType;
        if (!BusinessType.TryParse(accountInfo["BusinessType"], out businessType))
        {
            throw new Exception("Some Business Type field in the csv are not valid");
        };
        string? debitCardNumber = accountInfo["DebitCardNumber"];
        string? creditCardNumber = accountInfo["CreditCardNumber"];
        decimal overdraftAmount;
        if (!decimal.TryParse(accountInfo["OverdraftAmount"], out overdraftAmount))
        {
            throw new Exception("Some Overdraft Amount field in the csv are not valid");

        }
        string chequeBookId = accountInfo["ChequeBookId"];
        decimal loanRate;
        if (!decimal.TryParse(accountInfo["LoanRate"], out loanRate))
        {
            throw new Exception("Some Loan Rate field in the csv are not valid");
        }

        BusinessAccount newAccount = new(accountName, accountNumber, accountBalance, creationDate, businessName, businessType, debitCardNumber, creditCardNumber, overdraftAmount, chequeBookId, loanRate);

        return newAccount;
    }

    // A super user-friendly way to store account info

    // you don't even have to to specify path names on where you would like
    // to store it,
    // it has been already encapsulated for you, all you have to supply is
    // the data you want to store as a list of Account objects

    // Also it account types supplied here should be pure,
    // in the sense that you should not mix personal with business etc.
    public static void StoreDataAsCSV(List<Account> accounts, string accountType)
    {
        if (!Directory.Exists(Globals.LOCAL_DATA_PATH))
        {
            Directory.CreateDirectory(Globals.LOCAL_DATA_PATH);
        }

        // Clear the old data 

        string oldFileLocation = GetAccountInfoLocation(accountType);
        if (File.Exists(oldFileLocation))
        {
            try
            {
                File.Delete(oldFileLocation);

            }
            catch (Exception)
            {
                Console.WriteLine("The csv file is already in use, close it and try again");
                return;
            }
        }


        foreach (var account in accounts)
        {


            string accountDataLocation = GetAccountInfoLocation(accountType);
            // The file is rewritten every time the function is being called, so make sure all account info has been passed
            using (StreamWriter sr = new StreamWriter(accountDataLocation, true))
            {
                // Start by writing the first line of the file as a list of attribute names
                PropertyInfo[] props = null;
                if (accountType == "Personal") props = typeof(PersonalAccount).GetProperties();
                else if (accountType == "Business") props = typeof(BusinessAccount).GetProperties();
                else if (accountType == "ISA") props = typeof(ISAAccount).GetProperties();

                if (new FileInfo(accountDataLocation).Length == 0)
                {
                    List<string> propNames = new();
                    foreach (PropertyInfo? prop in props)
                    {
                        propNames.Add(prop.Name);
                    }
                    sr.WriteLine(String.Join(',', propNames));
                }

                List<string> valueNames = new();
                foreach (PropertyInfo? prop in props)
                {
                    valueNames.Add(prop.GetValue(account, null).ToString());
                }
                sr.WriteLine(String.Join(',', valueNames));
            }
        }
    }

    public static string GetAccountInfoLocation(string accountType)
    {
        return Globals.LOCAL_DATA_PATH + accountType + "Account" + ".csv";
    }

}
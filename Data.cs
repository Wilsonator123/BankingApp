using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Windows.Markup;

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

    // A super user-friendly way to store account info

    // you don't even have to to specify path names on where you would like
    // to store it,
    // it has been already encapsulated for you, all you have to supply is
    // the data you want to store as a list of Account objects
    public static void StoreDataAsCSV(List<Account> accounts)
    {
        if (!Directory.Exists(Globals.LOCAL_DATA_PATH))
        {
            Directory.CreateDirectory(Globals.LOCAL_DATA_PATH);
        }
        string fileName = "";

        // Clear the old data 
        string[] accountTypes = ["PersonalAccount", "BusinessAccount", "ISSAcount"];
        foreach (string accountType in accountTypes)
        {
            string oldFileLocation = Globals.LOCAL_DATA_PATH + accountType + ".csv";
            if (File.Exists(oldFileLocation))
            {
                File.Delete(oldFileLocation);
            }
        }

        foreach (var account in accounts)
        {
            if (account is PersonalAccount) fileName = "PersonalAccount";
            if (account is BusinessAccount) fileName = "BusinessAccount";
            if (account is ISAAccount) fileName = "ISAAccount";

            string accountDataLocation = Globals.LOCAL_DATA_PATH + fileName + ".csv";
            // The file is rewritten every time the function is being called, so make sure all account info has been passed
            using (StreamWriter sr = new StreamWriter(accountDataLocation, true))
            {
                // Start by writing the first line of the file as a list of attribute names
                PropertyInfo[] props = null;
                if (fileName == "PersonalAccount") props = typeof(PersonalAccount).GetProperties();
                else if (fileName == "BusinessAccount") props = typeof(BusinessAccount).GetProperties();
                else if (fileName == "ISAAccount") props = typeof(ISAAccount).GetProperties();

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

}
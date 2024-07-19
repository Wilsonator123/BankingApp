using BankingApp;
public class Program
{

    public static void Authorize()
    {
        bool validAccount = false;
        do
        {
            Console.Write("Username: ");
            string? tellerName = Console.ReadLine();
            Console.Write("Password: ");
            string? tellerPassword = Console.ReadLine();

            if (tellerName == "Test" && tellerPassword == "Pass")
            {
                Console.WriteLine($"Welcome {tellerName}!");
                validAccount = true;
            }
            else Console.WriteLine("Incorrect Username or Password");
        } while (!validAccount);

    }

    public static bool MainMenu()
    {
        string? choice;
        do
        {
            Console.Write("""
                              
                              Please select an option from the selection below
                              1. View Customer Account
                              2. Create Customer Account 
                              x. Exit
                              > 
                              """);
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    break;
                case "2":
                    CreateCustomer();
                    Console.Clear();
                    break;
                
            }
            
        } while (choice?.ToLower() != "x");

        return false;
    }

    public static void CreateCustomer()
    {
        Console.Clear();
        Console.WriteLine("\t **** Create a new Customer Account ****");
        Console.WriteLine("Please enter the following details");
        Console.Write("First Name: ");
        string? firstName = Console.ReadLine();
        while (firstName == "")
        {
            Console.Write("Enter a valid first name: ");
            firstName = Console.ReadLine();
        }

        Console.Write("Last Name: ");
        string? lastName = Console.ReadLine();
        while (lastName == "")
        {
            Console.Write("Enter a valid last name: ");
            lastName = Console.ReadLine();
        }

        Console.Write("Enter date of birth (dd/mm/yyy): ");
        string? dateOfBirth = Console.ReadLine();
        while (!Regex.IsMatch(dateOfBirth, @"^[0-3][0-9]\/[0-1][1-9]\/(?:19|20)[0-9][0-9]"))
        {
            Console.WriteLine("Invalid Format (dd/mm/yyyy)");
            Console.Write("Enter a valid date: ");
            Console.ReadLine();
        }

        Console.Write("""

                      Please Enter Choose a Photo ID type
                      1. UK Drivers License
                      2. UK Passport

                      """);

        string photoTypeInput = Console.ReadLine();
        while (photoTypeInput != "1" && photoTypeInput != "2")
        {
            Console.WriteLine("Invalid Selection");
            Console.Write("Please select a valid option: ");
            photoTypeInput = Console.ReadLine();
        }

        int photoIdType = int.Parse(photoTypeInput);

        Console.WriteLine($"You have chosen {(photoTypeInput == "1" ? "UK Drivers License" : "UK Passport")}");
        Console.Write("Please enter your ID Number: ");
        string? photoId = Console.ReadLine();

        Console.Write("Please enter your address ID: ");
        string? addressId = Console.ReadLine();

        Customer cus = new Customer(firstName, lastName, photoIdType, photoId, 100, dateOfBirth);
        Console.WriteLine(cus.ToString());
    }

    public static void Main(){
        // var businessAccount = new BusinessAccount("MyBusinessAccount", "12123", 1000m, "17-07-2024", "Warner Bros",
        //     BusinessType.Partnership, null, "1234512", 1000, "#1234", 4.5m);
        // businessAccount.DisplayAccountInformation();
        // Customer cus = new Customer("George", "Wilson", 100, 100, "24/01/2003");
        // Console.WriteLine(cus.ToString());
        // Validator.ValidateDriversLicense(cus, "WILSO001243G99KT");

        // Test transaction list
        //businessAccount.DisplayBalance();
        //businessAccount.Withdraw(333.33m);
        //businessAccount.DisplayBalance();
        //businessAccount.Deposit(111.11m);
        //businessAccount.DisplayBalance();
        //businessAccount.DisplayAccountTransactions();


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

        // Example of Transaction instantiation:
        //string dateString = "12/07/2012";
        //DateTime date = DateTime.Parse(dateString);

        //Transaction a = new Transaction("StandingOrder", date);
        //Transaction b = new Transaction("StandingOrder");

        //a.ShowTransactionDetails();
        //b.ShowTransactionDetails();



        Console.WriteLine("\t **** Welcome to ACME Bank! ****");
        Console.WriteLine("Please login to your account:");
        Authorize();

        while (MainMenu()) ;

    }
}

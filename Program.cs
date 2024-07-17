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
            
        } while (choice?.ToLower() != "x");

        return false;
    }

    public static void Main(){
        // var businessAccount = new BusinessAccount("MyBusinessAccount", 12123, 1000m, "17-07-2024", "Warner Bros", 
        //     BusinessType.Partnership, null, 1234512, 1000, "#1234", 4.5m);
        // businessAccount.DisplayAccountInformation();
        // Customer cus = new Customer("George", "Wilson", 100, 100, "24/01/2003");
        // Console.WriteLine(cus.ToString());

        Console.WriteLine("\t **** Welcome to ACME Bank! ****");
        Console.WriteLine("Please login to your account:");
        Authorize();

        while (MainMenu()) ;

    }
}

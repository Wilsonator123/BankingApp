namespace BankingApp;

/*
Driver's license number format
Based on the search results, here is a summary of the UK driving licence number format:

The licence number is 18 characters long and consists of: + 1-5: The first five characters of the surname (padded with 9s if fewer than 5 characters). For surnames beginning with “MAC”, they are treated as “MC” for all.
6: The decade digit from the year of birth (e.g., for 1987, it would be 8).
7-8: The month of birth in two-digit format (7th character is incremented by 5 if the driver is female, i.e., 51-62 instead of 01-12).
The remaining 12 characters are randomly generated and unique to each licence holder.

https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex?view=net-8.0
*/

public static class ValidateId
{
    
}
using System.Globalization;

namespace BankingApp;

public static class DateHelper
{
    public static string DateToString(DateTime date)
    {
        return $"{date.Day:00}/{date.Month:00}/{date.Year}";
    }
}
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BankingApp;

public static class DateHelper
{
    public static string DateToString(DateTime date)
    {
        return $"{date.Day:00}/{date.Month:00}/{date.Year}";
    }

    public static DateTime StringToDate(string date)
    {
        
        if (IsDateFormat(date))
        {
            return DateTime.ParseExact(date, "dd/MM/yyyy", new CultureInfo("en-GB"));
        }
        else
        {
            throw new FormatException("Invalid Date Format"); 
        }
        
    }

    public static bool IsDateFormat(string date)
    {
        return Regex.IsMatch(date, @"^(?:(?:0[1-9]|1[0-9]|2[0-9]|3[?:0|1])\/[0-1][1-9]\/(?:19|20)[0-9][0-9])");
    }
}
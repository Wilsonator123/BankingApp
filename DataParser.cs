namespace BankingApp;

public class DataParser
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
    /// list of key(atrribute name), value(attribute value) pairs 
    /// </returns>
    public static List<Dictionary<string, string>> ReadDataFromCSV(string filePath)
    {
        List<Dictionary<string, string>> userInfoList = new(); 
        string[] attributes = [];
        try
        {
            StreamReader sr = new StreamReader(filePath);
            // A line (except the first one) should be a list of comma
            // seperated values of attributes for a single account holder
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
                    Dictionary<string, string> userInfo = new();
                    for (int i = 0; i < fields.Length; i++)
                    {
                        userInfo.Add(attributes[i].Trim(),fields[i].Trim());                        
                    }

                    userInfoList.Add(userInfo);
                }

                lineCount++;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
        return userInfoList;
    } 
}
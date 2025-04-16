using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Util
{
    public class PropertyUtil
    {
        public static string GetPropertyString()
        {
            string filePath = @"D:\HEXA\C#\ProjectManagementSystem\Util\connectionDetails.txt";
            StringBuilder connectionString = new StringBuilder();

            foreach (var line in File.ReadLines(filePath))
            {
                var keyValue = line.Split('=');
                if (keyValue.Length == 2)
                {
                    string key = keyValue[0].Trim();
                    string value = keyValue[1].Trim();

                    switch (key)
                    {
                        case "hostname":
                            connectionString.Append($"Server={value};");
                            break;
                        case "dbname":
                            connectionString.Append($"Database={value};");
                            break;
                    }
                }
            }

            // Instead of flag directly, use "True" or "False" as string
            connectionString.Append($"Integrated Security=True;");
            connectionString.Append($"TrustServerCertificate=True;");

            return connectionString.ToString();
        }
    }
}
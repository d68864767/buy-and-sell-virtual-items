```csharp
using System;
using MMO_Marketplace;

namespace MMO_Marketplace
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandParser commandParser = new CommandParser();

            while (true)
            {
                Console.WriteLine("Enter command:");
                string command = Console.ReadLine();

                if (string.IsNullOrEmpty(command))
                {
                    break;
                }

                try
                {
                    string result = commandParser.ParseCommand(command);
                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
```

```csharp
using System;
using System.Collections.Generic;

namespace MMO_Marketplace
{
    public class CommandParser
    {
        private Marketplace marketplace;

        public CommandParser()
        {
            marketplace = new Marketplace();
        }

        public string ParseCommand(string command)
        {
            string[] commandParts = command.Split(' ');
            string commandType = commandParts[0];

            switch (commandType)
            {
                case Constants.SELL_COMMAND:
                    return HandleSellCommand(commandParts);
                case Constants.BUY_COMMAND:
                    return HandleBuyCommand(commandParts);
                case Constants.DISPLAY_ITEMS_COMMAND:
                    return marketplace.DisplayItemsForSale();
                case Constants.DISPLAY_TRANSACTIONS_COMMAND:
                    return marketplace.DisplayTransactions();
                default:
                    return "INVALID COMMAND";
            }
        }

        private string HandleSellCommand(string[] commandParts)
        {
            if (commandParts.Length != 4)
            {
                return "INVALID SELL COMMAND";
            }

            int playerID, itemID, price;

            if (!int.TryParse(commandParts[1], out playerID) || !int.TryParse(commandParts[2], out itemID) || !int.TryParse(commandParts[3], out price))
            {
                return "INVALID SELL COMMAND";
            }

            return marketplace.SellItem(playerID, itemID, price);
        }

        private string HandleBuyCommand(string[] commandParts)
        {
            if (commandParts.Length != 3)
            {
                return "INVALID BUY COMMAND";
            }

            int playerID, itemID;

            if (!int.TryParse(commandParts[1], out playerID) || !int.TryParse(commandParts[2], out itemID))
            {
                return "INVALID BUY COMMAND";
            }

            return marketplace.BuyItem(playerID, itemID);
        }
    }
}
```

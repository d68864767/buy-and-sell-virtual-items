```csharp
using System;
using System.Collections.Generic;

namespace MMO_Marketplace
{
    public class Marketplace
    {
        private Dictionary<int, Item> itemsForSale;
        private List<Transaction> transactions;

        public Marketplace()
        {
            itemsForSale = new Dictionary<int, Item>();
            transactions = new List<Transaction>();
        }

        public string SellItem(int playerID, int itemID, int price)
        {
            Player seller = new Player(playerID);
            Item item = new Item(itemID, price, seller);
            itemsForSale.Add(itemID, item);
            return $"ITEM LISTED: {itemID} at price {price}";
        }

        public string BuyItem(int playerID, int itemID)
        {
            if (!itemsForSale.ContainsKey(itemID))
            {
                return Constants.ITEM_NOT_AVAILABLE;
            }

            Player buyer = new Player(playerID);
            Item item = itemsForSale[itemID];
            Transaction transaction = new Transaction(item, buyer);
            transactions.Add(transaction);
            itemsForSale.Remove(itemID);
            return $"ITEM SOLD: {itemID}, Selling Price: {transaction.SellingPrice}, Commission: {transaction.Commission}, Final Price: {transaction.FinalPrice}";
        }

        public string DisplayItemsForSale()
        {
            if (itemsForSale.Count == 0)
            {
                return "NO ITEMS FOR SALE";
            }

            string output = "";
            foreach (var item in itemsForSale.Values)
            {
                output += $"ITEM: {item.ItemID}, PRICE: {item.Price}, SELLER: {item.Seller.PlayerID}\n";
            }
            return output.TrimEnd('\n');
        }

        public string DisplayTransactions()
        {
            if (transactions.Count == 0)
            {
                return "NO TRANSACTIONS";
            }

            string output = "TRANSACTIONS:\n";
            foreach (var transaction in transactions)
            {
                output += transaction.ToString() + "\n";
            }
            return output.TrimEnd('\n');
        }
    }
}
```

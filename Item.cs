```csharp
using System;

namespace MMO_Marketplace
{
    public class Item
    {
        public int ItemID { get; private set; }
        public int Price { get; private set; }
        public Player Seller { get; private set; }

        public Item(int itemID, int price, Player seller)
        {
            if (itemID < Constants.MIN_ITEM_ID || itemID > Constants.MAX_ITEM_ID)
            {
                throw new ArgumentException($"Item ID must be between {Constants.MIN_ITEM_ID} and {Constants.MAX_ITEM_ID}");
            }

            if (price < Constants.MIN_PRICE || price > Constants.MAX_PRICE)
            {
                throw new ArgumentException($"Price must be between {Constants.MIN_PRICE} and {Constants.MAX_PRICE}");
            }

            ItemID = itemID;
            Price = price;
            Seller = seller;
        }
    }
}
```

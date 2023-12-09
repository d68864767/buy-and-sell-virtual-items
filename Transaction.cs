```csharp
using System;

namespace MMO_Marketplace
{
    public class Transaction
    {
        public Item Item { get; private set; }
        public Player Buyer { get; private set; }
        public int SellingPrice { get; private set; }
        public int Commission { get; private set; }
        public int FinalPrice { get; private set; }

        public Transaction(Item item, Player buyer)
        {
            if (item == null || buyer == null)
            {
                throw new ArgumentException("Item and Buyer cannot be null");
            }

            Item = item;
            Buyer = buyer;
            SellingPrice = item.Price;
            Commission = CalculateCommission(SellingPrice);
            FinalPrice = SellingPrice - Commission;
        }

        private int CalculateCommission(int price)
        {
            return (int)Math.Round(price * Constants.COMMISSION_RATE);
        }

        public override string ToString()
        {
            return $"ITEM: {Item.ItemID}, SOLD BY: {Item.Seller.PlayerID}, BOUGHT BY: {Buyer.PlayerID}, SELLING PRICE: {SellingPrice}, COMMISSION: {Commission}, FINAL PRICE: {FinalPrice}";
        }
    }
}
```

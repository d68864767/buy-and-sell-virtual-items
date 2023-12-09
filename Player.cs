```csharp
using System;

namespace MMO_Marketplace
{
    public class Player
    {
        public int PlayerID { get; private set; }

        public Player(int playerID)
        {
            if (playerID < Constants.MIN_PLAYER_ID || playerID > Constants.MAX_PLAYER_ID)
            {
                throw new ArgumentException($"Player ID must be between {Constants.MIN_PLAYER_ID} and {Constants.MAX_PLAYER_ID}");
            }

            PlayerID = playerID;
        }
    }
}
```

using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly.History
{
    internal class BuyHouseHistoryEntry : IHistoryEntry
    {
        private readonly Player player;
        private readonly StreetCard streetCard;
        private readonly int amountOfHouses;

        public BuyHouseHistoryEntry(Player player, StreetCard streetCard, int amountOfHouses)
        {
            this.player = player;
            this.streetCard = streetCard;
            this.amountOfHouses = amountOfHouses;
        }

        public override string ToString()
        {
            return $"{player.Name} bought {amountOfHouses} house(s) on {streetCard.Color}";
		}
	}
}

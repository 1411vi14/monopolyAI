using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly.History
{
    internal class BuyStreetHistoryEntry : IHistoryEntry
    {
        public Player Buyer { get; }
        public StreetCard StreetCard { get; }
        public int Price { get; }
        public BuyStreetHistoryEntry(Player buyer, StreetCard streetCard)
        {
            Buyer = buyer;
            StreetCard = streetCard;
        }
        public override string ToString()
        {
            return $"{Buyer.Name} bought {StreetCard.Name} for {StreetCard.BuyPrice}";
		}
	}
}

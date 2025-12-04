using System;
using System.Collections.Generic;

namespace Monopoly
{
    public class Player
    {
        private Random Random;
        public int Money { get; private set; }
        public List<StreetCard> StreetCards { get; private set; } = new List<StreetCard>();
        public string Name { get; private set; }
        public Cell CurrentCell { get; set; }

        public Player(Random random, string name, Cell currentCell)
        {
            Random = random;
            Money = 5 * 1 + 1 * 5 + 2 * 10 + 1 * 20 + 1 * 50 + 4 * 100 + 2 * 500;
            Name = name;
            CurrentCell = currentCell;
        }

        public string GetCurrentPosition()
        {
            return CurrentCell == null ? "undefined" : "Cell" +  CurrentCell.Index;
        }

        public DiceThrow ThrowDice()
        {
            return new DiceThrow(Random.Next(1, 6), Random.Next(1, 6));
        }

        public void BuyStreetCard(StreetCard streetCard)
        {
            StreetCards.Add(streetCard);
            Money -= streetCard.BuyPrice;
        }

        public void AddMoney(int money)
        {
            Money += money;
        }
                public void TakeMoney(int money)
        {
            Money -= money;
        }
    }
}

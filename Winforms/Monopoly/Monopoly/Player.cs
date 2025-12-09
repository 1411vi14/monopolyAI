using System;
using System.Collections.Generic;

namespace Monopoly
{
	public class Player
	{
		public int Money { get; private set; } = 5 * 1 + 1 * 5 + 2 * 10 + 1 * 20 + 1 * 50 + 4 * 100 + 2 * 500;
		public List<StreetCard> StreetCards { get; } = new();
		public string Name { get; }
		public Cell CurrentCell { get; set; }

		public Player(string name, Cell currentCell)
		{
			Name = name;
			CurrentCell = currentCell;
		}

		public string GetCurrentPosition()
		{
			return CurrentCell == null ? "undefined" : "Cell" + CurrentCell.Index;
		}

		public DiceThrow ThrowDice()
		{
			return new DiceThrow();
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

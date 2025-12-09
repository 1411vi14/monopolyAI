using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly.History
{
	internal class TransactionHistoryEntry : IHistoryEntry
	{
		public Player FromPlayer { get; }
		public Player ToPlayer { get; }
		public int Amount { get; }
		public TransactionHistoryEntry(Player fromPlayer, Player toPlayer, int amount)
		{
			FromPlayer = fromPlayer;
			ToPlayer = toPlayer;
			Amount = amount;
		}
		public override string ToString()
		{
			return $"{FromPlayer.Name} paid {Amount} to {ToPlayer.Name}";
		}
	}
}

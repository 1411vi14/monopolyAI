using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly.History
{
    internal class DiceThrowHistoryEntry : IHistoryEntry
    {
        private readonly Player player;
        private readonly int diceThrow1;
        private readonly int diceThrow2;

        public DiceThrowHistoryEntry(Player player, int diceThrow1, int diceThrow2)
        {
            this.player = player;
            this.diceThrow1 = diceThrow1;
            this.diceThrow2 = diceThrow2;
        }
        public override string ToString()
        {
            return $"{player.Name} rolled {diceThrow1} and {diceThrow2}";
		}
	}
}

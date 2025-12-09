using System;

namespace Monopoly
{
    public class DiceThrow
    {
        public int Dice1 { get; } = Random.Shared.Next(1,6);
        public int Dice2 { get; } = Random.Shared.Next(1, 6);
		public int Sum => Dice1 + Dice2;
        public bool IsPair => Dice1 == Dice2;
    }
}

namespace Monopoly
{
    public class DiceThrow
    {
        public int Dice1 { get; set; } = 0;
        public int Dice2 { get; set; } = 0;
        public int Sum => Dice1 + Dice2;
        public bool IsPair => Dice1 == Dice2;

        public DiceThrow(int dice1, int dice2)
        {
            Dice1 = dice1;
            Dice2 = dice2;
        }
    }
}

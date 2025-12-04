namespace Monopoly
{
    public class Card
    {
        public string Name { get; private set; }

        public Card(string name)
        {
            Name = name;
        }
    }
}
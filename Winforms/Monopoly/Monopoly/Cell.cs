namespace Monopoly
{
    public class Cell
    {
        public int Index { get; private set; }
        public StreetCard StreetCard { get; private set; }

        public Cell(int index, StreetCard streetCard)
        {
            Index = index;
            StreetCard = streetCard;
        }
    }
}
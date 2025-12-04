using System.Collections.Generic;

namespace Monopoly
{
    public class StreetCard : Card
    {
        public int BuyPrice { get; private set; }
        public int HousePrice { get; private set; }
        public Dictionary<int,int> Prices { get; private set; } = new Dictionary<int,int>();
        public bool IsDeactivated { get; private set; } = false;
        public string Color { get; private set; }
        public int Houses { get;private set; } = 0;
        public int Hotels => Houses == 5 ? 1 : 0;

        public StreetCard(int buyPrice, int housePrice, int rent, int oneHousePrice, int twoHousesPrice, int threeHousesPrice,
            int fourHousesPrice, int hotelPrice, string name, string color) : base(name)
        {
            BuyPrice = buyPrice;
            HousePrice = housePrice;
            Prices.Add(0, rent);
            Prices.Add(1, oneHousePrice);
            Prices.Add(2, twoHousesPrice);
            Prices.Add(3, threeHousesPrice);
            Prices.Add(4, fourHousesPrice);
            Prices.Add(5, hotelPrice);
            Color = color;
        }

        public int GetPrice()
        {
            if (Houses < 0 || Houses >= Prices.Count)
                return 0;

            return Prices[Houses];
        }

        public bool AddHouses(int number)
        {
            if (Houses + number >= 6)
                return false;

            Houses += number;
            return true;
        }

        public bool RemoveHouses(int number)
        {
            if (Houses - number < 0)
                return false;

            Houses -= number;
            return true;
        }
    }
}
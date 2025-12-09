using System.Collections.Generic;
using System.Diagnostics;

namespace Monopoly
{
	public class StreetCard : Card
	{
		public int BuyPrice { get; }
		public int HousePrice { get; }
		public IReadOnlyList<int> Prices { get; }
		public bool IsDeactivated { get; } = false;
		public string Color { get; }
		public int Houses { get; private set; } = 0;
		public int Hotels => Houses == 5 ? 1 : 0;

		public StreetCard(
            int buyPrice,
            int housePrice,
            int rent,
            int oneHousePrice,
            int twoHousesPrice,
            int threeHousesPrice,
            int fourHousesPrice,
            int hotelPrice,
            string name,
            string color) : base(name)
		{
			BuyPrice = buyPrice;
			HousePrice = housePrice;
			Prices = new int[] {
				rent,
				oneHousePrice,
				twoHousesPrice,
				threeHousesPrice,
				fourHousesPrice,
				hotelPrice
			};

			Color = color;
		}

		public int GetPrice()
		{
			if (Houses < 0 || Houses >= Prices.Count)
				return 0;

			return Prices[Houses];
		}

		public bool TryAddHouses(int number)
		{
			if (Houses + number >= 6)
				return false;

			Houses += number;
			return true;
		}

		public bool TryRemoveHouses(int number)
		{
			if (Houses - number < 0)
				return false;

			Houses -= number;
			return true;
		}
	}
}
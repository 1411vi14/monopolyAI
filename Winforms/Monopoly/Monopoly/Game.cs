using Monopoly.History;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
	public class Game
	{
		public string Error { get; private set; } = "";
		public enum Stati { Standby, Running, Finished }
		public Stati Status { get; set; } = Stati.Standby;
		public List<Player> Players { get; private set; } = new List<Player>();
		public Player CurrentPlayer { get; private set; }
		public GameBoard GameBoard { get; private set; }
		public Setting Setting { get; private set; }
		public List<IHistoryEntry> History { get; private set; } = new();

		public Game(Setting setting)
		{
			Setting = setting;
			GameBoard = GameBoard.TryCreateGameBoard();
			Reset();
		}

		public bool Reset()
		{
			var startCell = GameBoard.Cells.First();
			for (int a = 0; a < Setting.NumberPlayers; a++)
			{
				Players.Add(new Player("Player" + (a + 1), startCell));
			}
			CurrentPlayer = Players[0];
			Status = Stati.Standby;
			return true;
		}

		public bool NextStep()
		{
			MovePlayer();
			CheckAction();

			if (Players.Any(i => i.Money < 0))
			{
				History.Add(new GameEndHistoryEntry(Players.MaxBy(p => p.Money).Name));
				Status = Stati.Finished;
				return true;
			}

			SelectNextPlayer();
			return true;
		}

		private void CheckAction()
		{
			// check community card/event card

			// Has to pay price
			var streetCardName = CurrentPlayer.CurrentCell.StreetCard.Name;
			Player playerToPayTo = Players.FirstOrDefault(i
				=> i.StreetCards.Any(c => c.Name == CurrentPlayer.CurrentCell.StreetCard.Name)
				&& i.Name != CurrentPlayer.Name
			);
			if (playerToPayTo != null)
			{
				StreetCard streetCard = playerToPayTo.StreetCards.First(i => i.Name == CurrentPlayer.CurrentCell.StreetCard.Name);
				int price = streetCard.GetPrice();
				playerToPayTo.AddMoney(price);
				CurrentPlayer.TakeMoney(price);
				History.Add(new TransactionHistoryEntry(CurrentPlayer, playerToPayTo, price));
			}
			// can buy available street
			else if (CurrentPlayer.CurrentCell.StreetCard != null &&
				CurrentPlayer.CurrentCell.StreetCard.BuyPrice <= CurrentPlayer.Money
				// is streetcard still available?
				&& GameBoard.AvailableStreetCars.FirstOrDefault(i => i.Name ==
				CurrentPlayer.CurrentCell.StreetCard.Name) != null)
			{
				GameBoard.AvailableStreetCars.Remove(CurrentPlayer.CurrentCell.StreetCard);
				CurrentPlayer.BuyStreetCard(CurrentPlayer.CurrentCell.StreetCard);
				History.Add(new BuyStreetHistoryEntry(CurrentPlayer, CurrentPlayer.CurrentCell.StreetCard));

				// can he now buy houses?
				string color = CurrentPlayer.CurrentCell.StreetCard.Color;
				if (CurrentPlayer.StreetCards.Count(i => i.Color == color) == GetAllStreetCards().Count(i => i.Color == color))
				{
					// for now buy as many houses as possible
					int houses = CurrentPlayer.Money / CurrentPlayer.CurrentCell.StreetCard.HousePrice;
					var streetsCards = CurrentPlayer.StreetCards.Where(i => i.Color == color).ToList();
					int numberStreets = streetsCards.Count;
					int housesPerStreet = houses / numberStreets;
					CurrentPlayer.TakeMoney(houses * CurrentPlayer.CurrentCell.StreetCard.HousePrice);
					History.Add(new BuyHouseHistoryEntry(CurrentPlayer, CurrentPlayer.CurrentCell.StreetCard, houses));

					for (int a = 0; a < streetsCards.Count; a++)
					{
						// give rest of houses to last streetcard
						if (a == streetsCards.Count - 1)
						{
							streetsCards[a].TryAddHouses(numberStreets);
							numberStreets = 0;
							break;
						}

						streetsCards[a].TryAddHouses(housesPerStreet);
						numberStreets -= housesPerStreet;
					}
				}
			}
		}

		private List<StreetCard> GetAllStreetCards()
		{
			List<StreetCard> all = new List<StreetCard>();
			all.AddRange(GameBoard.AvailableStreetCars);
			foreach (Player player in Players)
				all.AddRange(player.StreetCards);
			return all;
		}

		private void MovePlayer()
		{
			DiceThrow diceThrow = CurrentPlayer.ThrowDice();
			//int throws = 1;
			//while (throws < 3 && diceThrow.IsPair)
			//{
			//    diceThrow = CurrentPlayer.ThrowDice();

			int newIndex = CurrentPlayer.CurrentCell.Index + diceThrow.Sum;

			if (newIndex >= GameBoard.Cells.Count)
			{
				CurrentPlayer.AddMoney((newIndex == GameBoard.Cells.Count - 1) ? 400 : 200);
				newIndex -= GameBoard.Cells.Count;
			}

			CurrentPlayer.CurrentCell = GameBoard.Cells[newIndex];
			History.Add(new DiceThrowHistoryEntry(CurrentPlayer, diceThrow.Dice1, diceThrow.Dice2));
		}

		private void SelectNextPlayer()
		{
			if (Players.Count < 2)
				return;

			int index = 0;
			for (int a = 0; a < Players.Count; a++)
			{
				if (Players[a].Name == CurrentPlayer.Name)
					index = a;
			}

			if (index < Players.Count - 1)
				index++;
			else
				index = 0;

			CurrentPlayer = Players[index];
		}
	}
}
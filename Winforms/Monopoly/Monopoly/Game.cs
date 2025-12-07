using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    public class Game
    {
        public string Error { get; private set; } = "";
        public enum Stati { Standby, Running, Finished }
        public Stati Status { get; private set; } = Stati.Standby;
        private Random Random { get; set; } = new Random();
        public List<Player> Players { get; private set; } = new List<Player>();
        public Player CurrentPlayer { get; private set; }
        public GameBoard GameBoard { get; private set; }
        public Setting Setting { get; private set; }
        public List<StepHistoryEntry> History { get; private set; } = new List<StepHistoryEntry>();
        private StepHistoryEntry CurrentStepHistoryEntry { get; set; }

        public static Game TryCreateGame()
        {
                GameBoard gameBoard = GameBoard.TryCreateGameBoard();
                Setting setting = new Setting();
                Game game = new Game();
                game.GameBoard = gameBoard;
                game.Restart();
                return game;
        }

        public List<string[]> GetPlayersData()
        {
            List<string[]> data = new List<string[]>();
            foreach (Player player in Players)
                data.Add(new string[] { player.Name, player.Money.ToString(), player.GetCurrentPosition(), player.StreetCards.Count.ToString() });

            return data;
        }

        public bool Restart()
        {
            CurrentPlayer = new Player(Random, "Player1", GameBoard.Cells.First());
            Players.Add(CurrentPlayer);
            Players.Add(new Player(Random, "Player2", GameBoard.Cells.First()));
            Status = Stati.Running;
            return true;
        }

        public bool NextStep()
        {
            CurrentStepHistoryEntry = new StepHistoryEntry();
            MovePlayer();
            CheckAction();

            if (Players.Where(i => i.Money > 0).Count() <= 1)
            {
                CurrentStepHistoryEntry.AddEntry("Game finished");
                Status = Stati.Finished;
                return true;
            }

            SelectNextPlayer();
            History.Add(CurrentStepHistoryEntry);
            return true;
        }

        private void CheckAction()
        {
            // check community card/event card

            // Has to pay price
            Player playerToPayTo = Players.FirstOrDefault(i => i.StreetCards.Where(c => c.Name == CurrentPlayer.CurrentCell.StreetCard.Name).Count() > 0
            && i.Name != CurrentPlayer.Name);
            if (playerToPayTo != null)
            {
                StreetCard streetCard = playerToPayTo.StreetCards.First(i => i.Name == CurrentPlayer.CurrentCell.StreetCard.Name);
                int price = streetCard.GetPrice();
                playerToPayTo.AddMoney(price);
                CurrentPlayer.TakeMoney(price);
                CurrentStepHistoryEntry.AddEntry(CurrentPlayer.Name + " payed " + price + "€ to " + playerToPayTo.Name);
            }
            // can buy available street
            else if (CurrentPlayer.CurrentCell.StreetCard != null &&
                CurrentPlayer.CurrentCell.StreetCard.BuyPrice <= CurrentPlayer.Money)
            {
                GameBoard.AvailableStreetCars.Remove(CurrentPlayer.CurrentCell.StreetCard);
                CurrentPlayer.BuyStreetCard(CurrentPlayer.CurrentCell.StreetCard);
                CurrentStepHistoryEntry.AddEntry(CurrentPlayer.Name + " bought street " +
                    CurrentPlayer.CurrentCell.StreetCard.Name);

                // can he now buy houses?
                string color = CurrentPlayer.CurrentCell.StreetCard.Color;
                if (CurrentPlayer.StreetCards.Where(i => i.Color == color).Count() == GetAllStreetCards().Where(i => i.Color == color).Count())
                {
                    // for now buy as many houses as possible
                    int houses = CurrentPlayer.Money / CurrentPlayer.CurrentCell.StreetCard.HousePrice;
                    int numberStreets = CurrentPlayer.StreetCards.Where(i => i.Color == color).Count();
                    int housesPerStreet = houses / numberStreets;
                    var streetsCards = CurrentPlayer.StreetCards.Where(i => i.Color == color).ToList();
                    CurrentPlayer.TakeMoney(houses * CurrentPlayer.CurrentCell.StreetCard.HousePrice);
                    CurrentStepHistoryEntry.AddEntry(CurrentPlayer.Name + " bought " + houses
                         + " houses on " + color);

                    for (int a = 0; a < streetsCards.Count; a++)
                    {
                        // give rest of houses to last streetcard
                        if (a == streetsCards.Count -1)
                        {
                            streetsCards[a].AddHouses(numberStreets);
                            numberStreets = 0;
                            break;
                        }

                        streetsCards[a].AddHouses(housesPerStreet);
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
            CurrentStepHistoryEntry.AddEntry(CurrentPlayer.Name + " threw " + diceThrow.Dice1 + " and " + diceThrow.Dice2);
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
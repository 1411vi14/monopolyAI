using Invoker_;
using System;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

namespace Monopoly
{
    public static class Viewer
    {
        private static Form1 Form;

        public static void Init(Form1 form)
        {
            Form = form;
        }

        public static void ShowError(string error)
        {
            Invoker.invokeTextSet(Form, error);
        }

        public static void UpdateDataTable(Game game)
        {
            var countBuyedStreets = 0;
            var dataGrid = Form.GetDataGridView();

			for (int rowIndex = 0; rowIndex < game.Players.Count; rowIndex++)
            {
                Player player = game.Players[rowIndex];
				countBuyedStreets += player.StreetCards.Count;

				Invoker.invokeUpdateRow(dataGrid, rowIndex, player);
            }

            if (dataGrid.Rows.Count < game.Players.Count + 1)
            {
                Invoker.invokeAddRow(dataGrid);
            }
			Invoker.invokeUpdateLastRow(dataGrid, countBuyedStreets);
		}

        public static void ClearDataTable()
        {
            var dataGrid = Form.GetDataGridView();
            Invoker.invokeClearRows(dataGrid);
        }

		public static void UpdateView(Game game)
        {
            //         panel1.BackgroundImage = Image.FromFile
            //(System.Environment.GetFolderPath
            //(System.Environment.SpecialFolder.Personal)
            //+ @"\Image.gif");
            UpdateDataTable(game);

            var buttonText = game.Status switch
            {
                Game.Stati.Standby => "Start autorun",
                Game.Stati.Running => "Stop autorun",
                Game.Stati.Finished => "Reset Game",
                _ => "Unknown State"
            };
			Invoker.invokeTextSet(Form.ButtonAutoRun, buttonText);

			string lastEvent = game.History.Count > 0 ? (game.History.Count + ". step\n" + game.History.Last().ToString()) : "";
            Invoker.invokeTextSet(Form.GetRichTextBox(), lastEvent);
        }
    }
}
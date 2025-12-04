using Invoker_;
using System.Linq;

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

        public static void UpdateView(Game game)
        {
           //         panel1.BackgroundImage = Image.FromFile
           //(System.Environment.GetFolderPath
           //(System.Environment.SpecialFolder.Personal)
           //+ @"\Image.gif");

            Invoker.invokeClearRows(Form.GetDataGridView());
            foreach (string[] data in game.GetPlayersData())
                Invoker.invokeAddRow(Form.GetDataGridView(), data);
            Invoker.Resize(Form.GetDataGridView());

            string lastEvent = game.History.Count > 0 ? (game.History.Count + ". step\n" +  game.History.Last().ToString()) : "";
            Invoker.invokeTextSet(Form.GetRichTextBox(), lastEvent);
        }
    }
}

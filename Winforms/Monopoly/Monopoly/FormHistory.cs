using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly
{
    public partial class FormHistory : Form
    {
        private Game _game {  get; set; }

        public FormHistory(Game game)
        {
            InitializeComponent();
            _game = game;
        }

        private void FormHistory_Load(object sender, EventArgs e)
        {
			richTextBox1.Text = string.Join(Environment.NewLine, _game.History.TakeLast(50).Select(i => i.ToString()));
        }
    }
}

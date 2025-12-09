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
	public partial class FormSettings : Form
	{
		public Setting Setting { get; private set; }

		public FormSettings(Setting setting)
		{
			InitializeComponent();
			Setting = setting;
			textBoxNumberPlayer.Text = setting.NumberPlayers.ToString();
			DialogResult = DialogResult.Cancel;
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void buttonAccept_Click(object sender, EventArgs e)
		{
			if (int.TryParse(textBoxNumberPlayer.Text, out int numberOfPlayer))
			{
				if (numberOfPlayer != Setting.NumberPlayers)
				{
					Setting = Setting with { NumberPlayers = numberOfPlayer };
					DialogResult = DialogResult.OK;
				}
				Close();
			}
			else
			{
				MessageBox.Show("Invalid number of players. Please enter a valid integer.");
			}
		}
	}
}

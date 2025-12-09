using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly
{
	public partial class Form1 : Form
	{
		private Controller _controller;
		private const string Playername = "Playername";
		private const string Money = "Money";
		private const string Position = "Position";
		private const string NumberStreets = "NumberStreets";

		public Form1()
		{
			InitializeComponent();

			dataGridView1.Columns.Clear();
			dataGridView1.Columns.Add(Playername, Playername);
			dataGridView1.Columns.Add(Money, Money);
			dataGridView1.Columns.Add(Position, Position);
			dataGridView1.Columns.Add(NumberStreets, NumberStreets);
			dataGridView1.AllowUserToAddRows = dataGridView1.RowHeadersVisible = false;
			Viewer.Init(this);
		}

		public Button ButtonAutoRun => buttonAutoRun;

		private void Form1_Load(object sender, EventArgs e)
		{
			_controller = new Controller(new Setting { NumberPlayers = 4 });
		}

		public DataGridView GetDataGridView()
		{
			return dataGridView1;
		}

		public RichTextBox GetRichTextBox()
		{
			return richTextBox1;
		}

		private void buttonNextStep_Click(object sender, EventArgs e)
		{
			_controller.NextStep();
		}

		private void buttonAutoRun_Click(object sender, EventArgs e)
		{
			switch (_controller.Game.Status)
			{
				case Game.Stati.Standby:
					_controller.StartAutoRun(checkBoxWatching.Checked);
					break;
				case Game.Stati.Running:
					_controller.StopAutoRun();
					break;
				case Game.Stati.Finished:
					_controller = new Controller(_controller.Game.Setting);
					break;
			}
			Viewer.UpdateView(_controller.Game);
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			Task.Run(() =>
			{
				try
				{
					FormHistory formHistory = new FormHistory(_controller.Game);
					formHistory.ShowDialog();
				}
				catch (Exception ex)
				{
					Debugger.Break();
				}

			});
		}

		private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var formSettings = new FormSettings(_controller.Game.Setting);
			if (formSettings.ShowDialog() is DialogResult.OK)
			{
				_controller = new Controller(formSettings.Setting);
			}
		}
	}
}

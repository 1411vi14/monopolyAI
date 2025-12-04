using System;
using System.Windows.Forms;

namespace Monopoly
{
    public partial class Form1 : Form
    {
        private Controller _controller;

        public Form1()
        {
            InitializeComponent();

            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Playername", "Playername");
            dataGridView1.Columns.Add("Money", "Money");
            dataGridView1.Columns.Add("Position", "Position");
            dataGridView1.Columns.Add("NumberStreets", "NumberStreets");
            dataGridView1.AllowUserToAddRows = dataGridView1.RowHeadersVisible = false;
            Viewer.Init(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _controller = new Controller();
        }

        public DataGridView GetDataGridView()
        {
            return dataGridView1;
        }

        public RichTextBox GetRichTextBox()
        {
            return richTextBox1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.NextStep();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_controller.Status == Controller.Stati.IsStandby)
            {
                _controller.StartAutoRun(checkBoxWatching.Checked);
                buttonAutoRun.Text = "Stop autorun";
            }
            else if (_controller.Status == Controller.Stati.IsRunning)
            {
                _controller.StopAutoRun();
                buttonAutoRun.Text = "Start autorun";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormHistory formHistory = new FormHistory(_controller.Game);
            formHistory.ShowDialog();
        }
    }
}

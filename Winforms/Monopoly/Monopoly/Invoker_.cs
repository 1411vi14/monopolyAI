using Monopoly;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Invoker_
{
	class Invoker
	{
		public static void invokeProgressBar(ProgressBar myobject, int value, int min, int max)
		{
			if (myobject.InvokeRequired)
			{
				myobject.Invoke(() => myobject.Minimum = min);
				myobject.Invoke(() => myobject.Maximum = max);
				myobject.Invoke(() => myobject.Value = value);
			}
			else
			{
				myobject.Minimum = min;
				myobject.Maximum = max;
				myobject.Value = value;
			}
		}

		public static void Resize(object myobject)
		{
			if (myobject is DataGridView dataGridView)
			{
				dataGridView.Invoke(delegate
				{
					for (int i = 0; i < dataGridView.Columns.Count; i++)
						dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
					/*
					for (int i = 0; i < dataGridView.Columns.Count; i++)
					{
						int colw = dataGridView.Columns[i].Width;
						dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
						dataGridView.Columns[i].Width = colw;
					}
					*/
				});
			}
		}

		public static int invokeProgressBarGetMax(ProgressBar myobject)
		{
			int max = 0;
			if (myobject.InvokeRequired)
			{
				myobject.Invoke(() => max = myobject.Maximum);
			}
			else
			{
				max = myobject.Maximum;
			}
			return max;
		}

		public static int invokeSelectedIndex(object myobject)
		{
			int index = -1;
			if (myobject is ComboBox comboBox)
			{
				if (comboBox.InvokeRequired) comboBox.Invoke(() => index = comboBox.SelectedIndex);
				else index = comboBox.SelectedIndex;
			}

			return index;
		}

		public static void invokeIcon(object myobject, Form form)
		{
			if (myobject is Icon icon)
			{
				form.Invoke(delegate
				{
					form.Icon = icon;
				});
			}
		}

		public static void invokeSetLocation(object myobject, Point location)
		{
			if (myobject is PictureBox pictureBox)
			{
				if (pictureBox.InvokeRequired) pictureBox.Invoke(() => pictureBox.Location = location);
				else pictureBox.Location = location;
			}
		}

		public static Point invokeGetLocation(object myobject)
		{
			Point location = new Point();

			if (myobject is PictureBox pictureBox)
			{
				if (pictureBox.InvokeRequired) pictureBox.Invoke(() => location = pictureBox.Location);
				else location = pictureBox.Location;
			}

			return location;
		}

		public static void invokeSelect(object myobject, int index)
		{
			if (myobject is TreeView treeView)
			{
				if (treeView.InvokeRequired) treeView.Invoke(() => treeView.SelectedNode = treeView.Nodes[0]);
				else treeView.SelectedNode = treeView.Nodes[0];
			}
		}

		public static void invokeProgressBarValue(ProgressBar myobject, int value)
		{
			if (myobject.InvokeRequired)
			{
				myobject.Invoke(() => myobject.Value = value);
			}
			else
			{
				myobject.Value = value;
			}
		}

		public static void invokeVisible(object myobject, bool visible)
		{
            switch (myobject)
            {
                case Label label:
                    if (label.InvokeRequired) label.Invoke(() => label.Visible = visible);
                    else label.Visible = visible;
                    break;
                case PictureBox pictureBox:
                    if (pictureBox.InvokeRequired) pictureBox.Invoke(() => pictureBox.Visible = visible);
                    else pictureBox.Visible = visible;
                    break;
                case TextBox textBox:
                    if (textBox.InvokeRequired) textBox.Invoke(() => textBox.Visible = visible);
                    else textBox.Visible = visible;
                    break;
                case ProgressBar progressBar:
                    if (progressBar.InvokeRequired) progressBar.Invoke(() => progressBar.Visible = visible);
                    else progressBar.Visible = visible;
                    break;
                case GroupBox groupBox:
                    if (groupBox.InvokeRequired) groupBox.Invoke(() => groupBox.Visible = visible);
                    else groupBox.Visible = visible;
                    break;
            }
        }

		public static void invokeChecked(object myobject, bool isChecked)
		{
			if (myobject is CheckBox checkBox)
			{
				if (checkBox.InvokeRequired) checkBox.Invoke(() => checkBox.Checked = isChecked);
				else checkBox.Checked = isChecked;
			}
		}

		public static bool invokeIsChecked(object myobject)
		{
			bool isChecked = false;
			if (myobject is CheckBox checkBox)
			{
				if (checkBox.InvokeRequired) checkBox.Invoke(() => isChecked = checkBox.Checked);
				else isChecked = checkBox.Checked;
			}
			return isChecked;
		}


		public static void invokeNodeAdd(object myobject, string text)
		{
            switch (myobject)
            {
                case TreeNode treeNode:
                    if (treeNode.TreeView.InvokeRequired) treeNode.TreeView.Invoke(() => treeNode.Nodes.Add(text));
                    else treeNode.Nodes.Add(text);
                    break;
                case TreeView treeView:
                    if (treeView.InvokeRequired) treeView.Invoke(() => treeView.Nodes.Add(text));
                    else treeView.Nodes.Add(text);
                    break;
            }
        }

		public static void invokeItemsAdd(object myobject, string text)
		{
            switch (myobject)
            {
                case ListBox listBox:
                    if (listBox.InvokeRequired) listBox.Invoke(() => listBox.Items.Add(text));
                    else listBox.Items.Add(text);
                    break;
                case ComboBox comboBox:
                    if (comboBox.InvokeRequired) comboBox.Invoke(() => comboBox.Items.Add(text));
                    else comboBox.Items.Add(text);
                    break;
            }
        }

		public static void invokeItemsRemoveAt(object myobject, int at)
		{
			if (myobject is ListBox listBox)
			{
				if (listBox.InvokeRequired) listBox.Invoke(() => listBox.Items.RemoveAt(at));
				else listBox.Items.RemoveAt(at);
			}
		}
		public static int invokeItemsCount(object myobject)
		{
			int count = -1;
            switch (myobject)
            {
                case ListBox listBox:
                    if (listBox.InvokeRequired) listBox.Invoke(() => count = listBox.Items.Count);
                    else count = listBox.Items.Count;
                    break;
                case ComboBox comboBox:
                    if (comboBox.InvokeRequired) comboBox.Invoke(() => count = comboBox.Items.Count);
                    else count = comboBox.Items.Count;
                    break;
            }
            return count;
		}

		public static void invokeItemsClear(object myobject)
		{
            switch (myobject)
            {
                case ListBox listBox:
                    if (listBox.InvokeRequired) listBox.Invoke(() => listBox.Items.Clear());
                    else listBox.Items.Clear();
                    break;
                case ComboBox comboBox:
                    if (comboBox.InvokeRequired) comboBox.Invoke(() => comboBox.Items.Clear());
                    else comboBox.Items.Clear();
                    break;
            }
        }

		public static void invokeEnable(object myobject, bool enable)
		{
            switch (myobject)
            {
                case Label label:
                    if (label.InvokeRequired) label.Invoke(() => label.Enabled = enable);
                    else label.Enabled = enable;
                    break;
                case TextBox textBox:
                    if (textBox.InvokeRequired) textBox.Invoke(() => textBox.Enabled = enable);
                    else textBox.Enabled = enable;
                    break;
                case TabControl tabControl:
                    if (tabControl.InvokeRequired) tabControl.Invoke(() => tabControl.Enabled = enable);
                    else tabControl.Enabled = enable;
                    break;
                case PictureBox pictureBox:
                    if (pictureBox.InvokeRequired) pictureBox.Invoke(() => pictureBox.Enabled = enable);
                    else pictureBox.Enabled = enable;
                    break;
                case GroupBox groupBox:
                    if (groupBox.InvokeRequired) groupBox.Invoke(() => groupBox.Enabled = enable);
                    else groupBox.Enabled = enable;
                    break;
                case Button button:
                    if (button.InvokeRequired) button.Invoke(() => button.Enabled = enable);
                    else button.Enabled = enable;
                    break;
                case ToolStripMenuItem toolStripMenu:
                    if (toolStripMenu.GetCurrentParent().InvokeRequired) toolStripMenu.GetCurrentParent().Invoke(() => toolStripMenu.Enabled = enable);
                    else toolStripMenu.Enabled = enable;
                    break;
                case TreeView treeView:
                    if (treeView.InvokeRequired) treeView.Invoke(() => treeView.Enabled = enable);
                    else treeView.Enabled = enable;
                    break;
                case ComboBox comboBox:
                    if (comboBox.InvokeRequired) comboBox.Invoke(() => comboBox.Enabled = enable);
                    else comboBox.Enabled = enable;
                    break;
                case RichTextBox richTextBox:
                    if (richTextBox.InvokeRequired) richTextBox.Invoke(() => richTextBox.Enabled = enable);
                    else richTextBox.Enabled = enable;
                    break;
                case CheckBox checkBox:
                    if (checkBox.InvokeRequired) checkBox.Invoke(() => checkBox.Enabled = enable);
                    else checkBox.Enabled = enable;
                    break;
            }
        }

		public static void invokeTextSet(object myobject, string text)
		{
            switch (myobject)
            {
                case Label label:
                    if (label.InvokeRequired) label.Invoke(() => label.Text = text);
                    else label.Text = text;
                    break;
                case TextBox textBox:
                    if (textBox.InvokeRequired) textBox.Invoke(() => textBox.Text = text);
                    else textBox.Text = text;
                    break;
                case Button button:
                    if (button.InvokeRequired) button.Invoke(() => button.Text = text);
                    else button.Text = text;
                    break;
                case RichTextBox richTextBox:
                    if (richTextBox.InvokeRequired) richTextBox.Invoke(() => richTextBox.Text = text);
                    else richTextBox.Text = text;
                    break;
                case GroupBox groupBox:
                    if (groupBox.InvokeRequired) groupBox.Invoke(() => groupBox.Text = text);
                    else groupBox.Text = text;
                    break;
                case Form form:
                    if (form.InvokeRequired) form.Invoke(() => form.Text = text);
                    else form.Text = text;
                    break;
            }
        }

		public static void invokeInvalidate(Panel panel)
		{
			if (panel.InvokeRequired) panel.Invoke(() => panel.Invalidate());
			else panel.Invalidate();
		}

		public static string invokeTextGet(object myobject)
		{
			string text = "";
            switch (myobject)
            {
                case Label label:
                    if (label.InvokeRequired) label.Invoke(() => text = label.Text);
                    else text = label.Text;
                    break;
                case TextBox textBox:
                    if (textBox.InvokeRequired) textBox.Invoke(() => text = textBox.Text);
                    else text = textBox.Text;
                    break;
                case Button button:
                    if (button.InvokeRequired) button.Invoke(() => text = button.Text);
                    else text = button.Text;
                    break;
                case RichTextBox richTextBox:
                    if (richTextBox.InvokeRequired) richTextBox.Invoke(() => text = richTextBox.Text);
                    else text = richTextBox.Text;
                    break;
                case GroupBox groupBox:
                    if (groupBox.InvokeRequired) groupBox.Invoke(() => text = groupBox.Text);
                    else text = groupBox.Text;
                    break;
                case ComboBox comboBox:
                    if (comboBox.InvokeRequired) comboBox.Invoke(() => text = comboBox.Text);
                    else text = comboBox.Text;
                    break;
            }

            return text;
		}

		public static void invokeClearColumns(object myobject)
		{
			if (myobject is DataGridView dataGridView)
			{
				if (dataGridView.InvokeRequired) dataGridView.Invoke(() => dataGridView.Columns.Clear());
				else dataGridView.Columns.Clear();
			}
		}
		public static void invokeClearRows(object myobject)
		{
			if (myobject is DataGridView dataGridView)
			{
				if (dataGridView.InvokeRequired) dataGridView.Invoke(() => dataGridView.Rows.Clear());
				else dataGridView.Rows.Clear();
			}
		}
		public static void invokeAddRow(DataGridView dataGridView)
		{
			dataGridView.Invoke(() =>
			{
				dataGridView.Rows.Add(1);
			});
		}


		public static void invokeUpdateRow(DataGridView dataGridView, int rowIndex, Player player)
		{
			dataGridView.Invoke(() =>
				{
					if (dataGridView.Rows.Count < rowIndex + 1)
					{
						dataGridView.Rows.Add(player.Name, player.Money, player.CurrentCell?.StreetCard.Name ?? "undefined", player.StreetCards.Count);
					}
					else
					{
						var row = dataGridView.Rows[rowIndex];
						row.Cells[1].Value = player.Money;
						row.Cells[2].Value = player.CurrentCell?.StreetCard.Name ?? "undefined";
						row.Cells[3].Value = player.StreetCards.Count;
					}
				}
			);
		}

		public static void invokeUpdateLastRow(DataGridView dataGridView, int countBuyedStreets)
		{
			dataGridView.Invoke(() =>
				{
					if (dataGridView.Rows.Count is 0)
					{
						return;
					}
					var row = dataGridView.Rows[dataGridView.Rows.Count - 1];
					row.Cells[3].Value = countBuyedStreets;
				}
			);
		}

		public static void invokeAutoResizeColumns(object myobject, DataGridViewAutoSizeColumnsMode mode)
		{
			if (myobject is DataGridView dataGridView)
			{
				if (dataGridView.InvokeRequired) dataGridView.Invoke(() => dataGridView.AutoResizeColumns(mode));
				else dataGridView.AutoResizeColumns(mode);
			}
		}

		public static void invokeAddRow(object myobject, string[] cells)
		{
			if (myobject is DataGridView dataGridView)
			{
				if (dataGridView.InvokeRequired) dataGridView.Invoke(() => dataGridView.Rows.Add(cells));
				else dataGridView.Rows.Add(cells);
			}
		}

		public static void invokeAddColumn(object myobject, string column, string headerText)
		{
			if (myobject is DataGridView dataGridView)
			{
				if (dataGridView.InvokeRequired) dataGridView.Invoke(() => dataGridView.Columns.Add(column, headerText));
				else dataGridView.Columns.Add(column, headerText);
			}
		}


		public static void invokeAppendText(object myobject, string text)
		{
            switch (myobject)
            {
                case Label label:
                    if (label.InvokeRequired) label.Invoke(() => label.Text += text);
                    else label.Text += text;
                    break;
                case TextBox textBox:
                    if (textBox.InvokeRequired) textBox.Invoke(() => textBox.Text += text);
                    else textBox.Text += text;
                    break;
                case Button button:
                    if (button.InvokeRequired) button.Invoke(() => button.Text += text);
                    else button.Text += text;
                    break;
                case RichTextBox richTextBox:
                    if (richTextBox.InvokeRequired) richTextBox.Invoke(() => richTextBox.Text += text);
                    else richTextBox.Text += text;
                    break;
            }
        }

	}
}
namespace Monopoly
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new System.Windows.Forms.DataGridView();
            richTextBox1 = new System.Windows.Forms.RichTextBox();
            buttonNextStep = new System.Windows.Forms.Button();
            buttonAutoRun = new System.Windows.Forms.Button();
            checkBoxWatching = new System.Windows.Forms.CheckBox();
            button1 = new System.Windows.Forms.Button();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(36, 128);
            dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new System.Drawing.Size(686, 148);
            dataGridView1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new System.Drawing.Point(671, 340);
            richTextBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new System.Drawing.Size(248, 164);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // buttonNextStep
            // 
            buttonNextStep.Location = new System.Drawing.Point(810, 252);
            buttonNextStep.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonNextStep.Name = "buttonNextStep";
            buttonNextStep.Size = new System.Drawing.Size(88, 27);
            buttonNextStep.TabIndex = 2;
            buttonNextStep.Text = "Next Step";
            buttonNextStep.UseVisualStyleBackColor = true;
            buttonNextStep.Click += buttonNextStep_Click;
            // 
            // buttonAutoRun
            // 
            buttonAutoRun.Location = new System.Drawing.Point(183, 340);
            buttonAutoRun.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonAutoRun.Name = "buttonAutoRun";
            buttonAutoRun.Size = new System.Drawing.Size(141, 27);
            buttonAutoRun.TabIndex = 3;
            buttonAutoRun.Text = "Start autorun";
            buttonAutoRun.UseVisualStyleBackColor = true;
            buttonAutoRun.Click += buttonAutoRun_Click;
            // 
            // checkBoxWatching
            // 
            checkBoxWatching.AutoSize = true;
            checkBoxWatching.Location = new System.Drawing.Point(388, 372);
            checkBoxWatching.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBoxWatching.Name = "checkBoxWatching";
            checkBoxWatching.Size = new System.Drawing.Size(77, 19);
            checkBoxWatching.TabIndex = 4;
            checkBoxWatching.Text = "Watching";
            checkBoxWatching.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(512, 479);
            button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(152, 27);
            button1.TabIndex = 5;
            button1.Text = "Show History";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { settingsToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            menuStrip1.Size = new System.Drawing.Size(933, 24);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(933, 519);
            Controls.Add(button1);
            Controls.Add(checkBoxWatching);
            Controls.Add(buttonAutoRun);
            Controls.Add(buttonNextStep);
            Controls.Add(richTextBox1);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Monopoly";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonNextStep;
        private System.Windows.Forms.Button buttonAutoRun;
        private System.Windows.Forms.CheckBox checkBoxWatching;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}


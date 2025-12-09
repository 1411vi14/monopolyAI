namespace Monopoly
{
    partial class FormSettings
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
            label1 = new System.Windows.Forms.Label();
            textBoxNumberPlayer = new System.Windows.Forms.TextBox();
            buttonCancel = new System.Windows.Forms.Button();
            ButtonAccept = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(14, 25);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(148, 15);
            label1.TabIndex = 1;
            label1.Text = "Number of players (2-200):";
            // 
            // textBoxNumberPlayer
            // 
            textBoxNumberPlayer.Location = new System.Drawing.Point(174, 22);
            textBoxNumberPlayer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBoxNumberPlayer.Name = "textBoxNumberPlayer";
            textBoxNumberPlayer.Size = new System.Drawing.Size(98, 23);
            textBoxNumberPlayer.TabIndex = 2;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new System.Drawing.Point(186, 113);
            buttonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(88, 27);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // ButtonAccept
            // 
            ButtonAccept.Location = new System.Drawing.Point(281, 113);
            ButtonAccept.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ButtonAccept.Name = "ButtonAccept";
            ButtonAccept.Size = new System.Drawing.Size(88, 27);
            ButtonAccept.TabIndex = 4;
            ButtonAccept.Text = "Accept";
            ButtonAccept.UseVisualStyleBackColor = true;
            ButtonAccept.Click += buttonAccept_Click;
            // 
            // FormSettings
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(383, 153);
            Controls.Add(ButtonAccept);
            Controls.Add(buttonCancel);
            Controls.Add(this.textBoxNumberPlayer);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "FormSettings";
            Text = "FormSettings";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNumberPlayer;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button ButtonAccept;
    }
}
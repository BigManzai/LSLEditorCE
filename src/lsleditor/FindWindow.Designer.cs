namespace LSLEditor
{
	partial class FindWindow
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxFind = new System.Windows.Forms.ComboBox();
            this.FindNext = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxReplace = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxWholeWord = new System.Windows.Forms.CheckBox();
            this.checkBoxReverse = new System.Windows.Forms.CheckBox();
            this.checkBoxMatchCase = new System.Windows.Forms.CheckBox();
            this.Replace = new System.Windows.Forms.Button();
            this.ReplaceAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxFind);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(360, 74);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Suche nach:";
            // 
            // comboBoxFind
            // 
            this.comboBoxFind.FormattingEnabled = true;
            this.comboBoxFind.Location = new System.Drawing.Point(24, 25);
            this.comboBoxFind.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxFind.Name = "comboBoxFind";
            this.comboBoxFind.Size = new System.Drawing.Size(310, 28);
            this.comboBoxFind.TabIndex = 1;
            this.comboBoxFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxFind_KeyDown);
            // 
            // FindNext
            // 
            this.FindNext.Location = new System.Drawing.Point(120, 283);
            this.FindNext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FindNext.Name = "FindNext";
            this.FindNext.Size = new System.Drawing.Size(112, 35);
            this.FindNext.TabIndex = 6;
            this.FindNext.Text = "Weiter";
            this.FindNext.UseVisualStyleBackColor = true;
            this.FindNext.Click += new System.EventHandler(this.FindNext_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxReplace);
            this.groupBox2.Location = new System.Drawing.Point(12, 86);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(360, 74);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ersetzen mit:";
            // 
            // comboBoxReplace
            // 
            this.comboBoxReplace.FormattingEnabled = true;
            this.comboBoxReplace.Location = new System.Drawing.Point(24, 25);
            this.comboBoxReplace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxReplace.Name = "comboBoxReplace";
            this.comboBoxReplace.Size = new System.Drawing.Size(310, 28);
            this.comboBoxReplace.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxWholeWord);
            this.groupBox3.Controls.Add(this.checkBoxReverse);
            this.groupBox3.Controls.Add(this.checkBoxMatchCase);
            this.groupBox3.Location = new System.Drawing.Point(12, 172);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(360, 98);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Such Optionen";
            // 
            // checkBoxWholeWord
            // 
            this.checkBoxWholeWord.AutoSize = true;
            this.checkBoxWholeWord.Location = new System.Drawing.Point(168, 37);
            this.checkBoxWholeWord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxWholeWord.Name = "checkBoxWholeWord";
            this.checkBoxWholeWord.Size = new System.Drawing.Size(129, 24);
            this.checkBoxWholeWord.TabIndex = 4;
            this.checkBoxWholeWord.Text = "Ganzes Wort";
            this.checkBoxWholeWord.UseVisualStyleBackColor = true;
            // 
            // checkBoxReverse
            // 
            this.checkBoxReverse.AutoSize = true;
            this.checkBoxReverse.Location = new System.Drawing.Point(24, 62);
            this.checkBoxReverse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxReverse.Name = "checkBoxReverse";
            this.checkBoxReverse.Size = new System.Drawing.Size(109, 24);
            this.checkBoxReverse.TabIndex = 5;
            this.checkBoxReverse.Text = "Umkehren";
            this.checkBoxReverse.UseVisualStyleBackColor = true;
            // 
            // checkBoxMatchCase
            // 
            this.checkBoxMatchCase.AutoSize = true;
            this.checkBoxMatchCase.Location = new System.Drawing.Point(24, 37);
            this.checkBoxMatchCase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxMatchCase.Name = "checkBoxMatchCase";
            this.checkBoxMatchCase.Size = new System.Drawing.Size(110, 24);
            this.checkBoxMatchCase.TabIndex = 3;
            this.checkBoxMatchCase.Text = "Groﬂ/Klein";
            this.checkBoxMatchCase.UseVisualStyleBackColor = true;
            // 
            // Replace
            // 
            this.Replace.Location = new System.Drawing.Point(252, 283);
            this.Replace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Replace.Name = "Replace";
            this.Replace.Size = new System.Drawing.Size(112, 35);
            this.Replace.TabIndex = 7;
            this.Replace.Text = "Ersetzen";
            this.Replace.UseVisualStyleBackColor = true;
            this.Replace.Click += new System.EventHandler(this.Replace_Click);
            // 
            // ReplaceAll
            // 
            this.ReplaceAll.Location = new System.Drawing.Point(252, 320);
            this.ReplaceAll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ReplaceAll.Name = "ReplaceAll";
            this.ReplaceAll.Size = new System.Drawing.Size(112, 35);
            this.ReplaceAll.TabIndex = 8;
            this.ReplaceAll.Text = "Ersetze alles";
            this.ReplaceAll.UseVisualStyleBackColor = true;
            this.ReplaceAll.Click += new System.EventHandler(this.ReplaceAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 332);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 6;
            // 
            // FindWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 366);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ReplaceAll);
            this.Controls.Add(this.Replace);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.FindNext);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "    Suche";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FindWindow_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FindWindow_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox comboBoxFind;
		private System.Windows.Forms.Button FindNext;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox comboBoxReplace;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox checkBoxMatchCase;
		private System.Windows.Forms.Button Replace;
		private System.Windows.Forms.Button ReplaceAll;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkBoxWholeWord;
		private System.Windows.Forms.CheckBox checkBoxReverse;
	}
}
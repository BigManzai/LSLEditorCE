namespace LSLEditor
{
	partial class UpdateApplicationForm
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
            this.labelHelpversionString = new System.Windows.Forms.Label();
            this.labelHelpFile = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelLatestVersionString = new System.Windows.Forms.Label();
            this.labelOurVersionString = new System.Windows.Forms.Label();
            this.labelLatestVersion = new System.Windows.Forms.Label();
            this.labelOurVersion = new System.Windows.Forms.Label();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelHelpversionString);
            this.groupBox1.Controls.Add(this.labelHelpFile);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.labelLatestVersionString);
            this.groupBox1.Controls.Add(this.labelOurVersionString);
            this.groupBox1.Controls.Add(this.labelLatestVersion);
            this.groupBox1.Controls.Add(this.labelOurVersion);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(324, 197);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Versionsinformation";
            // 
            // labelHelpversionString
            // 
            this.labelHelpversionString.AutoSize = true;
            this.labelHelpversionString.Location = new System.Drawing.Point(156, 111);
            this.labelHelpversionString.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHelpversionString.Name = "labelHelpversionString";
            this.labelHelpversionString.Size = new System.Drawing.Size(0, 20);
            this.labelHelpversionString.TabIndex = 6;
            // 
            // labelHelpFile
            // 
            this.labelHelpFile.AutoSize = true;
            this.labelHelpFile.Location = new System.Drawing.Point(24, 111);
            this.labelHelpFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHelpFile.Name = "labelHelpFile";
            this.labelHelpFile.Size = new System.Drawing.Size(80, 20);
            this.labelHelpFile.TabIndex = 5;
            this.labelHelpFile.Text = "Hilfedatei:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(24, 148);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(276, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // labelLatestVersionString
            // 
            this.labelLatestVersionString.AutoSize = true;
            this.labelLatestVersionString.Location = new System.Drawing.Point(156, 74);
            this.labelLatestVersionString.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLatestVersionString.Name = "labelLatestVersionString";
            this.labelLatestVersionString.Size = new System.Drawing.Size(0, 20);
            this.labelLatestVersionString.TabIndex = 3;
            // 
            // labelOurVersionString
            // 
            this.labelOurVersionString.AutoSize = true;
            this.labelOurVersionString.Location = new System.Drawing.Point(156, 37);
            this.labelOurVersionString.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOurVersionString.Name = "labelOurVersionString";
            this.labelOurVersionString.Size = new System.Drawing.Size(0, 20);
            this.labelOurVersionString.TabIndex = 2;
            // 
            // labelLatestVersion
            // 
            this.labelLatestVersion.AutoSize = true;
            this.labelLatestVersion.Location = new System.Drawing.Point(24, 74);
            this.labelLatestVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLatestVersion.Name = "labelLatestVersion";
            this.labelLatestVersion.Size = new System.Drawing.Size(116, 20);
            this.labelLatestVersion.TabIndex = 1;
            this.labelLatestVersion.Text = "Letzte Version:";
            // 
            // labelOurVersion
            // 
            this.labelOurVersion.AutoSize = true;
            this.labelOurVersion.Location = new System.Drawing.Point(24, 37);
            this.labelOurVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOurVersion.Name = "labelOurVersion";
            this.labelOurVersion.Size = new System.Drawing.Size(99, 20);
            this.labelOurVersion.TabIndex = 0;
            this.labelOurVersion.Text = "Ihre Version:";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(72, 222);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(112, 35);
            this.buttonUpdate.TabIndex = 1;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(204, 222);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 35);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Ende";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // UpdateApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 272);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateApplicationForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update LSLEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpdateApplicationForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label labelLatestVersionString;
		private System.Windows.Forms.Label labelOurVersionString;
		private System.Windows.Forms.Label labelLatestVersion;
		private System.Windows.Forms.Label labelOurVersion;
		private System.Windows.Forms.Button buttonUpdate;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label labelHelpversionString;
		private System.Windows.Forms.Label labelHelpFile;
	}
}
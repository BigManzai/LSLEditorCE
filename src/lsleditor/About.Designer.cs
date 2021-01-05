namespace LSLEditor
{
	/// <summary>
	/// About dialogue box form.
	/// </summary>
	public partial class About
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Container for LSLife picture.
		/// </summary>
		private System.Windows.Forms.PictureBox pictureBox1;

		/// <summary>
		/// Container to hold all the elements.
		/// </summary>
		private System.Windows.Forms.GroupBox groupBox1;

		/// <summary>
		/// OK Button.
		/// </summary>
		private System.Windows.Forms.Button button1;

		/// <summary>
		/// Web Browser.
		/// </summary>
		private System.Windows.Forms.WebBrowser webBrowser1;

		/// <summary>
		/// Link label.
		/// </summary>
		private System.Windows.Forms.LinkLabel linkLabel1;

		/// <summary>
		/// Version label.
		/// </summary>
		private System.Windows.Forms.Label label1;

		/// <summary>
		/// LSL Editor label.
		/// </summary>
		private System.Windows.Forms.Label label2;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">True if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (this.components != null)) {
				this.components.Dispose();
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LSLEditor.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(32, 31);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(368, 154);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.webBrowser1);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(32, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox1.Size = new System.Drawing.Size(640, 692);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LSL-Editor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 215);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 215);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Version:";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(16, 246);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(40, 39);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(608, 431);
            this.webBrowser1.TabIndex = 2;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(32, 185);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(153, 25);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "© 2006 — 2021";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(480, 722);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(704, 789);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
	}
}

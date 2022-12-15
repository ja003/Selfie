
namespace Selfie1
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.pictureBox_Input = new System.Windows.Forms.PictureBox();
			this.pictureBox_Output = new System.Windows.Forms.PictureBox();
			this.button_Apply = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.folderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.button_Save = new System.Windows.Forms.Button();
			this.textBox_OutputFolder = new System.Windows.Forms.TextBox();
			this.pictureBox_EyeLeft = new System.Windows.Forms.PictureBox();
			this.pictureBox_EyeRight = new System.Windows.Forms.PictureBox();
			this.pictureBox_debug1 = new System.Windows.Forms.PictureBox();
			this.pictureBox_debug2 = new System.Windows.Forms.PictureBox();
			this.pictureBox_debug3 = new System.Windows.Forms.PictureBox();
			this.pictureBox_debug4 = new System.Windows.Forms.PictureBox();
			this.pictureBox_debug4b = new System.Windows.Forms.PictureBox();
			this.pictureBox_debug3b = new System.Windows.Forms.PictureBox();
			this.pictureBox_debug2b = new System.Windows.Forms.PictureBox();
			this.pictureBox_debug1b = new System.Windows.Forms.PictureBox();
			this.num_CurrentIndex = new System.Windows.Forms.NumericUpDown();
			this.textBox_OutputName = new System.Windows.Forms.TextBox();
			this.icon_exlMark = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_Input)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_Output)).BeginInit();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_EyeLeft)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_EyeRight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_debug1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_debug2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_debug3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_debug4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_debug4b)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_debug3b)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_debug2b)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_debug1b)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.num_CurrentIndex)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.icon_exlMark)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox_Input
			// 
			this.pictureBox_Input.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.pictureBox_Input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox_Input.Location = new System.Drawing.Point(13, 36);
			this.pictureBox_Input.Name = "pictureBox_Input";
			this.pictureBox_Input.Size = new System.Drawing.Size(640, 360);
			this.pictureBox_Input.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox_Input.TabIndex = 1;
			this.pictureBox_Input.TabStop = false;
			this.pictureBox_Input.Click += new System.EventHandler(this.pictureBox_Input_Click);
			// 
			// pictureBox_Output
			// 
			this.pictureBox_Output.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.pictureBox_Output.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox_Output.Location = new System.Drawing.Point(661, 36);
			this.pictureBox_Output.Name = "pictureBox_Output";
			this.pictureBox_Output.Size = new System.Drawing.Size(640, 360);
			this.pictureBox_Output.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox_Output.TabIndex = 10;
			this.pictureBox_Output.TabStop = false;
			// 
			// button_Apply
			// 
			this.button_Apply.Location = new System.Drawing.Point(532, 405);
			this.button_Apply.Name = "button_Apply";
			this.button_Apply.Size = new System.Drawing.Size(117, 71);
			this.button_Apply.TabIndex = 11;
			this.button_Apply.Text = "apply";
			this.button_Apply.UseVisualStyleBackColor = true;
			this.button_Apply.Click += new System.EventHandler(this.button_Apply_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.folderToolStripMenuItem1,
            this.saveToFolderToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1322, 24);
			this.menuStrip1.TabIndex = 12;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFileToolStripMenuItem});
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
			this.openToolStripMenuItem.Text = "Load - File";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem1_Click);
			// 
			// loadFileToolStripMenuItem
			// 
			this.loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
			this.loadFileToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
			this.loadFileToolStripMenuItem.Text = "Load file";
			// 
			// folderToolStripMenuItem1
			// 
			this.folderToolStripMenuItem1.Name = "folderToolStripMenuItem1";
			this.folderToolStripMenuItem1.Size = new System.Drawing.Size(89, 20);
			this.folderToolStripMenuItem1.Text = "Load - Folder";
			this.folderToolStripMenuItem1.Click += new System.EventHandler(this.folderToolStripMenuItem1_Click);
			// 
			// saveToFolderToolStripMenuItem
			// 
			this.saveToFolderToolStripMenuItem.Name = "saveToFolderToolStripMenuItem";
			this.saveToFolderToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
			this.saveToFolderToolStripMenuItem.Text = "Save to folder";
			this.saveToFolderToolStripMenuItem.Click += new System.EventHandler(this.saveToFolderToolStripMenuItem_Click);
			// 
			// button_Save
			// 
			this.button_Save.Location = new System.Drawing.Point(661, 405);
			this.button_Save.Name = "button_Save";
			this.button_Save.Size = new System.Drawing.Size(117, 71);
			this.button_Save.TabIndex = 13;
			this.button_Save.Text = "save";
			this.button_Save.UseVisualStyleBackColor = true;
			this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
			// 
			// textBox_OutputFolder
			// 
			this.textBox_OutputFolder.Location = new System.Drawing.Point(917, 405);
			this.textBox_OutputFolder.Name = "textBox_OutputFolder";
			this.textBox_OutputFolder.Size = new System.Drawing.Size(384, 23);
			this.textBox_OutputFolder.TabIndex = 14;
			this.textBox_OutputFolder.TextChanged += new System.EventHandler(this.textBox_OutputFolder_TextChanged);
			// 
			// pictureBox_EyeLeft
			// 
			this.pictureBox_EyeLeft.Location = new System.Drawing.Point(146, 405);
			this.pictureBox_EyeLeft.Name = "pictureBox_EyeLeft";
			this.pictureBox_EyeLeft.Size = new System.Drawing.Size(108, 62);
			this.pictureBox_EyeLeft.TabIndex = 15;
			this.pictureBox_EyeLeft.TabStop = false;
			// 
			// pictureBox_EyeRight
			// 
			this.pictureBox_EyeRight.Location = new System.Drawing.Point(304, 405);
			this.pictureBox_EyeRight.Name = "pictureBox_EyeRight";
			this.pictureBox_EyeRight.Size = new System.Drawing.Size(108, 62);
			this.pictureBox_EyeRight.TabIndex = 16;
			this.pictureBox_EyeRight.TabStop = false;
			// 
			// pictureBox_debug1
			// 
			this.pictureBox_debug1.Location = new System.Drawing.Point(13, 482);
			this.pictureBox_debug1.Name = "pictureBox_debug1";
			this.pictureBox_debug1.Size = new System.Drawing.Size(310, 154);
			this.pictureBox_debug1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox_debug1.TabIndex = 17;
			this.pictureBox_debug1.TabStop = false;
			// 
			// pictureBox_debug2
			// 
			this.pictureBox_debug2.Location = new System.Drawing.Point(343, 482);
			this.pictureBox_debug2.Name = "pictureBox_debug2";
			this.pictureBox_debug2.Size = new System.Drawing.Size(310, 154);
			this.pictureBox_debug2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox_debug2.TabIndex = 18;
			this.pictureBox_debug2.TabStop = false;
			// 
			// pictureBox_debug3
			// 
			this.pictureBox_debug3.Location = new System.Drawing.Point(661, 482);
			this.pictureBox_debug3.Name = "pictureBox_debug3";
			this.pictureBox_debug3.Size = new System.Drawing.Size(310, 154);
			this.pictureBox_debug3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox_debug3.TabIndex = 19;
			this.pictureBox_debug3.TabStop = false;
			// 
			// pictureBox_debug4
			// 
			this.pictureBox_debug4.Location = new System.Drawing.Point(991, 482);
			this.pictureBox_debug4.Name = "pictureBox_debug4";
			this.pictureBox_debug4.Size = new System.Drawing.Size(310, 154);
			this.pictureBox_debug4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox_debug4.TabIndex = 20;
			this.pictureBox_debug4.TabStop = false;
			// 
			// pictureBox_debug4b
			// 
			this.pictureBox_debug4b.Location = new System.Drawing.Point(991, 646);
			this.pictureBox_debug4b.Name = "pictureBox_debug4b";
			this.pictureBox_debug4b.Size = new System.Drawing.Size(310, 154);
			this.pictureBox_debug4b.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox_debug4b.TabIndex = 24;
			this.pictureBox_debug4b.TabStop = false;
			// 
			// pictureBox_debug3b
			// 
			this.pictureBox_debug3b.Location = new System.Drawing.Point(661, 646);
			this.pictureBox_debug3b.Name = "pictureBox_debug3b";
			this.pictureBox_debug3b.Size = new System.Drawing.Size(310, 154);
			this.pictureBox_debug3b.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox_debug3b.TabIndex = 23;
			this.pictureBox_debug3b.TabStop = false;
			// 
			// pictureBox_debug2b
			// 
			this.pictureBox_debug2b.Location = new System.Drawing.Point(343, 646);
			this.pictureBox_debug2b.Name = "pictureBox_debug2b";
			this.pictureBox_debug2b.Size = new System.Drawing.Size(310, 154);
			this.pictureBox_debug2b.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox_debug2b.TabIndex = 22;
			this.pictureBox_debug2b.TabStop = false;
			// 
			// pictureBox_debug1b
			// 
			this.pictureBox_debug1b.Location = new System.Drawing.Point(13, 646);
			this.pictureBox_debug1b.Name = "pictureBox_debug1b";
			this.pictureBox_debug1b.Size = new System.Drawing.Size(310, 154);
			this.pictureBox_debug1b.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox_debug1b.TabIndex = 21;
			this.pictureBox_debug1b.TabStop = false;
			// 
			// num_CurrentIndex
			// 
			this.num_CurrentIndex.Location = new System.Drawing.Point(1255, 435);
			this.num_CurrentIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			this.num_CurrentIndex.Name = "num_CurrentIndex";
			this.num_CurrentIndex.Size = new System.Drawing.Size(45, 23);
			this.num_CurrentIndex.TabIndex = 25;
			this.num_CurrentIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			// 
			// textBox_OutputName
			// 
			this.textBox_OutputName.Location = new System.Drawing.Point(1055, 434);
			this.textBox_OutputName.Name = "textBox_OutputName";
			this.textBox_OutputName.Size = new System.Drawing.Size(194, 23);
			this.textBox_OutputName.TabIndex = 26;
			// 
			// icon_exlMark
			// 
			this.icon_exlMark.Image = ((System.Drawing.Image)(resources.GetObject("icon_exlMark.Image")));
			this.icon_exlMark.Location = new System.Drawing.Point(889, 405);
			this.icon_exlMark.Name = "icon_exlMark";
			this.icon_exlMark.Size = new System.Drawing.Size(22, 22);
			this.icon_exlMark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.icon_exlMark.TabIndex = 27;
			this.icon_exlMark.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1322, 812);
			this.Controls.Add(this.icon_exlMark);
			this.Controls.Add(this.textBox_OutputName);
			this.Controls.Add(this.num_CurrentIndex);
			this.Controls.Add(this.pictureBox_debug4b);
			this.Controls.Add(this.pictureBox_debug3b);
			this.Controls.Add(this.pictureBox_debug2b);
			this.Controls.Add(this.pictureBox_debug1b);
			this.Controls.Add(this.pictureBox_debug4);
			this.Controls.Add(this.pictureBox_debug3);
			this.Controls.Add(this.pictureBox_debug2);
			this.Controls.Add(this.pictureBox_debug1);
			this.Controls.Add(this.pictureBox_EyeRight);
			this.Controls.Add(this.pictureBox_EyeLeft);
			this.Controls.Add(this.textBox_OutputFolder);
			this.Controls.Add(this.button_Save);
			this.Controls.Add(this.button_Apply);
			this.Controls.Add(this.pictureBox_Output);
			this.Controls.Add(this.pictureBox_Input);
			this.Controls.Add(this.menuStrip1);
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_Input)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_Output)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_EyeLeft)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_EyeRight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_debug1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_debug2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_debug3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_debug4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_debug4b)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_debug3b)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_debug2b)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_debug1b)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.num_CurrentIndex)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.icon_exlMark)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		public System.Windows.Forms.PictureBox pictureBox_Input;
		public System.Windows.Forms.PictureBox pictureBox_Output;
		private System.Windows.Forms.Button button_Apply;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem1;
		private System.Windows.Forms.Button button_Save;
		private System.Windows.Forms.ToolStripMenuItem loadFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToFolderToolStripMenuItem;
		private System.Windows.Forms.TextBox textBox_OutputFolder;
		public System.Windows.Forms.PictureBox pictureBox_EyeLeft;
		public System.Windows.Forms.PictureBox pictureBox_EyeRight;
		public System.Windows.Forms.PictureBox pictureBox_debug1;
		public System.Windows.Forms.PictureBox pictureBox_debug2;
		public System.Windows.Forms.PictureBox pictureBox_debug3;
		public System.Windows.Forms.PictureBox pictureBox_debug4;
		public System.Windows.Forms.PictureBox pictureBox_debug4b;
		public System.Windows.Forms.PictureBox pictureBox_debug3b;
		public System.Windows.Forms.PictureBox pictureBox_debug2b;
		public System.Windows.Forms.PictureBox pictureBox_debug1b;
		private System.Windows.Forms.NumericUpDown num_CurrentIndex;
		private System.Windows.Forms.TextBox textBox_OutputName;
		private System.Windows.Forms.PictureBox icon_exlMark;
	}
}


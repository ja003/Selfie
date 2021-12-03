
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
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_Input)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_Output)).BeginInit();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_EyeLeft)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_EyeRight)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox_Input
			// 
			this.pictureBox_Input.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.pictureBox_Input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox_Input.Location = new System.Drawing.Point(13, 47);
			this.pictureBox_Input.Name = "pictureBox_Input";
			this.pictureBox_Input.Size = new System.Drawing.Size(640, 360);
			this.pictureBox_Input.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox_Input.TabIndex = 1;
			this.pictureBox_Input.TabStop = false;
			this.pictureBox_Input.Click += new System.EventHandler(this.pictureBox_Input_Click);
			// 
			// pictureBox_Output
			// 
			this.pictureBox_Output.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.pictureBox_Output.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox_Output.Location = new System.Drawing.Point(661, 47);
			this.pictureBox_Output.Name = "pictureBox_Output";
			this.pictureBox_Output.Size = new System.Drawing.Size(640, 360);
			this.pictureBox_Output.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox_Output.TabIndex = 10;
			this.pictureBox_Output.TabStop = false;
			// 
			// button_Apply
			// 
			this.button_Apply.Location = new System.Drawing.Point(532, 474);
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
			this.button_Save.Location = new System.Drawing.Point(661, 474);
			this.button_Save.Name = "button_Save";
			this.button_Save.Size = new System.Drawing.Size(117, 71);
			this.button_Save.TabIndex = 13;
			this.button_Save.Text = "save";
			this.button_Save.UseVisualStyleBackColor = true;
			this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
			// 
			// textBox_OutputFolder
			// 
			this.textBox_OutputFolder.Location = new System.Drawing.Point(917, 522);
			this.textBox_OutputFolder.Name = "textBox_OutputFolder";
			this.textBox_OutputFolder.Size = new System.Drawing.Size(384, 23);
			this.textBox_OutputFolder.TabIndex = 14;
			this.textBox_OutputFolder.TextChanged += new System.EventHandler(this.textBox_OutputFolder_TextChanged);
			// 
			// pictureBox_EyeLeft
			// 
			this.pictureBox_EyeLeft.Location = new System.Drawing.Point(146, 423);
			this.pictureBox_EyeLeft.Name = "pictureBox_EyeLeft";
			this.pictureBox_EyeLeft.Size = new System.Drawing.Size(108, 62);
			this.pictureBox_EyeLeft.TabIndex = 15;
			this.pictureBox_EyeLeft.TabStop = false;
			// 
			// pictureBox_EyeRight
			// 
			this.pictureBox_EyeRight.Location = new System.Drawing.Point(304, 423);
			this.pictureBox_EyeRight.Name = "pictureBox_EyeRight";
			this.pictureBox_EyeRight.Size = new System.Drawing.Size(108, 62);
			this.pictureBox_EyeRight.TabIndex = 16;
			this.pictureBox_EyeRight.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1322, 559);
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
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.PictureBox pictureBox_Input;
		private System.Windows.Forms.PictureBox pictureBox_Output;
		private System.Windows.Forms.Button button_Apply;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem1;
		private System.Windows.Forms.Button button_Save;
		private System.Windows.Forms.ToolStripMenuItem loadFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToFolderToolStripMenuItem;
		private System.Windows.Forms.TextBox textBox_OutputFolder;
		private System.Windows.Forms.PictureBox pictureBox_EyeLeft;
		private System.Windows.Forms.PictureBox pictureBox_EyeRight;
	}
}


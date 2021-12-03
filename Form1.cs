using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using Emgu.CV;
using Emgu.CV.Structure;

namespace Selfie1
{
	public partial class Form1 : Form
	{
		Image<Bgr, byte> imgInput;

		ManualInput manualInput;
		Visuals visuals;
		SaveLoad saveLoad;
		BulkInputManager bulkInput;

		public Form1()
		{
			InitializeComponent();

			visuals = new Visuals(pictureBox_Input, pictureBox_Output);
			manualInput = new ManualInput(visuals);
			saveLoad = new SaveLoad(manualInput);
			bulkInput = new BulkInputManager(manualInput);

			this.KeyDown += new KeyEventHandler(Form1_KeyDown);
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			Debug.WriteLine(e.KeyCode);
			switch(e.KeyCode)
			{
				case Keys.Space:
					manualInput.Apply();
					break;
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			const string img_folder = "D:\\Coding\\C#\\Selfie\\Selfie1\\test_imgs\\";
			string filename = "IMG_20211113_150047_resize_1920.jpg";
			filename = "IMG_20190610_104519.jpg"; //[1784,1125]/(4160,2340)

			filename = "_0000_IMG_20171101_091405.jpg";
			filename = "IMG_20210413_222434.jpg";
			filename = "IMG_20211113_150047_resize_2912.jpg";

			FileInfo file = new FileInfo(img_folder + filename);

			//imgInput = new Image<Bgr, byte>(img_folder + filename);
			//double scale = 1920f / imgInput.Width;
			//imgInput = imgInput.Resize(scale, Emgu.CV.CvEnum.Inter.Linear);

			manualInput.SetInput(file);

			//pictureBox_Input.Image = imgInput.AsBitmap();

			//disable for now -> first implement manual
			//DetectFaceHaar();
			//DetectEyesHaar();
			//TODO:
			//pictureBox_Input.Image = Detection.DetectEyesHaar();
		}


		private void pictureBox_Input_Click(object sender, EventArgs e)
		{
			var mouseEventArgs = e as MouseEventArgs;
			if(mouseEventArgs != null)
				manualInput.OnClick_Input(mouseEventArgs);
			else
				Debug.WriteLine("Invalid input");
		}

		private void button_Apply_Click(object sender, EventArgs e)
		{
			manualInput.OnClick_Apply();
		}


		private void fileToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			if(dialog.ShowDialog() == DialogResult.OK)
			{
				//imgInput = new Image<Bgr, byte>(dialog.FileName);
				manualInput.SetInput(dialog.FileName);
			}
		}

		private void button_Save_Click(object sender, EventArgs e)
		{
			saveLoad.Save();
		}

		private void saveToFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			if(dialog.ShowDialog() == DialogResult.OK)
			{
				saveLoad.SetOutputFolder(dialog.SelectedPath);
			}
		}

		private void folderToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			if(dialog.ShowDialog() == DialogResult.OK)
			{
				bulkInput.SetInputFolder(dialog.SelectedPath);
			}
		}
	}
}

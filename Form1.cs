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

		public Form1()
		{
			InitializeComponent();

			manualInput = new ManualInput(pictureBox_Input, pictureBox_Output);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			const string img_folder = "D:\\Coding\\C#\\Selfie\\Selfie1\\test_imgs\\";
			string filename = "IMG_20211113_150047_resize_1920.jpg";
			filename = "IMG_20190610_104519.jpg";
			filename = "_0000_IMG_20171101_091405.jpg";
			//imgInput = new Image<Bgr, byte>(img_folder + filename);
			//double scale = 1920f / imgInput.Width;
			//imgInput = imgInput.Resize(scale, Emgu.CV.CvEnum.Inter.Linear);

			manualInput.SetInput(new Image<Bgr, byte>(img_folder + filename));

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
	}
}

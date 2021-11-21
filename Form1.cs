using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			imgInput = new Image<Bgr, byte>("D:\\Coding\\C#\\Selfie\\Selfie1\\test_imgs\\IMG_20211113_150047.jpg");
			pictureBox1.Image = imgInput.AsBitmap();

			DetectFaceHaar();
		}

		private void fileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			if(dialog.ShowDialog() == DialogResult.OK)
			{
				imgInput = new Image<Bgr, byte>(dialog.FileName);
				pictureBox1.Image = imgInput.AsBitmap();
			}
		}

		private void detectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if(imgInput == null)
				{
					throw new Exception("no image");
				}
				DetectFaceHaar();
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void DetectFaceHaar()
		{
			try
			{
				string facePath = Path.GetFullPath(@"../../../haar_data/haarcascade_frontalface_default.xml");
				CascadeClassifier classifier = new CascadeClassifier(facePath);
				var imgGray = imgInput.Convert<Gray, byte>().Clone();
				var faces = classifier.DetectMultiScale(imgGray, 1.1, 4);
				foreach(var face in faces)
				{
					imgInput.Draw(face, new Bgr(0, 0, 255), 2);
				}

				Bitmap bitmap = imgInput.AsBitmap();
				bitmap.SetResolution(pictureBox1.Width, pictureBox1.Height);
				pictureBox1.Image = bitmap;
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}

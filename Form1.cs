﻿using System;
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
			imgInput = new Image<Bgr, byte>("D:\\Coding\\C#\\Selfie\\Selfie1\\test_imgs\\IMG_20211113_150047_resize_1920.jpg");
			pictureBox1.Image = imgInput.AsBitmap();

			//DetectFaceHaar();
			DetectEyesHaar();
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

		public void DetectEyesHaar()
		{
			try
			{
				string facePath = Path.GetFullPath(@"../../../haar_data/haarcascade_eye.xml");
				CascadeClassifier classifier = new CascadeClassifier(facePath);
				var imgGray = imgInput.Convert<Gray, byte>().Clone();

				Size averageEyeSize = new Size(200, 150);
				Size minEyeSize = new Size(150, 100);
				Size maxEyeSize = new Size(250, 200);
				var eyes = classifier.DetectMultiScale(imgGray, 1.1, 3, minEyeSize, maxEyeSize);

				if(eyes.Length != 2)
				{
					throw new Exception("invalid eyes count detected");
				}

				Point eye1 = DetectPupil(imgGray, eyes[0], 0);
				Point eye2 = DetectPupil(imgGray, eyes[1], 1);

				pictureBox1.Image = imgInput.AsBitmap();

			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		private Point DetectPupil(Image<Gray, byte> pSourceImg, Rectangle pEye, int pEyeIndex)
		{
			imgInput.Draw(pEye, new Bgr(0, 0, 255), 4);
			Cross2DF eyeCenter = new Cross2DF(new PointF(pEye.X + pEye.Width / 2, pEye.Y + pEye.Height / 2), 20, 20);
			imgInput.Draw(eyeCenter, new Bgr(255, 0, 0), 4);

			pSourceImg.ROI = pEye;
			Image<Gray, byte> eyeImg = pSourceImg.Copy();


			//EYE
			PictureBox pictureBoxEye = pEyeIndex == 0 ? pictureBoxEye1 : pictureBoxEye2;
			pictureBoxEye.Image = eyeImg.AsBitmap();

			//THRESHOLD
			var threshold = eyeImg.ThresholdToZeroInv(new Gray(40));
			PictureBox pictureBoxEye_a = pEyeIndex == 0 ? pictureBoxEye1_a : pictureBoxEye2_a;
			pictureBoxEye_a.Image = threshold.AsBitmap();

			//CANNY
			const int cannyThreshold = 30;
			var canny = threshold.Canny(cannyThreshold, 2);
			PictureBox pictureBoxEye_b = pEyeIndex == 0 ? pictureBoxEye1_b : pictureBoxEye2_b;
			pictureBoxEye_b.Image = canny.AsBitmap();

			//HOUGH CIRCLES
			const int minRadius = 7;
			const int maxRadius = 12;
			const int accumulatorThreshold = 25;
			const int dp = 2;
			const int minDist = 5;
			var circlesChannels = threshold.HoughCircles(new Gray(cannyThreshold), new Gray(accumulatorThreshold), dp, minDist, minRadius, maxRadius);

			var pupil = eyeImg.Copy();
			foreach(var circleChannel in circlesChannels)
			{
				foreach(var circle in circleChannel)
				{
					pupil.Draw(circle, new Gray(255));
					Console.WriteLine(circle.Center.X);
				}
			}


			PictureBox pictureBoxEye_c = pEyeIndex == 0 ? pictureBoxEye1_c : pictureBoxEye2_c;
			pictureBoxEye_c.Image = pupil.AsBitmap();


			return new Point();
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

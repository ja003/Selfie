using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selfie1
{
	class Detection
	{
		private Visuals visuals;

		public Detection(Visuals visuals)
		{
			this.visuals = visuals;
		}

		public Tuple<Eye, Eye> DetectEyesHaar(Image<Bgr, byte> imgInput)
		{
			try
			{
				string facePath = Path.GetFullPath(@"../../../haar_data/haarcascade_eye.xml");
				CascadeClassifier classifier = new CascadeClassifier(facePath);
				var imgGray = imgInput.Convert<Gray, byte>().Clone();

				//_0000_IMG_20171101_091405 - 180x80
				Size averageEyeSize = new Size(200, 150);
				Size minEyeSize = new Size(150, 70);
				Size maxEyeSize = new Size(250, 200);
				Rectangle[] eyes = classifier.DetectMultiScale(imgGray, 1.1, 3, minEyeSize, maxEyeSize);

				if(eyes.Length != 2)
				{
					Debug.WriteLine("invalid eyes count detected - " + eyes.Length);
				}

				Tuple<Eye, Eye> result = new Tuple<Eye, Eye>(new Eye(), new Eye());
				if(eyes.Length >= 1)
				{
					result.Item1.Range = eyes[0];
					var imgInputCopy = imgInput.Copy();
					imgInputCopy.Draw(eyes[0], new Bgr(255, 0, 0), 5);
					visuals.SetDebug1(imgInputCopy.AsBitmap());
					result.Item1.Pupil = DetectPupil(imgGray, eyes[0], 0);
				}
				if(eyes.Length >= 2)
				{
					result.Item2.Range = eyes[1];
					var imgInputCopy = imgInput.Copy();
					imgInputCopy.Draw(eyes[1], new Bgr(255, 0, 0), 5);
					visuals.SetDebug1b(imgInputCopy.AsBitmap());
					result.Item2.Pupil = DetectPupil(imgGray, eyes[1], 1);
				}

				return result;

			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		private Point DetectPupil(Image<Gray, byte> pSourceImg, Rectangle pEye, int pEyeIndex)
		{
			//imgInput.Draw(pEye, new Bgr(0, 0, 255), 4);
			Cross2DF eyeCenter = new Cross2DF(new PointF(pEye.X + pEye.Width / 2, pEye.Y + pEye.Height / 2), 20, 20);
			//imgInput.Draw(eyeCenter, new Bgr(255, 0, 0), 4);

			pSourceImg.ROI = pEye;
			Image<Gray, byte> eyeImg = pSourceImg.Copy();


			//EYE
			//PictureBox pictureBoxEye = pEyeIndex == 0 ? pictureBoxEye1 : pictureBoxEye2;
			//pictureBoxEye.Image = eyeImg.AsBitmap();

			//THRESHOLD
			var threshold = eyeImg.ThresholdToZeroInv(new Gray(40));
			//PictureBox pictureBoxEye_a = pEyeIndex == 0 ? pictureBoxEye1_a : pictureBoxEye2_a;
			//pictureBoxEye_a.Image = threshold.AsBitmap();

			//CANNY
			const int cannyThreshold = 30;
			var canny = threshold.Canny(cannyThreshold, 2);
			//PictureBox pictureBoxEye_b = pEyeIndex == 0 ? pictureBoxEye1_b : pictureBoxEye2_b;
			//pictureBoxEye_b.Image = canny.AsBitmap();

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


			//PictureBox pictureBoxEye_c = pEyeIndex == 0 ? pictureBoxEye1_c : pictureBoxEye2_c;
			//pictureBoxEye_c.Image = pupil.AsBitmap();


			return new Point();
		}

		//public void DetectFaceHaar()
		//{
		//	try
		//	{
		//		string facePath = Path.GetFullPath(@"../../../haar_data/haarcascade_frontalface_default.xml");
		//		CascadeClassifier classifier = new CascadeClassifier(facePath);
		//		var imgGray = imgInput.Convert<Gray, byte>().Clone();
		//		var faces = classifier.DetectMultiScale(imgGray, 1.1, 4);
		//		foreach(var face in faces)
		//		{
		//			imgInput.Draw(face, new Bgr(0, 0, 255), 2);
		//		}

		//		Bitmap bitmap = imgInput.AsBitmap();
		//		bitmap.SetResolution(pictureBox_Input.Width, pictureBox_Input.Height);
		//		pictureBox_Input.Image = bitmap;
		//	}
		//	catch(Exception ex)
		//	{
		//		throw new Exception(ex.Message);
		//	}
		//}
		
	}
}

using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selfie1
{
	class ManualInput
	{
		Image<Bgr, byte> inputImage;
		Image<Bgr, byte> outputImage;

		private PictureBox pictureBox_Input;
		private PictureBox pictureBox_Output;

		PointF input_eyeLeft;
		PointF input_eyeRight;

		PointF output_eyeLeft; // 836/1920
		PointF output_eyeRight; // 1086/1920


		public ManualInput(PictureBox pictureBox_Input, PictureBox pictureBox_Output)
		{
			this.pictureBox_Input = pictureBox_Input;
			this.pictureBox_Output = pictureBox_Output;
		}


		internal void SetInput(Image<Bgr, byte> image)
		{
			double scale = 1920f / image.Width;
			inputImage = image;
			outputImage = image.CopyBlank();
			//inputImage = image.Resize(scale, Emgu.CV.CvEnum.Inter.Linear);

			pictureBox_Input.Image = inputImage.Copy().AsBitmap();

			//debug
			//OnClick_Apply();
		}

		bool isSetingLeft = true;
		internal void OnClick_Input(MouseEventArgs mouseEventArgs)
		{
			Debug.WriteLine($"{mouseEventArgs.X},{mouseEventArgs.Y} | {pictureBox_Input.Size}");

			if(isSetingLeft)
			{
				int testLeftX = (int)((float)mouseEventArgs.X / pictureBox_Input.Size.Width * inputImage.Size.Width);
				int testLeftY = (int)((float)mouseEventArgs.Y / pictureBox_Input.Size.Height * inputImage.Size.Height);
				input_eyeLeft = new PointF(testLeftX, testLeftY);
			}
			else
			{
				int testRightX = (int)((float)mouseEventArgs.X / pictureBox_Input.Size.Width * inputImage.Size.Width);
				int testRightY = (int)((float)mouseEventArgs.Y / pictureBox_Input.Size.Height * inputImage.Size.Height);
				input_eyeRight = new PointF(testRightX, testRightY);
			}
			isSetingLeft = !isSetingLeft;

		}

		internal void OnClick_Apply()
		{
			//debug

			/*
			//_0000_IMG_20171101_091405 - [1784,1125],[2276,1113]/(4160,2340)
			int testLeftX = 1784;
			int testLeftY = 1125;
			int testRightX = 2276;
			int testRightY = 1113;

			//_0000_IMG_20171101_091405 
			testLeftX = (int)(186f / pictureBox_Input.Size.Width * inputImage.Size.Width);
			testLeftY = (int)(138f / pictureBox_Input.Size.Height * inputImage.Size.Height);
			testRightX = (int)(247f / pictureBox_Input.Size.Width * inputImage.Size.Width);
			testRightY = (int)(139f / pictureBox_Input.Size.Height * inputImage.Size.Height);

			input_eyeLeft = new PointF(testLeftX, testLeftY);
			input_eyeRight = new PointF(testRightX, testRightY);
			*/

			int outputLeftX = (int)(836f / 1920 * inputImage.Size.Width);
			int outputRightX = (int)(1086f / 1920 * inputImage.Size.Width);
			int outputY = (int)(inputImage.Size.Height / 2);
			output_eyeLeft = new PointF(outputLeftX, outputY);
			output_eyeRight = new PointF(outputRightX, outputY);

			ApplyTransform();

			pictureBox_Output.Image = outputImage.AsBitmap();
		}

		private void ApplyTransform()
		{
			PointF thirdPointSrc = input_eyeRight;
			thirdPointSrc.Y += 10; //todo: calculate orthogonal point?
			//thirdPointSrc = input_eyeRight;
			PointF thirdPointDest = output_eyeRight;
			thirdPointDest.Y += 10;
			//thirdPointDest = output_eyeRight;

			PointF[] src = new PointF[] { input_eyeLeft, input_eyeRight, thirdPointSrc };
			PointF[] dest = new PointF[] { output_eyeLeft, output_eyeRight, thirdPointDest };

			//src = new PointF[] { new PointF(0, 0), new PointF(10, 0), new PointF(0, 10) };
			//const int offset = 200;
			//dest = new PointF[] { new PointF(offset, offset), new PointF(10 + offset, offset), new PointF(offset, 10 + offset) };

			Mat affineMat = CvInvoke.GetAffineTransform(src, dest);
			CvInvoke.WarpAffine(inputImage, outputImage, affineMat, inputImage.Size,
				Emgu.CV.CvEnum.Inter.Linear, Emgu.CV.CvEnum.Warp.Default,
				Emgu.CV.CvEnum.BorderType.Constant, new MCvScalar(255,255,255));
			
		}

	}
}

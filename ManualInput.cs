using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selfie1
{
	class ManualInput
	{
		Image<Bgr, byte> inputImage;
		Image<Bgr, byte> outputImage;
		public FileInfo InputImageFile { get; private set; }

		PointF inputEyeLeft;
		PointF inputEyeRight;

		PointF outputEyeLeft; // 836/1920
		PointF outputEyeRight; // 1086/1920

		public ManualInput(Visuals visuals)
		{
			this.visuals = visuals;


		}

		internal Bitmap GetOutputBitmap()
		{
			return outputImage.AsBitmap();
		}

		//internal void SetInput(Image<Bgr, byte> image, string fileName)
		internal void SetInput(string filePath)
		{
			SetInput(new FileInfo(filePath));
		}
		internal void SetInput(FileInfo file)
		{
			Image<Bgr, byte> image = new Image<Bgr, byte>(file.FullName);

			const int newWidth = 1920;
			double scale = 1920f / image.Width;
			int newHeight = (int)(image.Height * scale);
			inputImage = image.Resize(newWidth, newHeight, Emgu.CV.CvEnum.Inter.Linear);
			//inputImage = image.Resize(scale, Emgu.CV.CvEnum.Inter.Linear);
			//inputImage = image;
			outputImage = inputImage.CopyBlank();
			InputImageFile = file;

			visuals.SetInputImage(inputImage.AsBitmap());
			//pictureBox_Input.Image = inputImage.AsBitmap();

			//debug
			//OnClick_Apply();

			int outputLeftX = (int)(836f / 1920 * inputImage.Size.Width);
			int outputRightX = (int)(1086f / 1920 * inputImage.Size.Width);
			int outputY = (int)(inputImage.Size.Height / 2);
			outputEyeLeft = new PointF(outputLeftX, outputY);
			outputEyeRight = new PointF(outputRightX, outputY);

			//debug
			//187,130
			//253,129
			SetInputLeftEye(187, 130);
			SetInputRightEye(253, 129);
		}


		//bool isSetingLeft = true;
		private Visuals visuals;

		internal void OnClick_Input(MouseEventArgs mouseEventArgs)
		{
			Debug.WriteLine($"{mouseEventArgs.X},{mouseEventArgs.Y}");

			bool isSetingLeft = visuals.IsOnInputPictureLeftSide(mouseEventArgs.X);
			if(isSetingLeft)
			{
				SetInputLeftEye(mouseEventArgs.X, mouseEventArgs.Y);
			}
			else
			{
				SetInputRightEye(mouseEventArgs.X, mouseEventArgs.Y);
			}
			//isSetingLeft = !isSetingLeft;

		}

		private void SetInputLeftEye(int inputPictureCoordX, int inputPictureCoordY)
		{
			int imageCoordX = visuals.ConvertInputPictureCoordXToImage(inputPictureCoordX);
			int imageCoordY = visuals.ConvertInputPictureCoordYToImage(inputPictureCoordY);
			inputEyeLeft = new PointF(imageCoordX, imageCoordY);
			visuals.RefreshEyeVisuals(inputImage, inputEyeLeft, inputEyeRight);
		}


		private void SetInputRightEye(int inputPictureCoordX, int inputPictureCoordY)
		{
			int imageCoordX = visuals.ConvertInputPictureCoordXToImage(inputPictureCoordX);
			int imageCoordY = visuals.ConvertInputPictureCoordYToImage(inputPictureCoordY);
			inputEyeRight = new PointF(imageCoordX, imageCoordY);
			visuals.RefreshEyeVisuals(inputImage, inputEyeLeft, inputEyeRight);
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


			Apply();
		}

		public void Apply()
		{
			ApplyTransform();

			visuals.SetOutputImage(outputImage.AsBitmap());
			visuals.debug_ShowOutputEyes(outputImage, outputEyeLeft, outputEyeRight);
		}

		private void ApplyTransform()
		{
			PointF thirdPointSrc = inputEyeRight;
			thirdPointSrc.Y += 10; //todo: calculate orthogonal point?

			//thirdPointSrc = input_eyeRight;
			thirdPointSrc = GetThirdPoint(inputEyeLeft, inputEyeRight);

			PointF thirdPointDest = outputEyeRight;
			thirdPointDest.Y += 10;
			//thirdPointDest = new PointF(
			//	(outputEyeLeft.X + outputEyeRight.X) / 2,
			//	(outputEyeLeft.Y + outputEyeRight.Y) / 2);
			//thirdPointDest = output_eyeRight;
			thirdPointDest = GetThirdPoint(outputEyeLeft, outputEyeRight);

			PointF[] src = new PointF[] { inputEyeLeft, inputEyeRight, thirdPointSrc };
			PointF[] dest = new PointF[] { outputEyeLeft, outputEyeRight, thirdPointDest };

			Debug.WriteLine($"src = [{inputEyeLeft},{inputEyeRight},{thirdPointSrc}]");
			Debug.WriteLine($"dest = [{outputEyeLeft},{outputEyeRight},{thirdPointDest}]");
			Debug.WriteLine($"dest = [{outputEyeLeft},{outputEyeRight},{thirdPointDest}]");

			//src = new PointF[] { new PointF(0, 0), new PointF(10, 0), new PointF(0, 10) };
			//const int offset = 200;
			//dest = new PointF[] { new PointF(offset, offset), new PointF(10 + offset, offset), new PointF(offset, 10 + offset) };

			Mat affineMat = CvInvoke.GetAffineTransform(src, dest);
			CvInvoke.WarpAffine(inputImage, outputImage, affineMat, inputImage.Size,
				Emgu.CV.CvEnum.Inter.Linear, Emgu.CV.CvEnum.Warp.Default,
				Emgu.CV.CvEnum.BorderType.Constant, new MCvScalar(255, 255, 255));

		}

		public static PointF GetThirdPoint(PointF point1, PointF point2)
		{
			PointF thirdPoint;
			Vector2 ier = new Vector2(point2.X, point2.Y);
			Vector2 iel = new Vector2(point1.X, point1.Y);
			Vector2 dir = ier - iel;
			dir = new Vector2(-dir.Y, dir.X);
			Vector2 thirdPointSrcVec = (ier + iel) / 2 + dir / 2;
			thirdPoint = new PointF(thirdPointSrcVec.X, thirdPointSrcVec.Y);
			return thirdPoint;
		}
	}
}

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
		private const int REF_WIDTH = 1920;
		private const int REF_HEIGHT = 1080;
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
			InputImageFile = file;
			Image<Bgr, byte> image = new Image<Bgr, byte>(file.FullName);

			//detect if we will scale image to fit ref height or width
			float imageAspectRatio = (float)image.Size.Width / image.Size.Height;
			float refAspectRatio = (float)REF_WIDTH / REF_HEIGHT;
			bool isScaleHeight = imageAspectRatio < refAspectRatio;

			//    _________REF_WIDTH__________
			//   |                            |
			//   |                            |
			//   REF_HEIGHT                   |
			//   |                            |
			//   |                            |
			//   |____________________________|

			// isScaleHeight:
			//   borderDiff___newWidth____borderDiffRest
			//     |                        |
			//     |                        |
			//     newHeight                |
			//     |                        |
			//     |                        |
			// left|________________________|right


			//calculate new width and height
			int newWidth = REF_WIDTH;
			int newHeight = REF_HEIGHT;
			double scale = isScaleHeight ?
				(float)REF_HEIGHT / image.Height : (float)REF_WIDTH / image.Width;
			if(isScaleHeight)
				newWidth = (int)(image.Width * scale);
			else
				newHeight = (int)(image.Height * scale);


			image = image.Resize(newWidth, newHeight, Emgu.CV.CvEnum.Inter.Linear);
			inputImage = new Image<Bgr, byte>(REF_WIDTH, REF_HEIGHT, new Bgr(255, 0, 0));

			//calculate border difference
			int borderDiff = isScaleHeight ? 
				(REF_WIDTH - newWidth) / 2 : (REF_HEIGHT - newHeight) / 2;
			//https://docs.opencv.org/3.0-beta/modules/core/doc/operations_on_arrays.html#copymakeborder
			//the borders need to match exactly so if halfWidth is not even number, we have to 
			//calculate the remain
			int borderDiffRest = (isScaleHeight ? REF_WIDTH - image.Size.Width : REF_HEIGHT - image.Size.Height) - borderDiff;

			int top = isScaleHeight ? 0 : borderDiff;
			int bot = isScaleHeight ? 0 : borderDiffRest;
			int right = isScaleHeight ? borderDiff : 0;
			int left = isScaleHeight ? borderDiffRest : 0;
			//todo: make input
			MCvScalar whiteBg = new MCvScalar(255, 255, 255);
			CvInvoke.CopyMakeBorder(image, inputImage, top, bot, left, right,
				Emgu.CV.CvEnum.BorderType.Constant, whiteBg);
			visuals.SetInputImage(inputImage.AsBitmap());

			outputImage = inputImage.CopyBlank();

			SetOutputEyes();

			//DEBUG
			//IMG_20210413_222434
			SetInputLeftEye(214, 126);
			SetInputRightEye(271, 126);


			//debug
			//visuals.SetInputImage(image.AsBitmap());

			//debug
			//OnClick_Apply();


			//debug
			//187,130
			//253,129

			//206,126
			//283,123


			//IMG_20211113_150047_resize_2912
			//SetInputLeftEye(221, 135);
			//SetInputRightEye(269, 133);


		}

		private void SetOutputEyes()
		{
			//TODO: make as input
			const int destLeftEyePos = 836;
			const int destRightEyePos = 1086;


			int halfWidthDiffInOut = (REF_WIDTH - outputImage.Size.Width) / 2;

			int destLeftEyePosScaled = destLeftEyePos - halfWidthDiffInOut;
			int destRightEyePosScaled = outputImage.Size.Width - (REF_WIDTH - destRightEyePos - halfWidthDiffInOut);


			//int outputLeftX = (int)(outLeftEyePosPercentage * inputImage.Size.Width);
			//int outputRightX = (int)(outRightEyePosPercentage * inputImage.Size.Width);
			int outputLeftX = destLeftEyePosScaled;
			int outputRightX = destRightEyePosScaled;

			int outputY = (int)(inputImage.Size.Height / 2);
			outputEyeLeft = new PointF(outputLeftX, outputY);
			outputEyeRight = new PointF(outputRightX, outputY);
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

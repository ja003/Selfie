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
		//todo: make customizable
		public const int REF_WIDTH = 1920;
		public const int REF_HEIGHT = 1080;
		Image<Bgr, byte> inputImage;
		Image<Bgr, byte> outputImage;
		public FileInfo InputImageFile { get; private set; }

		PointF inputEyeLeft;
		PointF inputEyeRight;

		PointF outputEyeLeft; // 836/1920
		PointF outputEyeRight; // 1086/1920


		//bool isSetingLeft = true;
		private Visuals visuals;
		private Detection detection;

		public bool IsInputValid;

		public ManualInput(Visuals visuals, Detection detection)
		{
			this.visuals = visuals;
			this.detection = detection;
		}

		internal Bitmap GetOutputBitmap()
		{
			return outputImage.AsBitmap();
		}

		//internal void SetInput(Image<Bgr, byte> image, string fileName)
		internal void SetInput(string filePath)
		{
			try
			{
				SetInput(new FileInfo(filePath));
			}
			catch(Exception e)
			{
				SetInputInvalid();
			}
		}

		private void SetInputInvalid()
		{
			IsInputValid = false;
			visuals.SetInputImage(null);
			Debug.WriteLine("SetInputInvalid");
		}

		internal void SetInput(FileInfo file)
		{
			InputImageFile = file;
			IsInputValid = file.Exists;
			if(!file.Exists)
			{
				SetInputInvalid();
				return;
			}

			Image<Bgr, byte> image = new Image<Bgr, byte>(file.FullName);

			visuals.Reset();

			var formatedImage = SetInputImage(image);

			outputImage = inputImage.CopyBlank();

			SetOutputEyes();

			//set some init pos
			//SetInputLeftEye(287, 167, true);
			//SetInputRightEye(363, 167, true);

			var eyes = detection.DetectEyesHaar(formatedImage);
			SetInputEyes(eyes);
			//SetInputEye(eyes.Item1, true);
			//SetInputEye(eyes.Item2, false);
		}



		/// <summary>
		/// Format input image to fit ref width and height.
		/// Returns the formated image.
		/// </summary>
		Image<Bgr, byte> SetInputImage(Image<Bgr, byte> image)
		{
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
			return inputImage;
		}

		private void SetOutputEyes()
		{
			//TODO: make as input (after REF_WIDTH is made customizable)
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



		internal void OnClick_Input(MouseEventArgs mouseEventArgs)
		{
			Debug.WriteLine($"{mouseEventArgs.X},{mouseEventArgs.Y}");

			bool isSetingLeft = visuals.IsOnInputPictureLeftSide(mouseEventArgs.X);
			if(isSetingLeft)
			{
				SetInputLeftEye(mouseEventArgs.X, mouseEventArgs.Y, true);
			}
			else
			{
				SetInputRightEye(mouseEventArgs.X, mouseEventArgs.Y, true);
			}
			//isSetingLeft = !isSetingLeft;

		}


		int moveSpeed = 1;
		internal void ToggleMoveSpeed()
		{
			moveSpeed = moveSpeed > 1 ? 1 : 5;
		}

		public void MoveInputLeftEye(int xDiff, int yDiff)
		{
			inputEyeLeft = new PointF((int)inputEyeLeft.X + xDiff * moveSpeed, (int)inputEyeLeft.Y + yDiff * moveSpeed);
			RefreshEyeVisuals();
		}


		public void MoveInputRightEye(int xDiff, int yDiff)
		{
			inputEyeRight = new PointF((int)inputEyeRight.X + xDiff * moveSpeed, (int)inputEyeRight.Y + yDiff * moveSpeed);
			RefreshEyeVisuals();
		}



		private void SetInputEyes(Tuple<Eye, Eye> eyes)
		{
			Point eyeCenter1 = default;
			Point eyeCenter2 = default;
			eyes.Item1.GetRangeCenter(ref eyeCenter1);
			eyes.Item2.GetRangeCenter(ref eyeCenter2);
			bool isFirstLeft = eyeCenter1.X < eyeCenter2.X;
			SetInputEye(eyes.Item1, isFirstLeft);
			SetInputEye(eyes.Item2, !isFirstLeft);
		}

		private void SetInputEye(Eye eye, bool isLeft)
		{
			Point eyeCenter = default;
			Point pupil = default;
			if(eye.GetPupil(ref pupil))
			{
				if(isLeft)
					SetInputLeftEye(pupil.X, pupil.Y, false);
				else
					SetInputRightEye(pupil.X, pupil.Y, false);

			}
			else if(eye.GetRangeCenter(ref eyeCenter))
			{
				Debug.WriteLine("Eye detected but not pupil");
				if(isLeft)
					SetInputLeftEye(eyeCenter.X, eyeCenter.Y, false);
				else
					SetInputRightEye(eyeCenter.X, eyeCenter.Y, false);
			}
			else
			{
				Debug.WriteLine("Eye not detected");
			}
		}

		private void SetInputLeftEye(int x, int y, bool convertFromPictureToImage)
		{
			if(convertFromPictureToImage)
			{
				x = visuals.ConvertInputPictureCoordXToImage(x);
				y = visuals.ConvertInputPictureCoordYToImage(y);
			}
			inputEyeLeft = new PointF(x, y);
			RefreshEyeVisuals();
		}


		private void SetInputRightEye(int x, int y, bool convertFromPictureToImage)
		{
			if(convertFromPictureToImage)
			{
				x = visuals.ConvertInputPictureCoordXToImage(x);
				y = visuals.ConvertInputPictureCoordYToImage(y);
			}
			inputEyeRight = new PointF(x, y);
			RefreshEyeVisuals();
		}


		private void RefreshEyeVisuals()
		{
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
			if(!IsInputValid)
				return;

			ApplyTransform();

			//visuals.SetOutputImage(outputImage.AsBitmap());
			visuals.SetOuputImage(outputImage, outputEyeLeft, outputEyeRight);
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

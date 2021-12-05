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
	class Visuals
	{
		//private PictureBox pictureBox_Input;
		//private PictureBox pictureBox_Output;

		//private PictureBox pictureBox_EyeLeft;
		//private PictureBox pictureBox_EyeRight;

		


		Bgr colorLeft = new Bgr(255, 0, 0);
		Bgr colorRight = new Bgr(255, 255, 0);
		Bgr colorThird = new Bgr(50, 50, 50);
		private Form1 form;

		//public Visuals(PictureBox pictureBox_Input, PictureBox pictureBox_Output, PictureBox pictureBox_EyeLeft, PictureBox pictureBox_EyeRight)
		//{
		//	this.pictureBox_Input = pictureBox_Input;
		//	this.pictureBox_Output = pictureBox_Output;
		//	this.pictureBox_EyeLeft = pictureBox_EyeLeft;
		//	this.pictureBox_EyeRight = pictureBox_EyeRight;
		//}

		public Visuals(Form1 form)
		{
			this.form = form;
		}

		public void RefreshEyeVisuals(Image<Bgr, byte> inputImage, PointF eyeLeftPos, PointF eyeRightPos)
		{
			Image<Bgr, byte> inputImageVisual = inputImage.Copy();
			const int crossSize = 50;
			const int thickness = 5;

			inputImageVisual.Draw(new Cross2DF(eyeLeftPos, crossSize, crossSize), colorLeft, thickness);
			inputImageVisual.Draw(new Cross2DF(eyeRightPos, crossSize, crossSize), colorRight, thickness);
			inputImageVisual.Draw(new Cross2DF(ManualInput.GetThirdPoint(eyeLeftPos, eyeRightPos), crossSize, crossSize), colorThird, thickness);
			SetInputImage(inputImageVisual.AsBitmap());
			
			RefreshEyeCrop(inputImage, eyeLeftPos, true);
			RefreshEyeCrop(inputImage, eyeRightPos, false);
		}

		internal void SetDebug(int index, bool isA, Bitmap bitmap)
		{
			switch(index)
			{
				case 1:
					if(isA)
						form.pictureBox_debug1.Image = bitmap;
					else
						form.pictureBox_debug1b.Image = bitmap;
					return;
				case 2:
					if(isA)
						form.pictureBox_debug2.Image = bitmap;
					else
						form.pictureBox_debug2b.Image = bitmap;
					return;
				case 3:
					if(isA)
						form.pictureBox_debug3.Image = bitmap;
					else
						form.pictureBox_debug3b.Image = bitmap;
					return;
				case 4:
					if(isA)
						form.pictureBox_debug4.Image = bitmap;
					else
						form.pictureBox_debug4b.Image = bitmap;
					return;
			}
			Debug.WriteLine("Invalid SetDebug");
		}

		/// <summary>
		/// Set the eye closeup image
		/// </summary>
		private void RefreshEyeCrop(Image<Bgr, byte> inputImage, PointF eyePos, bool isLeft)
		{
			PictureBox pictureBox = isLeft ? form.pictureBox_EyeLeft : form.pictureBox_EyeRight;
			Point eyeCropStart = new Point(
							(int)eyePos.X - pictureBox.Size.Width / 2,
							(int)eyePos.Y - pictureBox.Size.Height / 2);
			try
			{
				Image<Bgr, byte> eyeCrop = inputImage.Copy(new Rectangle(eyeCropStart, pictureBox.Size));
				eyeCrop.Draw(new Cross2DF(new PointF(eyeCrop.Size.Width / 2, eyeCrop.Size.Height/ 2), eyeCrop.Size.Width, eyeCrop.Size.Height), isLeft ? colorLeft : colorRight, 1);
				pictureBox.Image = eyeCrop.AsBitmap();
			}
			catch(Exception e)
			{
				Debug.Write("Couldnt RefreshEyeCrop " + e);
			}
		}

		internal void SetInputImage(Bitmap bitmap)
		{
			form.pictureBox_Input.Image = bitmap;
		}

		public int ConvertInputPictureCoordXToImage(int pictureCoordX)
		{
			return (int)((float)pictureCoordX / form.pictureBox_Input.Size.Width * form.pictureBox_Input.Image.Size.Width);
		}

		public int ConvertInputPictureCoordYToImage(int pictureCoordY)
		{
			return (int)((float)pictureCoordY / form.pictureBox_Input.Size.Height* form.pictureBox_Input.Image.Size.Height);
		}

		internal bool IsOnInputPictureLeftSide(int x)
		{
			return x < form.pictureBox_Input.Size.Width / 2;
		}


		internal void SetOuputImage(Image<Bgr, byte> outputImage, PointF outputEyeLeft, PointF outputEyeRight)
		{
			Image<Bgr, byte> outputImageVisual = outputImage.Copy();
			const int crossSize = 50;
			const int thickness = 5;

			outputImageVisual.Draw(new Cross2DF(outputEyeLeft, crossSize, crossSize), colorLeft, thickness);
			outputImageVisual.Draw(new Cross2DF(outputEyeRight, crossSize, crossSize), colorRight, thickness);
			outputImageVisual.Draw(new Cross2DF(ManualInput.GetThirdPoint(outputEyeLeft, outputEyeRight), crossSize, crossSize), colorThird, thickness);

			form.pictureBox_Output.Image = outputImageVisual.AsBitmap();
		}
	}
}

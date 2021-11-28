using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selfie1
{
	class Visuals
	{
		private PictureBox pictureBox_Input;
		private PictureBox pictureBox_Output;

		Bgr colorLeft = new Bgr(255, 0, 0);
		Bgr colorRight = new Bgr(255, 255, 0);

		public Visuals(PictureBox pictureBox_Input, PictureBox pictureBox_Output)
		{
			this.pictureBox_Input = pictureBox_Input;
			this.pictureBox_Output = pictureBox_Output;
		}

		public void RefreshEyeVisuals(Image<Bgr, byte> inputImage, PointF eyeLeftPos, PointF eyeRightPos)
		{
			Image<Bgr, byte> inputImageVisual = inputImage.Copy();
			const int crossSize = 50;
			const int thickness = 20;
			
			inputImageVisual.Draw(new Cross2DF(eyeLeftPos, crossSize, crossSize), colorLeft, thickness);
			inputImageVisual.Draw(new Cross2DF(eyeRightPos, crossSize, crossSize), colorRight, thickness);


			SetInputImage(inputImageVisual.AsBitmap());
		}

		internal void SetInputImage(Bitmap bitmap)
		{
			pictureBox_Input.Image = bitmap;
		}

		public int ConvertInputPictureCoordXToImage(int pictureCoordX)
		{
			return (int)((float)pictureCoordX / pictureBox_Input.Size.Width * pictureBox_Input.Image.Size.Width);
		}

		public int ConvertInputPictureCoordYToImage(int pictureCoordY)
		{
			return (int)((float)pictureCoordY / pictureBox_Input.Size.Height* pictureBox_Input.Image.Size.Height);
		}

		internal bool IsOnInputPictureLeftSide(int x)
		{
			return x < pictureBox_Input.Size.Width / 2;
		}

		internal void SetOutputImage(Bitmap bitmap)
		{
			pictureBox_Output.Image = bitmap;
		}
	}
}

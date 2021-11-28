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
			inputImage = image.Resize(scale, Emgu.CV.CvEnum.Inter.Linear);

			pictureBox_Input.Image = inputImage.AsBitmap();

			//debug
			OnClick_Apply();
		}

		internal void OnClick_Input(MouseEventArgs mouseEventArgs)
		{
			Debug.WriteLine($"{mouseEventArgs.X},{mouseEventArgs.Y} | {pictureBox_Input.Size}");
		}

		internal void OnClick_Apply()
		{
			//debug
			input_eyeLeft = new PointF(186, 138);
			input_eyeRight = new PointF(247, 139);

			int outputLeftX = (int)(836f / 1920 * pictureBox_Output.Size.Width);
			int outputRightX = (int)(1086f / 1920 * pictureBox_Output.Size.Width);
			int outputY = pictureBox_Output.Size.Height / 2;
			output_eyeLeft = new PointF(outputLeftX, outputY);
			output_eyeRight = new PointF(outputRightX, outputY);

			ApplyTransform();

			pictureBox_Output.Image = inputImage.AsBitmap();
		}

		private void ApplyTransform()
		{
			PointF[] src = new PointF[] { input_eyeLeft, input_eyeRight, input_eyeRight };
			PointF[] dest = new PointF[] { output_eyeLeft, output_eyeRight, output_eyeRight };
			Mat affineMat = CvInvoke.GetAffineTransform(src, dest);

			inputImage.WarpAffine(affineMat, Emgu.CV.CvEnum.Inter.Linear, Emgu.CV.CvEnum.Warp.Default, Emgu.CV.CvEnum.BorderType.Default, new Bgr(255, 255, 255));
		}

	}
}

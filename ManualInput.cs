using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selfie1
{
	class ManualInput
	{
		private PictureBox pictureBox_Input;
		private PictureBox pictureBox_Output;

		public ManualInput(PictureBox pictureBox_Input, PictureBox pictureBox_Output)
		{
			this.pictureBox_Input = pictureBox_Input;
			this.pictureBox_Output = pictureBox_Output;
		}

		internal void OnClick_Input(MouseEventArgs mouseEventArgs)
		{
			Debug.WriteLine($"{mouseEventArgs.X},{mouseEventArgs.Y} | {pictureBox_Input.Size}");
		}

		internal void OnClick_Apply()
		{
			pictureBox_Output.Image = pictureBox_Input.Image;
		}

		internal void SetInput(Image<Bgr, byte> image)
		{
			double scale = 1920f / image.Width;
			image = image.Resize(scale, Emgu.CV.CvEnum.Inter.Linear);

			pictureBox_Input.Image = image.AsBitmap();

		}
	}
}

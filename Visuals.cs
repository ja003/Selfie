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

		public Visuals(PictureBox pictureBox_Input, PictureBox pictureBox_Output)
		{
			this.pictureBox_Input = pictureBox_Input;
			this.pictureBox_Output = pictureBox_Output;
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

		internal void SetOutputImage(Bitmap bitmap)
		{
			pictureBox_Output.Image = bitmap;
		}
	}
}

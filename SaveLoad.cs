using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selfie1
{
	class SaveLoad
	{
		private ManualInput manualInput;
		EncoderParameters encoderParams;
		ImageCodecInfo jpegCodec;
		public SaveLoad(ManualInput manualInput)
		{
			this.manualInput = manualInput;

			// Encoder parameter for image quality

			EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 8);

			EncoderParameters encoderParams = new EncoderParameters(1);
			encoderParams.Param[0] = qualityParam;

			// Jpeg image codec
			jpegCodec = this.getEncoderInfo("image/jpeg");


		}

		private ImageCodecInfo getEncoderInfo(string mimeType)
		{
			// Get image codecs for all image formats
			ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

			// Find the correct image codec
			for(int i = 0; i < codecs.Length; i++)
				if(codecs[i].MimeType == mimeType)
					return codecs[i];
			return null;
		}

		internal void Save()
		{
			if(jpegCodec == null)
			{
				Debug.WriteLine("no jpeg codec");
				return;
			}
			string path = "D:\\Coding\\C#\\Selfie\\output\\";
			string fileName = manualInput.InputImageFile.Name; //includes .jpg
			manualInput.GetOutputBitmap().Save(path + fileName, jpegCodec, encoderParams);
		}
	}
}

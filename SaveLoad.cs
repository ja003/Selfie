using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
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

		string outputPath = "D:\\Coding\\C#\\Selfie\\output\\";

		static public Action OnSave;

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
			if(!Directory.Exists(outputPath))
			{
				Debug.WriteLine($"path {outputPath} does not exist");
				return;
			}

			string fileName = manualInput.InputImageFile.Name; //includes .jpg
			string outputFileFullName = Path.Combine(outputPath, fileName);
			manualInput.GetOutputBitmap().Save(outputFileFullName, jpegCodec, encoderParams);

			OnSave.Invoke();
		}

		internal void SetOutputFolder(string path)
		{
			Debug.WriteLine($"SetOutputFolder {path}");

			if(!Directory.Exists(path))
			{
				Debug.WriteLine($"path {path} does not exist");
				return;
			}

			outputPath = path;

			PropertyManager.OutputFolder = path;
			Properties.Settings.Default["outputFolder"] = path;
		}
	}
}

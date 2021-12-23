using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selfie1
{
	class SaveLoad
	{
		private ManualInput manualInput;
		private TextBox textBox_OutputName;
		EncoderParameters encoderParams;
		ImageCodecInfo jpegCodec;

		string outputPath = "D:\\Coding\\C#\\Selfie\\output\\";

		static public Action OnSave;

		public SaveLoad(ManualInput manualInput, TextBox textBox_OutputName)
		{
			this.manualInput = manualInput;
			this.textBox_OutputName = textBox_OutputName;

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

		internal void Save(int index)
		{
			if(!manualInput.IsInputValid)
			{
				Debug.WriteLine("Input is not valid");
				return;
			}

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



			bool useFileName = textBox_OutputName.Text.Length == 0;
			string fileName = useFileName ?
				manualInput.InputImageFile.Name : //includes .jpg
				textBox_OutputName.Text;

			if(index >= 0)
			{
				fileName = useFileName ? 
					Path.GetFileNameWithoutExtension(manualInput.InputImageFile.FullName) :
					fileName;
				fileName += "_" + index.ToString("00");
				fileName += Path.GetExtension(manualInput.InputImageFile.FullName);
			}

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

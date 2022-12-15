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
			Logger.Log("--- Save ---");

			if(!manualInput.IsInputValid)
			{
				Logger.Log("Input is not valid");
				return;
			}

			if(jpegCodec == null)
			{
				Logger.Log("no jpeg codec");
				return;
			}
			if(!Directory.Exists(outputPath))
			{
				Logger.Log($"path {outputPath} does not exist");
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
			if(File.Exists(outputFileFullName))
			{

				DialogResult dialogResult = MessageBox.Show($"File {outputFileFullName} already exists", "Do you want to owerwrite?", MessageBoxButtons.YesNo);
				if(dialogResult == DialogResult.No)
				{
					Logger.Log("save canceled");
					return;
				}
			}

			manualInput.GetOutputBitmap().Save(outputFileFullName, jpegCodec, encoderParams);

			OnSave.Invoke();

			Logger.Log("--- Saved ---");
		}

		internal bool SetOutputFolder(string path)
		{
			Logger.Log($"SetOutputFolder {path}");

			if(!Directory.Exists(path))
			{
				Logger.Log($"path {path} does not exist");
				outputPath = "";
				return false;
			}

			outputPath = path;

			PropertyManager.OutputFolder = path;
			Properties.Settings.Default["outputFolder"] = path;
			return true;
		}
	}
}

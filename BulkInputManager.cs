using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selfie1
{
	class BulkInputManager
	{
		private DirectoryInfo inputFolder;
		private FileInfo[] inputFiles = new FileInfo[0];
		public static int currentFileIndex = -1;
		private ManualInput manualInput;

		public BulkInputManager(ManualInput manualInput)
		{
			this.manualInput = manualInput;
			SaveLoad.OnSave += ProcessNextFile;
		}

		internal void SetInputFolder(string path)
		{
			currentFileIndex = -1;

			if(!Directory.Exists(path))
			{
				Debug.WriteLine($"path {path} does not exist");
				return;
			}
			inputFolder = new DirectoryInfo(path);

			if(inputFolder.GetFiles().Length == 0)
			{
				Debug.WriteLine($"there are no files");
				return;
			}

			inputFiles = inputFolder.GetFiles();
			ProcessNextFile();
		}

		public void ProcessNextFile()
		{
			currentFileIndex++;

			if(!ExistsNextFile())
			{
				Debug.WriteLine("no next file to process");
				currentFileIndex = -1;
				manualInput.SetInput("");
				return;
			}
			ProcessFile(inputFiles[currentFileIndex]);
		}

		private bool ExistsNextFile()
		{
			return currentFileIndex < inputFiles.Length;
		}

		private void ProcessFile(FileInfo fileInfo)
		{
			manualInput.SetInput(fileInfo);
		}
	}
}
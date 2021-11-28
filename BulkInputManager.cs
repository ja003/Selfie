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
		private FileInfo[] inputFiles;
		int currentFileIndex;
		private ManualInput manualInput;

		public BulkInputManager(ManualInput manualInput)
		{
			this.manualInput = manualInput;
		}

		internal void SetInputFolder(string path)
		{
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
			ProcessFile(inputFiles[currentFileIndex]);
			currentFileIndex++;
		}

		private void ProcessFile(FileInfo fileInfo)
		{
			manualInput.SetInput(fileInfo);
		}
	}
}
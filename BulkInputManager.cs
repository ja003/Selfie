using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selfie1
{
	class BulkInputManager
	{
		private DirectoryInfo inputFolder;
		private FileInfo[] inputFiles = new FileInfo[0];
		//public static int currentFileIndex = -1;
		private ManualInput manualInput;
		NumericUpDown num_CurrentIndex;

		public BulkInputManager(ManualInput manualInput, NumericUpDown num_CurrentIndex)
		{
			this.manualInput = manualInput;
			SaveLoad.OnSave += ProcessNextFile;
			this.num_CurrentIndex = num_CurrentIndex;
		}

		internal void SetInputFolder(string path)
		{
			num_CurrentIndex.Value = -1;

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
			if(num_CurrentIndex.Value < 0)
			{
				Debug.WriteLine("dont ProcessNextFile");
				return;
			}

			num_CurrentIndex.Value++;

			if(!ExistsNextFile())
			{
				Debug.WriteLine("no next file to process");
				num_CurrentIndex.Value = -1;
				manualInput.SetInput("");
				return;
			}
			ProcessFile(inputFiles[(int)num_CurrentIndex.Value]);
		}

		private bool ExistsNextFile()
		{
			return num_CurrentIndex.Value < inputFiles.Length;
		}

		private void ProcessFile(FileInfo fileInfo)
		{
			manualInput.SetInput(fileInfo);
		}
	}
}
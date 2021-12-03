using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selfie1
{
	static class PropertyManager
	{
		public static string OutputFolder
		{
			get
			{
				return GetProperty(EPropertyKey.OutputFolder);
			}
			internal set
			{
				SetProperty(EPropertyKey.OutputFolder, value);
			}
		}

		private static string GetProperty(EPropertyKey key)
		{
			return (string)Properties.Settings.Default[key.ToString()];
		}

		private static void SetProperty(EPropertyKey key, string value)
		{
			Properties.Settings.Default[key.ToString()] = value;
			Properties.Settings.Default.Save();
		}
	}

	public enum EPropertyKey
	{
		None,
		OutputFolder
	}
}

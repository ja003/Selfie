using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selfie1
{
	static class Logger
	{
		static RichTextBox textBox;

		public static void Init(RichTextBox inTextBox)
		{
			textBox = inTextBox;
		}

		public static void Log(string text)
		{
			//todo: message type (info, error, ..)

			Debug.WriteLine(text);
			textBox.Text = text + "\n" + textBox.Text;
			//textBox.AppendText(textBox.Text.Length > 0 ? "\n" : "" + text);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selfie1
{
	class Eye
	{
		public Rectangle Range;
		public Point Pupil;

		public Point RangeCenter => new Point(Range.X + Range.Width / 2, Range.Y + Range.Height / 2);
	}
}

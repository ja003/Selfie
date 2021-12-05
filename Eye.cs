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
		public Rectangle? Range = null;
		public Point? Pupil = null;

		public Point? RangeCenter => Range != null ? new Point(((Rectangle)Range).X + ((Rectangle)Range).Width / 2, ((Rectangle)Range).Y + (((Rectangle)Range)).Height / 2) : null;

		public bool GetPupil(ref Point pupil)
		{
			if(Pupil != null)
				pupil = (Point)Pupil;

			return Pupil != null;
		}

		internal bool GetRangeCenter(ref Point center)
		{
			if(RangeCenter != null)
				center = (Point)RangeCenter;

			return RangeCenter != null;
		}
	}
}

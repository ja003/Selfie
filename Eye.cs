using System.Drawing;

namespace Selfie1
{
	/// <summary>
	/// _________________________________
	/// |								|
	/// |								|
	/// |								|
	/// |								|
	/// |		____Range___			|
	/// |		|			|			|
	/// |		|	<Pupil>	|			|
	/// |		|___________|			|
	/// |								|
	/// |								|
	/// |_______________________________|
	/// </summary>
	class Eye
	{
		public Rectangle? Range = null;
		//local coord in Range
		public Point? PupilLocal = null;

		public Point? RangeCenter => Range != null ? new Point(((Rectangle)Range).X + ((Rectangle)Range).Width / 2, ((Rectangle)Range).Y + (((Rectangle)Range)).Height / 2) : null;

		public bool GetPupil(ref Point pupil)
		{
			if(PupilLocal != null)
			{
				pupil = (Point)PupilLocal;
				pupil.X += ((Rectangle)Range).X;
				pupil.Y += ((Rectangle)Range).Y;
			}

			return PupilLocal != null;
		}

		internal bool GetRangeCenter(ref Point center)
		{
			if(RangeCenter != null)
				center = (Point)RangeCenter;

			return RangeCenter != null;
		}
	}
}

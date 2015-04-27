using System;
using System.Collections.Generic;
using System.Text;

namespace Parkers.Postcodes.Coordinates
{
	internal class Ellipsoid
	{
		public static readonly Ellipsoid Airy1830;
		public static readonly Ellipsoid WGS84;

		static Ellipsoid()
		{
			Airy1830 = new Ellipsoid( 6377563.396, 6356256.909 );
			WGS84 = new Ellipsoid( 6378137.000, 6356752.3141 );
		}

		private Ellipsoid( double a, double b )
		{
			this.a = a;
			this.b = b;
			this.eSquared = ((a * a) - (b * b)) / (a * a);
		}

		public readonly double a;
		public readonly double b;
		public readonly double eSquared;
	}
}

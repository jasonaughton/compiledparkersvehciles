using System;
using System.Collections.Generic;
using System.Text;

namespace Parkers.Postcodes.Coordinates
{
	internal class HelmertTransform
	{
		public static readonly HelmertTransform WGS84toAiry1830;
		public static readonly HelmertTransform Airy1830toWGS84;

		static HelmertTransform()
		{
			WGS84toAiry1830 = new HelmertTransform( -446.448, 124.157, -542.060,
				                                    -0.1502, -0.2470, -0.8421,
			                                        20.4894 );

			Airy1830toWGS84 = new HelmertTransform( 446.448, -124.157, 542.060,
													0.1502, 0.2470, 0.8421,
													-20.4894 );
		}



		internal double _tx;
		internal double _ty;
		internal double _tz;
		internal double _rx;
		internal double _ry;
		internal double _rz;
		internal double _s;

		private HelmertTransform( double tx, double ty, double tz, // metres
								 double rx, double ry, double rz, // arc seconds
								 double s )                       // ppm
		{
			_tx = tx;
			_ty = ty;
			_tz = tz;
			_rx = SecondsToRadians( rx );
			_ry = SecondsToRadians( ry );
			_rz = SecondsToRadians( rz );
			_s = s / 1000000.0; // convert from ppm
		}

		public LatLng Transform( LatLng input )
		{



			LatLng result = new LatLng(0.0, 0.0);
			return result;
		}

		private double SecondsToRadians( double sec )
		{
			double deg = sec / 3600.0;
			double rad = deg * Math.PI / 180.0;
			return rad;
		}

	}
}

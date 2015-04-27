using System;
using System.Collections.Generic;
using System.Text;

namespace Parkers.Postcodes.Coordinates
{
	internal class OsRef
	{
		public int Easting
		{
			get { return _easting; }
			set { _easting = value; }
		}
		private int _easting;

		public int Northing
		{
			get { return _northing; }
			set { _northing = value; }
		}
		private int _northing;

		public OsRef( int easting, int northing )
		{
			_easting = easting;
			_northing = northing;
		}

		public double DistanceInMetresFrom( OsRef start )
		{
			return Math.Pow( Math.Pow( (double) _northing - start.Northing, 2.0 ) + Math.Pow( (double) _easting - start.Easting, 2.0 ), 0.5 );
		}

		/// <summary>
		/// Converts this instance to a WGS84 latitude and longitude
		/// </summary>
		/// <returns></returns>
		public LatLng ToLatLng()
		{
			return LatLng.OsRefToWGS84LatLng( this );
		}

		/// <summary>
		/// Converts this instance to an Airy1830 latitude and longitude
		/// </summary>
		/// <returns></returns>
		public LatLng ToAiry1830LatLng()
		{
			return LatLng.OsRefToAiry1830LatLng( this );
		}
	}
}

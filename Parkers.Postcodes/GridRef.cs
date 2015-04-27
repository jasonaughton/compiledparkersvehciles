using System;
using System.Collections.Generic;
using System.Text;

using Parkers.Postcodes.Coordinates;

namespace Parkers.Postcodes
{
	public class GridRef
	{
		private static readonly double _metresPerMile = 1609.344;

		private OsRef _osRef;
		private LatLng _latLng;
		private bool _canonicalOsRef = false;
		private bool _canonicalLatLng = false;

		public int Easting
		{
			get { return _osRef.Easting; }
		}

		public int Northing
		{
			get { return _osRef.Northing; }
		}

		public double Latitude
		{
			get { return _latLng.Latitude; }
		}

		public double Longitude
		{
			get { return _latLng.Longitude; }
		}

		public GridRef( int easting, int northing )
		{
			_osRef = new OsRef( easting, northing );
			_canonicalOsRef = true;

			_latLng = _osRef.ToLatLng();
		}

		public GridRef( double latitude, double longitude )
		{
			_latLng = new LatLng( latitude, longitude );
			_canonicalLatLng = true;

			_osRef = _latLng.ToOsRef();
		}

		public GridRef( int easting, int northing, double latitude, double longitude )
		{
			_latLng = new LatLng( latitude, longitude );
			_canonicalLatLng = true;

			_osRef = new OsRef( easting, northing );
			_canonicalOsRef = true;
		}

		/// <summary>
		/// Calculates the distance from the specified GridRef in metres
		/// </summary>
		/// <param name="start">Another GridRef</param>
		/// <returns>A distance in metres</returns>
		public double DistanceInMetresFrom( GridRef start )
		{
			// Use OsRef if both have canonical values...
			if ( _canonicalOsRef && start._canonicalOsRef )
			{
				return _osRef.DistanceInMetresFrom( start._osRef );
			}
			// ... otherwise use LatLng if both have canonical values...
			else if ( _canonicalLatLng && start._canonicalLatLng )
			{
				return _latLng.DistanceInMetresFrom( start._latLng );
			}

			// ...otherwise go back to OsRef. One location will have to be converted, so we may as well use the simpler distance calculation.
			return _osRef.DistanceInMetresFrom( start._osRef );
		}

		/// <summary>
		/// Calculates the distance from the specified GridRef in miles
		/// </summary>
		/// <param name="start">Another GridRef</param>
		/// <returns>A distance in miles</returns>
		public double DistanceInMilesFrom( GridRef start )
		{
			return this.DistanceInMetresFrom( start ) / _metresPerMile;
		}

		public override string ToString()
		{
			if ( _canonicalOsRef )
			{
				return Easting.ToString() + "m, " + Northing.ToString() + "m";
			}
			else
			{
				return Latitude.ToString() + ", " + Longitude.ToString();
			}
		}
	}
}

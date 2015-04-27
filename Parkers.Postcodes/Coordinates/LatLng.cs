using System;
using System.Collections.Generic;
using System.Text;

namespace Parkers.Postcodes.Coordinates
{
	internal class LatLng
	{
		public double Latitude
		{
			get { return _latitude; }
			set { _latitude = value; }
		}
		private double _latitude;

		public double Longitude
		{
			get { return _longitude; }
			set { _longitude = value; }
		}
		private double _longitude;

		public LatLng( double latitude, double longitude )
		{
			_latitude = latitude;
			_longitude = longitude;
		}

		public double DistanceInMetresFrom( LatLng start )
		{
			double radius = 6366.707; //km
			double deg2rad = Math.PI / 180.0;

			double distance = radius * Math.Acos( Math.Sin( _latitude * deg2rad ) * Math.Sin( start.Latitude * deg2rad ) + Math.Cos( _latitude * deg2rad ) * Math.Cos( start._latitude * deg2rad ) * Math.Cos( deg2rad * (_latitude - start.Latitude) ) );
			//d = acos(sin(lat1).sin(lat2)+cos(lat1).cos(lat2).cos(long2-long1)).R

			return distance * 1000; //metres
		}
		
		#region Datum conversions

		/// <summary>
		/// Converts this instance to WGS84, assuming that it is currently based on the Airy1830 datum.
		/// </summary>
		/// <returns></returns>
		public LatLng ToWGS84()
		{
			return ChangeDatum( Ellipsoid.Airy1830, HelmertTransform.Airy1830toWGS84, Ellipsoid.WGS84 );
		}

		/// <summary>
		/// Converts this instance to Airy1830, assuming that it is currently based on the WGS84 datum.
		/// </summary>
		/// <returns></returns>
		public LatLng ToAiry1830()
		{
			return ChangeDatum( Ellipsoid.WGS84, HelmertTransform.WGS84toAiry1830, Ellipsoid.Airy1830 );
		}

		private LatLng ChangeDatum( Ellipsoid currentEllipsoid, HelmertTransform transform, Ellipsoid targetEllipsoid )
		{
			// This is deliberately ugly C#. It's ported from javascript at http://www.jstott.me.uk/jscoord/ (v1.1.1)
			// The less I touch it, the less chance there is of breaking it.

			var a = currentEllipsoid.a;
			var b = currentEllipsoid.b;
			var eSquared = currentEllipsoid.eSquared;
			var phi = DegreesToRadians( _latitude );
			var lambda = DegreesToRadians( _longitude );

			var v = a / (Math.Sqrt( 1 - eSquared * SinSquared( phi ) ));
			var H = 0.0; // height
			var x = (v + H) * Math.Cos( phi ) * Math.Cos( lambda );
			var y = (v + H) * Math.Cos( phi ) * Math.Sin( lambda );
			var z = ((1 - eSquared) * v + H) * Math.Sin( phi );

			var tx = transform._tx;
			var ty = transform._ty;
			var tz = transform._tz;
			var s = transform._s;
			var rx = transform._rx;
			var ry = transform._ry;
			var rz = transform._rz;

			var xB = tx + (x * (1 + s)) + (-rx * y) + (ry * z);
			var yB = ty + (rz * x) + (y * (1 + s)) + (-rx * z);
			var zB = tz + (-ry * x) + (rx * y) + (z * (1 + s));

			a = targetEllipsoid.a;
			b = targetEllipsoid.b;
			eSquared = targetEllipsoid.eSquared;

			var lambdaB = RadiansToDegrees( Math.Atan( yB / xB ) );

			var p = Math.Sqrt( (xB * xB) + (yB * yB) );
			var phiN = Math.Atan( zB / (p * (1 - eSquared)) );
			for ( var i = 1; i < 10; i++ )
			{
				v = a / (Math.Sqrt( 1 - eSquared * SinSquared( phiN ) ));
				var phiN1 = Math.Atan( (zB + (eSquared * v * Math.Sin( phiN ))) / p );
				phiN = phiN1;
			}

			var phiB = RadiansToDegrees( phiN );

			LatLng result = new LatLng( phiB, lambdaB );
			return result;
		}

		#endregion


		#region OsRef to LatLng and back

		/// <summary>
		/// Converts this instance to an OSGB36 easting and northing, assuming that it is based on the WGS84 datum.
		/// </summary>
		/// <returns></returns>
		public OsRef ToOsRef()
		{
			LatLng airy1830 = this.ToAiry1830();
			return airy1830.ToOsRefFromAiry1830();
		}

		/// <summary>
		/// Converts this instance to an OSGB36 easting and northing, assuming that it is based on the Airy1830 datum.
		/// </summary>
		/// <returns></returns>
		public OsRef ToOsRefFromAiry1830()
		{
			// This is deliberately ugly C#. It's ported from javascript at http://www.jstott.me.uk/jscoord/ (v1.1.1)
			// The less I touch it, the less chance there is of breaking it.

			var OSGB_F0 = 0.9996012717;
			var N0 = -100000.0;
			var E0 = 400000.0;
			var phi0 = DegreesToRadians( 49.0 );
			var lambda0 = DegreesToRadians( -2.0 );

			var a = Ellipsoid.Airy1830.a;
			var b = Ellipsoid.Airy1830.b;
			var eSquared = Ellipsoid.Airy1830.eSquared;
			
			var phi = DegreesToRadians( _latitude );
			var lambda = DegreesToRadians( _longitude );
			
			var E = 0.0;
			var N = 0.0;
			var n = (a - b) / (a + b);
			var v = a * OSGB_F0 * Math.Pow( 1.0 - eSquared * SinSquared( phi ), -0.5 );
			var rho =
			  a * OSGB_F0 * (1.0 - eSquared) * Math.Pow( 1.0 - eSquared * SinSquared( phi ), -1.5 );
			var etaSquared = (v / rho) - 1.0;
			var M =
			  (b * OSGB_F0)
				* (((1 + n + ((5.0 / 4.0) * n * n) + ((5.0 / 4.0) * n * n * n))
				  * (phi - phi0))
				  - (((3 * n) + (3 * n * n) + ((21.0 / 8.0) * n * n * n))
					* Math.Sin( phi - phi0 )
					* Math.Cos( phi + phi0 ))
				  + ((((15.0 / 8.0) * n * n) + ((15.0 / 8.0) * n * n * n))
					* Math.Sin( 2.0 * (phi - phi0) )
					* Math.Cos( 2.0 * (phi + phi0) ))
				  - (((35.0 / 24.0) * n * n * n)
					* Math.Sin( 3.0 * (phi - phi0) )
					* Math.Cos( 3.0 * (phi + phi0) )));
			var I = M + N0;
			var II = (v / 2.0) * Math.Sin( phi ) * Math.Cos( phi );
			var III =
			  (v / 24.0)
				* Math.Sin( phi )
				* Math.Pow( Math.Cos( phi ), 3.0 )
				* (5.0 - TanSquared( phi ) + (9.0 * etaSquared));
			var IIIA =
			  (v / 720.0)
				* Math.Sin( phi )
				* Math.Pow( Math.Cos( phi ), 5.0 )
				* (61.0 - (58.0 * TanSquared( phi )) + Math.Pow( Math.Tan( phi ), 4.0 ));
			var IV = v * Math.Cos( phi );
			var V = (v / 6.0) * Math.Pow( Math.Cos( phi ), 3.0 ) * ((v / rho) - TanSquared( phi ));
			var VI =
			  (v / 120.0)
				* Math.Pow( Math.Cos( phi ), 5.0 )
				* (5.0
				  - (18.0 * TanSquared( phi ))
				  + (Math.Pow( Math.Tan( phi ), 4.0 ))
				  + (14 * etaSquared)
				  - (58 * TanSquared( phi ) * etaSquared));

			N =
			  I
				+ (II * Math.Pow( lambda - lambda0, 2.0 ))
				+ (III * Math.Pow( lambda - lambda0, 4.0 ))
				+ (IIIA * Math.Pow( lambda - lambda0, 6.0 ));
			E =
			  E0
				+ (IV * (lambda - lambda0))
				+ (V * Math.Pow( lambda - lambda0, 3.0 ))
				+ (VI * Math.Pow( lambda - lambda0, 5.0 ));

			return new OsRef( (int) Math.Round( E, 0), (int) Math.Round( N, 0 ) );
		}

		// We include these here as internal methods to keep all the ported javascript trigonometry in one class.
		// They are exposed as public methods of OsRef.
		internal static LatLng OsRefToWGS84LatLng( OsRef osref )
		{
			LatLng airy1830 = OsRefToAiry1830LatLng( osref );
			return airy1830.ToWGS84();
		}

		internal static LatLng OsRefToAiry1830LatLng( OsRef osref )
		{
			// This is deliberately ugly C#. It's ported from javascript at http://www.jstott.me.uk/jscoord/ (v1.1.1)
			// The less I touch it, the less chance there is of breaking it.

			var OSGB_F0 = 0.9996012717;
			var N0 = -100000.0;
			var E0 = 400000.0;
			var phi0 = DegreesToRadians( 49.0 );
			var lambda0 = DegreesToRadians( -2.0 );
			var a = Ellipsoid.Airy1830.a;
			var b = Ellipsoid.Airy1830.b;
			var eSquared = Ellipsoid.Airy1830.eSquared;
			var phi = 0.0;
			var lambda = 0.0;
			var E = osref.Easting;
			var N = osref.Northing;
			var n = (a - b) / (a + b);
			var M = 0.0;
			var phiPrime = ((N - N0) / (a * OSGB_F0)) + phi0;
			do
			{
				M =
				  (b * OSGB_F0)
					* (((1 + n + ((5.0 / 4.0) * n * n) + ((5.0 / 4.0) * n * n * n))
					  * (phiPrime - phi0))
					  - (((3 * n) + (3 * n * n) + ((21.0 / 8.0) * n * n * n))
						* Math.Sin( phiPrime - phi0 )
						* Math.Cos( phiPrime + phi0 ))
					  + ((((15.0 / 8.0) * n * n) + ((15.0 / 8.0) * n * n * n))
						* Math.Sin( 2.0 * (phiPrime - phi0) )
						* Math.Cos( 2.0 * (phiPrime + phi0) ))
					  - (((35.0 / 24.0) * n * n * n)
						* Math.Sin( 3.0 * (phiPrime - phi0) )
						* Math.Cos( 3.0 * (phiPrime + phi0) )));
				phiPrime += (N - N0 - M) / (a * OSGB_F0);
			} while ( (N - N0 - M) >= 0.001 );
			var v = a * OSGB_F0 * Math.Pow( 1.0 - eSquared * SinSquared( phiPrime ), -0.5 );
			var rho =
			  a
				* OSGB_F0
				* (1.0 - eSquared)
				* Math.Pow( 1.0 - eSquared * SinSquared( phiPrime ), -1.5 );
			var etaSquared = (v / rho) - 1.0;
			var VII = Math.Tan( phiPrime ) / (2 * rho * v);
			var VIII =
			  (Math.Tan( phiPrime ) / (24.0 * rho * Math.Pow( v, 3.0 )))
				* (5.0
				  + (3.0 * TanSquared( phiPrime ))
				  + etaSquared
				  - (9.0 * TanSquared( phiPrime ) * etaSquared));
			var IX =
			  (Math.Tan( phiPrime ) / (720.0 * rho * Math.Pow( v, 5.0 )))
				* (61.0
				  + (90.0 * TanSquared( phiPrime ))
				  + (45.0 * TanSquared( phiPrime ) * TanSquared( phiPrime )));
			var X = Sec( phiPrime ) / v;
			var XI =
			  (Sec( phiPrime ) / (6.0 * v * v * v))
				* ((v / rho) + (2 * TanSquared( phiPrime )));
			var XII =
			  (Sec( phiPrime ) / (120.0 * Math.Pow( v, 5.0 )))
				* (5.0
				  + (28.0 * TanSquared( phiPrime ))
				  + (24.0 * TanSquared( phiPrime ) * TanSquared( phiPrime )));
			var XIIA =
			  (Sec( phiPrime ) / (5040.0 * Math.Pow( v, 7.0 )))
				* (61.0
				  + (662.0 * TanSquared( phiPrime ))
				  + (1320.0 * TanSquared( phiPrime ) * TanSquared( phiPrime ))
				  + (720.0
					* TanSquared( phiPrime )
					* TanSquared( phiPrime )
					* TanSquared( phiPrime )));
			phi =
			  phiPrime
				- (VII * Math.Pow( E - E0, 2.0 ))
				+ (VIII * Math.Pow( E - E0, 4.0 ))
				- (IX * Math.Pow( E - E0, 6.0 ));
			lambda =
			  lambda0
				+ (X * (E - E0))
				- (XI * Math.Pow( E - E0, 3.0 ))
				+ (XII * Math.Pow( E - E0, 5.0 ))
				- (XIIA * Math.Pow( E - E0, 7.0 ));

			return new LatLng( RadiansToDegrees( phi ), RadiansToDegrees( lambda ) );
		}

		#endregion


		#region Miscellaneous trig

		private static double DegreesToRadians( double deg )
		{
			return deg * Math.PI / 180.0;
		}

		private static double RadiansToDegrees( double rad )
		{
			return rad * 180.0 / Math.PI;
		}

		private static double SinSquared( double rad )
		{
			return Math.Sin( rad ) * Math.Sin( rad );
		}

		private static double CosSquared( double rad )
		{
			return Math.Cos( rad ) * Math.Cos( rad );
		}

		private static double TanSquared( double rad )
		{
			return Math.Tan( rad ) * Math.Tan( rad );
		}

		private static double Sec( double rad )
		{
			return 1.0 / Math.Cos( rad );
		}

		#endregion
	}
}

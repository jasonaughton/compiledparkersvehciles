using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Parkers.Data;


namespace Parkers.Postcodes
{
	/// <summary>
	/// Represents a UK postcode. Provides location data via CapScan,
	/// and supports parsing out the component parts of the postcode.
	/// </summary>
	public class Postcode : IPlace
	{
		private static readonly string _siteName = "www.parkers.co.uk";

		private static readonly Regex _outcodeRegex;
		private static readonly Regex _completeRegex;

		private static readonly com.bauerhosting.postcodes.PostcodeService _service;

		static Postcode()
		{
			_completeRegex = new Regex( "^([A-Z][A-Z]?)([0-9][A-Z0-9]?) ?([0-9][ABDEFGHJLNPQRSTUWXYZ]{2})([0-9][A-Z])?$" );
			_outcodeRegex = new Regex( "^([A-Z][A-Z]?)([0-9][A-Z0-9]?)" );

			_service = new Parkers.Postcodes.com.bauerhosting.postcodes.PostcodeService();
		}

		public Postcode()
		{
		}

		public Postcode( string value )
		{
			Value = value;
		}

		public string Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = value;
				if ( _value == null )
				{
					_value = "";
				}
				_value = _value.ToUpper().Trim();
				Parse();
			}
		}
		private string _value;

		public string Outcode
		{
			get
			{
				return _outcode;
			}
		}
		private string _outcode = null;

		public string Incode
		{
			get
			{
				if ( IsValid )
				{
					return _value.Substring( _outcode.Length ).Trim();
				}
				else
				{
					return null;
				}
			}
		}
		
		public string Area
		{
			get
			{
				return _area;
			}
		}
		private string _area = null;

		public bool IsValid
		{
			get
			{
				return _isValid;
			}
		}
		private bool _isValid = false;

		private GridRef _gridRef = null;

		/// <summary>
		/// Checks whether Value is a valid postcode, and extracts the Area and Outcode if it is.
		/// If Value is not a valid complete postcode, extracts an Area and Outcode is possible.
		/// </summary>
		/// <remarks>
		/// Valid formats are (with or without the space)
		/// A1 1AA
		/// A11 1AA
		/// A1A 1AA
		/// AA1 1AA
		/// AA11 1AA
		/// </remarks>
		/// <returns>true if Value is a valid complete postcode, false otherwise</returns>
		protected bool Parse()
		{
			Match m = _completeRegex.Match( _value.Replace(" ", "") );
			if ( m.Success )
			{
				// _value is a complete postcode
				_area = m.Groups[1].Value;
				_outcode = _area + m.Groups[2].Value;
				_value = _outcode + " " + m.Groups[3].Value;
				_isValid = true;
			}
			else
			{
				m = _outcodeRegex.Match( _value );
				if ( m.Success )
				{
					// _value is a valid outcode, but not a complete postcode
					_area = m.Groups[1].Value;
					_outcode = _area + m.Groups[2].Value;
					_isValid = false;
				}
				else
				{
					// _value contains nothing meaningful
					_area = null;
					_outcode = null;
					_isValid = false;
				}
			}
			return _isValid;
		}

		/// <summary>
		/// Returns a grid reference for the postcode, or null if none can be determined. 
		/// </summary>
		/// <returns></returns>
		public GridRef GetLocation()
		{
			if ( _gridRef == null )
			{
				// If we have a complete postcode, get a location from Capscan
				if ( _isValid )
				{
					com.bauerhosting.postcodes.GridRef g = _service.GetLocation( _value, _siteName );
					if ( g != null )
					{
						_gridRef = new GridRef( g.Easting, g.Northing,  g.Latitude, g.Longitude );
					}
					//_gridRef = CapScanUtil.GetLocation( _value );
				}

				// If this is a Belfast postcode and Capscan reports that it is east of Douglas, something
				// has gone wrong. Throw the grid ref away and get one from the database.
				if ( _gridRef != null && _outcode != null
					  && _outcode.StartsWith( "BT" ) && _gridRef.Easting > 237800 )
				{
					_gridRef = null;
				}

				// If we have an outcode but no grid ref, get a approximate location from the database
				if ( _gridRef == null && _outcode != null )
				{
					Sproc sp = new Sproc( "PostcodeDistrict_Select", "ParkersMeta" );
					sp.Parameters.Add( "@Postcode", SqlDbType.VarChar, 10 ).Value = _outcode;
					using ( SqlDataReader dr = sp.ExecuteReader() )
					{
						if ( dr.HasRows && dr.Read() )
						{
							_gridRef = new GridRef( (int) dr["Easting"], (int) dr["Northing"], (double) dr["Latitude"], (double) dr["Longitude"] );
						}
						else
						{
							_gridRef = null;
						}
					}
				}
			}

			return _gridRef;
		}

		public Address GetAddress()
		{
			return GetAddress( "" );
		}

		public Address GetAddress( string houseNumber )
		{
			if ( !_isValid )
			{
				return null;
			}

			string houseNumberToSearch = houseNumber;
			if ( String.IsNullOrEmpty( houseNumberToSearch ) )
			{
				houseNumberToSearch = "0";
			}

			//return CapScanUtil.GetAddress( houseNumberToSearch + ", " + _value );
			com.bauerhosting.postcodes.AddressResult ar = _service.GetAddress( _value, houseNumberToSearch, _siteName );
			if ( ar != null )
			{
				Address a = AddressFromServiceResult( ar );

				return a;
			}
			else
			{
				return null;
			}
		}

		private static Address AddressFromServiceResult( com.bauerhosting.postcodes.AddressResult ar )
		{
			Address a = new Address();
			a.Line1 = ar.Line1;
			a.Line2 = ar.Line2;
			a.Town = ar.Town;
			a.County = ar.County;
			a.Postcode = new Postcode( ar.Postcode );
			return a;
		}

		public Address[] GetAddresses()
		{
			return GetAddresses( "" );
		}

		public Address[] GetAddresses( string houseNumber )
		{
			if ( !_isValid )
			{
				return new Address[]{};
			}

			string houseNumberToSearch = houseNumber;
			if ( String.IsNullOrEmpty( houseNumberToSearch ) )
			{
				houseNumberToSearch = "0";
			}

			//return CapScanUtil.GetAddresses( houseNumberToSearch + ", " + _value );
			com.bauerhosting.postcodes.AddressResult[] results = _service.GetAddresses( _value, houseNumberToSearch, _siteName );
			List<Address> addresses = new List<Address>();
			foreach ( com.bauerhosting.postcodes.AddressResult ar in results )
			{
				addresses.Add( AddressFromServiceResult( ar ) );
			}
			return addresses.ToArray();
		}

		public override string ToString()
		{
			return _value;
		}


		#region IPlace Members

		GridRef IPlace.GetGridRef()
		{
			return GetLocation();
		}

		string IPlace.GetDisplayName()
		{
			return _value;
		}

		#endregion
	}
}

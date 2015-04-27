using System;
using System.Collections.Generic;
using System.Text;

namespace Parkers.Postcodes
{
	/// <summary>
	/// A postal address
	/// </summary>
	public class Address
	{
		public string Line1
		{
			get { return _line1; }
			set { _line1 = value; }
		}
		private string _line1;

		public string Line2
		{
			get	{ return _line2; }
			set	{ _line2 = value; }
		}
		private string _line2;

		public string Town
		{
			get { return _town; }
			set { _town = value; }
		}
		private string _town;

		public string County
		{
			get { return _county; }
			set { _county = value; }
		}
		private string _county;

		public Postcode Postcode
		{
			get { return _postcode; }
			set { _postcode = value; }
		}
		private Postcode _postcode;

		/// <summary>
		/// Create an Address from a single string, probably the result of a call to CapScan
		/// </summary>
		/// <remarks>
		/// <para>The address is assumed to be in one of the following forms</para>
		/// <list type="bullet">
		/// <item>[line1],[town],[county],[postcode]</item>
		/// <item>[line1],[line2],[town],[county],[postcode]</item>
		/// <item>[line1],LONDON,[postcode]</item>
		/// <item>[line1],[line2],LONDON,[postcode]</item>
		/// </list>
		/// <para>Line2 will combine any additional lines between the first and the town, so may contains commas.</para>
		/// <para>For London addresses, County is an empty string.</para>
		/// <para>If </para>
		/// </remarks>
		/// <param name="input"></param>
		/// <returns></returns>
		public static Address Parse( string input )
		{
			Address newAddress = new Address();

			string[] parts = input.TrimEnd(",".ToCharArray()).Split( ",".ToCharArray() );
			newAddress.Postcode = new Postcode( parts[parts.Length - 1] );

			int townLine = parts.Length - 3;

			if ( parts[parts.Length - 2].ToUpper() == "LONDON" )
			{
				newAddress.County = "";
				newAddress.Town = parts[parts.Length - 2].Trim();
				townLine = parts.Length - 2;
			}
			else
			{
				newAddress.County = parts[parts.Length - 2].Trim();
				newAddress.Town = parts[parts.Length - 3].Trim();
			}
			if ( townLine > 0 )
			{
				newAddress.Line1 = parts[0].Trim();
			}
			else
			{
				newAddress.Line1 = "";
			}
			string line2 = "";
			for ( int i = 1; i < townLine; i++ )
			{
				line2 += parts[i].Trim() + ", ";
			}
			line2 = line2.TrimEnd( ", ".ToCharArray() );
			newAddress.Line2 = line2;

			return newAddress;
		}

	}

}

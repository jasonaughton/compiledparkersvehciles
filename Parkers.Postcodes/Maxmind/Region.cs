using System;
using System.IO;

#pragma warning disable 1587, 168

namespace Maxmind
{

	internal class Region
	{
		public String countryCode;
		public String countryName;
		public String region;
		public Region()
		{
		}
		public Region( String countryCode, String countryName, String region )
		{
			this.countryCode = countryCode;
			this.countryName = countryName;
			this.region = region;
		}
		public String getcountryCode()
		{
			return countryCode;
		}
		public String getcountryName()
		{
			return countryName;
		}
		public String getregion()
		{
			return region;
		}
	}

}

#pragma warning restore 1587, 168
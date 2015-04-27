using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;

using Maxmind;

namespace Parkers.Postcodes
{
	public static class MaxmindUtil
	{
		private static readonly LookupService _service;

		static MaxmindUtil()
		{
			string filename = ConfigurationManager.AppSettings["Parkers.Postcodes.MaxmindConfig"];
			if ( File.Exists( filename ) )
			{
				_service = new LookupService( filename, LookupService.GEOIP_MEMORY_CACHE );
			}
		}

		public static GridRef GetLocation( string ip )
		{
			if ( _service == null )
			{
				return null;
			}

			Location l = _service.getLocation( ip );
			if ( l == null )
			{
				return null;
			}

			return new GridRef( l.latitude, l.longitude );
		}

		public static string GetCity( string ip )
		{
			if ( _service == null )
			{
				return null;
			}

			Location l = _service.getLocation( ip );
			if ( l == null )
			{
				return null;
			}

			return l.city;
		}
	}
}

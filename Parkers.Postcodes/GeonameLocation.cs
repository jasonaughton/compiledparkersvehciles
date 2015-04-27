using System;
using System.Collections.Generic;
using System.Text;

namespace Parkers.Postcodes
{
	public class GeonameLocation
	{
		public long Id
		{
			get { return _id; }
			set { _id = value; }
		}
		private long _id;

		public string FeatureCode
		{
			get { return _featureCode; }
			set { _featureCode = value; }
		}
		private string _featureCode;
		
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}
		private string _name;

		public string County
		{
			get { return _county; }
			set { _county = value; }
		}
		private string _county;
		
		public GridRef Location
		{
			get { return _location; }
			set { _location = value; }
		}
		private GridRef _location;

		public static GeonameLocation FromString( string text )
		{
			return new GeonameLocation();
		}

		public static List<GeonameLocation> ListFromString( string text )
		{
			return new List<GeonameLocation>();
		}

		public static GeonameLocation FromGridRef( GridRef gridRef )
		{
			return new GeonameLocation();
		}
	}
}
